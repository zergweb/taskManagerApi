using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entitys
{
    public class TaskTemplate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public TaskFieldEnum[] EnumFields { get; set; }
        public TaskField[] Fields { get; set; }
    }
}
