use master
GO
Create Database Sales;

GO
Create Database Warehouse;

GO
Create Database EventDispatcher;

Use EventDispatcher
Create table Events
(Id UNIQUEIDENTIFIER PRIMARY KEY,
EventType Nvarchar(200) not null,
SerializedContent nvarchar(max) not null,
CreationDateTime datetime not null,
IsProcessed bit not null)

USE Sales
CREATE SEQUENCE Order_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint

	CREATE SEQUENCE Product_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint
	
	CREATE SEQUENCE Category_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint

USE Warehouse
CREATE SEQUENCE Stock_Seq
    START WITH 1  
    INCREMENT BY 1
	AS bigint