using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using GenericApi.Model.Contexts;
using GenericApi.Core.Settings;
using System;
using GenericApi.Bl.Mapper;
using Dallas.Services.Tests.Data;

namespace Dallas.Services.Tests.Fixtures
{

    public class ServicesTestsFixture : ServicesTestsData, IDisposable
    {
        private const string _dbName = "TestPermissions";
        public DbContextOptionsBuilder<GenericDbContext> OptionsBuilder { get; private set; }

        public GenericDbContext Context { get; private set; }
        public IMapper Mapper;

        public ServicesTestsFixture()
        {
            #region Automapper

            Mapper = new MapperConfiguration(x => x.AddProfile<MainProfile>()).CreateMapper();

            #endregion

            #region Repository

            OptionsBuilder = new DbContextOptionsBuilder<GenericDbContext>();
            OptionsBuilder.UseInMemoryDatabase(_dbName);

            Context = new GenericDbContext(OptionsBuilder.Options);

            Context.Permissions.AddRange(_permissions, _permissions2);
            Context.PermissionType.AddRange(_permissionType, _permissionType2);

            Context.SaveChanges();

            #endregion
        }
 
        public void Dispose()
        {
            Console.WriteLine("Disposing");
        }
    }
}