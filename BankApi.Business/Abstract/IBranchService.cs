using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Abstract
{
    public interface IBranchService
    {
        List<Branch> GetAllBranches();

        Branch GetBranchById(int id);

        Branch CreateBranch(Branch branch);

        Branch UpdateBranch(Branch branch);

        Branch DeleteBranch(int id);
    }
}
