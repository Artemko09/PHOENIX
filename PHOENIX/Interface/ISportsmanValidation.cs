using PHOENIX.Models;

namespace PHOENIX.Interface
{
    public interface ISportsmanValidation
    {
        Task<List<string>> ValidateSportsmanAsync(ApplicationUser sportsman);
    }
}
