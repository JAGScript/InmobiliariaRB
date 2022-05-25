CREATE PROCEDURE [dbo].[ActualizarParroquia]
	@i_id_parroquia INT,
	@i_id_canton    INT,
    @i_codigo       VARCHAR(100),
    @i_nombre       VARCHAR(100),
    @i_estado       BIT
AS

UPDATE  dbo.PARROQUIA
SET     IDCANTON        = ISNULL(@i_id_canton, IDCANTON),
        CODPARROQUIA    = ISNULL(@i_codigo, CODPARROQUIA),
        NOMBREPARROQUIA = ISNULL(@i_nombre, NOMBREPARROQUIA),
        ESTADOPARROQUIA = ISNULL(@i_estado, ESTADOPARROQUIA)
WHERE   IDPARROQUIA     = @i_id_parroquia

RETURN 0
