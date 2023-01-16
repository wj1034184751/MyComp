using Microsoft.EntityFrameworkCore; 
using YuanTu.Platform.UC;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<UCBlog> UCBlog { get; set; }

        public DbSet<UCCatalog> UCCatalog { get; set; }
    }
}