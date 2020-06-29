using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Alura.GoogleMaps.Web.Models
{
    public class conectandoMongoDBGeo
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "geo";
        public const string NOME_DA_COLECAO = "airports";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _BaseDeDados;

        static conectandoMongoDBGeo()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _BaseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient cliente
        {
            get { return _cliente; }
        }

        public IMongoCollection<Aeroporto> Airports
        {
            get { return _BaseDeDados.GetCollection<Aeroporto>(NOME_DA_COLECAO); }
        }


    }
}