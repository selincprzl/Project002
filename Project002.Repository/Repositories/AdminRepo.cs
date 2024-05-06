using Microsoft.EntityFrameworkCore;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project002.Repository.Repositories
{
    // AdminRepository.cs
    public class AdminRepo : IAdminRepository
    {
        private readonly Dbcontext _adminRepo;

        public AdminRepo(Dbcontext adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            return await _adminRepo.Admin.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<bool> AuthenticateAdminAsync(string email, string password)
        {
            // Implement your authentication logic here, such as querying the database
            // to check if there is an admin with the provided email and password

            // Example: Check if an admin exists with the provided email and password
            var admin = await _adminRepo.Admin.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);

            // Return true if admin is found, false otherwise
            return admin != null;
        }

        public Task<bool> VerifyPasswordAsync(string password, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
