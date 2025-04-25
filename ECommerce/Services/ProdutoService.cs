// Services/ProdutoService.cs
public class ProdutoService
{
    private readonly List<Produto> produtos = new()
    {
        new Produto { Id = 1, ImagemUrl="./Assets/planta1.jpg", Descricao="teste", Nome="Lírio-Aranha", Preco=89.90m },
        new Produto { Id = 2, ImagemUrl="./Assets/planta2.jpg", Descricao="teste", Nome="Girassol", Preco=49.90m },
        new Produto { Id = 3, ImagemUrl="./Assets/planta3.jpg", Descricao="teste", Nome="Begonia ", Preco=59.90m },
        new Produto { Id = 4, ImagemUrl="./Assets/planta4.jpg", Descricao="teste", Nome="Lisianthus", Preco=59.90m },
        new Produto { Id = 5, ImagemUrl="./Assets/planta5.jpg" , Descricao="teste" , Nome="Conjunto Flores Casamento", Preco=59.90m},
        new Produto { Id = 6, ImagemUrl="./Assets/planta6.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 1", Preco=59.90m},
        new Produto { Id = 7, ImagemUrl="./Assets/planta7.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 2", Preco=59.90m},
        new Produto { Id = 8, ImagemUrl="./Assets/planta8.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 3", Preco=59.90m},
        new Produto { Id = 9, ImagemUrl="./Assets/planta9.jpg"  , Descricao="teste" , Nome="Conjunto de Vasos 4" ,Preco=59.90m},
        new Produto { Id = 10, ImagemUrl="./Assets/planta10.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 5" ,Preco=59.90m},
        new Produto { Id = 11, ImagemUrl="./Assets/planta11.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 6" ,Preco=59.90m},
        new Produto { Id = 12, ImagemUrl="./Assets/planta12.jpg" , Descricao="teste" , Nome="Conjunto de Vasos 7" ,Preco=59.90m},
        new Produto { Id = 13, ImagemUrl="./Assets/planta13.jpg" ,Descricao="teste" ,Nome="Rosa Branca", Preco=59.90m },
        new Produto { Id = 14, ImagemUrl="./Assets/planta14.jpg" ,Descricao="teste" ,Nome="Bromélia", },
        new Produto { Id = 15, ImagemUrl="./Assets/planta15.jpg" ,Descricao="teste" ,Nome="Peônia", Preco=59.90m },
        new Produto { Id = 16, ImagemUrl="./Assets/planta16.jpg" ,Descricao="teste" ,Nome="Alamanda", Preco=59.90m},
        new Produto { Id = 17, ImagemUrl="./Assets/planta17.jpg" ,Descricao="teste" ,Nome="Begônia", Preco=59.90m},
        new Produto { Id = 18, ImagemUrl="./Assets/planta18.jpg" ,Descricao="teste" ,Nome="Calêndula", Preco=59.90m},
        new Produto { Id = 19, ImagemUrl="./Assets/planta19.jpg" ,Descricao="teste" ,Nome="Cactus", Preco=59.90m},
        new Produto { Id = 20, ImagemUrl="./Assets/planta20.jpg" ,Descricao="teste" ,Nome="Estrelícia", Preco=59.90m},
    };

    public IReadOnlyList<Produto> Produtos => produtos;

    public Task<List<Produto>> ObterTodosAsync() => Task.FromResult(produtos);

    public Produto? ObterPorId(int id) => produtos.FirstOrDefault(p => p.Id == id);
}
