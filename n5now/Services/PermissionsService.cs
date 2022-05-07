using n5now.DTOs;
using n5now.Models;
using n5now.Persistences;

namespace n5now.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly ContextDatabase _contextDatabase;
        public PermissionsService(ContextDatabase contextDatabase) => _contextDatabase = contextDatabase;
        public Response AddPermission(Permissions permissions)
        {
            try
            {               
                var validator = Validators(permissions);
                if (validator.isCorrect)
                {
                    _contextDatabase.Permissions.Add(permissions);
                    _contextDatabase.SaveChanges();
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
            catch(Exception ex)
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
            var type = _contextDatabase.PermissionTypes.Where(x => x.PermissionTypesId == permissions.PermissionType).FirstOrDefault();
            if (type == null)
                return (false, "PermissionType doesn't exists");

            // If surname or forename is empty
            if(string.IsNullOrEmpty(permissions.EmployeeSurname) || string.IsNullOrEmpty(permissions.EmployeeForename))
                return (false, "surname or forname cannot be empty");

            // if everything is correct
            return (true, "successful operation");
        }
    }
}
