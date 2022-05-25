CREATE TABLE [dbo].[TRANSACCION]
(
	[IDTRANSACCION]         INT IDENTITY(1,1)   NOT NULL , 
    [NOMBRE]                VARCHAR(50)         NULL, 
    [DESCRIPCION]           VARCHAR(300)        NULL, 
    [ESTADO]                BIT                 NULL, 
    [MENU]                  VARCHAR(300)        NULL, 
    [SUBMENU]               BIT                 NULL, 
    [MENUPADRE]             INT                 NULL,
    [IDUSUARIOMODIFICACION] INT                 NULL, 
    [FECHAMODIFICACION]     DATETIME            NULL, 
    CONSTRAINT [PK_Transaccion] PRIMARY KEY (IDTRANSACCION)
)
