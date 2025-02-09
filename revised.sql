USE [DB_121607_nomadsq]
GO
/****** Object:  Table [dbo].[client]    Script Date: 9/1/2020 3:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[client] [varchar](47) NOT NULL,
	[given_n] [varchar](277) NOT NULL,
	[sur_n] [varchar](277) NOT NULL,
	[electro_mail] [varchar](277) NOT NULL,
	[customer] [numeric](8, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[component]    Script Date: 9/1/2020 3:51:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[component](
	[ID] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
	[component] [varchar](277) NOT NULL,
	[stoc_qty] [numeric](8, 2) NOT NULL,
	[tag] [varchar](277) NOT NULL,
	[tag_set_name] [varchar](277) NOT NULL,
	[base_cost] [numeric](8, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 9/1/2020 3:51:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[ID] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
	[customer] [varchar](277) NOT NULL,
	[street] [varchar](277) NOT NULL,
	[city] [varchar](277) NOT NULL,
	[state] [varchar](14) NOT NULL,
	[zip] [varchar](14) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_]    Script Date: 9/1/2020 3:51:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_](
	[ID] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
	[customer] [numeric](8, 0) NOT NULL,
	[ordered] [numeric](18, 0) NOT NULL,
	[ordered2] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_order_comp]    Script Date: 9/1/2020 3:51:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_order_comp](
	[ID] [numeric](8, 0) IDENTITY(1,1) NOT NULL,
	[order_] [numeric](8, 0) NOT NULL,
	[comp] [numeric](8, 0) NOT NULL,
	[cost] [numeric](8, 2) NOT NULL,
	[qty] [numeric](8, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_client]  DEFAULT ('') FOR [client]
GO
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_given_n]  DEFAULT ('') FOR [given_n]
GO
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_sur_n]  DEFAULT ('') FOR [sur_n]
GO
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_electro_mail]  DEFAULT ('') FOR [electro_mail]
GO
ALTER TABLE [dbo].[client] ADD  CONSTRAINT [DF_client_customer]  DEFAULT ((0)) FOR [customer]
GO
ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_item_item]  DEFAULT ('') FOR [component]
GO
ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_item_stoc_qty]  DEFAULT ((0)) FOR [stoc_qty]
GO
ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_item_tag]  DEFAULT ('') FOR [tag]
GO
ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_item_tag_set_name]  DEFAULT ('') FOR [tag_set_name]
GO
ALTER TABLE [dbo].[component] ADD  CONSTRAINT [DF_item_base_cost]  DEFAULT ((0)) FOR [base_cost]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_customer]  DEFAULT ('') FOR [customer]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_street]  DEFAULT ('') FOR [street]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_city]  DEFAULT ('') FOR [city]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_state]  DEFAULT ('') FOR [state]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_zip]  DEFAULT ('') FOR [zip]
GO
ALTER TABLE [dbo].[order_] ADD  CONSTRAINT [DF_order__customer]  DEFAULT ((0)) FOR [customer]
GO
ALTER TABLE [dbo].[order_] ADD  CONSTRAINT [DF_order__ordered]  DEFAULT ((0)) FOR [ordered]
GO
ALTER TABLE [dbo].[order_] ADD  CONSTRAINT [DF_order__ordered2]  DEFAULT ('4/4/1900') FOR [ordered2]
GO
ALTER TABLE [dbo].[rel_order_comp] ADD  CONSTRAINT [DF_rel_order_item_order_]  DEFAULT ((0)) FOR [order_]
GO
ALTER TABLE [dbo].[rel_order_comp] ADD  CONSTRAINT [DF_rel_order_item_item]  DEFAULT ((0)) FOR [comp]
GO
ALTER TABLE [dbo].[rel_order_comp] ADD  CONSTRAINT [DF_rel_order_item_cost]  DEFAULT ((0)) FOR [cost]
GO
ALTER TABLE [dbo].[rel_order_comp] ADD  CONSTRAINT [DF_rel_order_item_qty]  DEFAULT ((0)) FOR [qty]
GO
