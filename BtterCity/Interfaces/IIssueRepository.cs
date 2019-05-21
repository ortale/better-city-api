using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BtterCity.Models;

namespace BtterCity.Interfaces
{
    public interface IIssueRepository
    {
        Task<bool> Save(Issue issue);
        Task<IEnumerable> GetAll();
    }
}
