CREATE PROCEDURE [dbo].[ActualizarBarrio]
	@i_id_barrio        INT,
	@i_id_parroquia      INT,
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

UPDATE  dbo.BARRIO
SET     IDPARROQUIA     = ISNULL(@i_id_parroquia, IDPARROQUIA),
        NOMBREBARRIO    = ISNULL(@i_nombre, NOMBREBARRIO),
        ESTADOBARRIO    = ISNULL(@i_estado, ESTADOBARRIO)
WHERE   IDBARRIO        = @i_id_barrio

RETURN 0
