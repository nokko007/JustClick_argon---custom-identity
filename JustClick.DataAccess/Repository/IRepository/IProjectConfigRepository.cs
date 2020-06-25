using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface IProjectConfigRepository : IRepository<ProjectConfigModel>
    {

        void Update(ProjectConfigModel ProjectConfig);
    }
}
