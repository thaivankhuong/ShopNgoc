USE [master]
GO
/****** Object:  Database [DBMissingPiece]    Script Date: 06/29/2020 2:55:45 PM ******/
CREATE DATABASE [DBMissingPiece]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBMissingPiece', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBMissingPiece.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBMissingPiece_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DBMissingPiece_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBMissingPiece].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBMissingPiece] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBMissingPiece] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBMissingPiece] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBMissingPiece] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBMissingPiece] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBMissingPiece] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBMissingPiece] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBMissingPiece] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBMissingPiece] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBMissingPiece] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBMissingPiece] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBMissingPiece] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBMissingPiece] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBMissingPiece] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBMissingPiece] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBMissingPiece] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBMissingPiece] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBMissingPiece] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBMissingPiece] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBMissingPiece] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBMissingPiece] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBMissingPiece] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBMissingPiece] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBMissingPiece] SET  MULTI_USER 
GO
ALTER DATABASE [DBMissingPiece] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBMissingPiece] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBMissingPiece] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBMissingPiece] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBMissingPiece', N'ON'
GO
USE [DBMissingPiece]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[Position] [nvarchar](150) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK__Account__536C85E57F60ED59] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](300) NULL,
	[Avatar] [nvarchar](255) NULL,
	[Thumb] [nvarchar](255) NULL,
	[Content] [ntext] NULL,
	[Keyword] [nvarchar](255) NULL,
	[Status] [int] NULL,
	[Position] [int] NULL,
	[ViewTime] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[SeoUrl] [nvarchar](250) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](550) NULL,
	[DescriptionLong] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Mobi] [nvarchar](250) NULL,
	[Map] [nvarchar](2500) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collection]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collection](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Avatar] [nvarchar](500) NULL,
	[Deripstion] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[SeoUrl] [nvarchar](500) NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](255) NULL,
	[Content] [nvarchar](2000) NULL,
	[Status] [int] NULL,
	[SendTime] [datetime] NULL,
	[ApproveTime] [datetime] NULL,
	[ApproveBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Introduce]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Introduce](
	[IntroduceID] [int] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](255) NULL,
	[Thumb] [nvarchar](255) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](300) NULL,
	[Content] [ntext] NULL,
	[Status] [int] NULL,
	[Position] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ContentSort] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IntroduceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Mobi] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[Content] [nvarchar](2500) NULL,
	[ProductName] [nvarchar](250) NULL,
	[SendTime] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](800) NULL,
	[Avatar] [nvarchar](255) NULL,
	[Thumb] [nvarchar](255) NULL,
	[ListImage] [nvarchar](1000) NULL,
	[Content] [ntext] NULL,
	[Keyword] [nvarchar](255) NULL,
	[Price] [nvarchar](100) NULL,
	[PriceSale] [nvarchar](100) NULL,
	[MadeIn] [nvarchar](500) NULL,
	[ListBranch] [nvarchar](100) NULL,
	[Status] [bit] NULL,
	[Position] [int] NULL,
	[ViewTime] [int] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[SeoUrl] [nvarchar](250) NULL,
	[MetaTitle] [nvarchar](250) NULL,
	[MetaDescription] [nvarchar](550) NULL,
	[Tags] [nvarchar](4000) NULL,
	[ProductSize] [nvarchar](max) NULL,
	[ProductColor] [nvarchar](max) NULL,
	[CollectionId] [int] NULL,
 CONSTRAINT [PK__Product__B40CC6ED1273C1CD] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Status] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[SeoUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColor]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductId] [int] NULL,
	[SizeId] [int] NULL,
	[ColorId] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reason]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reason](
	[ReasonID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [ntext] NULL,
	[ProductID] [int] NULL,
 CONSTRAINT [PK_Reason] PRIMARY KEY CLUSTERED 
(
	[ReasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeoMeta]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeoMeta](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](200) NULL,
	[KeyWord] [nvarchar](2000) NULL,
	[Avatar] [nvarchar](250) NULL,
 CONSTRAINT [PK_SeoMeta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 06/29/2020 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[SliderID] [int] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](250) NULL,
	[Status] [bit] NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[SliderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Username], [Password], [FullName], [Position], [Status]) VALUES (N'admin', N'13F8798FDD79E20F2BC35C4119BA6D18', N'Dev', N'Dev', 1)
INSERT [dbo].[Account] ([Username], [Password], [FullName], [Position], [Status]) VALUES (N'chinhanh', N'E8F83760B6519E0B32011A12EF508BAD', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ArticleID], [Title], [Description], [Avatar], [Thumb], [Content], [Keyword], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl], [MetaTitle], [MetaDescription], [DescriptionLong]) VALUES (39, N'View Blog 3', NULL, N'/Areas/Admin/Content/Fileuploads/images/TMP_FLIGHTOFFANCY-1465_grande6d0e.jpg', N'/Areas/Admin/Content/FileUploads/_thumbs/Images/TMP_FLIGHTOFFANCY-1465_grande6d0e.jpg', N'<div class="blog-excerpt" style="box-sizing: border-box; margin: 8px 0px 15px; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px;">
	<span class="blog-date" style="box-sizing: border-box; position: relative; color: rgb(28, 28, 28); text-transform: uppercase; font-size: 12px; padding: 0px 0px 8px;">&nbsp;<span style="box-sizing: border-box;">JUNE 05, 2020</span></span></div>
<div class="article-name" style="box-sizing: border-box; font-size: 24px; color: rgb(28, 28, 28); text-transform: uppercase; font-weight: 600; margin: 0px 0px 13px; font-family: Montserrat;">
	GIVING BACK TO THE MIGRANT WORKERS</div>
<div class="rte" itemprop="articleBody" style="box-sizing: border-box; color: rgb(28, 28, 28); font-size: 14px; line-height: 21px; margin: 0px 0px 22px; font-family: Montserrat;">
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		<span style="box-sizing: border-box;">With most people&rsquo;s lives being completely turned upside down&nbsp;and businesses being affected, Covid-19 has&nbsp;not stopped our passion to give back. Instead of focusing on the negative, we&#39;ve decided to put our resources towards helping the very people who have built&nbsp;our city and homes.&nbsp;</span></p>
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		On Easter Sunday, we launched&nbsp;3 of our most joyous and cheerful pieces from our&nbsp;Moments Collection and pledged up&nbsp;to 50% of the&nbsp;proceeds from the sale of that launch towards raising funds to provide food for&nbsp;the quarantined migrant workers. Banding together with a like-minded community, we worked with 20 caterers and a team of up to 10 private hire drivers to deliver food to ~500 migrant workers. Each day we managed to provide two square meals (Indian cuisine) with an addition of 2 &ndash; 3 pieces of fruit.</p>
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		&nbsp;</p>
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		<span style="box-sizing: border-box;">Together with several families and our kids, we also made&nbsp;encouragement cards to accompany the meals distributed to the workers. We were so glad&nbsp;to see the smiles of gratitude from the workers as they waved their cards in thanks to all who helped make them.</span></p>
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		&nbsp;</p>
	<p style="box-sizing: border-box; margin: 0px 0px 15px;">
		We could not have done this without the generous support and encouragement of our TMP community, so thank you for helping us to&nbsp;give back and show love in a&nbsp;time of need</p>
</div>
<p>
	&nbsp;</p>
', NULL, 1, 12, 0, CAST(N'2020-06-12T21:41:13.907' AS DateTime), CAST(N'2020-06-27T14:30:02.900' AS DateTime), N'admin', N'admin', N'view-blog-3.html', NULL, NULL, N'Our CNY2020 collection invites the wearer to leave behind the mundane, and let their soul take flight to a paradise of light, colour, imagination and movement.   Botanical and bird prints and painterly patterns meet a springtime palette of blues, greens, and fuchsia, pink and coral hues. Expect modern cheongsams with a twist, as well as the feminine textures and flattering cuts that The Missing Piece is known for, as well. For the first time, this collection will also introduce a number of ingenious new designs, with convertible details that allow the wearer to change their look effortlessly. These clever convertible classics do double or even triple duty. Necklines, skirt lengths, draping and fit become customisable thanks to well-placed fastenings. Dresses effortlessly become casual separates to take you from everyday day life and on that Flight of Fancy whenever you choose. ')
INSERT [dbo].[Article] ([ArticleID], [Title], [Description], [Avatar], [Thumb], [Content], [Keyword], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl], [MetaTitle], [MetaDescription], [DescriptionLong]) VALUES (40, N'view blog 2', N'view blog 2', N'/Areas/Admin/Content/Fileuploads/images/TMP_FLIGHTOFFANCY-1465_grande6d0e.jpg', N'/Areas/Admin/Content/FileUploads/_thumbs/Images/TMP_FLIGHTOFFANCY-1465_grande6d0e.jpg', N'<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<img alt="" height="341" src="https://cdn.shopify.com/s/files/1/1187/0028/files/White_HOG_74bd5273-5577-4b2a-b660-63f2c11fbb05_large.jpeg?v=1583163746" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" width="271" /></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/TMP_FLIGHTOFFANCY-2988_large.jpg?v=1583371745" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /></p>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">The Missing Piece teamed up with 9 other women-led businesses to create a campaign featuring 10 gold-themed collections from November 2019 till Christmas Day 2019. With the aim to raise a minimum of $10,000 for the campaign, we&nbsp;have rallied together with their communities and raised $13,692&nbsp;influencing hundreds of others to participate in the spirit of giving.</strong><br style="box-sizing: border-box;" />
	&nbsp;</div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/B51E787E-E4F1-4630-8ABA-6AD4EB5D2CF6_grande.jpg?v=1583164372" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto;" /></div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	&nbsp;</div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">With the theme in mind, we designed&nbsp;<a href="https://iwantthemissingpiece.com/collections/heart-of-gold" style="box-sizing: border-box; color: rgb(116, 116, 116); transition: all 150ms ease-in-out 0s; text-decoration-line: none; background: transparent;" title="Heart of Gold - Operation Hope">7 exquisite pieces</a>&nbsp;that encompasses The Missing Piece women who are multifaceted yet elegantly beautiful in their own individual ways.</strong><br style="box-sizing: border-box;" />
	&nbsp;</div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">We pledged 10% of our sales in December from this capsule to go towards supporting Operation Hope ($3,692). The total funds went towards rebuilding homes for villagers affected by the 2015 Nepal earthquake, and building a bigger safe haven for abandoned children and orphans with provision of education, healthcare and life skills in Pokhara, Nepal. To Crib Society and the brands that partnered with us in this initiative, thank you for championing such a great cause and making a difference!&nbsp;</strong></div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">@ans.ein<br style="box-sizing: border-box;" />
	@badtandco<br style="box-sizing: border-box;" />
	@chocgems<br style="box-sizing: border-box;" />
	@in_trigue</strong></div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">@jeannierichardjewelry</strong></div>
<div style="box-sizing: border-box; margin-bottom: 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-align: center;">
	<strong style="box-sizing: border-box;">@jokilda<br style="box-sizing: border-box;" />
	@ksisters.sg<br style="box-sizing: border-box;" />
	@nidashay<br style="box-sizing: border-box;" />
	@triathelabel</strong></div>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<img alt="" height="365" src="https://cdn.shopify.com/s/files/1/1187/0028/files/Heart_of_Gold_2_large.jpeg?v=1583164249" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px auto; display: block;" width="283" /></p>
', NULL, 1, NULL, 4, CAST(N'2020-06-24T17:07:50.023' AS DateTime), CAST(N'2020-06-27T14:29:49.407' AS DateTime), N'admin', N'admin', N'view-blog-2.html', NULL, NULL, N'Our CNY2020 collection invites the wearer to leave behind the mundane, and let their soul take flight to a paradise of light, colour, imagination and movement.   Botanical and bird prints and painterly patterns meet a springtime palette of blues, greens, and fuchsia, pink and coral hues. Expect modern cheongsams with a twist, as well as the feminine textures and flattering cuts that The Missing Piece is known for, as well. For the first time, this collection will also introduce a number of ingenious new designs, with convertible details that allow the wearer to change their look effortlessly. These clever convertible classics do double or even triple duty. Necklines, skirt lengths, draping and fit become customisable thanks to well-placed fastenings. Dresses effortlessly become casual separates to take you from everyday day life and on that Flight of Fancy whenever you choose. ')
INSERT [dbo].[Article] ([ArticleID], [Title], [Description], [Avatar], [Thumb], [Content], [Keyword], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl], [MetaTitle], [MetaDescription], [DescriptionLong]) VALUES (41, N'view blog 1', N'Eden', N'/Areas/Admin/Content/Fileuploads/images/DSCF9373_grande7184.jpg', N'/Areas/Admin/Content/FileUploads/_thumbs/Images/DSCF9373_grande7184.jpg', N'<p style="margin-left: 40px;">
	<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">With most people&rsquo;s lives being completely turned upside down&nbsp;and businesses being affected, Covid-19 has&nbsp;not stopped our passion to give back. Instead of focusing on the negative, we&#39;ve decided to put our resources towards helping the very people who have built&nbsp;our city and homes.&nbsp;</span></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	On Easter Sunday, we launched&nbsp;3 of our most joyous and cheerful pieces from our&nbsp;Moments Collection and pledged up&nbsp;to 50% of the&nbsp;proceeds from the sale of that launch towards raising funds to provide food for&nbsp;the quarantined migrant workers. Banding together with a like-minded community, we worked with 20 caterers and a team of up to 10 private hire drivers to deliver food to ~500 migrant workers. Each day we managed to provide two square meals (Indian cuisine) with an addition of 2 &ndash; 3 pieces of fruit.</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/IMG_5772_large.JPG?v=1591372341" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<em style="box-sizing: border-box;"><img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/IMG_5774_large.JPG?v=1591372325" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /></em></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<span style="box-sizing: border-box;">Together with several families and our kids, we also made&nbsp;encouragement cards to accompany the meals distributed to the workers. We were so glad&nbsp;to see the smiles of gratitude from the workers as they waved their cards in thanks to all who helped make them.</span></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;&nbsp;<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/IMG_5775_large.JPG?v=1591372347" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/IMG_5776_large.JPG?v=1591372332" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	<img alt="" src="https://cdn.shopify.com/s/files/1/1187/0028/files/Cards_large.jpeg?v=1588092667" style="box-sizing: border-box; border: 0px none; max-width: 100%; height: auto; margin: 0px;" /><em style="box-sizing: border-box;">﻿</em></p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px;">
	We could not have done this without the generous support and encouragement of our TMP community, so thank you for helping us to&nbsp;give back and show love in a&nbsp;time of need.</p>
', NULL, 1, 3, 7, CAST(N'2020-06-24T17:10:49.407' AS DateTime), CAST(N'2020-06-27T14:29:34.390' AS DateTime), N'admin', N'admin', N'view-blog-1.html', NULL, NULL, N'With our new capsule collection, we are heading back to Eden. Back to a time where things were simple, free and unhindered, and yet perfectly beautiful. Inspired by dancing light through leafy canopies, the whisper of wind through rustling grass, and organic textures and colours, we''ve created easy pieces with pretty botanical details and ladylike hemlines. With sustainable textured fabrics as our canvas and playing with customised embroidery and lace, we''ve tried to paint a picture of the Garden of Eden in our mind''s eye; a picture of harmony, natural beauty and simplicity.  In flowy silks, elegant lace and light fabrics, these pieces aim to inspire movement. We imagine you lightly moving through dreamy forests, lush foliage and beautiful flowering trees in them, creating poetry in the everyday moments of life.')
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([BranchID], [Title], [Address], [Mobi], [Map], [Status]) VALUES (4, N'Mk Fashion', N'219 Đề Thám, P.Phạm Ngũ Lão, Q.1', N'0983753924', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.566649839754!2d106.69143031514221!3d10.767842892327398!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3dff331a2b%3A0x892766a79a6bb635!2zMjE5IMSQ4buBIFRow6FtLCBQaMaw4budbmcgUGjhuqFtIE5nxakgTMOjbywgUXXhuq1uIDEsIEjhu5MgQ2jDrSBNaW5oLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1593249985052!5m2!1svi!2s', 1)
SET IDENTITY_INSERT [dbo].[Branch] OFF
SET IDENTITY_INSERT [dbo].[Collection] ON 

INSERT [dbo].[Collection] ([Id], [Title], [Avatar], [Deripstion], [CreateDate], [SeoUrl]) VALUES (1, N'Bộ sưu tập đông xuân', N'/Areas/Admin/Content/Fileuploads/images/TMP_FLIGHTOFFANCY-1465_grande6d0e.jpg', N'With our new capsule collection, we are heading back to Eden. Back to a time where things were simple, free and unhindered, and yet perfectly beautiful. Inspired by dancing light through leafy canopies, the whisper of wind through rustling grass, and organic textures and colours, we''ve created easy pieces with pretty botanical details and ladylike hemlines. With sustainable textured fabrics as our canvas and playing with customised embroidery and lace, we''ve tried to paint a picture of the Garden of Eden in our mind''s eye; a picture of harmony, natural beauty and simplicity. In flowy silks, elegant lace and light fabrics, these pieces aim to inspire movement. We imagine you lightly moving through dreamy forests, lush foliage and beautiful flowering trees in them, creating poetry in the everyday moments of life.', CAST(N'2020-06-27T14:35:54.877' AS DateTime), N'bo-suu-tap-dong-xuan.html')
INSERT [dbo].[Collection] ([Id], [Title], [Avatar], [Deripstion], [CreateDate], [SeoUrl]) VALUES (2, N'Bộ sưu tập xuân hè', N'/Areas/Admin/Content/Fileuploads/images/DSCF9373_grande7184.jpg', N'Our CNY2020 collection invites the wearer to leave behind the mundane, and let their soul take flight to a paradise of light, colour, imagination and movement. Botanical and bird prints and painterly patterns meet a springtime palette of blues, greens, and fuchsia, pink and coral hues. Expect modern cheongsams with a twist, as well as the feminine textures and flattering cuts that The Missing Piece is known for, as well. For the first time, this collection will also introduce a number of ingenious new designs, with convertible details that allow the wearer to change their look effortlessly. These clever convertible classics do double or even triple duty. Necklines, skirt lengths, draping and fit become customisable thanks to well-placed fastenings. Dresses effortlessly become casual separates to take you from everyday day life and on that Flight of Fancy whenever you choose', CAST(N'2020-06-27T14:36:10.640' AS DateTime), N'bo-suu-tap-xuan-he.html')
SET IDENTITY_INSERT [dbo].[Collection] OFF
SET IDENTITY_INSERT [dbo].[Introduce] ON 

INSERT [dbo].[Introduce] ([IntroduceID], [Avatar], [Thumb], [Title], [Description], [Content], [Status], [Position], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [ContentSort]) VALUES (1, NULL, NULL, N'title 1 ', NULL, N'<p style="margin: 0px 0px 10px; padding: 0px; border: 0px; font-variant-numeric: inherit; font-stretch: inherit; font-size: 14px; line-height: 22px; font-family: arial, Verdana, tahoma; vertical-align: baseline; color: rgb(102, 102, 102); text-align: justify;">
	<span style="color: rgb(0, 0, 0); font-family: Montserrat; text-align: center; text-transform: uppercase;">THE MISSING PIECE IS A SMALL HOMEGROWN SINGAPORE BUSINESS, WHICH MAKES STYLISH, FLATTERING AND COMFORTABLE CLOTHES FOR REAL WOMEN AND THEIR FAMILIES. WE SPECIALISE IN MODERN CHEONGSAMS WITH THE ADDITIONAL BONUS OF COORDINATED OPTIONS FOR FAMILIES.</span></p>
', 1, 1, CAST(N'2016-10-15T09:03:39.670' AS DateTime), CAST(N'2020-06-24T13:48:23.357' AS DateTime), N'admin', N'admin', NULL)
INSERT [dbo].[Introduce] ([IntroduceID], [Avatar], [Thumb], [Title], [Description], [Content], [Status], [Position], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [ContentSort]) VALUES (2, N'', N'', N'WHAT SETS US APART', N'WHAT SETS US APART', N'<p>
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">Here at The Missing Piece, pairing timeless, flattering silhouettes with comfortable fabrics, is our primary objective.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">As such, all our pieces are in soft and breathable fabrics, which are great for our balmy climate. Whether it be formal or casual, we pride ourselves in ensuring that our lady is always effortlessly stylish, chic and comfortable.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">We make clothes that not only make you feel and look good, but are also practical for the woman on the go. Our handpicked fabrics are mainly imported from South East Asia and the US. Each piece is lovingly handmade and paired with handpicked details to ensure customer satisfaction.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">Each collection is limited edition to ensure exclusivity and quality. We largely do not mass produce and work on a made-to-order basis. Each piece is lovingly tailored and usually gets to you within 2-4 weeks.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">We offer tasteful and comfortable clothing for women, kids and even men, so the whole family can now find their missing pieces here!</span></p>
', 1, 2, CAST(N'2020-06-24T13:25:27.643' AS DateTime), CAST(N'2020-06-24T13:25:27.643' AS DateTime), N'admin', N'admin', N'Here at The Missing Piece, pairing timeless, flattering silhouettes with comfortable fabrics, is our primary objective.

As such, all our pieces are in soft and breathable fabrics, which are great for our balmy climate. Whether it be formal or casual, we pride ourselves in ensuring that our lady is always effortlessly stylish, chic and comfortable.

We make clothes that not only make you feel and look good, but are also practical for the woman on the go. Our handpicked fabrics are mainly imported from South East Asia and the US. Each piece is lovingly handmade and paired with handpicked details to ensure customer satisfaction.

Each collection is limited edition to ensure exclusivity and quality. We largely do not mass produce and work on a made-to-order basis. Each piece is lovingly tailored and usually gets to you within 2-4 weeks.

We offer tasteful and comfortable clothing for women, kids and even men, so the whole family can now find their missing pieces here!')
INSERT [dbo].[Introduce] ([IntroduceID], [Avatar], [Thumb], [Title], [Description], [Content], [Status], [Position], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [ContentSort]) VALUES (3, NULL, N'', N'ABOUT THE FOUNDER', NULL, N'<p>
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">Ee-ling is a mother of three who wants to make comfortable, unique pieces that the whole family would wear.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">She picked up sewing when she was living in Australia and loved to shop for fabric and make her own clothes as a hobby. After becoming a mum, she started making one-of-a-kind pieces for her own kids and when she had a daughter, she started making matching outfits for the both of them! Before she knew it, others started asking where they could get clothes like theirs, and the rest, as they say, is history.</span><br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<br style="box-sizing: border-box; color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;" />
	<span style="color: rgb(116, 116, 116); font-family: Montserrat; font-size: 14px; text-align: center;">Our full collections can be seen on this website. If you have any queries at all with regards to any of the products you see here or on our instagram page, do feel free to contact us at hello@iwantthemissingpiece.com. We also provide customisation (with an additional fee), so do contact us if you require that option! We look forward to helping you find your Missing Pieces! xoxo</span></p>
', 1, 3, CAST(N'2020-06-24T13:47:08.393' AS DateTime), CAST(N'2020-06-24T13:47:34.080' AS DateTime), N'admin', N'admin', N'Ee-ling is a mother of three who wants to make comfortable, unique pieces that the whole family would wear.

She picked up sewing when she was living in Australia and loved to shop for fabric and make her own clothes as a hobby. After becoming a mum, she started making one-of-a-kind pieces for her own kids and when she had a daughter, she started making matching outfits for the both of them! Before she knew it, others started asking where they could get clothes like theirs, and the rest, as they say, is history.

Our full collections can be seen on this website. If you have any queries at all with regards to any of the products you see here or on our instagram page, do feel free to contact us at hello@iwantthemissingpiece.com. We also provide customisation (with an additional fee), so do contact us if you require that option! We look forward to helping you find your Missing Pieces! xoxo')
SET IDENTITY_INSERT [dbo].[Introduce] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [Code], [Title], [Description], [Avatar], [Thumb], [ListImage], [Content], [Keyword], [Price], [PriceSale], [MadeIn], [ListBranch], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [CategoryID], [SeoUrl], [MetaTitle], [MetaDescription], [Tags], [ProductSize], [ProductColor], [CollectionId]) VALUES (123, N'aacc', N'DAHLIA CHEONGSAM', NULL, N'/Areas/Admin/Content/Fileuploads/files/DSCF6642_ab5a55fe-051c-4172-8c56-aeca38e328f4_grande27a6.jpg', N'/Areas/Admin/Content/Fileuploads/files/DSCF6642_ab5a55fe-051c-4172-8c56-aeca38e328f4_grande27a6.jpg', N'/Areas/Admin/Content/Fileuploads/images/TMP_X_MATTER_The_Convertible_Sleeveless_Cut_Out_Dress_Zalya_Reblue_3_0e5bbfd0-33ea-4a8c-a734-e3eaaa3471ff90e0.png;/Areas/Admin/Content/Fileuploads/images/TMP_X_MATTER_The_Convertible_Sleeveless_Cut_Out_Dress_Zalya_Reblue_1290e0.png;/Areas/Admin/Content/Fileuploads/images/TMP_X_MATTER_The_Convertible_Sleeveless_Cut_Out_Dress_Zalya_Reblue_1190e0.png;/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_mediumeb4b.jpg;/Areas/Admin/Content/Fileuploads/images/TMP_X_MATTER_The_Convertible_Sleeveless_Cut_Out_Dress_Zalya_Reblue_3_0e5bbfd0-33ea-4a8c-a734-e3eaaa3471ff90e0.png', N'<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
	<span style="box-sizing: border-box;">A&nbsp;traditional cheongsam with a modern twist, the Dahlia features a beautiful watercolour floral print accented by contrast piping, handmade Chinese knots and a subtle slit on the front.&nbsp;<br style="box-sizing: border-box;" />
	<br style="box-sizing: border-box;" />
	- Vegan cupro imported from Europe (Black floral)<br style="box-sizing: border-box;" />
	- Back zipper</span><br style="box-sizing: border-box;" />
	<span style="box-sizing: border-box;">- Side pockets</span></p>
<table border="1" cellpadding="1" cellspacing="1" style="width:500px;">
	<tbody>
		<tr>
			<td>
				<strong style="box-sizing: border-box; color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">&nbsp;MEASUREMENTS OF THE GARMENT ON ONE SIDE (CM)</strong></td>
		</tr>
		<tr>
			<td>
				<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; CHEST &nbsp; &nbsp; &nbsp; WAIST &nbsp; &nbsp; &nbsp; &nbsp;LENGTH</span></td>
		</tr>
		<tr>
			<td>
				<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">UK6&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;42&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;34&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;108</span></td>
		</tr>
		<tr>
			<td>
				<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">UK8&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;44&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;36&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;110</span></td>
		</tr>
		<tr>
			<td>
				<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">UK10&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;46&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;38&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;112</span></td>
		</tr>
		<tr>
			<td>
				<span style="color: rgb(28, 28, 28); font-family: Montserrat; font-size: 14px; text-transform: uppercase;">UK12&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;48&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;40&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;114</span></td>
		</tr>
	</tbody>
</table>
<p>
	&nbsp;</p>
', NULL, N'180000', N'250000', NULL, NULL, 1, NULL, 404, CAST(N'2020-06-12T20:46:04.063' AS DateTime), CAST(N'2020-06-14T09:49:48.663' AS DateTime), N'admin', N'admin', 1, N'dahlia-cheongsam.html', NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Product] ([ProductID], [Code], [Title], [Description], [Avatar], [Thumb], [ListImage], [Content], [Keyword], [Price], [PriceSale], [MadeIn], [ListBranch], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [CategoryID], [SeoUrl], [MetaTitle], [MetaDescription], [Tags], [ProductSize], [ProductColor], [CollectionId]) VALUES (124, N'123a', N'đầm licuxial', N'123121asdadasd', N'/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_grandeeb4b.jpg', N'/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_grandeeb4b.jpg', NULL, NULL, NULL, N'180000', N'170000', NULL, NULL, 1, 12, 0, CAST(N'2020-06-12T20:54:53.007' AS DateTime), CAST(N'2020-06-20T13:05:39.037' AS DateTime), N'admin', N'admin', 1, N'dam-licuxial.html', NULL, NULL, NULL, N'1,2,3,4', N'2,4,5,6', 1)
INSERT [dbo].[Product] ([ProductID], [Code], [Title], [Description], [Avatar], [Thumb], [ListImage], [Content], [Keyword], [Price], [PriceSale], [MadeIn], [ListBranch], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [CategoryID], [SeoUrl], [MetaTitle], [MetaDescription], [Tags], [ProductSize], [ProductColor], [CollectionId]) VALUES (126, N'aacc', N'đầm váy ', N'không có gì ', N'/Areas/Admin/Content/Fileuploads/images/DSC09922-60_granded465.jpg', N'/Areas/Admin/Content/Fileuploads/images/DSC09922-60_granded465.jpg', NULL, N'<p>
	cccc</p>
', NULL, N'190000', N'180000', NULL, NULL, 1, 11, 2, CAST(N'2020-06-20T12:42:55.167' AS DateTime), CAST(N'2020-06-20T12:42:56.027' AS DateTime), N'admin', N'admin', 1, N'dam-vay.html', NULL, NULL, NULL, N'1', N'2,3,4,5', 1)
INSERT [dbo].[Product] ([ProductID], [Code], [Title], [Description], [Avatar], [Thumb], [ListImage], [Content], [Keyword], [Price], [PriceSale], [MadeIn], [ListBranch], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [CategoryID], [SeoUrl], [MetaTitle], [MetaDescription], [Tags], [ProductSize], [ProductColor], [CollectionId]) VALUES (127, NULL, N'VERA  DRESS 111 - WHITE/PINK', NULL, N'/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_mediumeb4b.jpg', N'/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_mediumeb4b.jpg', N'/Areas/Admin/Content/Fileuploads/images/0rMFNgHJTsmFuYrlubIRGg_thumb_62376084.jpg;/Areas/Admin/Content/Fileuploads/images/152aae.png;/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_grandeeb4b.jpg;/Areas/Admin/Content/Fileuploads/images/2020whitedressside_1_82925a68-ec1c-4c05-ad07-5925fcfaed5b_grandeeb4b(1).jpg;/Areas/Admin/Content/Fileuploads/images/DreaEmbroiderySignaturewithSleevesMidiDress_Black_1_medium0db0.jpg', NULL, NULL, N'253000', NULL, NULL, NULL, 1, 1, 6, CAST(N'2020-06-27T12:21:55.473' AS DateTime), CAST(N'2020-06-27T16:38:09.657' AS DateTime), N'admin', N'admin', 3, N'vera-dress-111-white-pink.html', NULL, NULL, NULL, N'2,3', N'2', 1)
INSERT [dbo].[Product] ([ProductID], [Code], [Title], [Description], [Avatar], [Thumb], [ListImage], [Content], [Keyword], [Price], [PriceSale], [MadeIn], [ListBranch], [Status], [Position], [ViewTime], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [CategoryID], [SeoUrl], [MetaTitle], [MetaDescription], [Tags], [ProductSize], [ProductColor], [CollectionId]) VALUES (128, NULL, N'VERA HALTER CONVERTIBLE DRESS BATIK - WHITE/PINK', NULL, N'/Areas/Admin/Content/Fileuploads/images/9636b4ba3553c80d9142.jpg', N'/Areas/Admin/Content/Fileuploads/images/9636b4ba3553c80d9142.jpg', N'/Areas/Admin/Content/Fileuploads/images/TMP_X_MATTER_The_Convertible_Sleeveless_Cut_Out_Dress_Zalya_Reblue_1290e0.png;/Areas/Admin/Content/Fileuploads/images/10c297f7c01e3d40640f.jpg;;;', N'<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
	This season&rsquo;s Vera Halter Convertible Dress comes in five&nbsp;unique prints.&nbsp;</p>
<p style="box-sizing: border-box; margin: 0px 0px 15px; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
	The Vera Halter Convertible Dress allows&nbsp;for multiple wear options.<br style="box-sizing: border-box;" />
	This piece features&nbsp;press studs which allows you to effortlessly create an elegant drape detail which pairs perfectly with a striking prints for dressier occasions.&nbsp;When&nbsp;undraped, it converts to a relaxed midi wrap skirt suitable for casual weekends. Cut in a flattering halter neckline that shows off your shoulders, this is one piece you definitely want in your wardrobe.&nbsp;</p>
<ul>
	<li style="box-sizing: border-box; margin-bottom: 0.4em; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
		Back zipper</li>
	<li style="box-sizing: border-box; margin-bottom: 0.4em; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
		Side pockets with adjustable skirt</li>
	<li style="box-sizing: border-box; margin-bottom: 0.4em; color: rgb(137, 137, 137); font-family: Montserrat; font-size: 14px;">
		Cold hand wash acceptable, hang dry</li>
</ul>
', NULL, N'850000', N'599000', NULL, NULL, 1, NULL, 1, CAST(N'2020-06-27T16:37:10.133' AS DateTime), CAST(N'2020-06-27T16:37:34.527' AS DateTime), N'admin', N'admin', 10, N'vera-halter-convertible-dress-batik-white-pink.html', NULL, NULL, NULL, N'2', N'3', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProductCategoryID], [Title], [Status], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl]) VALUES (1, N'sale', 1, CAST(N'2016-10-13T09:54:11.160' AS DateTime), CAST(N'2020-06-11T21:16:08.693' AS DateTime), N'admin', N'admin', N'sale.html')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [Title], [Status], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl]) VALUES (3, N'new in', 1, CAST(N'2016-10-13T09:54:29.917' AS DateTime), CAST(N'2020-06-11T21:17:14.687' AS DateTime), N'admin', N'admin', N'new-in.html')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [Title], [Status], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl]) VALUES (10, N'ladies', 1, CAST(N'2020-06-11T21:17:51.447' AS DateTime), CAST(N'2020-06-11T21:17:51.447' AS DateTime), N'admin', N'admin', N'ladies.html')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [Title], [Status], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl]) VALUES (11, N'girls', 1, CAST(N'2020-06-11T21:18:05.437' AS DateTime), CAST(N'2020-06-11T21:18:05.437' AS DateTime), N'admin', N'admin', N'girls.html')
INSERT [dbo].[ProductCategory] ([ProductCategoryID], [Title], [Status], [CreateTime], [ModifyTime], [CreateBy], [ModifyBy], [SeoUrl]) VALUES (12, N'boys', 1, CAST(N'2020-06-11T21:18:16.350' AS DateTime), CAST(N'2020-06-11T21:18:16.350' AS DateTime), N'admin', N'admin', N'boys.html')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[ProductColor] ON 

INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (1, N'Red')
INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (2, N'Blue')
INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (3, N'White')
INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (4, N'Black')
INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (5, N'Orance')
INSERT [dbo].[ProductColor] ([Id], [Name]) VALUES (6, N'Green')
SET IDENTITY_INSERT [dbo].[ProductColor] OFF
SET IDENTITY_INSERT [dbo].[ProductSize] ON 

INSERT [dbo].[ProductSize] ([Id], [Name]) VALUES (1, N'6')
INSERT [dbo].[ProductSize] ([Id], [Name]) VALUES (2, N'8')
INSERT [dbo].[ProductSize] ([Id], [Name]) VALUES (3, N'10')
INSERT [dbo].[ProductSize] ([Id], [Name]) VALUES (4, N'12')
SET IDENTITY_INSERT [dbo].[ProductSize] OFF
SET IDENTITY_INSERT [dbo].[Reason] ON 

INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (1, N'mk fashion', N'mk fashion', 35)
INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (2, N'mk fashion', N'mk fashion', NULL)
INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (3, N'mk fashion', N'mk fashion', 34)
INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (120, N'mk fashion', N'mk fashion', 123)
INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (121, N'mk fashion', N'mk fashion', 124)
INSERT [dbo].[Reason] ([ReasonID], [Title], [Content], [ProductID]) VALUES (122, N'mk fashion', N'mk fashion', 125)
SET IDENTITY_INSERT [dbo].[Reason] OFF
INSERT [dbo].[SeoMeta] ([ID], [Title], [Description], [KeyWord], [Avatar]) VALUES (1, N'mk fashion', N'mk fashion', N'trang chủ', NULL)
INSERT [dbo].[SeoMeta] ([ID], [Title], [Description], [KeyWord], [Avatar]) VALUES (2, N'mk fashion', N'mk fashion', N'tin tức', NULL)
INSERT [dbo].[SeoMeta] ([ID], [Title], [Description], [KeyWord], [Avatar]) VALUES (3, N'mk fashion', N'mk fashion', N'sản phẩm', NULL)
INSERT [dbo].[SeoMeta] ([ID], [Title], [Description], [KeyWord], [Avatar]) VALUES (4, N'mk fashion', N'mk fashion', N'liên hệ', NULL)
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([SliderID], [Avatar], [Status], [Description]) VALUES (6, N'/Areas/Admin/Content/Fileuploads/files/slide1_imagef680.jpg', 1, NULL)
INSERT [dbo].[Slider] ([SliderID], [Avatar], [Status], [Description]) VALUES (8, N'/Areas/Admin/Content/Fileuploads/files/slide2_image37ec.jpg', 1, NULL)
INSERT [dbo].[Slider] ([SliderID], [Avatar], [Status], [Description]) VALUES (9, N'/Areas/Admin/Content/Fileuploads/files/slide3_image968b.jpg', 1, NULL)
INSERT [dbo].[Slider] ([SliderID], [Avatar], [Status], [Description]) VALUES (10, N'/Areas/Admin/Content/Fileuploads/files/slide4_image5a1f.jpg', 1, NULL)
SET IDENTITY_INSERT [dbo].[Slider] OFF
USE [master]
GO
ALTER DATABASE [DBMissingPiece] SET  READ_WRITE 
GO
