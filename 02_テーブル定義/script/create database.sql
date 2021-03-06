USE [master]
GO
/****** Object:  Database [BackDoor]    Script Date: 2019/10/10 11:53:31 ******/
CREATE DATABASE [BackDoor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BackDoor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BackDoor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BackDoor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BackDoor_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BackDoor] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BackDoor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BackDoor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BackDoor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BackDoor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BackDoor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BackDoor] SET ARITHABORT OFF 
GO
ALTER DATABASE [BackDoor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BackDoor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BackDoor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BackDoor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BackDoor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BackDoor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BackDoor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BackDoor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BackDoor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BackDoor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BackDoor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BackDoor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BackDoor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BackDoor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BackDoor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BackDoor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BackDoor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BackDoor] SET RECOVERY FULL 
GO
ALTER DATABASE [BackDoor] SET  MULTI_USER 
GO
ALTER DATABASE [BackDoor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BackDoor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BackDoor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BackDoor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BackDoor] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BackDoor', N'ON'
GO
ALTER DATABASE [BackDoor] SET QUERY_STORE = OFF
GO
USE [BackDoor]
GO
/****** Object:  User [BackDoorUser]    Script Date: 2019/10/10 11:53:32 ******/
CREATE USER [BackDoorUser] FOR LOGIN [BackDoorUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [BackDoorUser]
GO
/****** Object:  Schema [QNIKKA]    Script Date: 2019/10/10 11:53:32 ******/
CREATE SCHEMA [QNIKKA]
GO
/****** Object:  UserDefinedFunction [QNIKKA].[Zaiko_Zero2]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [QNIKKA].[Zaiko_Zero2]
(	
	-- Add the parameters for the function here
	@ERR_CNT NUMERIC, 
	@ERR_CD VARCHAR
)
RETURNS NUMERIC 
AS
begin
	declare @iCnt int;
	set @iCnt = 1;
	return @icnt;
end
GO
/****** Object:  Table [dbo].[Ｍ＿ＩＰアドレス管理マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿ＩＰアドレス管理マスタ](
	[ＩＰアドレス] [nvarchar](14) NOT NULL,
	[設備コード] [nchar](4) NULL,
	[稼動区分] [nchar](1) NULL,
	[用途区分] [nchar](2) NULL,
	[機種] [nvarchar](30) NULL,
	[備考] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ＩＰアドレス] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿再塗装管理データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿再塗装管理データ](
	[ロットＮＯ] [char](10) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[判定回数＿前] [numeric](2, 0) NULL,
	[作番＿前] [char](7) NULL,
	[補修完了区分] [char](1) NULL,
	[作番] [char](7) NOT NULL,
	[投入時間] [date] NULL,
	[投入年月日] [date] NULL,
	[更新日時] [date] NULL,
	[補修判定時間] [date] NOT NULL,
	[補修判定日] [date] NULL,
	[設備コード] [char](4) NULL,
	[理由コード] [char](3) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿在庫データ](
	[品名コード] [char](12) NOT NULL,
	[詳細工程コード] [char](3) NOT NULL,
	[デポコード] [char](3) NOT NULL,
	[前月残] [numeric](6, 0) NULL,
	[当月受入数量] [numeric](6, 0) NULL,
	[当月払出数量] [numeric](6, 0) NULL,
	[当月その他払出数量] [numeric](6, 0) NULL,
	[当日受入数量] [numeric](6, 0) NULL,
	[当日払出数量] [numeric](6, 0) NULL,
	[当日その他払出数量] [numeric](6, 0) NULL,
	[在庫残] [numeric](6, 0) NULL,
	[最終更新年月日] [date] NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿実績管理修正データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿実績管理修正データ](
	[作業実績数量] [numeric](6, 0) NULL,
	[塗装状態フラグ] [char](1) NULL,
	[不良工程コード] [char](3) NULL,
	[不良コード] [char](2) NULL,
	[品名コード] [char](12) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[判定時間] [date] NOT NULL,
	[設備コード] [char](4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿実績時間別ワークデータ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿実績時間別ワークデータ](
	[作業実績数量] [numeric](6, 0) NULL,
	[設備コード] [char](4) NOT NULL,
	[データ区分] [char](3) NOT NULL,
	[氏名コード] [char](4) NOT NULL,
	[品名コード] [char](12) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿実績履歴データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿実績履歴データ](
	[品名コード] [char](12) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[判定時間] [date] NULL,
	[設備コード] [char](4) NULL,
	[不良工程コード] [char](3) NULL,
	[不良コード] [char](2) NULL,
	[塗装状態フラグ] [char](1) NULL,
	[作業実績数量] [numeric](6, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿生産情報監視データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿生産情報監視データ](
	[品名コード] [char](12) NULL,
	[工程コード] [char](3) NOT NULL,
	[ライン区分] [char](1) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿半製品払出データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿半製品払出データ](
	[前工程半製品コード] [nchar](12) NOT NULL,
	[ロットＮＯ] [nchar](10) NOT NULL,
	[工程コード] [nchar](3) NOT NULL,
	[連番] [decimal](2, 0) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[前工程半製品コード] ASC,
	[ロットＮＯ] ASC,
	[工程コード] ASC,
	[連番] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ｍ＿補修管理データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ｍ＿補修管理データ](
	[塗装状態フラグ] [char](1) NULL,
	[作業実績数量] [numeric](6, 0) NULL,
	[品名コード] [char](12) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[補修判定時間] [date] NOT NULL,
	[補修判定日] [date] NULL,
	[設備コード] [char](4) NULL,
	[理由コード] [char](3) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[vStr] [varchar](10) NULL,
	[nStr] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[コードマスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[コードマスタ](
	[コード] [nvarchar](20) NOT NULL,
	[コード名称] [nvarchar](50) NOT NULL,
	[コード区分] [nchar](3) NOT NULL,
	[項目１] [nvarchar](20) NULL,
	[項目２] [nvarchar](20) NULL,
	[項目３] [nvarchar](50) NULL,
	[項目４] [nvarchar](20) NULL,
	[項目５] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[コード] ASC,
	[コード区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[コンテナ管理データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[コンテナ管理データ](
	[コンテナ区分] [char](2) NOT NULL,
	[コンテナNO] [char](10) NOT NULL,
	[事業所コード] [char](3) NULL,
	[発行年月日] [date] NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[コンテナ区分] ASC,
	[コンテナNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[コンテナ明細データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[コンテナ明細データ](
	[コンテナ区分] [char](2) NOT NULL,
	[コンテナNO] [char](10) NOT NULL,
	[ロットNO] [char](12) NOT NULL,
	[事業所コード] [char](3) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[コンテナ区分] ASC,
	[コンテナNO] ASC,
	[ロットNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[シミュレーション組立順序]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[シミュレーション組立順序](
	[種別] [nchar](1) NOT NULL,
	[車種コード] [nchar](4) NOT NULL,
	[構成要素区分] [nvarchar](4) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[組立順序] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[種別] ASC,
	[品名略称] ASC,
	[納入先コード] ASC,
	[納入区分] ASC,
	[組立順序] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[稼働日マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[稼働日マスタ](
	[稼働年月日] [date] NOT NULL,
	[直区分] [nchar](1) NOT NULL,
	[稼働区分] [nchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[稼働年月日] ASC,
	[直区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[区分標準通過工程]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[区分標準通過工程](
	[構成要素区分コード] [varchar](4) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[標準通過工程コード] [varchar](10) NOT NULL,
	[工程順位] [char](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[構成要素区分コード] ASC,
	[工程コード] ASC,
	[標準通過工程コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[原価品名マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[原価品名マスタ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[設備NO] [nchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[品名コード] ASC,
	[設備NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[個体ＮＯ管理データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[個体ＮＯ管理データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[個体ＮＯ] [nvarchar](14) NOT NULL,
	[個体ＮＯ変換種別] [nchar](1) NOT NULL,
	[区分個体NO] [nvarchar](14) NOT NULL,
	[構成要素区分] [nvarchar](4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[個体ＮＯ] ASC,
	[個体ＮＯ変換種別] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[工程マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[工程マスタ](
	[工程コード] [nchar](2) NOT NULL,
	[工程略称] [nvarchar](20) NOT NULL,
	[ラインロット区分] [nchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[工程コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[工程間実績チェックマスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[工程間実績チェックマスタ](
	[車種] [char](4) NOT NULL,
	[詳細工程コード] [char](3) NOT NULL,
	[品種コード] [char](2) NOT NULL,
	[対象詳細工程コード０１] [char](3) NULL,
	[対象詳細工程コード０２] [char](3) NULL,
	[対象詳細工程コード０３] [char](3) NULL,
	[対象詳細工程コード０４] [char](3) NULL,
	[対象詳細工程コード０５] [char](3) NULL,
	[対象詳細工程コード０６] [char](3) NULL,
	[対象詳細工程コード０７] [char](3) NULL,
	[対象詳細工程コード０８] [char](3) NULL,
	[対象詳細工程コード０９] [char](3) NULL,
	[対象詳細工程コード１０] [char](3) NULL,
	[対象詳細工程コード１１] [char](3) NULL,
	[対象詳細工程コード１２] [char](3) NULL,
	[対象詳細工程コード１３] [char](3) NULL,
	[対象詳細工程コード１４] [char](3) NULL,
	[対象詳細工程コード１５] [char](3) NULL,
	[対象詳細工程コード１６] [char](3) NULL,
	[対象詳細工程コード１７] [char](3) NULL,
	[対象詳細工程コード１８] [char](3) NULL,
	[対象詳細工程コード１９] [char](3) NULL,
	[対象詳細工程コード２０] [char](3) NULL,
	[対象詳細工程コード２１] [char](3) NULL,
	[対象詳細工程コード２２] [char](3) NULL,
	[対象詳細工程コード２３] [char](3) NULL,
	[対象詳細工程コード２４] [char](3) NULL,
	[対象詳細工程コード２５] [char](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[車種] ASC,
	[詳細工程コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[工程車種品種組合せマスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[工程車種品種組合せマスタ](
	[工程コード] [char](3) NOT NULL,
	[品種コード] [char](2) NOT NULL,
	[車種コード] [char](4) NOT NULL,
	[説明] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[工程コード] ASC,
	[品種コード] ASC,
	[車種コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[梱包指示データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[梱包指示データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[梱包ＮＯ] [nchar](7) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[梱包指示数] [decimal](6, 0) NULL,
	[梱包年月日] [date] NULL,
	[梱包時間] [time](7) NULL,
	[梱包直区分] [nchar](1) NULL,
	[コンテナＮＯ] [nchar](5) NULL,
	[台車ＮＯ] [nchar](3) NULL,
	[同期一貫ＮＯ] [nchar](4) NULL,
	[順列ＳＥＱＮＯ] [nchar](10) NULL,
	[台車ＳＥＱＮＯ] [nchar](10) NULL,
	[作番] [nchar](7) NULL,
	[納入年月日] [date] NULL,
	[納入時間] [time](7) NULL,
	[納入場所] [nchar](3) NULL,
	[段ＮＯ] [decimal](1, 0) NULL,
	[要求元ライン] [nchar](1) NULL,
	[取消フラグ] [nchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[梱包ＮＯ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[梱包実績データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[梱包実績データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[梱包ＮＯ] [nchar](7) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[梱包実績数] [decimal](6, 0) NULL,
	[梱包年月日] [date] NULL,
	[梱包時間] [time](7) NULL,
	[コンテナＮＯ] [nchar](5) NULL,
	[台車ＮＯ] [nchar](3) NULL,
	[同期一貫ＮＯ] [nchar](4) NULL,
	[納入年月日] [date] NULL,
	[納入時間] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[採番マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[採番マスタ](
	[管理ＮＯ種別] [nchar](2) NOT NULL,
	[固定部] [nvarchar](8) NOT NULL,
	[変動データ部] [nvarchar](10) NULL,
	[番号] [decimal](10, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[管理ＮＯ種別] ASC,
	[固定部] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[在庫データ](
	[事業所コード] [nvarchar](25) NOT NULL,
	[品名コード] [nvarchar](25) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[工程コード] [nchar](2) NULL,
	[製品半製品区分] [nvarchar](25) NULL,
	[前月残] [nvarchar](25) NULL,
	[当月受入数量] [int] NULL,
	[当月払出数量] [int] NULL,
	[在庫数] [int] NULL,
	[引当可能数量] [int] NULL,
	[再塗装数量] [int] NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[材料在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[材料在庫データ](
	[資材コード] [char](5) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[材料理論在庫量] [numeric](13, 6) NULL,
	[在庫更新日] [datetime] NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[作業計画データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[作業計画データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[作番] [nchar](7) NOT NULL,
	[作業年月日] [date] NOT NULL,
	[作業時間] [time](7) NULL,
	[直区分] [nchar](1) NOT NULL,
	[作業順序] [int] NOT NULL,
	[品名コード] [nchar](12) NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[工程コード] [nchar](2) NULL,
	[作業指示数量] [int] NULL,
	[確定状態] [nchar](1) NOT NULL,
	[取消フラグ] [nchar](1) NOT NULL,
	[再塗装フラグ] [nchar](1) NOT NULL,
	[着手区分] [nchar](1) NULL,
	[セット品フラグ] [nchar](1) NULL,
	[金型番号] [nvarchar](3) NULL,
	[計画台車NO] [nvarchar](3) NULL,
	[計画同期一貫ＮＯ] [nchar](4) NULL,
	[計画台車ＳＥＱＮＯ] [nchar](10) NULL,
	[計画納入年月日] [date] NULL,
	[計画納入時間] [time](7) NULL,
	[計画要求元ライン] [nchar](1) NULL,
	[計画時発行ＮＯ] [nvarchar](11) NULL,
	[製造ライン] [nchar](1) NULL,
	[保留フラグ] [nchar](1) NOT NULL,
	[生産手配フラグ] [nchar](1) NOT NULL,
	[設備NO] [nchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[作番] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[作業指示明細データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[作業指示明細データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[個体ＮＯ] [nvarchar](11) NOT NULL,
	[作番] [nchar](7) NULL,
	[品名コード] [nchar](12) NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[作業年月日] [date] NULL,
	[作業時間] [time](7) NULL,
	[直区分] [nchar](1) NULL,
	[工程コード] [nchar](2) NULL,
	[作業指示数量] [decimal](6, 0) NULL,
	[ラベル発行フラグ] [nchar](1) NULL,
	[着手実績フラグ] [nchar](1) NULL,
	[連番] [int] NULL,
	[取消フラグ] [nchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[個体ＮＯ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[使用資材]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[使用資材](
	[資材品名コード] [nchar](12) NOT NULL,
	[資材品名略称] [nvarchar](30) NOT NULL,
	[使用数量] [decimal](6, 0) NOT NULL,
	[標準通過工程コード] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[資材品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[資材マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[資材マスタ](
	[資材品名コード] [nchar](12) NOT NULL,
	[資材品名略称] [nvarchar](30) NOT NULL,
	[単位] [nvarchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[資材品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[事業所マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[事業所マスタ](
	[事業所コード] [nchar](1) NOT NULL,
	[事業所名称] [nvarchar](50) NULL,
	[事業所正式名] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[実績管理データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[実績管理データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[区分個体ＮＯ] [nvarchar](14) NOT NULL,
	[組立個体NO] [nchar](11) NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[塗装カウント] [int] NOT NULL,
	[作業年月日] [date] NOT NULL,
	[作業時間] [time](7) NOT NULL,
	[作番] [nchar](7) NOT NULL,
	[工程コード] [nchar](2) NOT NULL,
	[標準通過工程コード] [nvarchar](10) NOT NULL,
	[ラベル発行回数] [int] NULL,
	[梱包NO] [nchar](7) NULL,
	[設備NO] [nchar](4) NULL,
	[保管場所コード] [nvarchar](4) NULL,
	[コンテナNO] [nchar](5) NULL,
	[実績判定区分] [nchar](1) NULL,
	[不良コード] [nvarchar](4) NULL,
	[不良区分] [nchar](1) NULL,
	[保管区分] [nchar](1) NULL,
	[塗装工程状態] [nvarchar](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[区分個体ＮＯ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[実績数量]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[実績数量](
	[事業所コード] [nvarchar](4) NOT NULL,
	[作番] [nchar](7) NOT NULL,
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[着手数] [decimal](6, 0) NULL,
	[完成数] [decimal](6, 0) NULL,
	[不良数] [decimal](6, 0) NULL,
	[再塗装数] [decimal](6, 0) NULL,
	[指示残] [decimal](6, 0) NULL,
	[リペア数] [decimal](6, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[作番] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[社員マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[社員マスタ](
	[氏名コード] [nchar](4) NOT NULL,
	[氏名] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[車種マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[車種マスタ](
	[車種コード] [nchar](4) NOT NULL,
	[車種名] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[受払データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[受払データ](
	[シーケンス] [nvarchar](14) NOT NULL,
	[事業所コード] [nvarchar](14) NULL,
	[個体NO] [nvarchar](14) NULL,
	[品名コード] [nvarchar](14) NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[工程コード] [nchar](2) NULL,
	[製品半製品区分] [nvarchar](14) NULL,
	[受払年月日] [nvarchar](14) NULL,
	[受払区分] [nvarchar](14) NULL,
	[振替区分] [nvarchar](14) NULL,
	[備考] [nvarchar](54) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[シーケンス] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[順列納入指示データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[順列納入指示データ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[順列ＳＥＱＮＯ] [nchar](10) NOT NULL,
	[台車ＳＥＱＮＯ] [nchar](10) NULL,
	[納入年月日] [date] NULL,
	[納入時間] [time](7) NULL,
	[要元] [nchar](1) NULL,
	[メーカー] [nchar](4) NULL,
	[デポコード] [nchar](2) NULL,
	[台車ＮＯ] [nchar](3) NULL,
	[同期一貫ＮＯ] [nchar](4) NULL,
	[品名コード] [nchar](12) NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[部品番号] [nchar](12) NULL,
	[納入場所] [nchar](3) NULL,
	[納入指示数] [decimal](6, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[順列ＳＥＱＮＯ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[生産項目マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[生産項目マスタ](
	[品名コード] [char](12) NOT NULL,
	[品名略称] [varchar](30) NOT NULL,
	[製品半製品区分] [char](1) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[構成要素区分] [varchar](4) NOT NULL,
	[セット品名コード] [char](12) NULL,
	[基幹品名略称] [varchar](25) NULL,
	[音源ファイルパス] [varchar](100) NULL,
	[塗布機表示NO] [varchar](2) NULL,
	[塗布機ハーネス品名] [varchar](4) NULL,
	[ガラス接合区分] [varchar](2) NULL,
	[ガラス品名] [varchar](6) NULL,
	[インナ指示略称] [varchar](6) NULL,
	[インナ品種] [varchar](4) NULL,
	[完成仕様] [varchar](6) NULL,
	[ヒンジボルト] [varchar](2) NULL,
	[オープナーSW] [varchar](2) NULL,
	[アウタ生地仕様] [varchar](4) NULL,
	[車種] [char](4) NULL,
	[塗装車種] [char](12) NULL,
	[アウタ生地] [char](12) NULL,
	[アウタ穴仕様] [varchar](4) NULL,
	[コンビランプ] [varchar](6) NULL,
	[成形品名コード] [char](12) NULL,
	[仕向地] [varchar](4) NULL,
	[カメラ] [varchar](4) NULL,
	[カメラ建付装置用] [varchar](4) NULL,
	[クリヤー] [varchar](4) NULL,
	[プライマー] [varchar](4) NULL,
	[塗装色] [varchar](4) NULL,
	[穴明仕様コード] [varchar](4) NULL,
	[チェックシート区分] [varchar](4) NULL,
	[基準車系] [varchar](4) NULL,
	[ロック品種] [varchar](4) NULL,
	[ボックス品種] [varchar](4) NULL,
	[SUBASSY名称] [char](12) NULL,
	[棚ＮＯ] [varchar](4) NULL,
	[DVD名称] [varchar](10) NULL,
	[発注用部品] [varchar](12) NULL,
	[ハーネス] [varchar](4) NULL,
	[AV_CONT数量] [numeric](4, 0) NULL,
	[チェック表部品表示] [char](1) NULL,
	[ＯＦフラグ] [char](1) NULL,
	[設定コード名２] [varchar](2) NULL,
	[分割区分] [varchar](2) NULL,
	[キャップBD] [varchar](4) NULL,
	[非接触センサー] [varchar](2) NULL,
	[同色の変更可能な品名コード] [char](12) NULL,
	[ナンバープレート] [varchar](2) NULL,
	[成形モジュール] [varchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[生産品名マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[生産品名マスタ](
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[製品半製品区分] [nchar](1) NOT NULL,
	[工程コード] [nchar](2) NOT NULL,
	[構成要素区分] [nvarchar](4) NOT NULL,
	[塗装フラグ] [nchar](1) NOT NULL,
	[セット親品名コード] [nchar](12) NULL,
	[セット親品名略称] [nvarchar](25) NOT NULL,
	[セット親納入先コード] [nvarchar](4) NOT NULL,
	[セット親納入区分] [nchar](1) NOT NULL,
	[基幹品名略称] [nvarchar](25) NULL,
	[有効フラグ] [nchar](1) NULL,
	[単位] [nvarchar](2) NULL,
	[音源ファイルパス] [nvarchar](100) NULL,
	[塗布機表示NO] [nvarchar](2) NULL,
	[塗布機ハーネス品名] [nvarchar](4) NULL,
	[ガラス接合区分] [nvarchar](2) NULL,
	[ガラス品名] [nvarchar](6) NULL,
	[インナ指示略称] [nvarchar](6) NULL,
	[インナ品種] [nvarchar](4) NULL,
	[完成仕様] [nvarchar](6) NULL,
	[ヒンジボルト] [nvarchar](2) NULL,
	[オープナーSW] [nvarchar](2) NULL,
	[アウタ生地仕様] [nvarchar](4) NULL,
	[車種] [nchar](4) NULL,
	[塗装車種] [nchar](12) NULL,
	[生地名] [nvarchar](12) NULL,
	[アウタ穴仕様] [nvarchar](4) NULL,
	[コンビランプ] [nvarchar](6) NULL,
	[成形品名コード] [nchar](12) NULL,
	[仕向地] [nvarchar](4) NULL,
	[カメラ] [nvarchar](4) NULL,
	[カメラ建付装置用] [nvarchar](4) NULL,
	[クリヤー] [nvarchar](4) NULL,
	[プライマー] [nvarchar](4) NULL,
	[塗装色] [nvarchar](4) NULL,
	[穴明仕様コード] [nvarchar](4) NULL,
	[チェックシート区分] [nvarchar](4) NULL,
	[基準車系] [nvarchar](4) NULL,
	[ロック品種] [nvarchar](4) NULL,
	[ボックス品種] [nvarchar](4) NULL,
	[SUBASSY名称] [nchar](12) NULL,
	[棚ＮＯ] [nvarchar](4) NULL,
	[DVD名称] [nvarchar](10) NULL,
	[発注用部品] [nvarchar](12) NULL,
	[ハーネス] [nvarchar](4) NULL,
	[AV-CONT数量] [decimal](4, 0) NULL,
	[チェック表部品表示] [nchar](1) NULL,
	[Ｏ/Ｆフラグ] [nchar](1) NULL,
	[設定コード名２] [nvarchar](2) NULL,
	[分割区分] [nvarchar](2) NULL,
	[キャップB/D] [nvarchar](4) NULL,
	[非接触センサー] [nvarchar](2) NULL,
	[同色の変更可能な品名コード] [nchar](12) NULL,
	[ナンバープレート] [nvarchar](2) NULL,
	[成形モジュール] [nvarchar](4) NULL,
PRIMARY KEY CLUSTERED 
(
	[品名略称] ASC,
	[納入先コード] ASC,
	[納入区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[製品マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[製品マスタ](
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[客先部品番号] [nvarchar](15) NOT NULL,
	[品種コード] [nchar](2) NOT NULL,
	[車種コード] [nchar](4) NOT NULL,
	[取付け指示コード] [nvarchar](5) NOT NULL,
	[製品出荷ＳＮＰ] [decimal](1, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[品名略称] ASC,
	[納入先コード] ASC,
	[納入区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[設備マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[設備マスタ](
	[事業所コード] [nvarchar](4) NOT NULL,
	[設備NO] [nchar](4) NOT NULL,
	[設備略称] [nvarchar](20) NOT NULL,
	[標準通過工程コード] [nvarchar](10) NOT NULL,
	[ラインコード] [nvarchar](4) NULL,
	[工程コード] [nchar](2) NULL,
	[表示順序] [decimal](4, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[事業所コード] ASC,
	[設備NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[組付品名マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[組付品名マスタ](
	[品名コード] [nchar](12) NOT NULL,
	[品名略称] [nvarchar](25) NOT NULL,
	[納入先コード] [nvarchar](4) NOT NULL,
	[納入区分] [nchar](1) NOT NULL,
	[親品名コード] [nchar](12) NOT NULL,
	[親品名略称] [nvarchar](25) NOT NULL,
	[親納入先コード] [nvarchar](4) NOT NULL,
	[親納入区分] [nchar](1) NOT NULL,
	[使用数量] [decimal](4, 0) NOT NULL,
	[標準通過工程コード] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[品名略称] ASC,
	[納入先コード] ASC,
	[納入区分] ASC,
	[親品名略称] ASC,
	[親納入先コード] ASC,
	[親納入区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[大工程マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[大工程マスタ](
	[詳細工程コード] [char](3) NOT NULL,
	[詳細工程名称] [char](1) NOT NULL,
	[詳細工程略称] [varchar](20) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[表示順] [numeric](3, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[詳細工程コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[通過工程間チェック]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[通過工程間チェック](
	[構成要素区分コード] [nvarchar](4) NOT NULL,
	[工程コード] [nchar](2) NOT NULL,
	[標準通過工程コード] [nvarchar](10) NOT NULL,
	[先行通過工程コード] [nvarchar](10) NOT NULL,
	[先行構成要素区分] [nvarchar](1) NOT NULL,
	[チェック区分] [nvarchar](10) NOT NULL,
	[基準経過時間（以降）] [decimal](4, 0) NULL,
	[基準経過時間（以内）] [decimal](4, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[構成要素区分コード] ASC,
	[工程コード] ASC,
	[標準通過工程コード] ASC,
	[先行通過工程コード] ASC,
	[先行構成要素区分] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[納入指示データ（新設）]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[納入指示データ（新設）](
	[要元] [char](1) NOT NULL,
	[発行ＮＯ] [varchar](11) NOT NULL,
	[納入年月日] [date] NOT NULL,
	[納入指示時間] [numeric](4, 0) NULL,
	[メーカー] [char](4) NULL,
	[区分] [char](1) NULL,
	[納入場所] [char](2) NULL,
	[荷卸単位] [char](1) NULL,
	[品名コード] [char](12) NULL,
	[客先部品番号] [varchar](15) NULL,
	[納入先コード] [char](3) NULL,
	[納入指示数量] [numeric](6, 0) NULL,
	[納入指示端数] [numeric](6, 0) NULL,
	[化成注略] [varchar](6) NULL,
	[最終顧客コード] [char](2) NULL,
	[原価部門コード] [char](2) NULL,
	[売上品種コード] [char](3) NULL,
	[納入指示端数区分] [char](1) NULL,
	[要求元ライン] [char](1) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[要元] ASC,
	[発行ＮＯ] ASC,
	[納入年月日] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[標準通過工程マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[標準通過工程マスタ](
	[標準通過工程コード] [nvarchar](10) NOT NULL,
	[標準通過工程略称] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[標準通過工程コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[不良現象マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[不良現象マスタ](
	[工程コード] [nchar](2) NOT NULL,
	[不良コード] [nchar](2) NOT NULL,
	[不良現象名] [nvarchar](14) NOT NULL,
	[表示区分] [nchar](1) NULL,
	[表示順序] [int] NULL,
	[ボタン表示] [nchar](1) NULL,
	[ボタン表示順序] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[有償支給直送先マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[有償支給直送先マスタ](
	[取引先コード] [char](5) NOT NULL,
	[直送先コード] [char](2) NOT NULL,
	[直送先名] [varchar](30) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[Ｍ＿在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[Ｍ＿在庫データ](
	[品名コード] [char](12) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[デポコード] [char](3) NOT NULL,
	[前月残] [numeric](6, 0) NULL,
	[受入数量] [numeric](6, 0) NULL,
	[払出数量] [numeric](6, 0) NULL,
	[その他払出数量] [numeric](6, 0) NULL,
	[当日受入数量] [numeric](6, 0) NULL,
	[当日払出数量] [numeric](6, 0) NULL,
	[当日その他払出数量] [numeric](6, 0) NULL,
	[在庫残] [numeric](6, 0) NULL,
	[最終更新年月日] [datetime] NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[品名コード] ASC,
	[工程コード] ASC,
	[デポコード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[Ｍ＿在庫データ＿資材]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[Ｍ＿在庫データ＿資材](
	[資材コード] [char](5) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[倉庫コード] [char](3) NOT NULL,
	[前月残＿資材] [numeric](6, 0) NULL,
	[受入数量＿資材] [numeric](6, 0) NULL,
	[払出数量＿資材] [numeric](6, 0) NULL,
	[その他払出数量＿資材] [numeric](6, 0) NULL,
	[当日受入数量＿資材] [numeric](6, 0) NULL,
	[当日払出数量＿資材] [numeric](6, 0) NULL,
	[当日その他払出数量＿資材] [numeric](6, 0) NULL,
	[在庫残＿資材] [numeric](6, 0) NULL,
	[最終更新年月日] [datetime] NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[Ｍ＿作業計画データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[Ｍ＿作業計画データ](
	[作番] [char](7) NOT NULL,
	[作業年月日] [date] NOT NULL,
	[直区分] [char](1) NOT NULL,
	[作業順序] [numeric](4, 0) NOT NULL,
	[品名コード] [char](12) NULL,
	[工程コード] [char](3) NULL,
	[作業指示数量] [numeric](6, 0) NULL,
	[作業必要数量] [numeric](6, 0) NULL,
	[作業開始予定時間] [char](5) NULL,
	[作業終了予定時間] [char](5) NULL,
	[作業開始予定日時] [date] NULL,
	[作業終了予定日時] [date] NULL,
	[処理フラグ] [char](1) NULL,
	[作業指示発行フラグ] [char](1) NULL,
	[確定フラグ] [char](1) NULL,
	[台車ＮＯ] [char](3) NULL,
	[出荷年月日] [date] NULL,
	[納入時間] [char](4) NULL,
	[台車ＳＥＱＮＯ] [char](10) NULL,
	[引当区分] [char](1) NULL,
	[設備コード] [char](4) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
	[補正フラグ] [char](1) NULL,
	[作業計画フラグ] [char](1) NULL,
	[備考] [varchar](40) NULL,
	[品種コード] [char](2) NULL,
	[車種コード] [char](4) NULL,
	[品種コード＿半] [char](2) NULL,
	[ＭＩＣＳ作番] [varchar](7) NULL,
	[ＭＩＣＳ品名コード] [varchar](12) NULL,
	[ＭＩＣＳ順番] [numeric](4, 0) NULL,
	[日産組立ライン] [char](1) NULL,
	[金型番号] [varchar](20) NULL,
	[ラベル発行フラグ] [char](1) NULL,
	[ライン区分] [char](1) NULL,
	[変更フラグ] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[作番] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[材料在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[材料在庫データ](
	[資材コード] [char](5) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[材料理論在庫量] [numeric](13, 6) NULL,
	[在庫更新日] [datetime] NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[資材マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[資材マスタ](
	[資材コード] [char](5) NOT NULL,
	[資材区分] [char](1) NOT NULL,
	[資材品名略称] [varchar](25) NOT NULL,
	[資材発注名称] [varchar](25) NOT NULL,
	[資材発注内示区分] [char](1) NOT NULL,
	[資材発注単位コード] [varchar](2) NOT NULL,
	[資材検査対象区分] [char](1) NOT NULL,
	[小口材料区分] [char](1) NOT NULL,
	[資材調達期間] [numeric](3, 0) NOT NULL,
	[資材発注ロット] [numeric](8, 2) NOT NULL,
	[資材発注ＳＮＰ] [numeric](8, 2) NOT NULL,
	[資材単価＿今期] [numeric](11, 2) NOT NULL,
	[資材単価＿今期実行] [numeric](11, 2) NULL,
	[資材単価＿来期] [numeric](11, 2) NOT NULL,
	[資材単価＿来期実行] [numeric](11, 2) NULL,
	[型償却適用区分＿資材] [char](1) NOT NULL,
	[メーカー区分] [char](1) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
	[現品票発行区分] [char](1) NOT NULL,
	[調達区分] [char](1) NOT NULL,
	[原価部門] [char](2) NOT NULL,
	[登録フラグ] [char](1) NULL,
	[ＭＩＣＳ更新フラグ] [char](1) NULL,
	[ＭＩＣＳ対象フラグ] [char](1) NULL,
	[ＤＬ時間] [date] NULL,
	[荷姿] [varchar](30) NULL,
	[見積り更新フラグ] [char](1) NULL,
	[資材単価＿再来期] [numeric](11, 2) NOT NULL,
	[資材単価＿再来期実行] [numeric](11, 2) NULL,
	[常非区分] [char](1) NULL,
	[検要区分] [char](1) NULL,
	[受渡場所コード] [char](2) NULL,
PRIMARY KEY CLUSTERED 
(
	[資材発注名称] ASC,
	[資材発注内示区分] ASC,
	[原価部門] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[製品在庫データ＿デポ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[製品在庫データ＿デポ](
	[品名コード] [char](12) NOT NULL,
	[デポ先コード] [char](3) NOT NULL,
	[デポ理論在庫数量] [numeric](8, 2) NULL,
	[在庫更新日] [datetime] NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL,
 CONSTRAINT [PK_製品在庫データ＿デポ] PRIMARY KEY CLUSTERED 
(
	[品名コード] ASC,
	[デポ先コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[製品半製品在庫データ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[製品半製品在庫データ](
	[品名コード] [char](12) NOT NULL,
	[在庫更新日] [datetime] NULL,
	[工程コード] [char](3) NULL,
	[製品半製品理論在庫数量] [numeric](8, 2) NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[品種マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[品種マスタ](
	[品種コード] [char](2) NOT NULL,
	[品種名] [varchar](20) NOT NULL,
	[登録日時] [datetime] NULL,
	[更新日時] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[品種コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [QNIKKA].[品名マスタ]    Script Date: 2019/10/10 11:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QNIKKA].[品名マスタ](
	[品名コード] [char](12) NOT NULL,
	[加工費コード] [char](2) NOT NULL,
	[工程コード] [char](3) NOT NULL,
	[品名略称] [varchar](30) NOT NULL,
	[製品半製品区分] [char](1) NOT NULL,
	[ＳＴ＿今期] [numeric](5, 2) NOT NULL,
	[ＳＴ＿今期実行] [numeric](5, 2) NULL,
	[ＳＴ＿来期] [numeric](5, 2) NOT NULL,
	[ＳＴ＿来期実行] [numeric](5, 2) NULL,
	[ＳＴ＿実行] [numeric](5, 2) NOT NULL,
	[総合ＯＴ＿今期] [numeric](5, 2) NOT NULL,
	[総合ＯＴ＿今期実行] [numeric](5, 2) NULL,
	[総合ＯＴ＿来期] [numeric](5, 2) NOT NULL,
	[総合ＯＴ＿来期実行] [numeric](5, 2) NULL,
	[総合ＯＴ＿実行] [numeric](5, 2) NOT NULL,
	[金型コード] [char](5) NOT NULL,
	[不良率＿今期] [numeric](4, 2) NOT NULL,
	[不良率＿今期実行] [numeric](4, 2) NULL,
	[不良率＿来期] [numeric](4, 2) NOT NULL,
	[不良率＿来期実行] [numeric](4, 2) NULL,
	[理論在庫引落区分] [char](1) NOT NULL,
	[材料費] [numeric](8, 2) NOT NULL,
	[材料費＿今期実行] [numeric](8, 2) NULL,
	[材料費＿来期] [numeric](8, 2) NOT NULL,
	[材料費＿来期実行] [numeric](8, 2) NULL,
	[直人費１] [numeric](7, 2) NOT NULL,
	[直人費１＿今期実行] [numeric](7, 2) NULL,
	[直人費１＿来期] [numeric](7, 2) NOT NULL,
	[直人費１＿来期実行] [numeric](7, 2) NULL,
	[直人費２] [numeric](7, 2) NOT NULL,
	[直人費２＿今期実行] [numeric](7, 2) NULL,
	[直人費２＿来期] [numeric](7, 2) NOT NULL,
	[直人費２＿来期実行] [numeric](7, 2) NULL,
	[間接人件費] [numeric](7, 2) NOT NULL,
	[間接人件費＿今期実行] [numeric](7, 2) NULL,
	[間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[間接人件費＿来期実行] [numeric](7, 2) NULL,
	[変動間接人件費] [numeric](7, 2) NOT NULL,
	[変動間接人件費＿今期実行] [numeric](7, 2) NULL,
	[変動間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[変動間接人件費＿来期実行] [numeric](7, 2) NULL,
	[固定間接人件費] [numeric](7, 2) NOT NULL,
	[固定間接人件費＿今期実行] [numeric](7, 2) NULL,
	[固定間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[固定間接人件費＿来期実行] [numeric](7, 2) NULL,
	[材料不良費] [numeric](7, 2) NOT NULL,
	[材料不良費＿今期実行] [numeric](7, 2) NULL,
	[材料不良費＿来期] [numeric](7, 2) NOT NULL,
	[材料不良費＿来期実行] [numeric](7, 2) NULL,
	[加工不良費] [numeric](7, 2) NOT NULL,
	[加工不良費＿今期実行] [numeric](7, 2) NULL,
	[加工不良費＿来期] [numeric](7, 2) NOT NULL,
	[加工不良費＿来期実行] [numeric](7, 2) NULL,
	[総材料費] [numeric](8, 2) NOT NULL,
	[総材料費＿今期実行] [numeric](8, 2) NULL,
	[総材料費＿来期] [numeric](8, 2) NOT NULL,
	[総材料費＿来期実行] [numeric](8, 2) NULL,
	[総直人費１] [numeric](7, 2) NOT NULL,
	[総直人費１＿今期実行] [numeric](7, 2) NULL,
	[総直人費１＿来期] [numeric](7, 2) NOT NULL,
	[総直人費１＿来期実行] [numeric](7, 2) NULL,
	[総直人費２] [numeric](7, 2) NOT NULL,
	[総直人費２＿今期実行] [numeric](7, 2) NULL,
	[総直人費２＿来期] [numeric](7, 2) NOT NULL,
	[総直人費２＿来期実行] [numeric](7, 2) NULL,
	[総間接人件費] [numeric](7, 2) NOT NULL,
	[総間接人件費＿今期実行] [numeric](7, 2) NULL,
	[総間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[総間接人件費＿来期実行] [numeric](7, 2) NULL,
	[総変動間接人件費] [numeric](7, 2) NOT NULL,
	[総変動間接人件費＿今期実行] [numeric](7, 2) NULL,
	[総変動間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[総変動間接人件費＿来期実行] [numeric](7, 2) NULL,
	[総固定間接人件費] [numeric](7, 2) NOT NULL,
	[総固定間接人件費＿今期実行] [numeric](7, 2) NULL,
	[総固定間接人件費＿来期] [numeric](7, 2) NOT NULL,
	[総固定間接人件費＿来期実行] [numeric](7, 2) NULL,
	[総材料不良費] [numeric](7, 2) NOT NULL,
	[総材料不良費＿今期実行] [numeric](7, 2) NULL,
	[総材料不良費＿来期] [numeric](7, 2) NOT NULL,
	[総材料不良費＿来期実行] [numeric](7, 2) NULL,
	[積上不良費] [numeric](7, 2) NULL,
	[積上不良費＿今期実行] [numeric](7, 2) NULL,
	[積上不良費＿来期] [numeric](7, 2) NULL,
	[積上不良費＿来期実行] [numeric](7, 2) NULL,
	[原価計算フラグ] [char](1) NOT NULL,
	[設備コード] [char](4) NULL,
	[売上品種コード] [char](3) NULL,
	[滅却区分] [char](1) NULL,
	[タクト] [numeric](5, 0) NULL,
	[実行不良率] [numeric](7, 0) NULL,
	[レジスタＮＯ] [char](2) NULL,
	[入数] [numeric](4, 0) NULL,
	[現決区分] [char](1) NULL,
	[登録日時] [date] NULL,
	[更新日時] [date] NULL,
	[取数] [numeric](2, 0) NULL,
	[背番号＿半] [varchar](4) NULL,
	[品種コード＿半] [char](2) NULL,
	[品種コード] [char](2) NULL,
	[加工費コード＿来期] [char](2) NULL,
	[設備コード＿来期] [char](4) NULL,
	[検索区分] [char](3) NULL,
	[製品グループ＿半] [char](2) NULL,
	[車種コード] [char](4) NULL,
	[在庫更新区分] [char](1) NULL,
	[内作品支給資材コード] [char](1) NULL,
	[作業指示形態＿半] [char](5) NULL,
	[ＳＴ＿再来期] [numeric](5, 2) NOT NULL,
	[ＳＴ＿再来期実行] [numeric](5, 2) NULL,
	[総合ＯＴ＿再来期] [numeric](5, 2) NOT NULL,
	[総合ＯＴ＿再来期実行] [numeric](5, 2) NULL,
	[不良率＿再来期] [numeric](4, 2) NOT NULL,
	[不良率＿再来期実行] [numeric](4, 2) NULL,
	[材料費＿再来期] [numeric](8, 2) NOT NULL,
	[材料費＿再来期実行] [numeric](8, 2) NULL,
	[直人費１＿再来期] [numeric](7, 2) NOT NULL,
	[直人費１＿再来期実行] [numeric](7, 2) NULL,
	[直人費２＿再来期] [numeric](7, 2) NOT NULL,
	[直人費２＿再来期実行] [numeric](7, 2) NULL,
	[間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[変動間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[変動間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[固定間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[固定間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[材料不良費＿再来期] [numeric](7, 2) NOT NULL,
	[材料不良費＿再来期実行] [numeric](7, 2) NULL,
	[加工不良費＿再来期] [numeric](7, 2) NOT NULL,
	[加工不良費＿再来期実行] [numeric](7, 2) NULL,
	[総材料費＿再来期] [numeric](8, 2) NOT NULL,
	[総材料費＿再来期実行] [numeric](8, 2) NULL,
	[総直人費１＿再来期] [numeric](7, 2) NOT NULL,
	[総直人費１＿再来期実行] [numeric](7, 2) NULL,
	[総直人費２＿再来期] [numeric](7, 2) NOT NULL,
	[総直人費２＿再来期実行] [numeric](7, 2) NULL,
	[総間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[総間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[総変動間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[総変動間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[総固定間接人件費＿再来期] [numeric](7, 2) NOT NULL,
	[総固定間接人件費＿再来期実行] [numeric](7, 2) NULL,
	[総材料不良費＿再来期] [numeric](7, 2) NOT NULL,
	[総材料不良費＿再来期実行] [numeric](7, 2) NULL,
	[積上不良費＿再来期] [numeric](7, 2) NULL,
	[積上不良費＿再来期実行] [numeric](7, 2) NULL,
	[加工費コード＿再来期] [char](2) NULL,
	[設備コード＿再来期] [char](4) NULL,
	[照合対象フラグ] [char](1) NULL,
	[フリー項目１] [varchar](2) NULL,
	[フリー項目２] [varchar](1) NULL,
	[新基幹＿品名コード] [varchar](10) NULL,
	[入庫用＿品名コード] [varchar](10) NULL,
	[登録日時２] [date] NULL,
	[更新日時２] [date] NULL,
	[MFZ_FLG] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[品名コード] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ｍ＿在庫データ] ADD  DEFAULT ((0)) FOR [品名コード]
GO
ALTER TABLE [dbo].[Ｍ＿在庫データ] ADD  DEFAULT ((0)) FOR [詳細工程コード]
GO
ALTER TABLE [dbo].[Ｍ＿在庫データ] ADD  DEFAULT ((0)) FOR [デポコード]
GO
ALTER TABLE [dbo].[Ｍ＿在庫データ] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [dbo].[Ｍ＿補修管理データ] ADD  DEFAULT ((0)) FOR [塗装状態フラグ]
GO
ALTER TABLE [dbo].[梱包指示データ] ADD  DEFAULT ((0)) FOR [段ＮＯ]
GO
ALTER TABLE [dbo].[作業計画データ] ADD  DEFAULT ((0)) FOR [保留フラグ]
GO
ALTER TABLE [dbo].[作業計画データ] ADD  DEFAULT ((0)) FOR [生産手配フラグ]
GO
ALTER TABLE [dbo].[納入指示データ（新設）] ADD  DEFAULT ((0)) FOR [納入指示端数区分]
GO
ALTER TABLE [dbo].[納入指示データ（新設）] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [dbo].[不良現象マスタ] ADD  DEFAULT ((0)) FOR [表示区分]
GO
ALTER TABLE [dbo].[有償支給直送先マスタ] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT ('0') FOR [引当区分]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT ('0') FOR [補正フラグ]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT ('0') FOR [作業計画フラグ]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT ('0') FOR [ラベル発行フラグ]
GO
ALTER TABLE [QNIKKA].[Ｍ＿作業計画データ] ADD  DEFAULT ('0') FOR [変更フラグ]
GO
ALTER TABLE [QNIKKA].[資材マスタ] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [QNIKKA].[品種マスタ] ADD  CONSTRAINT [登録日時]  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT ((0)) FOR [実行不良率]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT ('0') FOR [現決区分]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT (getdate()) FOR [登録日時]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT ((1)) FOR [取数]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT ('0') FOR [内作品支給資材コード]
GO
ALTER TABLE [QNIKKA].[品名マスタ] ADD  DEFAULT ('0') FOR [MFZ_FLG]
GO
/****** Object:  StoredProcedure [dbo].[Zaiko_S]    Script Date: 2019/10/10 11:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************/
/* モジュール名 ：Zaiko_S                                   */
/* 処理概要     ：Ｍ＿在庫データ連動処理                    */
/************************************************************/
CREATE procedure [dbo].[Zaiko_S]
as
begin

	declare @p_update_cnt int                    /* 更新レコード件数        */
	declare @p_update_cnt2 int					 /* 更新レコード件数        */
	declare @p_rtn int							 /* 戻り値                  */
	declare @rtn_val int						 /* リターン値              */
	declare @p_suryo int                         /* 製品半製品理論在庫数量  */

    /*** テーブル変数宣言 **********************/
	declare @p_品名コード char(12)
	declare @p_工程コード char(3)
	declare @p_デポコード char(3)
	declare @p_在庫残 numeric

	declare @p_前月残 numeric
	declare @p_製品半製品理論在庫数量 numeric
	declare @p_デポ理論在庫数量 numeric

    /** カーソル宣言(Ｍ＿在庫データ検索用) **/
	Declare CSR_MZ Cursor
	for SELECT 品名コード,
               工程コード,
               デポコード,
               在庫残
        FROM Ｍ＿在庫データ
		ORDER BY 品名コード,工程コード,デポコード
	
	set @p_update_cnt = 0
	set @p_update_cnt2 = 0

	Open CSR_MZ
	Fetch next From CSR_MZ
	Into @p_品名コード,@p_工程コード,@p_デポコード,@p_在庫残
	while(@@fetch_status=0)
	begin

        /* デポ先コードチェック */
        IF @p_デポコード='000'
		begin

		    /** カーソル宣言(製品半製品在庫データ検索用) **/
			Declare CSR_Z CURSOR
			for SELECT 製品半製品理論在庫数量
				FROM 製品半製品在庫データ
				WHERE 品名コード   = @p_品名コード
					AND 工程コード = @p_工程コード

            /* 製品・半製品 */
            OPEN CSR_Z

            FETCH next From CSR_Z
			INTO @p_suryo
			while(@@fetch_status=0)
			begin

            --IF CSR_Z%ROWCOUNT = 0 Then
            --    /* 存在しない場合エラーログ */
            --    P_ZLOG.ERR('P_MBL0300','O','製品半製品在庫データ未登録エラー',@p_品名コード||':'||@p_工程コード);
            --    ERR_CNT := ERR_CNT + 1;
            --ELSE
                /* 存在している場合更新 */
                UPDATE 製品半製品在庫データ
                   SET 製品半製品理論在庫数量 = @p_在庫残,
                       在庫更新日 =	getdate(),
                       更新日時   = getdate()
                 WHERE 品名コード     = @p_品名コード
                   AND 工程コード     = @p_工程コード

                set @p_update_cnt = @p_update_cnt + 1
            --END IF;

				FETCH next From CSR_Z
					INTO @p_suryo
            
			end
			CLOSE CSR_Z
			Deallocate CSR_Z
		end
        ELSE
		begin

		    /** カーソル宣言(製品在庫データ＿デポ検索用) **/
			Declare CSR_D CURSOR
			for SELECT デポ理論在庫数量
				FROM 製品在庫データ＿デポ
				WHERE 品名コード   = @p_品名コード
				AND デポ先コード = @p_デポコード

            /* デポ */
            OPEN CSR_D
            FETCH next From CSR_D 
			INTO @p_suryo
			while(@@fetch_status=0)
			begin

            --IF CSR_D%ROWCOUNT = 0 Then
            --    /* 存在しない場合エラーログ */
            --    P_ZLOG.ERR('P_MBL0300','O','製品在庫データ_デポ未登録エラー',@p_品名コード||':'||@p_デポコード);
            --    ERR_CNT := ERR_CNT + 1;
            --ELSE
                /* 存在している場合更新 */
                UPDATE 製品在庫データ＿デポ
                   SET デポ理論在庫数量 = @p_在庫残,
                       在庫更新日 = getdate(),
                       更新日時   = getdate()
                 WHERE 品名コード   = @p_品名コード
                   AND デポ先コード = @p_デポコード
                set @p_update_cnt2 = @p_update_cnt2 + 1
            --END IF;
				FETCH next From CSR_D 
					INTO @p_suryo
            
			end
			CLOSE CSR_D
			Deallocate CSR_D
        END

		Fetch next From CSR_MZ
		Into @p_品名コード,@p_工程コード,@p_デポコード,@p_在庫残
    END

	Close CSR_MZ
	Deallocate CSR_MZ

END
GO
/****** Object:  StoredProcedure [dbo].[Zaiko_Zero1]    Script Date: 2019/10/10 11:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Zaiko_Zero1]
as
begin

	declare @p_update_cnt4 int
	declare @p_rtn int
	declare @rtn_val int

	declare @p_品名コード char(12)
	declare @p_工程コード char(3)
	declare @p_デポコード char(3)
	declare @p_前月残 int
	declare @p_受入数量 int
	declare @p_払出数量 int
	declare @p_その他払出数量 int
	declare @p_当日受入数量 int
	declare @p_当日払出数量 int
	declare @p_当日その他払出数量 int
	declare @p_在庫残 numeric

	Declare CSR_MZ Cursor
		for SELECT 品名コード,
                            工程コード,
                            デポコード,
                            前月残,
                            受入数量,
                            払出数量,
                            その他払出数量,
                            当日受入数量,
                            当日払出数量,
                            当日その他払出数量
                       FROM Ｍ＿在庫データ
                   ORDER BY 品名コード,工程コード,デポコード
	Open CSR_MZ
	Fetch next From CSR_MZ
	Into @p_品名コード,@p_工程コード,@p_デポコード,@p_前月残,@p_受入数量,@p_払出数量,
		@p_その他払出数量,@p_当日受入数量,@p_当日払出数量,@p_当日その他払出数量
	while(@@fetch_status=0)
		 begin
			  
			  set @p_在庫残 = @p_前月残 + @p_受入数量 + @p_当日受入数量 - @p_払出数量 - @p_当日払出数量 - @p_その他払出数量 - @p_当日その他払出数量
        set @p_受入数量 = @p_受入数量 + @p_当日受入数量
        set @p_払出数量 = @p_払出数量 + @p_当日払出数量
        set @p_その他払出数量 = @p_その他払出数量 + @p_当日その他払出数量

        /* Ｍ＿在庫データの更新 */
        UPDATE Ｍ＿在庫データ
           SET 受入数量           = @p_受入数量,
               払出数量           = @p_払出数量,
               その他払出数量     = @p_その他払出数量,
               当日受入数量       = 0,
               当日払出数量       = 0,
               当日その他払出数量 = 0,
               在庫残             = @p_在庫残,
               最終更新年月日     = getdate(),
               更新日時           = getdate()
         WHERE 品名コード = @p_品名コード
           AND 工程コード = @p_工程コード
           AND デポコード = @p_デポコード;
       set @p_update_cnt4 = @p_update_cnt4 + 1

			  fetch next From CSR_MZ Into @p_品名コード,@p_工程コード,@p_デポコード,@p_前月残,@p_受入数量,@p_払出数量,
										  @p_その他払出数量,@p_当日受入数量,@p_当日払出数量,@p_当日その他払出数量
		 end
	Close CSR_MZ
	Deallocate CSR_MZ

    --P_ZLOG.TRACE('J','UPD','Ｍ＿在庫データ',TO_CHAR(p_update_cnt4));

    --return(0);

    --/**************** <<例外処理>> ****************/
    --EXCEPTION
    --WHEN USR_ERROR_ABEND Then
    --    ROLLBACK;
    --    return(rtn_val);
    --WHEN OTHERS Then
    --    P_ZLOG.ERR('P_MBL0300.Zaiko_Zero1','O',sqlcode,sqlerrm(sqlcode));
    --    P_ZLOG.TRACE('J','END','P_MBL0300.Zaiko_Zero1','Abnomal End');
    --    ERR_CD := sqlcode;
    --    /*** ロールバック ***/
    --    ROLLBACK WORK;
    --    return(-3);


	--return 0

END
GO
/****** Object:  StoredProcedure [dbo].[Zaiko_Zero2]    Script Date: 2019/10/10 11:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Zaiko_Zero2]
AS
BEGIN
    DECLARE @p_update_cnt5  NUMERIC                       /* 更新レコード件数        */
    DECLARE @rtn_val        NUMERIC                       /* リターン値              */
	
	DECLARE @資材コード CHAR(5)
	DECLARE @工程コード CHAR(5)
	DECLARE @倉庫コード CHAR(5)
	DECLARE @前月残＿資材 NUMERIC(6)
	DECLARE @受入数量＿資材 NUMERIC(6)
	DECLARE @払出数量＿資材 NUMERIC(6)
	DECLARE @その他払出数量＿資材 NUMERIC(6)
	DECLARE @当日受入数量＿資材 NUMERIC(6)
	DECLARE @当日払出数量＿資材 NUMERIC(6)
	DECLARE @当日その他払出数量＿資材 NUMERIC(6)
	DECLARE @在庫残＿資材 NUMERIC(6)
	
	DECLARE CSR_MZ CURSOR FOR 
					 SELECT 資材コード,
                            工程コード,
                            倉庫コード,
                            前月残＿資材,
                            受入数量＿資材,
                            払出数量＿資材,
                            その他払出数量＿資材,
                            当日受入数量＿資材,
                            当日払出数量＿資材,
                            当日その他払出数量＿資材
                       FROM Ｍ＿在庫データ＿資材
                   ORDER BY 資材コード,工程コード,倉庫コード
	
	--カーソルオープン
	OPEN CSR_MZ
	
	--最初の1行目を取得して変数へ値をセット
	FETCH NEXT FROM CSR_MZ
	INTO @資材コード,@工程コード,@倉庫コード,@前月残＿資材,@受入数量＿資材,@払出数量＿資材,@その他払出数量＿資材,@当日受入数量＿資材,@当日払出数量＿資材,@当日その他払出数量＿資材
	
	--データの行数分ループ処理を実行する
	
	BEGIN
	
		-- ========= ループ内の実際の処理 ここから===
		
        /* 計算 */
        set @在庫残＿資材 = @前月残＿資材 + @受入数量＿資材 + @当日受入数量＿資材 - @払出数量＿資材 - @当日払出数量＿資材 - @その他払出数量＿資材 - @当日その他払出数量＿資材
        set @受入数量＿資材 = @受入数量＿資材 + @当日受入数量＿資材
        set @払出数量＿資材 = @払出数量＿資材 + @当日払出数量＿資材
        set @その他払出数量＿資材 = @その他払出数量＿資材 + @当日その他払出数量＿資材
		
		UPDATE Ｍ＿在庫データ＿資材
           SET 受入数量＿資材           = @受入数量＿資材,
               払出数量＿資材           = @払出数量＿資材,
               その他払出数量＿資材      = @その他払出数量＿資材,
               当日受入数量＿資材       = 0,
               当日払出数量＿資材       = 0,
               当日その他払出数量＿資材  = 0,
               在庫残＿資材            = @在庫残＿資材,
               最終更新年月日     = GETDATE(),
               更新日時           = GETDATE()
         WHERE 資材コード = @資材コード
           AND 工程コード = @工程コード
           AND 倉庫コード = @倉庫コード
	
		-- ========= ループ内の実際の処理 ここまで===	
	
		--次の行のデータを取得して変数へ値をセット
		FETCH NEXT FROM CSR_MZ
		INTO @資材コード,@工程コード,@倉庫コード,@前月残＿資材,@受入数量＿資材,@払出数量＿資材,@その他払出数量＿資材,@当日受入数量＿資材,@当日払出数量＿資材,@当日その他払出数量＿資材	
	
	END
	
	--カーソルを閉じる
	CLOSE CSR_MZ
	DEALLOCATE CSR_MZ	
END
GO
/****** Object:  StoredProcedure [QNIKKA].[P_MBL0300]    Script Date: 2019/10/10 11:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [QNIKKA].[P_MBL0300] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT GETDATE()
END
GO
USE [master]
GO
ALTER DATABASE [BackDoor] SET  READ_WRITE 
GO
