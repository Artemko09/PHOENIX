using PHOENIX.Interface;
using PHOENIX.Models;

namespace PHOENIX.Services
{
    public class CalculatePointsService : ICalculatePointsService
    {
        public double Calculate(TournamentStatus status, int place, int participants)
        {
            // 1. Коефіцієнт статусу змагань (Колонка 1-2)
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

            // 2. Спеціальні випадки: Збори та Атестація (фіксовано 50 балів)
            if (status == TournamentStatus.TrainingCamp || status == TournamentStatus.Attestation)
            {
                return 50.0 * statusCoeff;
            }

            // 3. Базові бали за місце (Колонка 3-4)
            double basePoints = place switch
            {
                1 => 100,
                2 => 75,
                3 => 50,
                5 => 35,
                7 => 30,
                9 => 25,
                11 => 20,
                0 => 15, // "У" (участь) кодуємо як 0
                _ => 0
            };

            // 4. Коефіцієнт кількості учасників (Колонка 5-6)
            double participantsCoeff = participants switch
            {
                < 5 => 1.0,
                <= 8 => 1.2,
                <= 16 => 1.4,
                <= 32 => 1.6,
                <= 64 => 1.8,
                _ => 2.0 // Більше 65
            };

            // Підсумкова формула
            return basePoints * statusCoeff * participantsCoeff;
        }
    }
}