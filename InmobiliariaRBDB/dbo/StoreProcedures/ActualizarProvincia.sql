CREATE PROCEDURE [dbo].[ActualizarProvincia]
	@i_id_provincia     INT,
    @i_cod_provincia    VARCHAR(100),
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

UPDATE  dbo.PROVINCIA
SET     CODPROVINCIA        = ISNULL(@i_cod_provincia, CODPROVINCIA),
        NOMBREPROVINCIA     = ISNULL(@i_nombre, NOMBREPROVINCIA),
        ESTADOPROVINCIA     = ISNULL(@i_estado, ESTADOPROVINCIA)
WHERE   IDPROVINCIA         = @i_id_provincia

RETURN 0
