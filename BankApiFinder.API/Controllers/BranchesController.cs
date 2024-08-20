using BankApi.Business.Abstract;
using BankApi.Business.Concrete;
using BankApi.Entities;
using BankApiFinder.API.Fake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BankApiFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private IBranchService _branchService;
        public BranchesController()
        {
            _branchService = new BranchManager();
        }
        private List<Branch> _branches = FakeDataBranch.GetBranches();
        [HttpGet]
        public List<Branch> Get()
        {
            return _branches;
        }

        [HttpGet("{id}")]
        public Branch Get(int id)
        {
            var branch = _branches.FirstOrDefault(x => x.Id == id);
            return branch;
        }

        [HttpPost]
        public Branch Post([FromBody] Branch branch)
        {
            _branches.Add(branch);
            return branch;
        }

        [HttpPut]
        public Branch Put([FromBody] Branch branch)
        {
            var editedBranch = _branches.FirstOrDefault(x => x.Id == branch.Id);
            editedBranch.branch_name = branch.branch_name;
            editedBranch.phone_number = branch.phone_number;
            editedBranch.email = branch.email;
            editedBranch.location = branch.location;
            editedBranch.status = branch.status;
            return branch;
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteBranch = _branches.FirstOrDefault(x => x.Id == id);
            _branches.Remove(deleteBranch);
        }
    }
}
