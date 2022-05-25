CREATE PROCEDURE [dbo].[GuardarParroquia]
	@i_id_canton     INT,
    @i_codigo           VARCHAR(100),
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

INSERT INTO dbo.PARROQUIA
(
    IDCANTON,
    CODPARROQUIA,
    NOMBREPARROQUIA,
    ESTADOPARROQUIA
)
VALUES
(
    @i_id_canton,
    @i_codigo,
    @i_nombre,
    @i_estado
)

RETURN 0
