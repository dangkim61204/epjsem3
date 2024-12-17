using Business_BLL.DepartmentSrv;
using Data_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_BLL.BrancheSrv
{
    public class BrancheService : IBranche
    {
        private readonly ConnectDB _context;

        public BrancheService(ConnectDB context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Branche>> GetAll()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branche> GetById(int id)
        {
            var br = await _context.Branches.FindAsync(id);
          
            if (br == null)
            {
                throw new KeyNotFoundException("Branche not found.");
            }

            return br;
        }
        public async Task Add(Branche branche)
        {
             _context.Branches.Add(branche);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Branche branche)
        {
            var br = await _context.Branches.FindAsync(branche.Id);
            if (br != null)
            {
                br.Region = branche.Region; 
                br.Address = branche.Address;
                br.ContactPerson = branche.ContactPerson;
                br.Email = branche.Email;
                br.Phone = branche.Phone;
                br.Description = branche.Description;
                br.GoogleMap = branche.GoogleMap;

                _context.Branches.Update(br);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            if (id == null)
            {
                throw new Exception("not found");
            }

            var br = await _context.Branches.SingleOrDefaultAsync(x => x.Id == id);
            _context.Branches.Remove(br);
            await _context.SaveChangesAsync();
        }

    }
}
