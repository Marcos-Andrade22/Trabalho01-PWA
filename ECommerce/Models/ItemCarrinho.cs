namespace ECommerce.Models
{
    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Total => Produto.Preco * Quantidade;
    }
}