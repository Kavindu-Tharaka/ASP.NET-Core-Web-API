using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using ResturentAPI.Data;
using ResturentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturentAPI.Repositories.Resturant
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ResturantRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddResturant(Handlers.Resturant.AddResturant.ResturantModel resturantModel)
        {
            var resturant = mapper.Map<Data.Resturant>(resturantModel);   //mehema harida?  //swagger walin test karaddi add nam una

            context.Resturants.Add(resturant);
            await context.SaveChangesAsync();

            return resturant.Id;
        }

        public async Task DeleteResturant(int resturantId)
        {
            var resturant = new Data.Resturant() { Id = resturantId };
            context.Resturants.Remove(resturant);
            await context.SaveChangesAsync();
        }

        public async Task<List<Handlers.Resturant.GetAllResturants.ResturantModel>> GetAllResturants()
        {
            var records = await context.Resturants.Include(resturant => resturant.Products).ToListAsync();

            return mapper.Map<List<Handlers.Resturant.GetAllResturants.ResturantModel>>(records);
        }

        public async Task<Handlers.Resturant.GetResturantById.ResturantModel> GetResturantById(int id)
        {
            var resturant = await context.Resturants.Include(resturant => resturant.Products).FirstOrDefaultAsync(pc => pc.Id.Equals(id));
            return mapper.Map<Handlers.Resturant.GetResturantById.ResturantModel>(resturant);
        }

        public async Task UpdateResturant(int resturantId, JsonPatchDocument document)
        {
            var resturant = await context.Resturants.FindAsync(resturantId);
            if (resturant != null)
            {
                document.ApplyTo(resturant);
                await context.SaveChangesAsync();
            }
        }
    }
}
