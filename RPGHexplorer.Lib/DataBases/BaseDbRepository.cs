using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiteDB;

namespace RPGHexplorer.Lib.DataBases
{
    public abstract class BaseDbRepository<T> where T : class
    {
        private readonly LiteDbFactory _factory;

        protected abstract string TableName { get; }

        protected LiteDatabase GetDb() => _factory.GetDb();
        
        protected BaseDbRepository(LiteDbFactory factory)
        {
            _factory = factory;
        }

        protected Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var documents = collection.Find(filter).ToList();

                return Task.FromResult(documents);
            }
        }
        
        protected Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var document = collection.FindOne(filter);

                return Task.FromResult(document);
            }
        }

        protected Task<List<T>> GetAsync(IEnumerable<string> ids)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var documents = collection
                    .Find(Query.In("Id", ids.Select(i => new BsonValue(i)))).ToList();

                return Task.FromResult(documents);
            }
        }
        
        protected Task<T> GetAsync(string id)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var document = collection.FindById(id);

                return Task.FromResult(document);
            }
        }
        
        protected Task SaveAsync(T document)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                collection.Upsert(document);
            }
            
            return Task.CompletedTask;
        }
        
        protected Task SaveAsync(IEnumerable<T> documents)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                collection.Upsert(documents);
            }
            
            return Task.CompletedTask;
        }
        
        protected Task DeleteAsync(T document)
        {
            
            
            return Task.CompletedTask;
        }
    }
}