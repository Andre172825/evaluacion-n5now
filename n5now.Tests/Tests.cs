using Microsoft.AspNetCore.Mvc;
using n5now.Controllers;
using n5now.DTOs;
using n5now.Models;
using n5now.Services;
using n5now.Tests.ServicesTest;
using Xunit;

namespace n5now.Tests
{
    public class Tests
    {
        private readonly PermissionsController _permissionsController;
        private readonly IPermissionsService _permissionsService;
        private readonly IESClientProvider _clientProvider;

        public Tests()
        {
            _permissionsService = new PermissionsServicesFake();
            _clientProvider = new ESClientProviderFake();
            _permissionsController = new PermissionsController(_permissionsService, _clientProvider);
        }

        [Fact]
        public void AddPermission_ShouldReturnBadRequest1()
        {
            //Arrange
            var request = new Request
            {
                EmployeeForename = "",
                EmployeeSurname = "",
                PermissionType = 2
            };
            var permission = new Permissions(request.EmployeeForename, request.EmployeeSurname, request.PermissionType);

            ////Act
            var result = _permissionsController.AddPermission(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result as ObjectResult);
        }

        [Fact]
        public void AddPermission_ShouldReturnBadRequest2()
        {
            //Arrange
            var request = new Request
            {
                EmployeeForename = "Guillermo",
                EmployeeSurname = "Burga",
                PermissionType = 8
            };
            var permission = new Permissions(request.EmployeeForename, request.EmployeeSurname, request.PermissionType);

            ////Act
            var result = _permissionsController.AddPermission(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result as ObjectResult);
        }

        [Fact]
        public void AddPermission_ShouldReturnOkRequest()
        {
            //Arrange
            var request = new Request
            {
                EmployeeForename = "Angel",
                EmployeeSurname = "Sotelo",
                PermissionType = 2
            };
            var permission = new Permissions(request.EmployeeForename, request.EmployeeSurname, request.PermissionType);

            ////Act
            var result = _permissionsController.AddPermission(request);

            //Assert
            Assert.IsType<OkObjectResult>(result as ObjectResult);
        }
    }
}