using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class listandoDocumentosCriterios
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

            Console.WriteLine("Listando todos os documentos por ordem de título");      
            var filtro = new BsonDocument();
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro).SortBy(x => x.Titulo).Limit(5).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.Titulo);
            }
            Console.WriteLine("");

           

        }
    }
}
