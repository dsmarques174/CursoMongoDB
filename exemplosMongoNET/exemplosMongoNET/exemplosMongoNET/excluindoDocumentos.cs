using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class excluindoDocumentos
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
            Console.WriteLine("Listando o livro 20000 Léguas Submarinas");
            var construtor = Builders<Livro>.Filter;
            var filtro_builder = construtor.Eq(x => x.Titulo, "20000 Léguas Submarinas");
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
              
            }
            Console.WriteLine("");
            await conexaoBiblioteca.Livros.DeleteManyAsync(filtro_builder);
                  

        }
    }
}
