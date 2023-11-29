using MediatR;
using Web.Domain;
using Web.Services;

namespace WebApplication1.Applications.Queries
{
    public class CategoryQueryHandle : IRequestHandler<SelectCategory, Category>
    {
        #region Proprietes
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CategoryQueryHandle(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        #endregion
        public Task<Category> Handle(SelectCategory request, CancellationToken cancellationToken)
        {
            var result = _categoryService.Get(request.CategoryId);
            return Task.FromResult(result);
        }
    }
}
