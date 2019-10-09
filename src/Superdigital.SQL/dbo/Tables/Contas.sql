CREATE TABLE [dbo].[Contas] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [TitularId]         UNIQUEIDENTIFIER NOT NULL,
    [TipoContaId]       INT              NOT NULL,
    [DataAberturaConta] DATETIME         NOT NULL,
    [Saldo]             DECIMAL (18, 2)  NOT NULL,
    [Ativo]             BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClienteConta] FOREIGN KEY ([TitularId]) REFERENCES [dbo].[Clientes] ([Id]),
    CONSTRAINT [FK_TipoContaConta] FOREIGN KEY ([TipoContaId]) REFERENCES [dbo].[TipoConta] ([Id])
);





