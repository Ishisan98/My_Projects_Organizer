USE [MyProjectsOrganizer_db]
GO

IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'Models_StoredProcedures'
            AND type = 'P'
      )
     DROP PROCEDURE dbo.Models_StoredProcedures
GO


CREATE PROCEDURE Models_StoredProcedures (	@ModelId INTEGER,
											@ModelName NVARCHAR (50),
											@Description NVARCHAR (255),
											@ProjectId INTEGER, 
											@Process NVARCHAR(50)='')
AS
	BEGIN
		
		IF @Process = 'CreateModel'
			BEGIN
				INSERT INTO Models (Model_Name, Description, Project_Id)
				VALUES (@ModelName, @Description, @ProjectId)
			END


		ELSE IF @Process = 'GetAllModels'
			BEGIN
				SELECT * FROM Models
			END


		ELSE IF @Process = 'GetModelsByProjectId'
			BEGIN
				SELECT * FROM Models WHERE Project_Id = @ProjectId
			END


		ELSE IF @Process = 'UpdateModelById'
			BEGIN 
				UPDATE Models SET Model_Name = @ModelName, Description = @Description
				WHERE Model_Id = @ModelId
			END


		ELSE IF @Process = 'DeleteModelById'
			BEGIN 
				DELETE FROM Models WHERE Model_Id = @ModelId
			END

	END
GO




