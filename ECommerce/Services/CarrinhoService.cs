// Services/CarrinhoService.cs
public class CarrinhoService
{
    public List<Produto> Itens { get; private set; } = new();

    public event Action? OnChange;

    public void Adicionar(Produto produto)
    {
        Itens.Add(produto);
        OnChange?.Invoke();
    }

    public void Remover(Produto produto)
    {
        Itens.Remove(produto);
        OnChange?.Invoke();
    }

    public void Limpar()
    {
        Itens.Clear();
        OnChange?.Invoke();
    }
}
