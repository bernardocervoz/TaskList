var tableTableTask;
$(document).ready(function () {
    TableTasks();
    $('#tableTask').on('draw.dt', function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
});

$("#btnCreate").click(function (e) {
    ModalCadastro(0,"", "", "", 1);
});

function ModalCadastro(id,name, description, date, status, disabled = false) {
    var disabledValue = '';
    if (disabled) {
        disabledValue = 'disabled';
    }
    var modalCadastro = new MetaModal({
        header: "Gerenciador de tarefas",
        body: '<div>' +
            'Nome:  <input type="text" '+ disabledValue +' maxlength="50" id="txtName" value="' + name + '" Style="text-align:left;width: 100%; height: 25px;"/>' +
            '</div>' +
            '<div Style="Color:red; display:none;" id=msgName>' +
            '<span >Campo nome é obrigatório</span>' +
            '</div>' +
            '<div>' +
            'Data:  <input type="text" ' + disabledValue +' id="txtDate" value="' + date + '" Style="text-align:left;width: 100%; height: 25px;"/>' +
            '</div>' +
            '<div Style="Color:red; display:none;" id=msgDate>' +
            '<span >Campo data é obrigatório</span>' +
            '</div>' +
            '<div Style="Color:red; display:none;" id=msgDateInvalida>' +
            '<span >Data inválida</span>' +
            '</div>' +
            'Status: <select ' + disabledValue +' id="status" Style="text-align:left;width: 100%; height: 25px;>' + 
            '<option value="0"></option> ' + 
            '<option value="1">Criada</option> ' + 
            '<option value="2">Em execução</option> ' + 
            '<option value="3">Concluída</option> ' + 
            '<option value="4" >Cancelada</option> ' + 
            '</select >' +
            '</div>' +
            '<div Style="Color:red; display:none;" id=msgName>' +
            '<span >Campo nome é obrigatório</span>' +
            '</div>' +
            '<div>' +
            'Descrição:  <textarea type="text"  ' + disabledValue +'  maxlength="250" id="txtDescription"  Style="text-align:left;width: 100%; height: 150px;">' + description + '</textarea>' +
            '</div>' +
            '<div Style="Color:red; display:none;" id=msgDescription>' +
            '<span >Campo descrição é obrigatório</span>' +
            '</div>' +
            '<div>' +
            '</div>',
        footer: '<button id="btnNao" style="width:100px;" type="button" class="btn btn-primary">Cancelar</button> ' +
            '<button id="btnSim" ' + disabledValue +' style="width:100px;" type="button" class="btn btn-primary">Ok</button>',
        btnSim: "#btnSim",
        btnNao: "#btnNao",
        onSim: function (e) {
            if (!disabled) {

                $("#txtName").css("border", "");
                $("#msgName").hide();
                $("#txtDescription").css("border", "");
                $("#msgDescription").hide();
                $("#txtDate").css("border", "");
                $("#msgDate").hide();
                $("#msgDateInvalida").hide();

                var validate = true;
                if ($("#txtName").val() == "") {
                    validate = false;
                    $("#txtName").css("border", "solid 1px red");
                    $("#msgName").show();
                }
                if ($("#txtDescription").val() == "") {
                    validate = false;
                    $("#txtDescription").css("border", "solid 1px red");
                    $("#msgDescription").show();
                }
                if ($("#txtDate").val() == "") {
                    validate = false;
                    $("#txtDate").css("border", "solid 1px red");
                    $("#msgDate").show();
                }
                else if (/^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/.test($("#txtDate").val()) == false) {
                    validate = false;
                    $("#txtDate").css("border", "solid 2px red");
                    $("#msgDateInvalida").show();
                }

                if (validate) {
                    if (id == "0") {
                        SaveTask(id, $("#txtName").val(), $("#txtDescription").val(), $("#txtDate").val(), 1);
                    }
                    else {
                        SaveTask(id, $("#txtName").val(), $("#txtDescription").val(), $("#txtDate").val(), $('#status').val());
                    }
                    modalCadastro.fechar();
                }
            }
        },
        onNao: function (e) {
            modalCadastro.fechar();
        }
    });
    modalCadastro.exibir();
    $('#txtDate').mask('99/99/9999');
    $('#status').val(status);
}

// #region Melhorias

function TableTasks() {
    if (tableTableTask != undefined) {
        var oTable = $('#tableTask').dataTable();
        oTable.fnDestroy();
    }
    tableTableTask = $('#tableTask').dataTable({
        "oLanguage":
        {
            "sLengthMenu": "Exibir  <select> <option value='5'>5</option> <option value='10'>10</option><option value='50'>50</option><option value='100'>100</option></select>   registros por página.",
        },
        "iDisplayLength": 5,
        "sPaginationType": "full_numbers",
        "bProcessing": true,
        "bServerSide": true,
        "bInfo": true,
        "bFilter": false,
        "sAjaxSource": document.URL,
        "sServerMethod": "POST",
        "bDeferRender": false,
        "bSort": false,
        "aoColumns": [
            { "mDataProp": "Name" },
            { "mDataProp": "Description" },
            { "mDataProp": "TaskDate" },
            { "mDataProp": "Status" },
            { "mDataProp": "Id" }
        ],
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            var btnEdit = '<a  data-toggle="tooltip" class="btn btn-primary btn-xs" title="Editar" href="javascript:void(0)" id="btnEditar_' + aData.Id + ' " onclick="EditTask(' + aData.Id + ')" role="button"><span class="glyphicon glyphicon-pencil"></span></a>';
            var btnDelete = '<a class="btn btn-primary btn-xs" data-toggle="tooltip"  href="javascript:void(0)" id="btnExcluir_' + aData.Id + ' " title="Excluir" onclick="ValidadeDelete(' + aData.Id + ')" role="button"><span class="glyphicon glyphicon-trash"></span></a>';
            var btnVisualize = '<a class="btn btn-primary btn-xs" data-toggle="tooltip"  href="javascript:void(0)" id="btnVisualize' + aData.Id + ' " title="Visualizar" onclick="Visualize(' + aData.Id + ')" role="button"><span class="glyphicon glyphicon-eye-open"></span></a>';
            var btnCompleted = '<a class="btn btn-primary btn-xs" data-toggle="tooltip"  href="javascript:void(0)" id="btnCompleted' + aData.Id + ' " title="Concluir Tarefa" onclick="CompletedTask(' + aData.Id + ')" role="button"><span class="glyphicon glyphicon glyphicon-ok"></span></a>';
            var btns = btnEdit + "  " +
                btnVisualize + "  " + btnCompleted + "  " + btnDelete;

            $('td:eq(4)', nRow).html(btns);
            $('td:eq(4)', nRow).attr('nowrap', 'nowrap');
        }
    });
}

function SaveTask(id, name, description, date, status) {
    $.ajax({
        url: '/TaskManager/SavaTaskManager',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            id: id,
            name: name,
            description: description,
            date: date,
            status: status
        }),
        async: false,
        beforeSend: function () {
            $('#modalLoading').show();
        },
        complete: function () {
            $('#modalLoading').hide();
        },
        success: function (data) {
            TableTasks();
        },
        error: function () {
            $('#modalLoading').hide();
        }
    })
}

function ValidadeDelete(id) {

    var pergunta = new MetaModal({
        header: "Mensagem de Alerta",
        body: "Deseja realmente excluir o registro?",
        footer: '<button id="btnSim" style="width:100px;" type="button" class="btn btn-primary">Sim</button> <button id="btnNao" style="width:100px;" type="button" class="btn btn-primary">Não</button>',
        btnSim: "#btnSim",
        btnNao: "#btnNao",
        onSim: function (e) {
            DeleteTask(id);
            pergunta.fechar();
        },
        onNao: function (e) {

            pergunta.fechar();
        }
    });
    pergunta.exibir();
}

function DeleteTask(id) {
    $.ajax({
        url: 'TaskManager/DeleteTaskManager',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            id: id
        }),
        async: false,

        beforeSend: function () {
            $('#modalLoading').show();
        },
        complete: function () {
            $('#modalLoading').hide();
        },
        success: function (data) {
            TableTasks();
        },
        error: function () {
            $('#modalLoading').hide();
        }
    });
}

function EditTask(id) {

    var task = GetTaskById(id);
    var name = task.Name;
    var description = task.Description;
    var date = task.TaskDate;
    var status = task.Status;
    ModalCadastro(id, name, description, date, status);
}

function GetTaskById(id) {
    var record = "";
    $.ajax({
        url: 'TaskManager/GetTaskManagerById',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            id: id
        }),
        async: false,

        beforeSend: function () {
            $('#modalLoading').show();
        },
        complete: function () {
            $('#modalLoading').hide();
        },
        success: function (data) {
            record = data;
        },
        error: function () {
            $('#modalLoading').hide();
        }
    });
    return record;

}

function Visualize(id) {
    var task = GetTaskById(id);
    var name = task.Name;
    var description = task.Description;
    var date = task.TaskDate;
    var status = task.Status;
    ModalCadastro(id,name, description, date, status, true);
}
function CompletedTask(id) {
    $.ajax({
        url: 'TaskManager/CompletedTask',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            id: id
        }),
        async: false,

        beforeSend: function () {
            $('#modalLoading').show();
        },
        complete: function () {
            $('#modalLoading').hide();
        },
        success: function (data) {
            TableTasks();
        },
        error: function () {
            $('#modalLoading').hide();
        }
    });
}


// #endregion