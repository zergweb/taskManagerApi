using Infrastructure.Model.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entitys
{
    public class TaskField
    {
        [BsonElement("Indicator")]
        public string Indicator { get; set; }
        public TaskFieldType Type { get;set;}
        public string Value { get; set; }
    }
}
