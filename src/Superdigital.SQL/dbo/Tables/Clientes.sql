CREATE TABLE [dbo].[Clientes] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [NomePessoa]   VARCHAR (100)    NOT NULL,
    [DtNascimento] DATETIME         NOT NULL,
    [NomeMae]      VARCHAR (100)    NOT NULL,
    [NomePai]      VARCHAR (100)    NOT NULL,
    [NomeSocial]   VARCHAR (100)    NOT NULL,
    [Cpf]          INT              NOT NULL,
    [Email]        VARCHAR (100)    NOT NULL,
    [DataCriacao]  DATETIME         NOT NULL,
    [Ativo]        BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

