using MongoDB.Bson;

namespace Chat.Infrastructure.Entities
{
    public abstract class Base
    {
        public ObjectId Id { get; set; }
    }
}