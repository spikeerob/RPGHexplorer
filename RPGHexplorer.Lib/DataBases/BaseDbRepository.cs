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

        public Task<List<T>> GetAllAsync()
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var documents = collection.FindAll().ToList();

                return Task.FromResult(documents);
            }
        }
        
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var documents = collection.Find(filter).ToList();

                return Task.FromResult(documents);
            }
        }
        
        public Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var document = collection.FindOne(filter);

                return Task.FromResult(document);
            }
        }

        public Task<List<T>> GetAsync(IEnumerable<string> ids)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var documents = collection
                    .Find(Query.In("Id", ids.Select(i => new BsonValue(i)))).ToList();

                return Task.FromResult(documents);
            }
        }
        
        public Task<T> GetAsync(string id)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                var document = collection.FindById(id);

                return Task.FromResult(document);
            }
        }
        
        public Task SaveAsync(T document)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                collection.Upsert(document);
            }
            
            return Task.CompletedTask;
        }
        
        public Task SaveAsync(IEnumerable<T> documents)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                collection.Upsert(documents);
            }
            
            return Task.CompletedTask;
        }
        
        public Task DeleteAsync(string id)
        {
            using (var db = GetDb())
            {
                var collection = db.GetCollection<T>(TableName);

                collection.Delete(id);
            }
            
            return Task.CompletedTask;
        }
    }
}