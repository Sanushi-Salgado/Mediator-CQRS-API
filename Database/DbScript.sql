USE [master]
GO
/****** Object:  Database [TechnicalAssignment]    Script Date: 10/17/2021 12:44:17 AM Sanushi  ******/
CREATE DATABASE [TechnicalAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'technical_assignment', FILENAME = N'D:\Setups\Microsoft_SQL_Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\technical_assignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'technical_assignment_log', FILENAME = N'D:\Setups\Microsoft_SQL_Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\technical_assignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TechnicalAssignment] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechnicalAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechnicalAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechnicalAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechnicalAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TechnicalAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechnicalAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET RECOVERY FULL 
GO
ALTER DATABASE [TechnicalAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [TechnicalAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechnicalAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechnicalAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechnicalAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechnicalAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechnicalAssignment', N'ON'
GO
ALTER DATABASE [TechnicalAssignment] SET QUERY_STORE = OFF
GO
USE [TechnicalAssignment]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](15) NOT NULL,
	[last_name] [varchar](15) NOT NULL,
	[country_code] [varchar](6) NOT NULL,
	[contact_no] [varchar](12) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[gender] [char](1) NULL,
	[salary] [decimal](8, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[log_id] [int] IDENTITY(1,1) NOT NULL,
	[record_id] [int] NOT NULL,
	[event_type] [varchar](15) NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[log_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByEmail]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SP for retrieving customer details by customer email
CREATE PROCEDURE [dbo].[GetCustomerByEmail] @Email varchar(30)
AS
SELECT * FROM Customer WHERE email = @Email
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerById]    Script Date: 10/17/2021 12:44:18 AM Sanushi  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SP for retrieving customer details by customer id
CREATE PROCEDURE [dbo].[GetCustomerById] @CustomerId int
AS
SELECT * FROM Customer WHERE customer_id = @CustomerId
GO
USE [master]
GO
ALTER DATABASE [TechnicalAssignment] SET  READ_WRITE 
GO
