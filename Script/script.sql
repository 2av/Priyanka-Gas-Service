USE [master]
GO
/****** Object:  Database [CRM]    Script Date: 30-06-2018 11:46:31 ******/
CREATE DATABASE [CRM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\CRM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\CRM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CRM] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRM] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CRM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CRM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CRM] SET  MULTI_USER 
GO
ALTER DATABASE [CRM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRM] SET QUERY_STORE = OFF
GO
USE [CRM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CRM]
GO
/****** Object:  Table [dbo].[tblMenu]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMenu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[Submenuid] [int] NULL,
	[MenuName] [nvarchar](300) NULL,
	[ControllerName] [nvarchar](300) NULL,
	[PageName] [nvarchar](300) NULL,
	[MenuUrl] [nvarchar](300) NULL,
	[Icon] [nvarchar](300) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK__tblMenu__C99ED230730E3940] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserType]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[id] [int] NULL,
	[name] [varchar](max) NULL,
	[age] [int] NULL,
	[active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblMenu] ON 

INSERT [dbo].[tblMenu] ([MenuId], [Submenuid], [MenuName], [ControllerName], [PageName], [MenuUrl], [Icon], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, NULL, N'Menu', N'Menu', N'Index', N'/Menu/Index', NULL, 0, NULL, CAST(N'2018-06-25T22:30:23.427' AS DateTime), NULL, CAST(N'2018-06-25T22:30:23.427' AS DateTime))
INSERT [dbo].[tblMenu] ([MenuId], [Submenuid], [MenuName], [ControllerName], [PageName], [MenuUrl], [Icon], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, NULL, N'User Type', N'UserType', N'Index', N'/UserType/Index', NULL, 0, NULL, CAST(N'2018-06-30T07:06:26.400' AS DateTime), NULL, CAST(N'2018-06-30T07:06:26.400' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblMenu] OFF
SET IDENTITY_INSERT [dbo].[tblUserType] ON 

INSERT [dbo].[tblUserType] ([UserTypeId], [UserTypeName], [Description], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Admin', N'have a complete rights', 0, NULL, CAST(N'2018-06-30T11:10:59.153' AS DateTime), NULL, CAST(N'2018-06-30T11:10:59.153' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblUserType] OFF
ALTER TABLE [dbo].[tblMenu] ADD  CONSTRAINT [DF__tblMenu__Created__239E4DCF]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblMenu] ADD  CONSTRAINT [DF__tblMenu__Modifie__24927208]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[tblUserType] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblUserType] ADD  DEFAULT (getdate()) FOR [ModifiedDate]
GO
/****** Object:  StoredProcedure [dbo].[procGenerateClass]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[procGenerateClass]
@TableName nvarchar(max)
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
				when 'float' then 'float'
				when 'image' then 'byte[]'
				when 'int' then 'int'
				when 'money' then 'decimal'
				when 'nchar' then 'string'
				when 'ntext' then 'string'
				when 'numeric' then 'decimal'
				when 'nvarchar' then 'string'
				when 'real' then 'double'
				when 'smalldatetime' then 'DateTime'
				when 'smallint' then 'short'
				when 'smallmoney' then 'decimal'
				when 'text' then 'string'
				when 'time' then 'TimeSpan'
				when 'timestamp' then 'DateTime'
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
/****** Object:  StoredProcedure [dbo].[procMenu]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[procMenu]      
@Action nvarchar(max),      
@MenuId int=null,      
@Submenuid int=null,      
@MenuName varchar(50)=null, 
@ControllerName varchar(300)=null,     
@PageName varchar(300)=null,
@MenuUrl nvarchar(300)=null,      
@Icon nvarchar(300)=null,      
@IsActive bit=null,      
@CreatedBy int=null,
@CreatedDate nvarchar(max)=null,
@ModifiedBy int=null,
@ModifiedDate nvarchar(max)=null
as      
begin                        
  IF(@Action='SELECT')      
  BEGIN      
   SELECT * FROM tblMenu      
  END  
  IF(@Action='DD_MENU') 
  BEGIN
	select MenuId,MenuName,MenuUrl, 'home' Icon from tblMenu
  END
  IF(@Action='INSERT')
  BEGIN

  IF NOT EXISTS(select 1 from tblMenu where MenuName=@MenuName)
  BEGIN
	INSERT INTO tblMenu(Submenuid,MenuName,ControllerName,PageName,MenuUrl,icon,isActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
	values(@Submenuid,@MenuName,@ControllerName,@PageName,@MenuUrl,@Icon,@IsActive,@CreatedBy,GETDATE(),@ModifiedBy,GETDATE())
	select 'Successfully inserted'
  END
  ELSE 
  BEGIN
	select @MenuName+' > Menu name already exists!'
  END

  END   
end

GO
/****** Object:  StoredProcedure [dbo].[procUserType]    Script Date: 30-06-2018 11:46:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[procUserType]
@Action nvarchar(max),
@UserTypeId int=null,
@UserTypeName nvarchar(max)=null,
@Description nvarchar(max)=null,
@IsActive bit=null,      
@CreatedBy int=null,
@CreatedDate datetime=null,
@ModifiedBy int=null,
@ModifiedDate datetime=null
as
begin
	if(@Action='SELECT')
	BEGIN
		select UserTypeName,Description from tblUserType
	END
	IF(@Action='INSERT')
	BEGIN
		INSERT INTO tblUserType(UserTypeName,Description ,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
		values(@UserTypeName,@Description ,@IsActive,@CreatedBy,getdate(),@ModifiedBy,getdate())
		select 'Insrted Successfully'
	END
end
GO
USE [master]
GO
ALTER DATABASE [CRM] SET  READ_WRITE 
GO
