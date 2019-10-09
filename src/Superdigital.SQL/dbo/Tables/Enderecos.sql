CREATE TABLE [dbo].[Enderecos] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [PessoaId]    UNIQUEIDENTIFIER NOT NULL,
    [Endereco]    VARCHAR (100)    NOT NULL,
    [Complemento] VARCHAR (250)    NOT NULL,
    [Bairro]      VARCHAR (100)    NOT NULL,
    [Cidade]      VARCHAR (100)    NOT NULL,
    [Uf]          VARCHAR (2)      NOT NULL,
    [Cep]         VARCHAR (10)     NOT NULL,
    [DataCriacao] DATETIME         NOT NULL,
    [Ativo]       BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_PesEnderecos] FOREIGN KEY ([PessoaId]) REFERENCES [dbo].[Clientes] ([Id])
);



