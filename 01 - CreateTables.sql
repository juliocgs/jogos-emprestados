IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_game]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing] DROP CONSTRAINT [FK_borrowing_game]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_friend]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing] DROP CONSTRAINT [FK_borrowing_friend]
GO
/****** Object:  Table [dbo].[app_user]    Script Date: 28/02/2018 02:29:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[app_user]') AND type in (N'U'))
DROP TABLE [dbo].[app_user]
GO
/****** Object:  Table [dbo].[game]    Script Date: 28/02/2018 02:29:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[game]') AND type in (N'U'))
DROP TABLE [dbo].[game]
GO
/****** Object:  Table [dbo].[friend]    Script Date: 28/02/2018 02:29:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[friend]') AND type in (N'U'))
DROP TABLE [dbo].[friend]
GO
/****** Object:  Table [dbo].[borrowing]    Script Date: 28/02/2018 02:29:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[borrowing]') AND type in (N'U'))
DROP TABLE [dbo].[borrowing]
GO
/****** Object:  Table [dbo].[borrowing]    Script Date: 28/02/2018 02:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[borrowing]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[borrowing](
	[id] [uniqueidentifier] NOT NULL,
	[game_id] [uniqueidentifier] NOT NULL,
	[friend_id] [uniqueidentifier] NOT NULL,
	[borrowed_date] [datetime] NOT NULL,
	[return_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[friend]    Script Date: 28/02/2018 02:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[friend]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[friend](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](120) NOT NULL,
	[phone_number] [numeric](11, 0) NULL,
	[email] [varchar](150) NULL,
	[nickname] [varchar](120) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[game]    Script Date: 28/02/2018 02:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[game]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[game](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](120) NOT NULL,
	[registration_date] [datetime] NOT NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[app_user]    Script Date: 28/02/2018 02:29:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[app_user]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[app_user](
	[id] [uniqueidentifier] NOT NULL,
	[username] [varchar](10) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[last_login] [datetime] NULL,
	[registration_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_friend]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing]  WITH CHECK ADD  CONSTRAINT [FK_borrowing_friend] FOREIGN KEY([friend_id])
REFERENCES [dbo].[friend] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_friend]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing] CHECK CONSTRAINT [FK_borrowing_friend]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_game]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing]  WITH CHECK ADD  CONSTRAINT [FK_borrowing_game] FOREIGN KEY([game_id])
REFERENCES [dbo].[game] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_borrowing_game]') AND parent_object_id = OBJECT_ID(N'[dbo].[borrowing]'))
ALTER TABLE [dbo].[borrowing] CHECK CONSTRAINT [FK_borrowing_game]
GO