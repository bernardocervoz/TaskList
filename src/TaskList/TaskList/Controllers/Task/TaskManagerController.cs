using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskList.Domain.Commons.DTO;
using TaskList.Domain.Commons.Enums;
using TaskList.Domain.Commons.Helpers;
using TaskList.Domain.Models.Entities;
using TaskList.Helpers;
using TaskList.Service.Interfaces.Services;

namespace TaskList.Controllers.Task
{
    public class TaskManagerController : Controller
    {

        #region Property Service
        private ITaskManagerService _taskManagerService;
        #endregion Property Service

        #region Constructors
        public TaskManagerController
            (ITaskManagerService taskManagerService
            )
        {
            _taskManagerService = taskManagerService;
        }
        #endregion Constructors

        public ActionResult Index()
        {
            return View();
        }
        #region Ajax

        #region Create and Update

        [HttpPost]
        public JsonResult SavaTaskManager(long id, string name, string date, string description, StatusTask status)
        {
            DateTime taskDate;
            DateTime.TryParse(date, out taskDate);
            if (id == 0)
            {
                var task = new TaskManager()
                {
                    Name = name.Trim(),
                    Description = description.Trim(),
                    Status = status,
                    TaskDate = taskDate,
                    Deleted = false,
                };
                _taskManagerService.Add(task);
                return Json(task.Id);
            }
            else
            {
                var task = _taskManagerService.GetById(id);
                if (task != null)
                {
                    task.Name = name.Trim();
                    task.Description = description.Trim();
                    task.Status = status;
                    task.TaskDate = taskDate;
                    task.UpdatedOn = DateTime.Now;
                    _taskManagerService.Update(task);
                }
                return Json(id);
            }

        }
        #endregion Create

        #region Delete
        [HttpPost]
        public JsonResult DeleteTaskManager(long id)
        {
            if (id != 0)
            {

                var task = _taskManagerService.GetById(id);
                if (task != null)
                {
                    task.Deleted = true;
                    task.UpdatedOn = DateTime.Now;
                    _taskManagerService.Update(task);
                    return Json(true);
                }
            }
            return Json(false);
        }
        #endregion Delete

        #region CompletedTask
        [HttpPost]
        public JsonResult CompletedTask(long id)
        {
            if (id != 0)
            {

                var task = _taskManagerService.GetById(id);
                if (task != null)
                {
                    task.Status = StatusTask.Completed;
                    task.UpdatedOn = DateTime.Now;
                    _taskManagerService.Update(task);
                    return Json(true);
                }
            }
            return Json(false);
        }
        #endregion CompletedTask

        #region Get Task Managers
        [HttpPost]
        public JsonResult Index(JQueryDataTablesModel jQueryDataTablesModel)
        {
            int totalRecordCount;
            int searchRecordCount;

            var tasks = GetTaskManagers(
                startIndex: jQueryDataTablesModel.iDisplayStart,
                pageSize: jQueryDataTablesModel.iDisplayLength,
                sortedColumns: Convert.ToInt32(Request["iSortCol_0"]),
                //tipoOrdem: Request["sSortDir_0"].ToString(),
                totalRegistrosCount: out totalRecordCount,
                searchRegistrosCount: out searchRecordCount
            //searchModel: searchModel
            );

            //TrataDadosGrid(produtos);

            return this.DataTablesJson(
                items: tasks,
                totalRecords: totalRecordCount,
                totalDisplayRecords: searchRecordCount,
                sEcho: jQueryDataTablesModel.sEcho
            );
        }
        private IList<TaskManagerViewModel> GetTaskManagers(int startIndex, int pageSize, int sortedColumns, out int totalRegistrosCount, out int searchRegistrosCount)
        {
            int count = 0;
            var records = _taskManagerService.GetTaskManagers(startIndex, pageSize, out count);
            //registros = OrdenarRegistros(_staticSortedColumns, _staticTipoOrdem, _staticSearchModel, registros);
            totalRegistrosCount = count;
            searchRegistrosCount = count;
            //var listaViewModelPortaria = new List<ViewModelPortaria>();
            //possuiDadosPesquisados = (searchRegistrosCount > 0);
            var tasks = new List<TaskManagerViewModel>();
            records.ForEach(x => tasks.Add(new TaskManagerViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                TaskDate = x.TaskDate.ToShortDateString(),
                Status = x.Status.ToDescription()
            }));
            return tasks;
        }

        [HttpPost]
        public JsonResult GetTaskManagerById(int id)
        {
            if (id != 0)
            {
                var task = _taskManagerService.GetById(id);
                return Json(new { task.Description, task.Status, task.Name, TaskDate = task.TaskDate.ToShortDateString()});
            }
            return Json("");
        }

        #endregion Get Task Managers
        #endregion Ajax
    }
}
