using System.Collections.Generic;
using System.Threading.Tasks;
using HelpApp.Application.DTOs;

namespace HelpApp.Application.Interfaces
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task Add(CategoryDTO categoryDto);
        Task Update(CategoryDTO categoryDto);
        Task Remove(int? id);
    }
}
