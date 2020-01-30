using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class CrudRepository<EntityType>
    {
        public IMongoCollection<EntityType> _collection;
        public CrudRepository(IMongoCollection<EntityType> collection)
        {
            _collection = collection;
        }
        public async Task<IEnumerable<EntityType>> GetAllItemsAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public Task<EntityType> GetItemAsync(string id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            return  _collection
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }
        public Task AddItemAsync(EntityType item)
        {
            return _collection.InsertOneAsync(item);
        }
        public Task<DeleteResult> RemoveTaskItemAsync(string id)
        {
            return _collection.DeleteOneAsync(
                 Builders<EntityType>.Filter.Eq("Id", id));
        }        
    }
}
