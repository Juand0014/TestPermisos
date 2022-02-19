using Dallas.Services.Tests.Fixtures;
using GenericApi.Bl.Dto;
using GenericApi.Bl.Validations;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenericApi.Services.Test
{
    public class PermissionsServicesTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IPermissionsService _permissionsServices;

        public PermissionsServicesTests(ServicesTestsFixture fixture)
        {
            IPermissionsRepository repository = new PermissionsRepository(fixture.Context);

            var validator = new PermissionsValidator();

            _permissionsServices = new PermissionsServices(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSavePermissionsAsync()
        {
            // Arrange
            var requesDto = new PermissionsDto
            {
                Name = "Juan David",
                LastName = "Matos",
                DatePermission = DateTime.Now
            };

            // Act
            var result = await _permissionsServices.AddAsync(requesDto);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllPermissionsAsync()
        {
            // Act
            var result = await _permissionsServices.GetAllAsync();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdatePermissionsAsync()
        {
            // Arrange
            var id = 1;
            var requesDto = new PermissionsDto
            {
                Id = 1,
                Name = "Pedro",
                LastName = "Martinez",
                DatePermission = DateTime.Today.AddDays(1)
            };  

            // Act
            var result = await _permissionsServices.UpdateAsync(id, requesDto);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requesDto.Name, result.Entity.Name);
        }

        [Fact]
        public async Task ShouldDeletePermissionsAsync()
        {
            // Arrange
            var id = 2;

            // Act
            var result = await _permissionsServices.DeleteByIdAsync(id);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }

        [Fact]
        public async Task ShouldGetByIdPermissionsAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _permissionsServices.GetByIdAsync(id);

            // Assert
            Assert.Equal(result.Id, id);
        }
    }
}   
