using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;

namespace Fina.Core.Handlers
{
    public interface ICategoryHandler
    {
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest request);
        Task<Response<Category?>> DelateAsync(DeleteCategoryRequest request);
        Task<Response<Category?>> UpdateAsync(UpdatedCategoryRequest request);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request);
        Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request);
    }
}
