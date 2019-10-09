CREATE TABLE [dbo].[TransferenciasBancarias] (
    [Id]                   UNIQUEIDENTIFIER NOT NULL,
    [StatusTrasferenciaId] INT              NOT NULL,
    [TipoTrasferenciasId]  INT              NOT NULL,
    [NumeroContaDestino]   UNIQUEIDENTIFIER NOT NULL,
    [NumeroContaOrigem]    UNIQUEIDENTIFIER NOT NULL,
    [ValorTrasferencia]    DECIMAL (18, 5)  NOT NULL,
    [DtHoraTrasferencia]   DATETIME         NOT NULL,
    CONSTRAINT [PK_TransferenciasBancarias] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_Status_Transferencia] FOREIGN KEY ([StatusTrasferenciaId]) REFERENCES [dbo].[StatusTrasferencia] ([Id]),
    CONSTRAINT [fk_Tipo_Transferencia] FOREIGN KEY ([StatusTrasferenciaId]) REFERENCES [dbo].[TipoTrasferencias] ([Id])
);



