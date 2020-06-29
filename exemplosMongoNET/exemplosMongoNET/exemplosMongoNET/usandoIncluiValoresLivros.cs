using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class usandoIncluiValoresLivros
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

            Livro Livro = new Livro();
            Livro = valoresLivro.incluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto-Ajuda");
            await conexaoBiblioteca.Livros.InsertOneAsync(Livro);
            Console.WriteLine("Documento incluido");

        }
    }
}
