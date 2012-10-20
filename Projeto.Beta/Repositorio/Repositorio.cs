using System;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;

namespace Repositorio
{
    public class Repositorio<T> where T : class
    {
        private readonly MongoDatabase db;
        private readonly MongoServer server;
        public MongoCollection<T> Collection { get; set; }

        public Repositorio()
        {
            var connectionString = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            server = MongoServer.Create(connectionString);
            db = server.GetDatabase(connectionString.DatabaseName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());

            //Corrige a hora no sevidor do banco
            DateTimeSerializationOptions.Defaults = new DateTimeSerializationOptions(DateTimeKind.Utc, BsonType.Document);

            var minhaConvensao = new ConventionProfile();
            minhaConvensao.SetIgnoreExtraElementsConvention(new AlwaysIgnoreExtraElementsConvention());
            BsonClassMap.RegisterConventions(minhaConvensao, (type) => true);
        }
    }
}
