using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PHOENIX.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Назва турніру/події")]
        public string Title { get; set; }

        [Display(Name = "Статус змагань")]
        public TournamentStatus Status { get; set; }

        [Display(Name = "Зайняте місце")]
        public int Place { get; set; } // 1, 2, 3, 5, 7, 9, 11 або 0 для "У" (участь)

        [Display(Name = "Кількість учасників у категорії")]
        public int ParticipantsCount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "Нараховані бали")]
        public double PointsEarned { get; set; }
    }

    public enum TournamentStatus
    {
        [Display(Name = "Навчально-тренувальні збори")] TrainingCamp,
        [Display(Name = "Атестаційний екзамен на КЮ")] Attestation,
        [Display(Name = "Чемпіонат області")] OblastChamp,
        [Display(Name = "Кубок області")] OblastCup,
        [Display(Name = "Серія А УКФ")] SeriesA_UKF,
        [Display(Name = "Прем'єр Ліга УКФ")] PremierLeague_UKF,
        [Display(Name = "Кубок України")] Cup_UA,
        [Display(Name = "Чемпіонат України")] Champ_UA,
        [Display(Name = "Міжнародний турнір")] International,
        [Display(Name = "Karate1 Youth League")] YouthLeague,
        [Display(Name = "Karate1 Series A")] SeriesA_WKF,
        [Display(Name = "Karate1 Premier League")] Premier_WKF,
        [Display(Name = "European Championship")] EuropeChamp,
        [Display(Name = "World Championship")] WorldChamp
    }
}
