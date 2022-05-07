using n5now.DTOs;
using n5now.Models;

namespace n5now.Services
{
    public interface IPermissionsService
    {
        Response AddPermission(Permissions permissions);
    }
}
