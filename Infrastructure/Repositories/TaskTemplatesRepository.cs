using Infrastructure.Entitys;
using Infrastructure.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskTemplatesRepository : CrudRepository<TaskTemplate>
    {
        public TaskTemplatesRepository(DbConfig config) : base(new MongoContext(config).TaskTemplates)
        {

        }
        public async Task<ReplaceOneResult> UpdateTaskItem(TaskTemplate item)
        {
            var filter = Builders<TaskTemplate>.Filter.Eq(s => s.Id, item.Id);
            return await _collection.ReplaceOneAsync(filter, item);
        }

      
    }
}
