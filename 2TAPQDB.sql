USE [2TAPQ_DB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID_acc] [varchar](10) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Email] [varchar](200) NULL,
	[Phone] [varchar](13) NULL,
	[Birthday] [datetime] NULL,
	[Address] [nvarchar](300) NOT NULL,
	[Role] [int] NOT NULL,
	[ID_role_Staff] [varchar](10) NULL,
	[ID_ward] [varchar](10) NOT NULL,
	[Date_join] [datetime] NOT NULL,
	[Image] [text] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_acc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cooperative_Room]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cooperative_Room](
	[ID_room] [varchar](10) NOT NULL,
	[ID_coo] [varchar](10) NOT NULL,
	[Join_code] [varchar](10) NOT NULL,
	[Pond_area] [float] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_room] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detail_Receipts_payments]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detail_Receipts_payments](
	[ID_detail_receipts_payments] [varchar](10) NOT NULL,
	[ID_Invoice] [varchar](10) NOT NULL,
	[NameStaff] [nvarchar](80) NULL,
	[Quanlity] [float] NULL,
	[Price] [decimal](18, 0) NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_detail_receipts_payments] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[District]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District](
	[ID_district] [varchar](10) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[type] [nvarchar](80) NOT NULL,
	[ID_province] [varchar](10) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_district] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Fish_category]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Fish_category](
	[ID_fcategory] [varchar](10) NOT NULL,
	[Category_name] [nvarchar](100) NOT NULL,
	[Image] [text] NULL,
	[Harvest_time] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Status] [int] NULL,
	[PH] [float] NULL,
	[Temperature] [float] NULL,
	[Water_level] [float] NULL,
	[Sanility] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_fcategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[History_store_house]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[History_store_house](
	[ID_history_store_house] [varchar](10) NOT NULL,
	[ID_staff] [varchar](10) NOT NULL,
	[ID_s_house] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Quanlity] [float] NOT NULL,
	[ID_item_category] [varchar](10) NOT NULL,
	[Note] [nvarchar](200) NULL,
	[Date] [datetime] NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_history_store_house] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item_category]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item_category](
	[ID_item_category] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_item_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item_store_house]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item_store_house](
	[ID_item_store_house] [varchar](10) NOT NULL,
	[ID_s_house] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Quanlity] [float] NOT NULL,
	[ID_item_category] [varchar](10) NOT NULL,
	[Note] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_item_store_house] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[ID_member] [varchar](10) NOT NULL,
	[ID_user] [varchar](10) NOT NULL,
	[ID_room] [varchar](10) NOT NULL,
	[date] [datetime] NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_member] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Notify]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Notify](
	[ID_Notify] [varchar](10) NOT NULL,
	[ID_acc] [varchar](10) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[Status] [int] NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Notify] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pond]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pond](
	[ID_pond] [varchar](10) NOT NULL,
	[ID_acc] [varchar](10) NOT NULL,
	[ID_fcategory] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Pond_area] [float] NULL,
	[Image] [text] NULL,
	[Session] [varchar](100) NULL,
	[Quantity_of_fingerlings] [float] NULL,
	[Quanlity_of_end] [float] NULL,
	[Start_day] [datetime] NULL,
	[End_day] [datetime] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_pond] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pond_diary]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pond_diary](
	[ID_diary] [varchar](10) NOT NULL,
	[ID_pond] [varchar](10) NOT NULL,
	[Sanility] [float] NULL,
	[PH] [float] NULL,
	[Temperature] [float] NULL,
	[Water_level] [float] NULL,
	[Fish_status] [varchar](100) NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_diary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Province]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Province](
	[ID_province] [varchar](10) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[type] [nvarchar](80) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_province] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Quantity_House]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Quantity_House](
	[ID_quantity] [varchar](10) NOT NULL,
	[ID_acc] [varchar](10) NOT NULL,
	[Quanlity] [float] NOT NULL,
	[Added_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_quantity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receipts_payments]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receipts_payments](
	[ID_Invoice] [varchar](10) NOT NULL,
	[ID_user] [varchar](10) NOT NULL,
	[Total] [decimal](18, 0) NULL,
	[Added_date] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Invoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[ID_role] [varchar](10) NOT NULL,
	[type] [nvarchar](100) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role_Staff]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role_Staff](
	[ID_role_Staff] [varchar](10) NOT NULL,
	[ID_acc] [varchar](10) NOT NULL,
	[ID_role] [varchar](10) NOT NULL,
	[salary] [money] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_role_Staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Store_house]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Store_house](
	[ID_s_house] [varchar](10) NOT NULL,
	[ID_user] [varchar](10) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_s_house] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 1/2/2023 8:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ward](
	[ID_ward] [varchar](10) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[type] [nvarchar](80) NOT NULL,
	[ID_district] [varchar](10) NOT NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role_Staff] FOREIGN KEY([ID_role_Staff])
REFERENCES [dbo].[Role_Staff] ([ID_role_Staff])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role_Staff]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Ward] FOREIGN KEY([ID_ward])
REFERENCES [dbo].[Ward] ([ID_ward])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Ward]
GO
ALTER TABLE [dbo].[Cooperative_Room]  WITH CHECK ADD  CONSTRAINT [FK_Cooperative_Room_Account] FOREIGN KEY([ID_coo])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Cooperative_Room] CHECK CONSTRAINT [FK_Cooperative_Room_Account]
GO
ALTER TABLE [dbo].[Detail_Receipts_payments]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Receipts_payments_Receipts_payments] FOREIGN KEY([ID_Invoice])
REFERENCES [dbo].[Receipts_payments] ([ID_Invoice])
GO
ALTER TABLE [dbo].[Detail_Receipts_payments] CHECK CONSTRAINT [FK_Detail_Receipts_payments_Receipts_payments]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_District_Province] FOREIGN KEY([ID_province])
REFERENCES [dbo].[Province] ([ID_province])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_District_Province]
GO
ALTER TABLE [dbo].[History_store_house]  WITH CHECK ADD  CONSTRAINT [FK_History_store_house_Account] FOREIGN KEY([ID_staff])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[History_store_house] CHECK CONSTRAINT [FK_History_store_house_Account]
GO
ALTER TABLE [dbo].[History_store_house]  WITH CHECK ADD  CONSTRAINT [FK_History_store_house_Item_category] FOREIGN KEY([ID_item_category])
REFERENCES [dbo].[Item_category] ([ID_item_category])
GO
ALTER TABLE [dbo].[History_store_house] CHECK CONSTRAINT [FK_History_store_house_Item_category]
GO
ALTER TABLE [dbo].[History_store_house]  WITH CHECK ADD  CONSTRAINT [FK_History_store_house_Store_house] FOREIGN KEY([ID_s_house])
REFERENCES [dbo].[Store_house] ([ID_s_house])
GO
ALTER TABLE [dbo].[History_store_house] CHECK CONSTRAINT [FK_History_store_house_Store_house]
GO
ALTER TABLE [dbo].[Item_store_house]  WITH CHECK ADD  CONSTRAINT [FK_Item_store_house_Item_category] FOREIGN KEY([ID_item_category])
REFERENCES [dbo].[Item_category] ([ID_item_category])
GO
ALTER TABLE [dbo].[Item_store_house] CHECK CONSTRAINT [FK_Item_store_house_Item_category]
GO
ALTER TABLE [dbo].[Item_store_house]  WITH CHECK ADD  CONSTRAINT [FK_Item_store_house_Store_house] FOREIGN KEY([ID_s_house])
REFERENCES [dbo].[Store_house] ([ID_s_house])
GO
ALTER TABLE [dbo].[Item_store_house] CHECK CONSTRAINT [FK_Item_store_house_Store_house]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Account] FOREIGN KEY([ID_user])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Account]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Cooperative_Room] FOREIGN KEY([ID_room])
REFERENCES [dbo].[Cooperative_Room] ([ID_room])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Cooperative_Room]
GO
ALTER TABLE [dbo].[Notify]  WITH CHECK ADD  CONSTRAINT [FK_Notify_Account] FOREIGN KEY([ID_acc])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Notify] CHECK CONSTRAINT [FK_Notify_Account]
GO
ALTER TABLE [dbo].[Pond]  WITH CHECK ADD  CONSTRAINT [FK_Pond_Account] FOREIGN KEY([ID_acc])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Pond] CHECK CONSTRAINT [FK_Pond_Account]
GO
ALTER TABLE [dbo].[Pond]  WITH CHECK ADD  CONSTRAINT [FK_Pond_Fish_category] FOREIGN KEY([ID_fcategory])
REFERENCES [dbo].[Fish_category] ([ID_fcategory])
GO
ALTER TABLE [dbo].[Pond] CHECK CONSTRAINT [FK_Pond_Fish_category]
GO
ALTER TABLE [dbo].[Pond_diary]  WITH CHECK ADD  CONSTRAINT [FK_Pond_diary_Pond] FOREIGN KEY([ID_pond])
REFERENCES [dbo].[Pond] ([ID_pond])
GO
ALTER TABLE [dbo].[Pond_diary] CHECK CONSTRAINT [FK_Pond_diary_Pond]
GO
ALTER TABLE [dbo].[Quantity_House]  WITH CHECK ADD  CONSTRAINT [FK_Quantity_House_Account] FOREIGN KEY([ID_acc])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Quantity_House] CHECK CONSTRAINT [FK_Quantity_House_Account]
GO
ALTER TABLE [dbo].[Receipts_payments]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_payments_Account] FOREIGN KEY([ID_user])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Receipts_payments] CHECK CONSTRAINT [FK_Receipts_payments_Account]
GO
ALTER TABLE [dbo].[Role_Staff]  WITH CHECK ADD  CONSTRAINT [FK_Role_Staff_Role] FOREIGN KEY([ID_role])
REFERENCES [dbo].[Role] ([ID_role])
GO
ALTER TABLE [dbo].[Role_Staff] CHECK CONSTRAINT [FK_Role_Staff_Role]
GO
ALTER TABLE [dbo].[Store_house]  WITH CHECK ADD  CONSTRAINT [FK_Store_house_Account] FOREIGN KEY([ID_user])
REFERENCES [dbo].[Account] ([ID_acc])
GO
ALTER TABLE [dbo].[Store_house] CHECK CONSTRAINT [FK_Store_house_Account]
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD  CONSTRAINT [FK_Ward_District] FOREIGN KEY([ID_district])
REFERENCES [dbo].[District] ([ID_district])
GO
ALTER TABLE [dbo].[Ward] CHECK CONSTRAINT [FK_Ward_District]
GO
