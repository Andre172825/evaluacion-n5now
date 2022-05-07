using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace n5now.Models
{
    [Table("Permissions")]
    public class Permissions
    {
        public Permissions()
        {

        }
        public Permissions(string? employeeForename, string? employeeSurname, int permissionType)
        {
            EmployeeForename = employeeForename;
            EmployeeSurname = employeeSurname;
            PermissionType = permissionType;
            PermissionDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string? EmployeeForename { get; set; }
        public string? EmployeeSurname { get; set; }
        [ForeignKey("PermissionTypes")]
        public int PermissionType { get; set; }
        public PermissionTypes? PermissionTypes { get; set; }
        [NotMapped]
        public DateTime PermissionDate { get; set; }
    }
}
