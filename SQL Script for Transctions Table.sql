USE [DBEXAM]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 5/29/2024 12:39:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Reference_Number] [nvarchar](20) NULL,
	[Quantity] [bigint] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Name] [nvarchar](250) NULL,
	[Transaction_Date] [datetime] NULL,
	[Symbol] [nvarchar](5) NULL,
	[Order_Side] [nvarchar](10) NULL,
	[Order_Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


