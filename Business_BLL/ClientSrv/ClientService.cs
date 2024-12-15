using Business_BLL.DepartmentSrv;
using Data_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_BLL.ClientSrv
{
    public class ClientService : IClient
    {

        private readonly ConnectDB _context;
        public ClientService(ConnectDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var client =  _context.Clients.Include(e => e.Service)
                                         .Include(x => x.ClientEmployees)
                                         .ThenInclude(s=>s.Employee);
            var cli = await client.ToListAsync();
            return cli;
        }


        public async Task<Client> GetById(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }

            return client;
        }

        public async Task Add(Client client, int[] emplyeeIds)
        {
            // Lưu Client vào bảng Clients
            _context.Clients.Add(client);
            await _context.SaveChangesAsync(); // Lưu Client trước để có ID (nếu có sử dụng Identity)

            // Lưu thông tin ClientEmployee nếu có
            if (emplyeeIds.Length > 0)
            {
                foreach (var employeeCode in emplyeeIds)
                {
                    var employee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.Code == employeeCode);

                    if (employee != null)
                    {
                        var clientEmployee = new ClientEmployee
                        {
                            ClientId = client.Id,
                            EmployeeId = employee.Code  // Đảm bảo là EmployeeId chứ không phải đối tượng employee
                        };
                        _context.clientEmployees.Add(clientEmployee);  // Thêm vào bảng ClientEmployee
                    }
                }
                await _context.SaveChangesAsync();  // Lưu bảng ClientEmployee
            }

        }

        public async Task Update(Client client, int[] emplyeeIds)
        {
            var Cli = await _context.Clients.FindAsync(client.Id);
           
                //_context.Clients.Update(Cli);
                //await _context.SaveChangesAsync();
            foreach (var employeeCode in emplyeeIds)
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.Code == employeeCode);

                if (employee != null)
                {
                    var clientEmployee = new ClientEmployee
                    {
                        ClientId = client.Id,
                        EmployeeId = employee.Code  
                    };
                    _context.clientEmployees.Update(clientEmployee);  
                }
            }
            await _context.SaveChangesAsync();  

        }

        public async Task Delete(int id)
        {
            var emp = await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
            if (emp == null)
            {
                throw new KeyNotFoundException("Client not found.");
            }
            
            _context.Clients.Remove(emp);
            await _context.SaveChangesAsync();
        }
    }
}
