using MediatR;
using Web.Domain;
using Web.Services.DTO;

namespace WebApplication1.Applications.Commands
{
    public class AddCategoryReq : IRequest<Category>
    {
        #region Proprietes
        public CategoryDto Item { get; set; }
        #endregion
    }
}
