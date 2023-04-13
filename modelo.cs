using System;

namespace Loja.classes
{
    public class Produto
    {
        public int idProd { get; set; }
        public string nomeProd { get; set; }
        public string descricaoProd { get; set; }
        public decimal precoProd { get; set; }
        public int categoriaProd { get; set; }

    }

    public class Categoria
    {
        public int idCat { get; set; }
        public string nomeCat { get; set; }
        public string descricaoCat { get; set; }
        public List<Produto> Produtos { get; set; }
    }

    public class Cliente
    {
        public int idCli { get; set; }
        public string nomeCli { get; set; }
        public string sobrenomeCli { get; set; }
        public string enderecoCli { get; set; }
        public string telefoneCli { get; set; }
    }

    public class Venda
    {
        public int idVendas { get; set; }
        public Cliente comprador { get; set; }
        public Produto produto { get; set; }
        public DateTime data { get; set; }
        public decimal valorTotal { get; set; }
    }
}

