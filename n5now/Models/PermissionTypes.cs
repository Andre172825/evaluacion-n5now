using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace n5now.Models
{
    public class PermissionTypes
    {
        [Key]
        public int PermissionTypesId { get; set; }
        public string? Description { get; set; }
        public ICollection<Permissions>? Permissions { get; set; }
    }
}
