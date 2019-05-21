using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BtterCity.Interfaces;
using BtterCity.Models;
using Microsoft.AspNetCore.Mvc;

namespace BtterCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypesController : ControllerBase
    {
        private readonly IIssueTypeRepository _repository;

        public IssueTypesController(IIssueTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueType>>> GetIssueTypes()
        {
            var issueTypes = await _repository.GetAll();

            return new OkObjectResult(issueTypes);
        }

        // GET: api/Todo/5
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(long id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }
        */

        // POST: api/Issue
        [HttpPost]
        public async Task<IActionResult> AddIssueType([FromBody] IssueType issueType)
        {
            var result = await _repository.Save(issueType);

            return new OkObjectResult(result);
        }
    }
}
