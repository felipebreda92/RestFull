USE [Estudo]
GO

/****** Object:  Table [dbo].[person]    Script Date: 27/01/2019 17:50:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[person](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[person] ADD  DEFAULT (NULL) FOR [FirstName]
GO

ALTER TABLE [dbo].[person] ADD  DEFAULT (NULL) FOR [LastName]
GO

ALTER TABLE [dbo].[person] ADD  DEFAULT (NULL) FOR [Address]
GO

ALTER TABLE [dbo].[person] ADD  DEFAULT (NULL) FOR [Gender]
GO

