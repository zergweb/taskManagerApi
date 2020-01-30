using Infrastructure.Entitys;
using Infrastructure.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly DbConfig _config;
        public MongoContext(DbConfig config)
        {
            _config = config;
            var client = new MongoClient(config.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(config.DatabaseName);
        }

        public IMongoCollection<TaskItem> TaskItems
        {
            get
            {
                return _database.GetCollection<TaskItem>(this._config.TasksCollectionName);
            }
        }

        public IMongoCollection<TaskTemplate> TaskTemplates
        {
            get
            {
                return _database.GetCollection<TaskTemplate>(this._config.TaskTemplatesCollectionName);
            }
        }
    }
}
