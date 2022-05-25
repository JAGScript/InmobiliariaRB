CREATE PROCEDURE [dbo].[ActualizarCanton]
    @i_id_canton        INT,
	@i_id_provincia     INT,
    @i_cod_canton       VARCHAR(100),
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

UPDATE  dbo.CANTON
SET     IDPROVINCIA     = ISNULL(@i_id_provincia, IDPROVINCIA),
        CODCANTON       = ISNULL(@i_cod_canton, CODCANTON),
        NOMBRECANTON    = ISNULL(@i_nombre, NOMBRECANTON),
        ESTADOCANTON    = ISNULL(@i_estado, ESTADOCANTON)
WHERE   IDCANTON        = @i_id_canton

RETURN 0
