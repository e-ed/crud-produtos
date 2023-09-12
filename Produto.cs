namespace ConsoleApp1
{
    public class Produto
    {

        public int id { get; set; }
        public string nome { get; set; }

        public string descricao { get; set; }

        public float preco { get; set; }

        public Produto() { }

        public Produto(string nome, float preco, string descricao)
        {

            this.nome = nome;
            this.preco = preco;
            this.descricao = descricao;
        }

    }
}