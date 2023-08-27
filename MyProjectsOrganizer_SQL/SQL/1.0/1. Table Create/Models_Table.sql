USE [MyProjectsOrganizer_db]

IF OBJECT_ID (N'[dbo].[Models]',N'U') IS NULL
BEGIN 
	CREATE TABLE [dbo].[Models](
		[Model_Id] [int] IDENTITY(1,1) NOT NULL,
		[Model_Name] [nvarchar] (50) NOT NULL,
		[Description] [nvarchar] (255) NULL,
		[Project_Id] [int] NOT NULL,
		PRIMARY KEY (Model_Id),
		FOREIGN KEY (Project_Id) REFERENCES Projects(Project_Id)
	)
END 
GO