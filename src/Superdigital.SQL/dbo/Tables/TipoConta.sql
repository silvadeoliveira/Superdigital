CREATE TABLE [dbo].[TipoConta] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descricao]   VARCHAR (100) NOT NULL,
    [DataCriacao] DATETIME      NOT NULL,
    [Ativo]       BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

