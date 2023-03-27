CREATE TABLE dbo.produto
(
idProduto INT IDENTITY(1,1) NOT NULL, 
descricaoProduto varchar(100) NOT NULL,
ativo BIT,
dataFabricao datetime,
dataValidade datetime,
idFornecedor int,
)