CREATE PROCEDURE [dbo].[GuardarUsuario]
	@i_nombre                   VARCHAR(50),
    @i_identificacion           VARCHAR(15),
    @i_username                 VARCHAR(50),
    @i_id_rol                   INT,
    @i_contrasena               VARCHAR(50) = NULL,
    @i_estado                   BIT
AS

INSERT INTO dbo.USUARIO
(
    IDROL,
    NOMBREUSUARIO,
    IDENTIFICACIONUSUARIO,
    CORREOUSUARIO,
    USERNAME,
    CONTRASENA,
    ESTADO
)
VALUES
(
    @i_id_rol,
    @i_nombre,
    @i_identificacion,
    @i_username,
    @i_username,
    PWDENCRYPT(@i_contrasena),
    1
)

RETURN 0
