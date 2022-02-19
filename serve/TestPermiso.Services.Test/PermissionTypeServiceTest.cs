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
    public class PermissionTypeServicesTests : IClassFixture<ServicesTestsFixture>
    {
        private readonly IPermissionTypeService _permissionTypeServices;

        public PermissionTypeServicesTests(ServicesTestsFixture fixture)
        {
            IPermissionTypeRepository repository = new PermissionTypeRepository(fixture.Context);

            var validator = new PermissionTypeValidator();

            _permissionTypeServices = new PermissionTypeServices(repository, fixture.Mapper, validator);
        }

        [Fact]
        public async Task ShouldSavePermissionTypeAsync()
        {
            // Arrange
            var requesDto = new PermissionTypeDto
            {
                Description = "Hi my friends"
            };

            // Act
            var result = await _permissionTypeServices.AddAsync(requesDto);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ShouldGetAllPermissionTypeAsync()
        {
            // Act
            var result = await _permissionTypeServices.GetAllAsync();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task ShouldUpdatePermissionTypeAsync()
        {
            // Arrange
            var id = 1;
            var requesDto = new PermissionTypeDto
            {
                Id = 1,
                Description = "Very Good"
            };  

            // Act
            var result = await _permissionTypeServices.UpdateAsync(id, requesDto);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.Equal(requesDto.Description, result.Entity.Description);
        }

        [Fact]
        public async Task ShouldDeletePermissionTypeAsync()
        {
            // Arrange
            var id = 2;

            // Act
            var result = await _permissionTypeServices.DeleteByIdAsync(id);

            // Assert
            Assert.True(result.IsSuccess, result.Errors.FirstOrDefault());
            Assert.NotNull(result.Entity);
            Assert.True(result.Entity.Deleted);
        }

        [Fact]
        public async Task ShouldGetByIdPermissionTypeAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _permissionTypeServices.GetByIdAsync(id);

            // Assert
            Assert.Equal(result.Id, id);
        }
    }
}   
