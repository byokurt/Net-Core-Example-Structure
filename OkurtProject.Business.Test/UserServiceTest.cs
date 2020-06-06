using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using OkurtProject.Business.Contracts;
using OkurtProject.Business.DTO;
using OkurtProject.Data.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OkurtProject.Data.Entity;
using OkurtProject.Utils.ExceptionHandling;

namespace OkurtProject.Business.Test
{
    [TestFixture]
    [Category("UnitTests.UserServiceTest")]
    public class UserServiceTest
    {
        IServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Substitute.For<IServiceProvider>();
        }
    }
}