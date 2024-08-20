using BankApi.DataAccess.Abstract;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApi.DataAccess.Concrete
{
    public class BranchRepository : IBranchRepository
    {
        public Branch CreateBranch(Branch branch)
        {
            using (var branchDbContext = new BranchDbContext())
            {
                branchDbContext.Branches.Add(branch);
                branchDbContext.SaveChanges();
                return branch;
            }
        }
        public void DeleteBranch(int id)
        {
            using (var branchDbContext = new BranchDbContext())
            {
                var deleteBranch = GetBranchById(id);
                branchDbContext.Branches.Remove(deleteBranch);
                branchDbContext.SaveChanges();
            }
        }

        public List<Branch> GetAllBranches()
        {
            using (var branchDbContext = new BranchDbContext())
            {
                return branchDbContext.Branches.ToList();
            }
        }

        public Branch GetBranchById(int id)
        {
            using (var branchDbContext = new BranchDbContext())
            {
                return branchDbContext.Branches.Find(id);
            }
        }
        public Branch UpdateBranch(Branch branch)
        {
            using (var branchDbContext = new BranchDbContext())
            {
                branchDbContext.Branches.Update(branch);
                return branch;
            }
        }
    }
}