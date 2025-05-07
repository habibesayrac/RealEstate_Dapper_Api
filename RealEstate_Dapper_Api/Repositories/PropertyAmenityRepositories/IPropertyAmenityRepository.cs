using RealEstate_Dapper_Api.Models.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {
       Task<List<ResultPropertyAmenityStatusByTrueDto>> ResultPropertyAmenityStatusByTrue(int id);
    }
}