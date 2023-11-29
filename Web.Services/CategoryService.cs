using Web.Data.Infrastructures;
using Web.Domain;
using Web.Services.DTO;

namespace Web.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOf) : base(unitOf)
        {
        }
    }
}
