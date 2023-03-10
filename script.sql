USE [master]
GO
/****** Object:  Database [banking_db]    Script Date: 2022-12-17 1:32:30 PM ******/
CREATE DATABASE [banking_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'banking_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\banking_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'banking_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\banking_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [banking_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [banking_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [banking_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [banking_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [banking_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [banking_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [banking_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [banking_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [banking_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [banking_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [banking_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [banking_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [banking_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [banking_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [banking_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [banking_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [banking_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [banking_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [banking_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [banking_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [banking_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [banking_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [banking_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [banking_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [banking_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [banking_db] SET  MULTI_USER 
GO
ALTER DATABASE [banking_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [banking_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [banking_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [banking_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [banking_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [banking_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [banking_db] SET QUERY_STORE = OFF
GO
USE [banking_db]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 2022-12-17 1:32:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[AccountNumber] [int] IDENTITY(10000,1) NOT NULL,
	[AccountType] [varchar](10) NOT NULL,
	[Balance] [float] NULL,
 CONSTRAINT [PK_accounts_1] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accountTransaction]    Script Date: 2022-12-17 1:32:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [int] NOT NULL,
	[TransactionId] [int] NOT NULL,
 CONSTRAINT [PK_accountTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2022-12-17 1:32:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](124) NOT NULL,
	[SIN] [int] NOT NULL,
	[PasswordHash] [varchar](10) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[RegistrationDate] [datetime] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 2022-12-17 1:32:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[amount] [float] NOT NULL,
	[currency] [varchar](3) NULL,
	[transactionDate] [datetime] NULL,
 CONSTRAINT [PK_transactions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userAccount]    Script Date: 2022-12-17 1:32:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [int] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_userAccount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accounts] ADD  CONSTRAINT [DF_accounts_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Clients] ADD  CONSTRAINT [DF_Clients_RegistrationDate]  DEFAULT (sysdatetime()) FOR [RegistrationDate]
GO
ALTER TABLE [dbo].[transactions] ADD  CONSTRAINT [DF_transactions_currency]  DEFAULT ('CAD') FOR [currency]
GO
ALTER TABLE [dbo].[transactions] ADD  CONSTRAINT [DF_transactions_transactionDate]  DEFAULT (sysdatetime()) FOR [transactionDate]
GO
ALTER TABLE [dbo].[accountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_accountTransaction_accounts] FOREIGN KEY([AccountNumber])
REFERENCES [dbo].[accounts] ([AccountNumber])
GO
ALTER TABLE [dbo].[accountTransaction] CHECK CONSTRAINT [FK_accountTransaction_accounts]
GO
ALTER TABLE [dbo].[accountTransaction]  WITH CHECK ADD  CONSTRAINT [FK_accountTransaction_transactions] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[transactions] ([id])
GO
ALTER TABLE [dbo].[accountTransaction] CHECK CONSTRAINT [FK_accountTransaction_transactions]
GO
ALTER TABLE [dbo].[userAccount]  WITH CHECK ADD  CONSTRAINT [FK_userAccount_accounts] FOREIGN KEY([AccountNumber])
REFERENCES [dbo].[accounts] ([AccountNumber])
GO
ALTER TABLE [dbo].[userAccount] CHECK CONSTRAINT [FK_userAccount_accounts]
GO
ALTER TABLE [dbo].[userAccount]  WITH CHECK ADD  CONSTRAINT [FK_userAccount_Clients] FOREIGN KEY([UserId])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[userAccount] CHECK CONSTRAINT [FK_userAccount_Clients]
GO
USE [master]
GO
ALTER DATABASE [banking_db] SET  READ_WRITE 
GO
