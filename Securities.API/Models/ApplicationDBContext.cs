using Microsoft.EntityFrameworkCore;

namespace Securities.API.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
    }
}
