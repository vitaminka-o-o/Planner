/****** Script for SelectTopNRows command from SSMS  ******/
USE [PlannerDB]


CREATE TABLE TodoItem(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsCompleted] [bit] NOT NULL,
        [Date] [date] NOT NULL,
 CONSTRAINT [PK_TodoItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)