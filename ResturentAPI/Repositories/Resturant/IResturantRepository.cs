using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.Resturant
{
    public interface IResturantRepository
    {
        Task<List<Handlers.Resturant.GetAllResturants.ResturantModel>> GetAllResturants();
        Task<Handlers.Resturant.GetResturantById.ResturantModel> GetResturantById(int id);
        Task<int> AddResturant(Handlers.Resturant.AddResturant.ResturantModel resturantModel);
        Task UpdateResturant(int resturantId, JsonPatchDocument document);
        Task DeleteResturant(int resturantId);
    }
}
