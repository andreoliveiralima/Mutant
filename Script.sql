USE [master]
GO
/****** Object:  Database [LanchesStartup]    Script Date: 02/06/2020 13:45:59 ******/
CREATE DATABASE [LanchesStartup]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LanchesStartup', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LanchesStartup.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LanchesStartup_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LanchesStartup_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LanchesStartup] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LanchesStartup].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LanchesStartup] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LanchesStartup] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LanchesStartup] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LanchesStartup] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LanchesStartup] SET ARITHABORT OFF 
GO
ALTER DATABASE [LanchesStartup] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LanchesStartup] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LanchesStartup] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LanchesStartup] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LanchesStartup] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LanchesStartup] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LanchesStartup] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LanchesStartup] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LanchesStartup] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LanchesStartup] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LanchesStartup] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LanchesStartup] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LanchesStartup] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LanchesStartup] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LanchesStartup] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LanchesStartup] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LanchesStartup] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LanchesStartup] SET RECOVERY FULL 
GO
ALTER DATABASE [LanchesStartup] SET  MULTI_USER 
GO
ALTER DATABASE [LanchesStartup] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LanchesStartup] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LanchesStartup] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LanchesStartup] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LanchesStartup] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LanchesStartup', N'ON'
GO
ALTER DATABASE [LanchesStartup] SET QUERY_STORE = OFF
GO
USE [LanchesStartup]
GO
/****** Object:  User [DESKTOP-SFQB4HK\andre]    Script Date: 02/06/2020 13:45:59 ******/
CREATE USER [DESKTOP-SFQB4HK\andre] FOR LOGIN [DESKTOP-SFQB4HK\andre] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_datareader] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [DESKTOP-SFQB4HK\andre]
GO
/****** Object:  Table [dbo].[ingrediente]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingrediente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[valor] [numeric](5, 2) NULL,
 CONSTRAINT [PK_ingrediente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingredientelanche]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredientelanche](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idLanche] [int] NULL,
	[idIngrediente] [int] NULL,
 CONSTRAINT [PK_ingredientelanche] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemPedido]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemPedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPedido] [int] NULL,
	[idLanche] [int] NULL,
 CONSTRAINT [PK_itemPedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemPedidoIngrediente]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemPedidoIngrediente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idItemPedido] [int] NULL,
	[idIngrediente] [int] NULL,
	[valor] [numeric](5, 2) NULL,
	[valorDesconto] [numeric](5, 2) NULL,
	[quantidade] [int] NULL,
 CONSTRAINT [PK_itemPedidoIngrediente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lanche]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lanche](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
 CONSTRAINT [PK_lanche] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedido]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [varchar](1) NULL,
	[calculoPromocao] [varchar](1) NOT NULL,
 CONSTRAINT [PK_pedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pedido] ADD  CONSTRAINT [DF_pedido_status]  DEFAULT ('N') FOR [status]
GO
ALTER TABLE [dbo].[pedido] ADD  CONSTRAINT [DF_pedido_calculoPromocao]  DEFAULT ('N') FOR [calculoPromocao]
GO
ALTER TABLE [dbo].[ingredientelanche]  WITH CHECK ADD  CONSTRAINT [FK_ingredientelanche_ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[ingrediente] ([id])
GO
ALTER TABLE [dbo].[ingredientelanche] CHECK CONSTRAINT [FK_ingredientelanche_ingrediente]
GO
ALTER TABLE [dbo].[ingredientelanche]  WITH CHECK ADD  CONSTRAINT [FK_ingredientelanche_lanche] FOREIGN KEY([idLanche])
REFERENCES [dbo].[lanche] ([id])
GO
ALTER TABLE [dbo].[ingredientelanche] CHECK CONSTRAINT [FK_ingredientelanche_lanche]
GO
ALTER TABLE [dbo].[itemPedido]  WITH CHECK ADD  CONSTRAINT [FK_itemPedido_lanche] FOREIGN KEY([idLanche])
REFERENCES [dbo].[lanche] ([id])
GO
ALTER TABLE [dbo].[itemPedido] CHECK CONSTRAINT [FK_itemPedido_lanche]
GO
ALTER TABLE [dbo].[itemPedido]  WITH CHECK ADD  CONSTRAINT [FK_itemPedido_pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[pedido] ([id])
GO
ALTER TABLE [dbo].[itemPedido] CHECK CONSTRAINT [FK_itemPedido_pedido]
GO
ALTER TABLE [dbo].[itemPedidoIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_itemPedidoIngrediente_ingrediente] FOREIGN KEY([idIngrediente])
REFERENCES [dbo].[ingrediente] ([id])
GO
ALTER TABLE [dbo].[itemPedidoIngrediente] CHECK CONSTRAINT [FK_itemPedidoIngrediente_ingrediente]
GO
ALTER TABLE [dbo].[itemPedidoIngrediente]  WITH CHECK ADD  CONSTRAINT [FK_itemPedidoIngrediente_itemPedido] FOREIGN KEY([idItemPedido])
REFERENCES [dbo].[itemPedido] ([id])
GO
ALTER TABLE [dbo].[itemPedidoIngrediente] CHECK CONSTRAINT [FK_itemPedidoIngrediente_itemPedido]
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTELANCHE_BUSCAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTELANCHE_BUSCAR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IL.ID idIngredienteLanche, IL.IDLANCHE idLanche, IL.IDINGREDIENTE idIngrediente, 
		   I.NOME nomeIngrediente, I.VALOR valorIngrediente 
	FROM INGREDIENTELANCHE IL INNER JOIN INGREDIENTE I ON 
	IL.idIngrediente = I.id
	WHERE IL.IDLANCHE = @ID
	ORDER BY I.NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTELANCHE_EXCLUIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTELANCHE_EXCLUIR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM INGREDIENTELANCHE WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTELANCHE_INSERIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTELANCHE_INSERIR] 
	@IDLANCHE INT
	,@IDINGREDIENTE INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO INGREDIENTELANCHE (IDLANCHE, IDINGREDIENTE) VALUES (@IDLANCHE, @IDINGREDIENTE);

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTES_ATUALIZAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTES_ATUALIZAR] 
	@ID INT
	,@NOME VARCHAR(50)
	,@VALOR NUMERIC(5,2)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE INGREDIENTE 
	SET NOME = @NOME, VALOR = @VALOR
	WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTES_BUSCAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTES_BUSCAR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idIngrediente, NOME nomeIngrediente, VALOR valorIngrediente 
	FROM INGREDIENTE 
	WHERE ID = @ID
	ORDER BY NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTES_EXCLUIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTES_EXCLUIR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM INGREDIENTE 
	WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTES_INSERIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTES_INSERIR] 
	@NOME VARCHAR(50)
	,@VALOR NUMERIC(5,2)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO INGREDIENTE (NOME, VALOR) VALUES (@NOME, @VALOR);

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INGREDIENTES_LISTAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_INGREDIENTES_LISTAR] 
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idIngrediente, NOME nomeIngrediente, VALOR valorIngrediente 
	FROM INGREDIENTE 
	ORDER BY NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMPEDIDO_ATUALIZAR_INGREDIENTE]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMPEDIDO_ATUALIZAR_INGREDIENTE] 
	@ID INT
	,@IDITEMPEDIDO INT
	,@IDINGREDIENTE INT
	,@VALOR NUMERIC(5,2)
	,@QUANTIDADE INT
	,@VALORDESCONTO NUMERIC(5,2)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ITEMPEDIDOINGREDIENTE SET 
	IDITEMPEDIDO = @IDITEMPEDIDO
	, IDINGREDIENTE = @IDINGREDIENTE
	, VALOR = @VALOR
	, QUANTIDADE = @QUANTIDADE 
	, VALORDESCONTO = @VALORDESCONTO 
	WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMPEDIDO_BUSCAR_POR_PEDIDO]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMPEDIDO_BUSCAR_POR_PEDIDO] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IP.ID idItemPedido, IP.IDPEDIDO idPedido, IP.IDLANCHE idLanche, 
		   IPI.IDINGREDIENTE idIngrediente, IPI.ID idItemPedidoIngrediente,
		   IPI.VALOR valor, IPI.QUANTIDADE quantidade, L.NOME nomeLanche,
		   I.NOME nomeProduto, IPI.VALORDESCONTO valorDesconto  
	FROM (((ITEMPEDIDO IP INNER JOIN ITEMPEDIDOINGREDIENTE IPI ON IP.id = IPI.idItemPedido) 
		INNER JOIN INGREDIENTE I ON IPI.IDINGREDIENTE = I.ID)
		INNER JOIN LANCHE L ON IP.IDLANCHE = L.ID)
		INNER JOIN PEDIDO P ON IP.IDPEDIDO = P.ID
	WHERE IP.IDPEDIDO = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMPEDIDO_INSERIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMPEDIDO_INSERIR] 
	@IDPEDIDO INT
	,@IDLANCHE INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ITEMPEDIDO (IDPEDIDO, IDLANCHE) 
	VALUES (@IDPEDIDO, @IDLANCHE);

	SELECT SCOPE_IDENTITY() idItemPedido;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ITEMPEDIDO_INSERIR_INGREDIENTE]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_ITEMPEDIDO_INSERIR_INGREDIENTE] 
	@IDITEMPEDIDO INT
	,@IDINGREDIENTE INT
	,@VALOR NUMERIC(5,2)
	,@QUANTIDADE INT
	,@VALORDESCONTO NUMERIC(5,2)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ITEMPEDIDOINGREDIENTE (IDITEMPEDIDO, IDINGREDIENTE, VALOR, QUANTIDADE,VALORDESCONTO) 
	VALUES (@IDITEMPEDIDO, @IDINGREDIENTE, @VALOR, @QUANTIDADE, @VALORDESCONTO);

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_ATUALIZAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_ATUALIZAR] 
	@ID INT
	,@NOME VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE LANCHE SET NOME = @NOME WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_BUSCAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_BUSCAR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idLanche, NOME nomeLanche
	FROM LANCHE 
	WHERE ID = @ID
	ORDER BY NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_EXCLUIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_EXCLUIR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE 
	FROM LANCHE 
	WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_INGREDIENTES]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_INGREDIENTES] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
	I.ID idIngrediente
	, I.NOME nomeIngrediente
	, I.valor valorIngrediente
	, 1 quantidade
	FROM 
			(INGREDIENTELANCHE IL INNER JOIN LANCHE L ON IL.IDLANCHE = L.ID) 
			INNER JOIN INGREDIENTE I ON IL.idIngrediente = I.id
	WHERE 
		L.ID = @ID
	UNION
	SELECT 
		I.ID idIngrediente
		, I.NOME nomeIngrediente
		, I.valor valorIngrediente
		, 0 quantidade
	FROM 
			INGREDIENTE I 
	WHERE 
		I.ID NOT IN (SELECT I.ID FROM 
			(INGREDIENTELANCHE IL INNER JOIN LANCHE L ON IL.IDLANCHE = L.ID) 
			INNER JOIN INGREDIENTE I ON IL.idIngrediente = I.id
					WHERE L.ID = @ID)	;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_INSERIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_INSERIR] 
	@NOME VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO LANCHE (NOME) VALUES (@NOME)

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_LISTAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_LISTAR] 
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idLanche, NOME nomeLanche
	FROM LANCHE 
	ORDER BY NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LANCHE_PRECOS]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_LANCHE_PRECOS] 
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		L.ID idLanche
		,L.NOME nomeLanche
		,SUM(I.VALOR) valor
	FROM 
		(INGREDIENTELANCHE IL INNER JOIN LANCHE L ON IL.IDLANCHE = L.ID) 
		INNER JOIN INGREDIENTE I ON IL.idIngrediente = I.id
	GROUP BY L.ID, L.NOME;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PEDIDO_ABRIR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_PEDIDO_ABRIR] 
	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO PEDIDO (STATUS) VALUES ('A');

	SELECT SCOPE_IDENTITY() idPedido;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PEDIDO_ATUALIZA_PROMOCAO]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_PEDIDO_ATUALIZA_PROMOCAO] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE PEDIDO SET CALCULOPROMOCAO = 'S' WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PEDIDO_BUSCAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_PEDIDO_BUSCAR] 
	@ID INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idPedido, STATUS status 
	FROM PEDIDO
	WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PEDIDO_BUSCAR_ABERTO]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_PEDIDO_BUSCAR_ABERTO] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID idPedido, STATUS status 
	FROM PEDIDO
	WHERE STATUS = 'A';

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PEDIDO_FECHAR]    Script Date: 02/06/2020 13:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Lima
-- Create date: 28/05/2020
-- =============================================
CREATE PROCEDURE [dbo].[SP_PEDIDO_FECHAR] 
	@ID INT 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE PEDIDO SET STATUS = 'F' WHERE ID = @ID;

	SET NOCOUNT OFF;
END
GO
USE [master]
GO
ALTER DATABASE [LanchesStartup] SET  READ_WRITE 
GO
