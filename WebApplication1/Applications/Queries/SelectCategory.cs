using MediatR;
using Web.Domain;

namespace WebApplication1.Applications.Queries
{
    public class SelectCategory : IRequest<Category>
    {
        #region Proprietes
        public int CategoryId { get; set; }
        #endregion
    }
}
