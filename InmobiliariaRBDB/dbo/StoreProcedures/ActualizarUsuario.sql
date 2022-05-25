CREATE PROCEDURE [dbo].[ActualizarUsuario]
	@i_id_usuario               INT,
    @i_nombre                   VARCHAR(50),
    @i_identificacion           VARCHAR(15),
    @i_username                 VARCHAR(50),
    @i_id_rol                   INT,
    @i_contrasena               VARCHAR(50) = NULL,
    @i_estado                   BIT
AS

UPDATE  dbo.USUARIO
SET     IDROL                   = @i_id_rol,
        NOMBREUSUARIO           = @i_nombre,
        IDENTIFICACIONUSUARIO   = @i_identificacion,
        USERNAME                = @i_username,
        CORREOUSUARIO           = @i_username,
        CONTRASENA              = ISNULL(PWDENCRYPT(@i_contrasena), CONTRASENA),
        ESTADO                  = @i_estado
WHERE   IDUSUARIO               = @i_id_usuario

RETURN 0
