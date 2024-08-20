using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.DataAccess.Abstract
{
   public interface IBranchRepository
    {
        List<Branch> GetAllBranches();

        Branch GetBranchById(int id);

        Branch CreateBranch(Branch branch);

        Branch UpdateBranch(Branch branch);

        void DeleteBranch(int id);
    }
}
