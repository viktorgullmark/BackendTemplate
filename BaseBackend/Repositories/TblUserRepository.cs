﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseBackend.DbContexts;

namespace BaseBackend.Repositories
{
    public class TblUserRepository
    {
        private readonly BaseDbContext _dbContext = BaseDbContext.Create();

        public TblUserRepository()
        {   
        }

        public TblUserRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertAsync(tblUser user)
        {
            user.Created = DateTime.Now;
            user.Modified = DateTime.Now;

            _dbContext.tblUser.Add(user);
            _dbContext.SaveChanges();
        }

        public async Task<tblUser> FindByNameAsync(string userName)
        {
            return await _dbContext.tblUser.FirstOrDefaultAsync(x => x.UserName == userName);
        }
        public async Task<tblUser> FindByEmailAsync(string email)
        {
            return await _dbContext.tblUser.FirstOrDefaultAsync(x => x.UserName == email);
        }
        public async Task<tblUser> FindByIdAsync(int userId)
        {
            return await _dbContext.tblUser.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}