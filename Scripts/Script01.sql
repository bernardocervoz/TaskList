USE [TaskList]
GO

CREATE TABLE [dbo].[TaskManager](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL,
	[TaskDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL
) ON [PRIMARY]


