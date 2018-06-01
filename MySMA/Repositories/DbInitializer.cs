using System.Data.Entity;

namespace MySMA.Repositories
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
    {

    }
}