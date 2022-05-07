using n5now.DTOs;
using n5now.Models;
using n5now.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5now.Tests.ServicesTest
{
    public class PermissionsServicesFake : IPermissionsService
    {
        private readonly List<PermissionTypes> permissionTypes;
        private readonly List<Permissions> permissionsM;

        public PermissionsServicesFake()
        {
            permissionTypes = new List<PermissionTypes>()
            {
                new PermissionTypes{PermissionTypesId = 1, Description="modify"},
                new PermissionTypes{PermissionTypesId = 2, Description="request"},
                new PermissionTypes{PermissionTypesId = 3, Description="get"}
            };
            permissionsM = new List<Permissions>()
            {
                new Permissions{ Id = 1, EmployeeForename = "Luis", EmployeeSurname = "Tolentino", PermissionType = 1, PermissionDate = DateTime.Now},         
            };
        }
       
        public Response AddPermission(Permissions permissions)
        {
            try
            {
                var validator = Validators(permissions);
                if (validator.isCorrect)
                {
                    permissionsM.Add(permissions);
                    return new Response
                    {
                        ResponseCode = 1,
                        ResponseMessage = validator.message,
                        GeneratedId = permissions.Id
                    };
                }

                return new Response
                {
                    ResponseCode = 0,
                    ResponseMessage = validator.message,
                    GeneratedId = 0
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    ResponseCode = 0,
                    ResponseMessage = ex.Message,
                    GeneratedId = 0
                };
            }
            
        }
        public (bool isCorrect, string message) Validators(Permissions permissions)
        {
            // If data is null
            if (permissions == null)
                return (false, "empty data");

            // If type doesn't exists
            var type = permissionTypes.Where(x => x.PermissionTypesId == permissions.PermissionType).FirstOrDefault();
            if (type == null)
                return (false, "PermissionType doesn't exists");

            // If surname or forename is empty
            if (string.IsNullOrEmpty(permissions.EmployeeSurname) || string.IsNullOrEmpty(permissions.EmployeeForename))
                return (false, "surname or forname cannot be empty");

            // if everything is correct
            return (true, "successful operation");
        }
    }
}
