CREATE TABLE [dbo].[USUARIO]
(
	[IDUSUARIO]             INT IDENTITY(1,1)   NOT NULL , 
    [IDROL]                 INT                 NULL, 
    [NOMBREUSUARIO]         VARCHAR(50)         NULL, 
    [IDENTIFICACIONUSUARIO] VARCHAR(15)         NULL, 
    [CORREOUSUARIO]         VARCHAR(100)        NULL, 
    [USERNAME]              VARCHAR(50)         NULL, 
    [CONTRASENA]            VARBINARY(MAX)      NULL, 
    [ESTADO]                BIT                 NULL,
    CONSTRAINT [PK_USUARIO] PRIMARY KEY (IDUSUARIO),
    CONSTRAINT [ROL_USUARIO_FK] FOREIGN KEY (IDROL) REFERENCES ROL(IDROL)
)
