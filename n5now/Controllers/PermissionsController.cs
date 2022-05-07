using Microsoft.AspNetCore.Mvc;
using n5now.DTOs;
using n5now.Models;
using n5now.Services;
using Nest;
using Serilog;

namespace n5now.Controllers
{
    /// <summary>
    /// Controller for permissions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionsService _permissionsService;
        private readonly ElasticClient _client;

        /// <summary>
        /// Controller for permissions
        /// </summary>
        /// <param name="permissionsService"></param>
        /// <param name="clientProvider"></param>
        public PermissionsController(IPermissionsService permissionsService, IESClientProvider clientProvider)
        {
            _permissionsService = permissionsService;
            _client = clientProvider.GetClient();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Log/n5nowlog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        /// <summary>
        /// Rest api to modify, request and get permissions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPermission(Request request)
        {
            Permissions permission = new Permissions(request.EmployeeForename, request.EmployeeSurname, request.PermissionType);
            Response response = _permissionsService.AddPermission(permission);
            if (response.ResponseCode == 1)
            {
                var _permission = new Permissions
                {
                    Id = response.GeneratedId,
                    EmployeeForename = permission.EmployeeForename,
                    EmployeeSurname = permission.EmployeeSurname,
                    PermissionType = permission.PermissionType,
                    PermissionDate = permission.PermissionDate,
                };
                _client.IndexDocument(_permission);
                Log.Debug($"Assigning permission {permission.PermissionType} to {permission.EmployeeForename}, {permission.EmployeeSurname}");
                return Ok(response);
            }
            else
            {
                Log.Error($"Error assigning permission: {response.ResponseMessage}");
                return BadRequest(response);
            }
                
        }

        /// <summary>
        /// Rest api for consult data for elastic search
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IReadOnlyCollection<Permissions> GetAllFromElasticSearch()
        {
            Log.Debug($"Consult data from ElasticSearch");
            return _client.Search<Permissions>(x => x
                .From(0)
                .Size(10))
                .Documents;
        }
    }
}
