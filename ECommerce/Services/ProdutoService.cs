// Services/ProdutoService.cs
public class ProdutoService
{
    private readonly List<Produto> produtos = new()
{
    new Produto { Id = 1, ImagemUrl="./Assets/planta1.jpg", Descricao="Com folhas longas e arqueadas, o Lírio-Aranha traz elegância e purifica o ambiente.", Nome="Lírio-Aranha", Preco=119.90m },
    new Produto { Id = 2, ImagemUrl="./Assets/planta2.jpg", Descricao="O Girassol irradia alegria e vida, perfeito para iluminar qualquer espaço.", Nome="Girassol", Preco=49.90m },
    new Produto { Id = 3, ImagemUrl="./Assets/planta3.jpg", Descricao="Com flores vibrantes, a Begônia é ideal para dar um toque de cor e charme ao seu lar.", Nome="Begonia", Preco=74.90m },
    new Produto { Id = 4, ImagemUrl="./Assets/planta4.jpg", Descricao="Delicado e sofisticado, o Lisianthus encanta com suas pétalas suaves e elegantes.", Nome="Lisianthus", Preco=59.90m },
    new Produto { Id = 5, ImagemUrl="./Assets/planta5.jpg", Descricao="Um arranjo especial para casamentos e celebrações, trazendo beleza e romantismo.", Nome="Conjunto Flores Casamento", Preco=139.90m },
    new Produto { Id = 6, ImagemUrl="./Assets/planta6.jpg", Descricao="Conjunto harmonioso de vasos para decorar com muito estilo e praticidade.", Nome="Conjunto de Vasos 1", Preco=89.90m },
    new Produto { Id = 7, ImagemUrl="./Assets/planta7.jpg", Descricao="Transforme seu ambiente com este elegante conjunto de vasos modernos.", Nome="Conjunto de Vasos 2", Preco=69.90m },
    new Produto { Id = 8, ImagemUrl="./Assets/planta8.jpg", Descricao="Beleza minimalista para compor jardins internos e varandas com muito charme.", Nome="Conjunto de Vasos 3", Preco=79.90m },
    new Produto { Id = 9, ImagemUrl="./Assets/planta9.jpg", Descricao="Design elegante e natural, perfeito para criar ambientes acolhedores.", Nome="Conjunto de Vasos 4", Preco=99.90m },
    new Produto { Id = 10, ImagemUrl="./Assets/planta10.jpg", Descricao="Conjunto de vasos versáteis, ideal para trazer vida a qualquer cantinho.", Nome="Conjunto de Vasos 5", Preco=89.90m },
    new Produto { Id = 11, ImagemUrl="./Assets/planta11.jpg", Descricao="Um toque de natureza e sofisticação para sua decoração.", Nome="Conjunto de Vasos 6", Preco=59.90m },
    new Produto { Id = 12, ImagemUrl="./Assets/planta12.jpg", Descricao="Complete seu espaço verde com este belo conjunto de vasos exclusivos.", Nome="Conjunto de Vasos 7", Preco=64.90m },
    new Produto { Id = 13, ImagemUrl="./Assets/planta13.jpg", Descricao="A Rosa Branca simboliza pureza e paz, perfeita para presentes e ambientes serenos.", Nome="Rosa Branca", Preco=79.90m },
    new Produto { Id = 14, ImagemUrl="./Assets/planta14.jpg", Descricao="A Bromélia encanta com sua forma exótica e cores vibrantes, ideal para interiores tropicais.", Nome="Bromélia", Preco=59.90m },
    new Produto { Id = 15, ImagemUrl="./Assets/planta15.jpg", Descricao="A Peônia é símbolo de prosperidade e romance, com flores grandes e deslumbrantes.", Nome="Peônia", Preco=109.90m },
    new Produto { Id = 16, ImagemUrl="./Assets/planta16.jpg", Descricao="Com flores amarelas vibrantes, a Alamanda é perfeita para jardins ensolarados.", Nome="Alamanda", Preco=69.90m },
    new Produto { Id = 17, ImagemUrl="./Assets/planta17.jpg", Descricao="A Begônia, com suas folhas exuberantes e flores delicadas, é ideal para decoração interna.", Nome="Begônia", Preco=54.90m },
    new Produto { Id = 18, ImagemUrl="./Assets/planta18.jpg", Descricao="A Calêndula encanta com seu tom dourado, conhecida também por suas propriedades terapêuticas.", Nome="Calêndula", Preco=44.90m },
    new Produto { Id = 19, ImagemUrl="./Assets/planta19.jpg", Descricao="O Cactus é resistente e cheio de estilo, ideal para quem busca praticidade e beleza.", Nome="Cactus", Preco=39.90m },
    new Produto { Id = 20, ImagemUrl="./Assets/planta20.jpg", Descricao="Com sua aparência exótica, a Estrelícia é a escolha perfeita para quem quer um toque tropical.", Nome="Estrelícia", Preco=129.90m },
};



    public IReadOnlyList<Produto> Produtos => produtos;

    public Task<List<Produto>> ObterTodosAsync() => Task.FromResult(produtos);

    public Produto? ObterPorId(int id) => produtos.FirstOrDefault(p => p.Id == id);
}
