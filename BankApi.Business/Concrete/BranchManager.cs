using BankApi.Business.Abstract;
using BankApi.DataAccess.Abstract;
using BankApi.DataAccess.Concrete;
using BankApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApi.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private IBranchRepository _branchRepository;

        public BranchManager()
        {
            _branchRepository = new BranchRepository();
        }

        public Branch CreateBranch(Branch branch)
        {
            return _branchRepository.CreateBranch(branch);
        }

        public void DeleteBranch(int id)
        {
            _branchRepository.DeleteBranch(id);
        }

        public Branch GetBranchById(int id)
        {
            return _branchRepository.GetBranchById(id);
        }

        public List<Branch> GetAllBranches()
        {
            return _branchRepository.GetAllBranches();
        }

        public Branch UpdateBranch(Branch branch)
        {
            return _branchRepository.UpdateBranch(branch);
        }

        Branch IBranchService.DeleteBranch(int id)
        {
            throw new NotImplementedException();
        }
    }
}
