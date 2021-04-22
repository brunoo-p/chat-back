using System;
using MongoDB.Driver;

namespace chatServer.Infrastructure.Database
{
    public class DbConnection
    {
        public IMongoDatabase database;
        public DbConnection(){

            try{
                var client = new MongoClient("ConnectionString");
                database = client.GetDatabase("Database");
            
            }catch(Exception ex)
            {
                throw new MongoException("It was not possible to connect to Database", ex);
            }
        }
    }
}