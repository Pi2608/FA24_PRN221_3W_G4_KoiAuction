using KoiAuction.Repositories;
using KoiAuction.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Services
{
    public class KoiFarmService
    {
        private KoiFarmRepository _repository;
        public KoiFarmService()
        {
            _repository = new KoiFarmRepository();
        }

        public async Task<List<KoiFarm>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(KoiFarm koiFarm)
        {
            return await _repository.CreateAsync(koiFarm);
        }

        public async Task<KoiFarm> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<KoiFarm> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(KoiFarm koiFarm)
        {
            return await _repository.UpdateAsync(koiFarm);
        }

        public async Task<bool> Delete(KoiFarm koiFarm)
        {
            return await _repository.RemoveAsync(koiFarm);
        }

        public async Task<List<KoiFarm>> Search(string? farmName, string? location, string? owner)
        {
            return await _repository.Search(farmName, location, owner);
        }
    }
}
