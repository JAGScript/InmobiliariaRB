CREATE TABLE [dbo].[BARRIO]
(
	[IDBARRIO]      INT IDENTITY(1, 1) NOT NULL,
    [IDPARROQUIA]   INT         NULL, 
    [NOMBREBARRIO]  VARCHAR(50) NULL, 
    [ESTADOBARRIO]  BIT         NULL,
	CONSTRAINT [PK_BARRIO] PRIMARY KEY (IDBARRIO),
    CONSTRAINT [PARROQUIA_BARRIO_FK] FOREIGN KEY (IDPARROQUIA) REFERENCES PARROQUIA(IDPARROQUIA)
)
