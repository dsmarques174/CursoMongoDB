using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class modificandoDocumentos
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
            Console.WriteLine("Listando somente Machado de Assis usando Builders");
            var construtor = Builders<Livro>.Filter;
            var filtro_builder = construtor.Eq(x => x.Titulo, "Dom Casmurro");
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                doc.Ano = 1930;
                doc.Paginas = 250;
                await conexaoBiblioteca.Livros.ReplaceOneAsync(filtro_builder, doc);            
            }
            Console.WriteLine("");

            Console.WriteLine("Listando somente livro Primeiros Passos na Matemãtica");
            construtor = Builders<Livro>.Filter;
            filtro_builder = construtor.Eq(x => x.Titulo, "Primeiros Passos na Matemática");
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            var construtorUpdate = Builders<Livro>.Update;
            var updateBuilder = construtorUpdate.Set(x => x.Autor, "M Ibanez");
            await conexaoBiblioteca.Livros.UpdateOneAsync(filtro_builder, updateBuilder);

            Console.WriteLine("Listando todos os livros do Iam Fleming");
            construtor = Builders<Livro>.Filter;
            filtro_builder = construtor.Eq(x => x.Autor, "Iam Fleming");
            listaLivros = await conexaoBiblioteca.Livros.Find(filtro_builder).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }
            Console.WriteLine("");

            construtorUpdate = Builders<Livro>.Update;
            updateBuilder = construtorUpdate.Set(x => x.Autor, "Fleming");
            await conexaoBiblioteca.Livros.UpdateManyAsync(filtro_builder, updateBuilder);



        }
    }
}
