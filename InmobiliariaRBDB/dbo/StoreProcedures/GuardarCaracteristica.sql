CREATE PROCEDURE [dbo].[GuardarCaracteristica]
	@i_metros				decimal = null,
	@i_plantas				int = null,
	@i_banios				int = null,
	@i_habitaciones			int = null,
	@i_parqueos				int = null,
	@i_servicios			varchar(100) = null,
	@i_otros				varchar(150) = null,
	@o_id_caracteristica	int out

AS

INSERT INTO dbo.CARACTERISTICA
(
	METROSCUADRADOS,
	PLANTAS,
	BANIOS,
	HABITACIONES,
	PARQUEADEROS,
	SERVICIOS,
	OTROS
)
VALUES
(
	@i_metros,
	@i_plantas,
	@i_banios,
	@i_habitaciones,
	@i_parqueos,
	@i_servicios,
	@i_otros
)

SET @o_id_caracteristica = SCOPE_IDENTITY()

RETURN 0
