using System;
using System.Collections;
using System.Threading.Tasks;
using BtterCity.Models;

namespace BtterCity.Interfaces
{
    public interface IIssueTypeRepository
    {
        Task<bool> Save(IssueType issueType);
        Task<IEnumerable> GetAll();
    }
}
