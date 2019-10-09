CREATE TABLE [dbo].[Contas] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [TitularId]         UNIQUEIDENTIFIER NOT NULL,
    [TipoContaId]       INT              NOT NULL,
    [DataAberturaConta] DATETIME         NOT NULL,
    [Saldo]             DECIMAL (18, 2)  NOT NULL,
    [Ativo]             BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_PesConta] FOREIGN KEY ([TitularId]) REFERENCES [dbo].[Clientes] ([Id]),
    CONSTRAINT [fk_TipoContaConta] FOREIGN KEY ([TipoContaId]) REFERENCES [dbo].[TipoConta] ([Id])
);



