using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Domain;
using Web.Services;
using Web.Services.DTO;
using WebApplication1.Applications.Commands;
using WebApplication1.Applications.Queries;
using WebApplication1.Controllers.Security;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors(SecurityCors.DEFAULT_POLICY_2)]
    public class CategoriesController : Controller
    {
        readonly ICategoryService categoryService;
        private readonly IMediator mediatR;
        private ILogger<CategoriesController> _logger;
        public CategoriesController(ILogger<CategoriesController> logger, IMediator mediator, ICategoryService categoryService) { 
            this.categoryService = categoryService;
            this.mediatR = mediator;
            this._logger = logger;

            this._logger.LogDebug("W's are degugging!");
            _logger.LogWarning("logging wanibh");
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                return Ok(categoryService.GetAll());
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCategory(CategoryDto item)
        {
            try
            {
                var result = await this.mediatR.Send(new AddCategoryReq() { Item = item });
                return result == null ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message, ex);
                return this.Problem(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
               var result = this.mediatR.Send(new SelectCategory() { CategoryId = id });
                return result == null ? NotFound() : this.Ok(result);
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
