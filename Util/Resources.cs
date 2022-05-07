using n5now.DTOs;
using n5now.Models;

namespace Util
{
    public class Resources
    {
        public static List<Permissions> GetTestPermissions()
        {
            var permissions = new List<Permissions>();
            permissions.Add(new Permissions()
            {
                Id = 1,
                EmployeeForename = "Luis",
                EmployeeSurname = "Tolentino",
                PermissionType = 1,
                PermissionDate = DateTime.Now,
            });
            permissions.Add(new Permissions()
            {
                Id = 1,
                EmployeeForename = "José",
                EmployeeSurname = "Tolentino",
                PermissionType = 2,
                PermissionDate = DateTime.Now,
            });
            permissions.Add(new Permissions()
            {
                Id = 1,
                EmployeeForename = "Maria",
                EmployeeSurname = "Castro",
                PermissionType = 3,
                PermissionDate = DateTime.Now,
            });
            permissions.Add(new Permissions()
            {
                Id = 1,
                EmployeeForename = "Jhosy",
                EmployeeSurname = "Yarleque",
                PermissionType = 2,
                PermissionDate = DateTime.Now,
            });
            return permissions;
        }

        public static Response GetTestEmptyResponse()
        {
            return new Response
            {
                ResponseCode = 0,
                ResponseMessage = "empty data",
                GeneratedId = 0
            };
        }
    }
}