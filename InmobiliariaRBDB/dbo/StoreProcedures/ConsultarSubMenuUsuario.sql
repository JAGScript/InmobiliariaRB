﻿CREATE PROCEDURE [dbo].[ConsultarSubMenuUsuario]
	@i_nombre_usuario	varchar(30),
	@i_menu_padre		int
AS

SELECT	TRANSACCION.*
FROM	USUARIO
		JOIN ROL ON USUARIO.IDROL = ROL.IDROL
		JOIN TRANSACCIONROL ON ROL.IDROL = TRANSACCIONROL.IDROL
		JOIN TRANSACCION ON TRANSACCIONROL.IDTRANSACCION = TRANSACCION.IDTRANSACCION
WHERE	USUARIO.USERNAME = @i_nombre_usuario
AND		TRANSACCION.MENUPADRE = @i_menu_padre
AND		TRANSACCION.ESTADO = 1
AND		TRANSACCION.SUBMENU = 1
ORDER BY TRANSACCION.IDTRANSACCION

RETURN 0
