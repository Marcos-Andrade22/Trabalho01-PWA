using ECommerce.Models;


namespace ECommerce.Services
{
    public class CarrinhoService
    {
        private readonly List<ItemCarrinho> itens = new();

        public IReadOnlyList<ItemCarrinho> Itens => itens.AsReadOnly();
        public decimal Total => itens.Sum(i => i.Total);

        public event Action? OnChange;

        public void Adicionar(Produto produto)
        {
            var itemExistente = itens.FirstOrDefault(i => i.Produto.Id == produto.Id);

            if (itemExistente != null)
            {
                itemExistente.Quantidade++;
            }
            else
            {
                itens.Add(new ItemCarrinho { Produto = produto, Quantidade = 1 });
            }

            OnChange?.Invoke();
        }

        public void Remover(Produto produto)
        {
            var item = itens.FirstOrDefault(i => i.Produto.Id == produto.Id);
            if (item != null)
            {
                itens.Remove(item);
                OnChange?.Invoke();
            }
        }

        public void Limpar()
        {
            itens.Clear();
            OnChange?.Invoke();
        }
    }

}