CREATE TABLE [dbo].[PROVINCIA]
(
	[IDPROVINCIA]       INT IDENTITY(1,1) NOT NULL , 
    [CODPROVINCIA]      VARCHAR(2)      NULL, 
    [NOMBREPROVINCIA]   VARCHAR(100)    NULL, 
    [ESTADOPROVINCIA]   BIT             NULL,
    CONSTRAINT [PK_PROVINCIA] PRIMARY KEY (IDPROVINCIA)
)
