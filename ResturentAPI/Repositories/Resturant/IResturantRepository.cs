using Microsoft.AspNetCore.JsonPatch;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.Resturant
{
    public interface IResturantRepository
    {
        Task<List<ResturantModel>> GetAllResturants();
        Task<ResturantModel> GetResturantById(int id);
        Task<int> AddResturant(ResturantModel resturantModel);
        Task UpdateResturant(int resturantId, JsonPatchDocument document);
        Task DeleteResturant(int resturantId);
    }
}
