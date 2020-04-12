using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Medium.Business.Entities
{
    [BsonDiscriminator("Story")]
    public class Story
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
