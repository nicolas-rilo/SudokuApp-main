DECLARE @Default_DB_Path as VARCHAR(64)  
 SET @Default_DB_Path = N'C:\source\'
 
USE [master]


/***** Drop database if already exists  ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'sudokuapp')
DROP DATABASE [sudokuapp]


USE [master]


/* DataBase Creation */

	                              
DECLARE @sql nvarchar(500)

SET @sql = 
  N'CREATE DATABASE [sudokuapp] 
    ON PRIMARY ( NAME = sudokuapp, FILENAME = "' + @Default_DB_Path + N'sudokuapp.mdf")
    LOG ON ( NAME = sudokuapp_log, FILENAME = "' + @Default_DB_Path + N'sudokuapp_log.ldf")'

EXEC(@sql)
PRINT N'Database [sudokuapp] created.'
GO
