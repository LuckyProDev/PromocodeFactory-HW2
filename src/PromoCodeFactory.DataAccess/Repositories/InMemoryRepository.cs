using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PromoCodeFactory.DataAccess.Repositories {
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data) {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync() {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id) {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<Guid> CreateAsync(T entity) {
            entity.Id = Guid.NewGuid();
            Data = Data.Append(entity);
            return Task.FromResult(entity.Id);
        }

        public Task UpdateAsync(Guid id, T entity) {
            entity.Id=id;

            if (Data.FirstOrDefault(x => x.Id == id) is null) {
                throw new NotImplementedException();
            }

            Data = Data.Where(x => x.Id != id).ToList().Append(entity);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id) {
            if (Data.FirstOrDefault(x => x.Id == id) is null) {
                throw new NotImplementedException();
            }

            Data = Data.Where(x => x.Id != id).ToList();

            return Task.CompletedTask;
        }
    }
}