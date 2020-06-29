using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoNET
{
    class manipulandoClassesExternasID
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
            Livro.Titulo = "Dom Casmurro";
            Livro.Autor = "Machado de Assis";
            Livro.Ano = 1923;
            Livro.Paginas = 188;
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Romance");
            Lista_Assuntos.Add("Literatura Brasileira");
            Livro.Assunto = Lista_Assuntos;

            await conexaoBiblioteca.Livros.InsertOneAsync(Livro);
            Console.WriteLine("Documento incluido");

        }
    }
}
