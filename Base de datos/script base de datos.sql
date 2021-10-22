CREATE DATABASE PruebasTicket
GO
USE [PruebasTicket]
GO
/****** Object:  Table [dbo].[EstatusTicket]    Script Date: 22/10/2021 0:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 22/10/2021 0:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](100) NULL,
	[FechaCreacion] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL,
	[EstatusTicketId] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EstatusTicket] ON 
GO
INSERT [dbo].[EstatusTicket] ([Id], [Descripcion]) VALUES (1, N'Abierto')
GO
INSERT [dbo].[EstatusTicket] ([Id], [Descripcion]) VALUES (2, N'Cerrado')
GO
SET IDENTITY_INSERT [dbo].[EstatusTicket] OFF
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (1, N'Andres', CAST(N'2021-10-22T00:18:47.297' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (2, N'Felipe', CAST(N'2021-10-22T00:18:52.590' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (3, N'Julian', CAST(N'2021-10-22T00:18:57.197' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (4, N'Karen', CAST(N'2021-10-22T00:19:10.987' AS DateTime), CAST(N'2021-10-22T00:33:07.500' AS DateTime), 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (5, N'John', CAST(N'2021-10-22T00:19:24.783' AS DateTime), NULL, 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (6, N'Juan', CAST(N'2021-10-22T00:19:28.257' AS DateTime), NULL, 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (7, N'Maria', CAST(N'2021-10-22T00:19:31.667' AS DateTime), NULL, 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (8, N'Liseth', CAST(N'2021-10-22T00:19:35.423' AS DateTime), NULL, 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (9, N'Ronal', CAST(N'2021-10-22T00:19:38.697' AS DateTime), NULL, 2)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (10, N'Jairo', CAST(N'2021-10-22T00:19:47.190' AS DateTime), NULL, 1)
GO
INSERT [dbo].[Ticket] ([Id], [Usuario], [FechaCreacion], [FechaActualizacion], [EstatusTicketId]) VALUES (13, N'Roberto', CAST(N'2021-10-22T00:31:39.113' AS DateTime), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_EstatusTicket] FOREIGN KEY([EstatusTicketId])
REFERENCES [dbo].[EstatusTicket] ([Id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_EstatusTicket]
GO
