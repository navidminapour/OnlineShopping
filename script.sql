USE [master]
GO
CREATE DATABASE Sales;

GO
CREATE DATABASE Warehouse;

GO
CREATE DATABASE EventDispatcher;

GO
USE Sales
GO
CREATE SEQUENCE Order_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint

GO
CREATE SEQUENCE Product_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint
	
GO
CREATE SEQUENCE Category_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint

GO
USE Warehouse
GO
CREATE SEQUENCE Stock_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint

GO
Use EventDispatcher
GO
Create table Events
(Id UNIQUEIDENTIFIER PRIMARY KEY,
EventType Nvarchar(200) not null,
SerializedContent nvarchar(max) not null,
CreationDateTime datetime not null,
IsProcessed bit not null)