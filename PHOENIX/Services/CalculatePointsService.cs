using PHOENIX.Interface;
using PHOENIX.Models;

namespace PHOENIX.Services
{
    public class CalculatePointsService : ICalculatePointsService
    {
        public double Calculate(TournamentStatus status, int place, int participants)
        {
            double statusCoeff = status switch
            {
                TournamentStatus.TrainingCamp or TournamentStatus.Attestation or
                TournamentStatus.OblastChamp or TournamentStatus.OblastCup => 1.0,
                TournamentStatus.SeriesA_UKF => 2.0,
                TournamentStatus.PremierLeague_UKF => 3.0,
                TournamentStatus.Cup_UA => 4.0,
                TournamentStatus.Champ_UA or TournamentStatus.International => 5.0,
                TournamentStatus.YouthLeague => 10.0,
                TournamentStatus.SeriesA_WKF => 15.0,
                TournamentStatus.Premier_WKF => 20.0,
                TournamentStatus.EuropeChamp => 25.0,
                TournamentStatus.WorldChamp => 30.0,
                _ => 1.0
            };

            if (status == TournamentStatus.TrainingCamp || status == TournamentStatus.Attestation)
            {
                return 50.0 * statusCoeff;
            }

            double basePoints = place switch
            {
                1 => 100,
                2 => 75,
                3 => 50,
                5 => 35,
                7 => 30,
                9 => 25,
                11 => 20,
                0 => 15, 
                _ => 0
            };

            double participantsCoeff = participants switch
            {
                < 5 => 1.0,
                <= 8 => 1.2,
                <= 16 => 1.4,
                <= 32 => 1.6,
                <= 64 => 1.8,
                _ => 2.0 
            };

            return basePoints * statusCoeff * participantsCoeff;
        }
    }
}