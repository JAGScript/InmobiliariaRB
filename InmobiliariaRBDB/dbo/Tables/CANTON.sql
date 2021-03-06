CREATE TABLE [dbo].[CANTON]
(
	[IDCANTON]      INT IDENTITY(1, 1) NOT NULL , 
    [IDPROVINCIA]   INT             NULL, 
    [CODCANTON]     VARCHAR(4)      NULL, 
    [NOMBRECANTON]  VARCHAR(100)    NULL, 
    [ESTADOCANTON]  BIT             NULL,
    CONSTRAINT [PK_CANTON] PRIMARY KEY (IDCANTON),
    CONSTRAINT [PROVINCIA_CANTON_FK] FOREIGN KEY (IDPROVINCIA) REFERENCES PROVINCIA(IDPROVINCIA)
)