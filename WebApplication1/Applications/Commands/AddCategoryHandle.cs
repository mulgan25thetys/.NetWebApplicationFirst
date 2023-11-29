using MediatR;
using Web.Domain;
using Web.Services;

namespace WebApplication1.Applications.Commands
{
    public class AddCategoryHandle : IRequestHandler<AddCategoryReq, Category>
    {
        private readonly ICategoryService categoryService;
        public AddCategoryHandle(ICategoryService service) {
            this.categoryService = service;        
        }
        public Task<Category> Handle(AddCategoryReq request, CancellationToken cancellationToken)
        {
            Category category = new Category()
            {
                Name = request.Item.Name,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
            categoryService.Add(category);
            categoryService.Commit();
            return Task.FromResult(category);   
        }
    }
}
