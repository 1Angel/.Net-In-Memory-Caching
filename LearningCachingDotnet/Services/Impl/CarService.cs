using LearningCachingDotnet.Data;
using LearningCachingDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LearningCachingDotnet.Services.Impl
{
    public class CarService : ICarService
    {
        private readonly AppdbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string carCacheKey = "secretkeyxd";
        public CarService(AppdbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Cars> Create(Cars vehicles)
        {
            var car = new Cars()
            {
                brand = vehicles.brand,
                Description = vehicles.Description,
                Name = vehicles.Name,
            };

            var create = await _context.cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return create.Entity;
            
        }

        public async Task<Cars> FindById(int id)
        {
            var carId = await _context.cars.FirstOrDefaultAsync(x => x.Id == id);
            return carId;
        }

        public async Task<List<Cars>> Get()
        {

            if(_cache.TryGetValue(carCacheKey, out List<Cars> car))
            {
                return car;
            }

            car = await _context.cars.ToListAsync();
            _cache.Set(carCacheKey, car, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5)).SetSlidingExpiration(TimeSpan.FromSeconds(3)));
            return car;
        }
    }
}
