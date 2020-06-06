using OkurtProject.Data.Contracts;
using OkurtProject.Data.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace OkurtProject.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
