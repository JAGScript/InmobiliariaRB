CREATE TABLE [dbo].[CARACTERISTICA]
(
	[IDCARACTERISTICA]  INT             NOT NULL , 
    [METROSCUADRADOS]   DECIMAL         NULL, 
    [PLANTAS]           INT             NULL, 
    [BANIOS]            INT             NULL, 
    [HABITACIONES]      INT             NULL, 
    [PARQUEADEROS]      INT             NULL, 
    [SERVICIOS]         VARCHAR(100)    NULL, 
    [OTROS]             VARCHAR(150)    NULL,
    CONSTRAINT [PK_CARACTERISTICA] PRIMARY KEY (IDCARACTERISTICA)
)
