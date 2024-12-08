using KoiAuction.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Services
{
    public class KoiFishService
    {
        private KoiAuction.Repositories.KoiFishRepository _repository;
        public KoiFishService()
        {
            _repository = new KoiAuction.Repositories.KoiFishRepository();
        }
        public async Task<List<KoiFish>> GetAll()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<List<KoiFish>> GetAllWith()
        {
            return await _repository.GetGroupAll();
        }
        public async Task<KoiFish> GetByIdWithIncludesAsync(int? id)
        {
            return await _repository.GetByIdWithIncludesAsync(id);
        }
        public async Task<int> Create(KoiFish koifish)
        {
            return await _repository.CreateAsync(koifish);
        }
        public async Task<KoiFish> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<int> UpdateAsync(KoiFish koifish)
        {
            return await _repository.UpdateAsync(koifish);
        }
        public async Task<bool> Delete(KoiFish koifish)
        {
            return await _repository.RemoveAsync(koifish);
        }
        public async Task<List<KoiFish>> SearchAsync(string? name, string? status, string? gender)
        {
            return await _repository.SearchAsync(name, status, gender);
        }
    }

}