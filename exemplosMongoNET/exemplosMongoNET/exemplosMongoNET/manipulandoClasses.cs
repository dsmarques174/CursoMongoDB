using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class manipulandoClasses
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
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            Livro Livro = new Livro();
            Livro.Titulo = "Sob a Redoma";
            Livro.Autor = "Stephen King";
            Livro.Ano = 2012;
            Livro.Paginas = 679;
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Ficção Científica");
            Lista_Assuntos.Add("Terror");
            Lista_Assuntos.Add("Ação");
            Livro.Assunto = Lista_Assuntos;

            await colecao.InsertOneAsync(Livro);
            Console.WriteLine("Documento incluido");

        }
    }
}
