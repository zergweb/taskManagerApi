using Infrastructure.Model.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entitys
{
    public class TaskFieldEnum
    {
        [BsonElement("Indicator")]
        public string Indicator { get; set; }
        public TaskFieldType Type { get; set; } = TaskFieldType.Enum;

       // [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<string, string> Values { get; set; }
        public int Order { get; set; }
    }
}
