namespace Superdigital.CoreShared.DomainObjects
{
        /// <summary>
        ///  Uma raiz agregada é uma entidade que é modelada usando eventos. O repositório raiz agregado padrão depende da AggregateRootinterface, que sua raiz agregada deve implementar.
        ///  Para facilitar as coisas, são fornecidas várias características que implementam a interface para que você não precise.
        ///  Agregado é um padrão em Design Dirigido por Domínio. Um agregado DDD é um cluster de objetos de domínio que podem ser tratados como uma única unidade. 
        ///  Um exemplo pode ser uma ordem e seus itens de linha, esses serão objetos separados, mas é útil para tratar o pedido (junto com seus itens de linha) como um único agregado. 
        ///  https://docs.abp.io/en/abp/0.6.1/Entities
        /// </summary>
        public interface IAggregateRoot { }
    
}