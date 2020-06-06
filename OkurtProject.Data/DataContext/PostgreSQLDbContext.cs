using Microsoft.EntityFrameworkCore;
using OkurtProject.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkurtProject.Data
{
    public class PostgreSQLDbContext : BaseDataContext, IPostgreSQLDbContext
    {
        public PostgreSQLDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
