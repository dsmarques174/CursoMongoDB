using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class listandoDocumentosFiltro
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
            Console.WriteLine();
            Console.WriteLine(" Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {

            var conexaoBiblioteca = new conectandoMongoDB();

            Console.WriteLine("Listando todos os documentos");      
            var filtro = new BsonDocument();
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            Console.WriteLine("Listando somente Machado de Assis");
            filtro = new BsonDocument("Autor", "Machado de Assis");
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            Console.WriteLine("Listando somente Machado de Assis usando Builders");
            var construtor = Builders<Livro>.Filter;
            var filtro_builder = construtor.Eq(x => x.Autor, "Machado de Assis");
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            Console.WriteLine("Listando livros publicados a partir de 1999");
            construtor = Builders<Livro>.Filter;
            filtro_builder = construtor.Gte(x => x.Ano, 1999);
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            Console.WriteLine("Listando livros publicados a partir de 1999 e com mais de 300 páginas");
            construtor = Builders<Livro>.Filter;
            filtro_builder = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            Console.WriteLine("Listando livros de ficção científica");
            construtor = Builders<Livro>.Filter;
            filtro_builder = construtor.AnyEq(x => x.Assunto, "Ficção Científica");
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

        }
    }
}
