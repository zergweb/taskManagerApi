using Infrastructure.Entitys;
using Infrastructure.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepository : CrudRepository<TaskItem>
    {

        public TaskRepository(DbConfig config) : base(new MongoContext(config).TaskItems)
        {
   
        }
        public async Task<ReplaceOneResult> UpdateTaskItem(TaskItem item)
        {
            var filter = Builders<TaskItem>.Filter.Eq(s => s.Id, item.Id);
            return await _collection.ReplaceOneAsync(filter, item);
        }

        public async Task<IEnumerable<TaskItem>> GetItemsAsync(string templateId)
        {
            var filter = Builders<TaskItem>.Filter.Eq("TemplateId", templateId);
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
