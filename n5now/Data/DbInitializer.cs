using n5now.Models;
using n5now.Persistences;

namespace n5now.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();

            if (context.PermissionTypes.Any()) return;

            var permissionTypes = new PermissionTypes[]
            {
                new PermissionTypes{Description="modify"},
                new PermissionTypes{Description="request"},
                new PermissionTypes{Description="get"}
            };
            foreach (PermissionTypes s in permissionTypes)
            {
                context.PermissionTypes.Add(s);
            }
            context.SaveChanges();
        }
    }
}
