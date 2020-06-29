using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class manipulandoClassesExternas
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
            Livro.Titulo = "Star Wars Legends";
            Livro.Autor = "Timothy Zahn";
            Livro.Ano = 2010;
            Livro.Paginas = 245;
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Ficção Científica");
            Lista_Assuntos.Add("Ação");
            Livro.Assunto = Lista_Assuntos;

            await conexaoBiblioteca.Livros.InsertOneAsync(Livro);
            Console.WriteLine("Documento incluido");

        }
    }
}
