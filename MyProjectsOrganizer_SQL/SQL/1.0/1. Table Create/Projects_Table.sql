USE [MyProjectsOrganizer_db]
IF OBJECT_ID (N'[dbo].[Projects]',N'U') IS NULL
BEGIN
	CREATE TABLE [dbo].[Projects](
		[Project_Id] [int] IDENTITY(1,1) NOT NULL,
		[Project_Name] [nvarchar] (50) NOT NULL,
		[Description] [nvarchar] (255) NULL,
		[Created_Date] [DateTime] NOT NULL,
		[Project_Status] [bit] NOT NULL,
		PRIMARY KEY (Project_Id)
	)
END 
GO