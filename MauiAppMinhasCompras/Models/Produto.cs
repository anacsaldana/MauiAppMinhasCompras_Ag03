using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _descricao = string.Empty; // Inicializa com uma string vazia
        public string Descricao
        {
            get => _descricao;
            set => _descricao = value ?? string.Empty; // Caso o valor seja null, define como uma string vazia
        }

        public double Quantidade { get; set; }
        public double Preco { get; set; }
    }
}
