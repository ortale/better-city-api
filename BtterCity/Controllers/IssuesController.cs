using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BtterCity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using BtterCity.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BtterCity.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueRepository _repository;

        public IssuesController(IIssueRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            var issues = await _repository.GetAll();

            return new OkObjectResult(issues);
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
        public async Task<IActionResult> AddIssue([FromBody] Issue issue)
        {
            var result = await _repository.Save(issue);

            return new OkObjectResult(result);
        }
    }
}
