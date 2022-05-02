
GO
/****** Object:  Table [dbo].[cegek]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cegek](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cegnev] [varchar](120) NOT NULL,
	[orszag] [int] NULL,
	[iranyitoszam] [int] NULL,
	[varos] [varchar](60) NULL,
	[cim] [varchar](200) NULL,
 CONSTRAINT [PK_cegek] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorHexa] [varchar](10) NOT NULL,
	[Name] [varchar](10) NULL,
 CONSTRAINT [PK_Colors_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Phone] [decimal](12, 0) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Copy Of dbo_ProfitCenter]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy Of dbo_ProfitCenter](
	[ID] [int] NOT NULL,
	[ProfitCenter] [nchar](10) NULL,
	[Megnevezés] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[id] [smallint] NOT NULL,
	[orszagkod] [varchar](2) NOT NULL,
	[orszagneve] [varchar](30) NOT NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[csomagolas]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csomagolas](
	[ID] [int] NOT NULL,
	[csomagolastipus] [varchar](35) NOT NULL,
 CONSTRAINT [PK_csomagolas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LSP]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LSP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](150) NULL,
	[CC] [varchar](150) NULL,
	[PostCode] [int] NULL,
	[City] [int] NULL,
	[Adress] [varchar](50) NULL,
	[Country] [smallint] NULL,
	[Fax] [decimal](11, 0) NULL,
 CONSTRAINT [PK_LSP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LSPKapcsolo]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LSPKapcsolo](
	[LSPID] [int] NULL,
	[ContactID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilkRunMovement]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilkRunMovement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrackingNumberID] [int] NOT NULL,
	[InDate] [datetime] NULL,
	[OutDate] [datetime] NULL,
	[receptionID] [int] NULL,
	[commentIN] [varchar](50) NULL,
	[InPalette] [int] NULL,
	[OutPalette] [int] NULL,
	[befele] [bit] NULL,
	[szalitolevelCMR] [varchar](200) NULL,
	[kártyaszám] [varchar](50) NULL,
	[plombaszam] [varchar](50) NULL,
	[kiszallitas] [bit] NULL,
	[commentOUT] [varchar](50) NULL,
	[EgyediAzonositIn] [varchar](50) NULL,
	[EgyediAzonositOut] [varchar](50) NULL,
 CONSTRAINT [PK_MilkRunMovement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Milkruns]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Milkruns](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrackingNumber] [varchar](50) NOT NULL,
	[TrailerNumber] [varchar](50) NULL,
	[DriverName] [varchar](50) NULL,
	[Active] [bit] NULL,
	[MRID] [int] NULL,
	[Date] [datetime] NULL,
	[Kartyaszam] [varchar](50) NULL,
 CONSTRAINT [PK_Milkruns] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MilkRunTimeTable]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MilkRunTimeTable](
	[ID] [int] NOT NULL,
	[TrackingNumberID] [int] NOT NULL,
	[InDate] [time](7) NOT NULL,
	[OutDate] [time](7) NOT NULL,
	[receptionID] [int] NOT NULL,
 CONSTRAINT [PK_MilkRunTimeTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moneytrans]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneytrans](
	[UserID] [int] NOT NULL,
	[Amount] [numeric](16, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Month]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Month](
	[ID] [int] NOT NULL,
	[MonthName] [varchar](50) NULL,
	[IDFull] [varchar](2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PDFiles]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PDFiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[data] [varbinary](max) NULL,
 CONSTRAINT [PK_PDFiles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PDFKapcsolo]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PDFKapcsolo](
	[PDFFilesID] [int] NOT NULL,
	[OrderID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfitCenter]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitCenter](
	[ID] [int] NOT NULL,
	[ProfitCenter] [nchar](10) NOT NULL,
	[Megnevezés] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SenderName]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SenderName](
	[userID] [varchar](6) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_SenderName] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SGHUOrder]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SGHUOrder](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ProfitCenter] [int] NULL,
	[Info] [text] NULL,
	[StartDate] [date] NULL,
	[Person] [nchar](40) NULL,
	[Computer] [nchar](10) NULL,
	[Nyomonkovetesi] [nchar](10) NULL,
	[Konyvelesi] [numeric](14, 0) NULL,
	[SzamlazottAr] [decimal](10, 4) NULL,
	[Szamlaszam] [nchar](20) NULL,
	[Olepdf] [nchar](10) NULL,
	[Igenylo] [nchar](50) NULL,
	[TrackingNumber] [varchar](25) NULL,
	[Honnan] [int] NULL,
	[Hova] [int] NULL,
	[Plannedpickup] [date] NULL,
	[Actualpickup] [date] NULL,
	[Plannedarrival] [datetime] NULL,
	[Actualarrival] [datetime] NULL,
	[Comment] [varchar](50) NULL,
	[Forwarder] [int] NULL,
	[Service] [varchar](50) NULL,
	[Subject] [varchar](50) NULL,
	[ColorID] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Arrived] [bit] NULL,
	[QRCodeID] [varchar](50) NULL,
	[TrailerNumber] [varchar](25) NULL,
	[receptionID] [int] NULL,
	[szalitolevelCMR] [varchar](50) NULL,
	[kártyaszám] [varchar](50) NULL,
	[plombaszam] [varchar](50) NULL,
	[kiszallitas] [bit] NULL,
 CONSTRAINT [PK_SGHUOrder] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SGHUosztaly]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SGHUosztaly](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[osztaly] [varchar](40) NULL,
 CONSTRAINT [PK_SGHUosztaly] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SGPSP]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SGPSP](
	[ID] [int] NOT NULL,
	[ProjectDef] [varchar](55) NULL,
	[PSP] [varchar](21) NULL,
	[Description] [varchar](45) NULL,
 CONSTRAINT [PK_SGPSP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SwitchPageNames]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SwitchPageNames](
	[MenuId] [int] NOT NULL,
	[UserId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[szalitastipusa]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[szalitastipusa](
	[ID] [tinyint] NOT NULL,
	[szalitastipus] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[UserID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Amount] [numeric](16, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TPageNames]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TPageNames](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[ParentmenuId] [int] NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[Url] [varchar](100) NULL,
 CONSTRAINT [PK_TPageNames] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportes]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportes](
	[transporter_id] [nchar](100) NULL,
	[transporter_name] [nchar](100) NULL,
	[transporter_email] [nchar](100) NULL,
	[post_code] [nchar](100) NULL,
	[city] [nchar](100) NULL,
	[address] [nchar](100) NULL,
	[country] [nchar](100) NULL,
	[transporter_contact_name] [nchar](100) NULL,
	[transporter_contact_name3] [nchar](100) NULL,
	[transporter_contact_phone] [nchar](100) NULL,
	[transporter_contact2_name] [nchar](100) NULL,
	[transporter_contact3_phone] [nchar](100) NULL,
	[transporter_contact2_phone] [nchar](100) NULL,
	[transporter_fax] [nchar](100) NULL,
	[transporter_internet] [nchar](100) NULL,
	[transporter_tax] [nchar](100) NULL,
	[fovallalkozo] [bit] NULL,
	[ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivation]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivation](
	[UserId] [int] NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserActivation] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userdet]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userdet](
	[UserID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Amount] [numeric](16, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Email] [nvarchar](60) NULL,
	[CreatedDate] [smalldatetime] NULL,
	[LastLoginDate] [smalldatetime] NULL,
	[Signature] [text] NULL,
	[Nev] [varchar](50) NULL,
	[CegID] [int] NULL,
	[torolve] [bit] NULL,
	[PasswordChange] [bit] NOT NULL,
	[HomePage] [int] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        TOP (100) PERCENT dbo.SGHUOrder.OrderID, DATEPART(mm, dbo.SGHUOrder.Plannedarrival) AS 'PlannedArrivalMonth', DATEDIFF(mi, 
                         dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival) AS [Perc Eltérnés], dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival, dbo.LSP.Name
FROM            dbo.LSP RIGHT OUTER JOIN
                         dbo.SGHUOrder ON dbo.LSP.ID = dbo.SGHUOrder.Forwarder
WHERE        (NOT (dbo.LSP.Name IS NULL)) AND (NOT (dbo.SGHUOrder.Plannedarrival IS NULL))
ORDER BY dbo.LSP.Name
GO
/****** Object:  View [dbo].[VLSP]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VLSP]
AS
SELECT        TOP (100) PERCENT dbo.LSP.ID, dbo.LSP.Name, dbo.LSP.Email, dbo.LSP.PostCode, dbo.LSP.Adress, dbo.LSP.Fax, dbo.City.City, dbo.country.orszagkod, 
                         dbo.Contact.Name AS ContactName, dbo.Contact.Phone AS ContactPhone, dbo.LSP.CC
FROM            dbo.Contact INNER JOIN
                         dbo.LSPKapcsolo ON dbo.Contact.ID = dbo.LSPKapcsolo.ContactID RIGHT OUTER JOIN
                         dbo.LSP LEFT OUTER JOIN
                         dbo.country ON dbo.LSP.Country = dbo.country.id LEFT OUTER JOIN
                         dbo.City ON dbo.LSP.City = dbo.City.ID ON dbo.LSPKapcsolo.LSPID = dbo.LSP.ID
ORDER BY dbo.LSP.Name
GO
/****** Object:  View [dbo].[vpercentmonth]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vpercentmonth]
AS
SELECT        TOP (100) PERCENT dbo.SGHUOrder.OrderID, DATEPART(mm, dbo.SGHUOrder.Plannedarrival) AS 'PlannedarrivalMonth', DATEDIFF(mi, 
                         dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival) AS [Perc Eltérnés], dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival, dbo.LSP.Name
FROM            dbo.LSP RIGHT OUTER JOIN
                         dbo.SGHUOrder ON dbo.LSP.ID = dbo.SGHUOrder.Forwarder
WHERE        (NOT (dbo.LSP.Name IS NULL)) AND (NOT (dbo.SGHUOrder.Plannedarrival IS NULL))
ORDER BY dbo.LSP.Name
GO
/****** Object:  View [dbo].[VSGHUORDER]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VSGHUORDER]
AS
SELECT        TOP (100) PERCENT dbo.SGHUOrder.OrderID, dbo.SGHUOrder.Info, dbo.ProfitCenter.ProfitCenter, dbo.SGHUOrder.StartDate, dbo.SGHUOrder.Person, dbo.SGHUOrder.Computer, dbo.SGHUOrder.Nyomonkovetesi, 
                         dbo.SGHUOrder.SzamlazottAr, dbo.SGHUOrder.Konyvelesi, dbo.LSP.Name AS Forwarder, dbo.SGHUOrder.Olepdf, dbo.SGHUOrder.Service, dbo.SGHUOrder.Szamlaszam, dbo.SGHUOrder.Igenylo, 
                         dbo.SGHUOrder.TrackingNumber, dbo.SGHUOrder.Deleted, dbo.SGHUOrder.Plannedpickup, dbo.SGHUOrder.Actualpickup, dbo.SGHUOrder.Plannedarrival, dbo.SGHUOrder.Actualarrival, dbo.SGHUOrder.Comment, 
                         dbo.country.orszagkod AS Hova, country_1.orszagkod AS Honnan, dbo.Colors.Name, dbo.Colors.ColorHexa, dbo.LSP.ID, dbo.SGHUOrder.TrailerNumber, YEAR(dbo.SGHUOrder.StartDate) AS ev, 
                         dbo.Users.Username AS Reception
FROM            dbo.Users RIGHT OUTER JOIN
                         dbo.SGHUOrder ON dbo.Users.UserId = dbo.SGHUOrder.receptionID LEFT OUTER JOIN
                         dbo.country ON dbo.SGHUOrder.Hova = dbo.country.id LEFT OUTER JOIN
                         dbo.Colors ON dbo.SGHUOrder.ColorID = dbo.Colors.ID LEFT OUTER JOIN
                         dbo.ProfitCenter ON dbo.SGHUOrder.ProfitCenter = dbo.ProfitCenter.ID LEFT OUTER JOIN
                         dbo.country AS country_1 ON dbo.SGHUOrder.Honnan = country_1.id LEFT OUTER JOIN
                         dbo.LSP ON dbo.SGHUOrder.Forwarder = dbo.LSP.ID
GO
ALTER TABLE [dbo].[Milkruns] ADD  CONSTRAINT [DF_Milkruns_Active]  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[SGHUOrder] ADD  CONSTRAINT [DF_SGHUOrder_Color]  DEFAULT ((1)) FOR [ColorID]
GO
ALTER TABLE [dbo].[SGHUOrder] ADD  CONSTRAINT [DF_SGHUOrder_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[SGHUOrder] ADD  CONSTRAINT [DF_SGHUOrder_Arrived]  DEFAULT ((0)) FOR [Arrived]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_active]  DEFAULT ((0)) FOR [active]
GO
ALTER TABLE [dbo].[LSP]  WITH CHECK ADD  CONSTRAINT [FK_LSP_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[LSP] CHECK CONSTRAINT [FK_LSP_City]
GO
ALTER TABLE [dbo].[LSP]  WITH CHECK ADD  CONSTRAINT [FK_LSP_country] FOREIGN KEY([Country])
REFERENCES [dbo].[country] ([id])
GO
ALTER TABLE [dbo].[LSP] CHECK CONSTRAINT [FK_LSP_country]
GO
ALTER TABLE [dbo].[LSPKapcsolo]  WITH CHECK ADD  CONSTRAINT [FK_LSPKapcsolo_Contact] FOREIGN KEY([ContactID])
REFERENCES [dbo].[Contact] ([ID])
GO
ALTER TABLE [dbo].[LSPKapcsolo] CHECK CONSTRAINT [FK_LSPKapcsolo_Contact]
GO
ALTER TABLE [dbo].[PDFKapcsolo]  WITH CHECK ADD  CONSTRAINT [FK_PDFKapcsolo_PDFiles] FOREIGN KEY([PDFFilesID])
REFERENCES [dbo].[PDFiles] ([ID])
GO
ALTER TABLE [dbo].[PDFKapcsolo] CHECK CONSTRAINT [FK_PDFKapcsolo_PDFiles]
GO
ALTER TABLE [dbo].[PDFKapcsolo]  WITH CHECK ADD  CONSTRAINT [FK_PDFKapcsolo_SGHUOrder] FOREIGN KEY([OrderID])
REFERENCES [dbo].[SGHUOrder] ([OrderID])
GO
ALTER TABLE [dbo].[PDFKapcsolo] CHECK CONSTRAINT [FK_PDFKapcsolo_SGHUOrder]
GO
/****** Object:  StoredProcedure [dbo].[HelloWorld]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|7|0|C:\Users\za85mc\AppData\Local\Temp\2\~vsFFCD.sql
-- Batch submitted through debugger: SQLQuery3.sql|7|0|C:\Users\za85mc\AppData\Local\Temp\2\~vsC9C7.sql
CREATE PROCEDURE [dbo].[HelloWorld] AS
DECLARE @a AS INT;
PRINT 'Hello, world!'
RETURN (0);
GO
/****** Object:  StoredProcedure [dbo].[Insert_User]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Insert_User]
	@Username NVARCHAR(20),
	@Password NVARCHAR(20),
	@Email NVARCHAR(60),
	@CegID INT,
	@Emailellenorzes bit,
	@PasswordChange bit
	

AS
BEGIN
	DECLARE @Kell  as bit =0;


	SET NOCOUNT ON;

	IF (@Emailellenorzes=1)
	BEGIN 
			IF EXISTS(SELECT UserId FROM dbo.Users WHERE (torolve = 0) AND (Email = @Email)) 
			BEGIN
				SET	@Kell = 0;
			END
			else
			begin
				SET	@Kell = 1;
			end

	
	END
	else
	begin
			IF EXISTS(SELECT UserId FROM dbo.Users WHERE (Username = @Username) AND (torolve = 0) ) 
			BEGIN
				SET	@Kell = 0;
			END
			else
			begin
				SET	@Kell = 1;
			end
		
	
	end





	IF (@Kell = 1)
		BEGIN
		INSERT INTO [Users]
			   ([Username]
			   ,[Password]
			   ,[Email]
			   ,[CreatedDate]
			   ,[CegID]
			   ,[PasswordChange]
			   )
		VALUES
			   (@Username
			   ,@Password
			   ,@Email
			   ,GETDATE()
			   ,@CegID
			   ,@PasswordChange)
		
		SELECT SCOPE_IDENTITY() -- UserId			   
     END
	 else
		begin
		    SELECT -1 -- Username exists.

		end
END
GO
/****** Object:  StoredProcedure [dbo].[Procedure]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Procedure]
	@param1 int = 0,
	@param2 int
AS
	SELECT @param1, @param2
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[Validate_User]    Script Date: 2018. 04. 24. 16:52:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Validate_User]
	@Username NVARCHAR(20),
	@Password NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @UserId INT, @LastLoginDate DATETIME
	
	SELECT @UserId = UserId, @LastLoginDate = LastLoginDate 
	FROM Users WHERE Username = @Username AND [Password] = @Password AND ([torolve] is null OR torolve = 0)
	
	IF @UserId IS NOT NULL
	BEGIN
		IF NOT EXISTS(SELECT UserId FROM UserActivation WHERE UserId = @UserId)
		BEGIN
			UPDATE Users
			SET LastLoginDate =  GETDATE()
			WHERE UserId = @UserId
			SELECT @UserId [UserId] -- User Valid
		END
		ELSE
		BEGIN
			SELECT -2 -- User not activated.
		END
	END
	ELSE
	BEGIN
		SELECT -1 -- User invalid.
	END
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LSP"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SGHUOrder"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[26] 2[9] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Contact"
            Begin Extent = 
               Top = 66
               Left = 47
               Bottom = 257
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LSPKapcsolo"
            Begin Extent = 
               Top = 0
               Left = 255
               Bottom = 121
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LSP"
            Begin Extent = 
               Top = 0
               Left = 654
               Bottom = 308
               Right = 824
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "country"
            Begin Extent = 
               Top = 207
               Left = 1219
               Bottom = 319
               Right = 1389
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City"
            Begin Extent = 
               Top = 40
               Left = 991
               Bottom = 135
               Right = 1161
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 27
         Width = 284
         Width = 3075
         Width = 4005
         Width = 2610
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VLSP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 6450
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VLSP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VLSP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[24] 4[15] 2[32] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "LSP"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 299
               Right = 240
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SGHUOrder"
            Begin Extent = 
               Top = 0
               Left = 678
               Bottom = 129
               Right = 857
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vpercentmonth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vpercentmonth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[32] 4[21] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "country"
            Begin Extent = 
               Top = 201
               Left = 831
               Bottom = 313
               Right = 1001
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SGHUOrder"
            Begin Extent = 
               Top = 0
               Left = 9
               Bottom = 276
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "Colors"
            Begin Extent = 
               Top = 6
               Left = 671
               Bottom = 118
               Right = 841
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ProfitCenter"
            Begin Extent = 
               Top = 13
               Left = 246
               Bottom = 125
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "country_1"
            Begin Extent = 
               Top = 6
               Left = 879
               Bottom = 118
               Right = 1049
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LSP"
            Begin Extent = 
               Top = 161
               Left = 464
               Bottom = 290
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Users"
            Begin Extent = 
               Top = 102
               Left = 1087
               Bottom = 232
               Right = 1267
            End
            DisplayFlags' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VSGHUORDER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 30
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 4905
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VSGHUORDER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VSGHUORDER'

GO
