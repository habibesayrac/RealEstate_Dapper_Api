using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        //void CreatePopularLocation(CreateCategoryDto categoryDto);
        //void DeleteCategoryPopularLocation(int id);
        //void UpdatePopularLocation(UpdateCategoryDto categoryDto);
        //Task<GetByIDCategoryDto> GetPopularLocation(int id);
    }
}
