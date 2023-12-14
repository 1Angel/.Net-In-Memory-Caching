using LearningCachingDotnet.Models;

namespace LearningCachingDotnet.Services
{
    public interface ICarService
    {
        Task<List<Cars>> Get();
        Task<Cars> FindById(int id);
        Task<Cars> Create(Cars vehicles);
    }
}
