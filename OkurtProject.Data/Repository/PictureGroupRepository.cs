using OkurtProject.Data.Contracts;
using OkurtProject.Data.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace OkurtProject.Data
{
    public class PictureGroupRepository : BaseRepository<PictureGroup>, IPictureGroupRepository
    {
        public PictureGroupRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
