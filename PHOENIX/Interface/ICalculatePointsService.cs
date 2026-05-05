using PHOENIX.Models;

namespace PHOENIX.Services
{
    public interface ICalculatePointsService
    {
        double Calculate(TournamentStatus status, int place, int participants);
    }
}