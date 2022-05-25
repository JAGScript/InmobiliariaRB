CREATE PROCEDURE [dbo].[GuardarBarrio]
	@i_id_parroquia     INT,
    @i_nombre           VARCHAR(100),
    @i_estado           BIT
AS

INSERT INTO dbo.BARRIO
(
    IDPARROQUIA,
    NOMBREBARRIO,
    ESTADOBARRIO
)
VALUES
(
    @i_id_parroquia,
    @i_nombre,
    @i_estado
)

RETURN 0