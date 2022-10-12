USE [SegurosABC]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 10/11/2022 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [varchar](250) NOT NULL,
	[Identification] [varchar](20) NOT NULL,
	[PIN] [varchar](4) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/11/2022 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClientPayments]    Script Date: 10/11/2022 10:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Erick Valderrama>
-- Create date: <11/10/2022,>
-- Description:	<Get payments from client or clients>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetClientPayments]
	-- Add the parameters for the stored procedure here
	@identification varchar(50)
AS
BEGIN

    -- Insert statements for procedure here
	SELECT p.Id as IdPayment, c.Fullname, c.Identification, c.PIN, p.Amount, p.Date 
	from Clients as c inner join Payments as p on c.Id=p.IdClient
	WHERE c.Identification = @identification or @identification='' or @identification is null
	ORDER BY p.Date DESC
END
GO
