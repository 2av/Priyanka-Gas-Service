USE [master]
GO
/****** Object:  Database [PriyankaGasService]    Script Date: 06/02/2020 07:26:45 ******/
CREATE DATABASE [PriyankaGasService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PriyankaGasService', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PriyankaGasService.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PriyankaGasService_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PriyankaGasService_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PriyankaGasService] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PriyankaGasService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PriyankaGasService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PriyankaGasService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PriyankaGasService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PriyankaGasService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PriyankaGasService] SET ARITHABORT OFF 
GO
ALTER DATABASE [PriyankaGasService] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PriyankaGasService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PriyankaGasService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PriyankaGasService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PriyankaGasService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PriyankaGasService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PriyankaGasService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PriyankaGasService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PriyankaGasService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PriyankaGasService] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PriyankaGasService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PriyankaGasService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PriyankaGasService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PriyankaGasService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PriyankaGasService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PriyankaGasService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PriyankaGasService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PriyankaGasService] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PriyankaGasService] SET  MULTI_USER 
GO
ALTER DATABASE [PriyankaGasService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PriyankaGasService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PriyankaGasService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PriyankaGasService] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PriyankaGasService] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PriyankaGasService] SET QUERY_STORE = OFF
GO
USE [PriyankaGasService]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [PriyankaGasService]
GO
/****** Object:  Table [dbo].[ItemMaster]    Script Date: 06/02/2020 07:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemMaster](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](500) NULL,
	[ItemDescription] [nvarchar](1000) NULL,
	[Price] [float] NULL,
	[SecurityDeposite] [float] NULL,
	[ServiceCharges] [float] NULL,
	[IsActive] [bit] NULL,
	[ActionBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GenerateClass]    Script Date: 06/02/2020 07:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[GenerateClass]
@TableName sysname
as
begin

declare @Result varchar(max) = 'public class ' + @TableName + '
{'

select @Result = @Result + '
    public ' + ColumnType + NullableSign + ' ' + ColumnName + ' { get; set; }
'
from
(
    select 
        replace(col.name, ' ', '_') ColumnName,
        column_id ColumnId,
        case typ.name 
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'string'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'decimal'
            when 'float' then 'double'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'decimal'
            when 'nchar' then 'string'
            when 'ntext' then 'string'
            when 'numeric' then 'decimal'
            when 'nvarchar' then 'string'
            when 'real' then 'float'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'smallmoney' then 'decimal'
            when 'text' then 'string'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'long'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'string'
            else 'UNKNOWN_' + typ.name
        end ColumnType,
        case 
            when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2', 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime', 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') 
            then '?' 
            else '' 
        end NullableSign
    from sys.columns col
        join sys.types typ on
            col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
    where object_id = object_id(@TableName)
) t
order by ColumnId

set @Result = @Result  + '
}'

print @Result

end
GO
/****** Object:  StoredProcedure [dbo].[procItemMaster]    Script Date: 06/02/2020 07:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[procItemMaster]
@Action nvarchar(100),
@ItemId int =null,
@ItemName nvarchar(500)=null,
@ItemDescription nvarchar(1000)=null,
@Price float=null,
@SecurityDeposite float=null,
@ServiceCharges float=null,
@ActionBy int=null
as
begin
	if(@Action='SELECT')
	begin
		select ItemName ,Price,SecurityDeposite,ServiceCharges from ItemMaster
	end

	/*Insert record into table */
	if(@Action='INSERT')
	begin
		insert into ItemMaster(ItemName,ItemDescription,Price,SecurityDeposite,ServiceCharges,isActive,ActionBy,CreatedDate,ModifyBy,ModifyDate)
		values(@ItemName,@ItemDescription,@Price,@SecurityDeposite,@ServiceCharges,1,@ActionBy,getdate(),@ActionBy,getdate())
		select 'Record succesfully saved'
	end
	
end
GO
USE [master]
GO
ALTER DATABASE [PriyankaGasService] SET  READ_WRITE 
GO
