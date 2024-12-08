using KoiAuction.Repositories;
using KoiAuction.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiAuction.Services
{
    public class GroupKoiService
    {        
        private GroupKoiRepository _repository;

        public GroupKoiService()
        {
            _repository = new GroupKoiRepository();
        }
        public async Task<List<GroupKoi>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<int> Create(GroupKoi groupKoi)
        {
            return await _repository.CreateAsync(groupKoi);
        }

        public async Task<GroupKoi> GetById(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<GroupKoi> GetById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> Update(GroupKoi groupKoi)
        {
            return await _repository.UpdateAsync(groupKoi);
        }

        public async Task<bool> Delete(GroupKoi groupKoi)
        {
            return await _repository.RemoveAsync(groupKoi);
        }

    }
}
