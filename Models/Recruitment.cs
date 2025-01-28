using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testcrud.Data.Enums;

namespace testcrud.Models
{
    public class Recruitment
    {
    [Key]
    public int Id { get; set; }

    public string Reference { get; set; }

    public string General { get; set; }

    public string ExperienceAlkhaleej { get; set; }

    public string ExperienceKuwait { get; set; }

    public int? VendorId { get; set; }
    [ForeignKey("VendorId")]
    public Vendor Vendor { get; set; }

    public int? JobId { get; set; }
    [ForeignKey("JobId")]
    public JobRecruitment JobRecruitment { get; set; }

    public int? ContractPeriod { get; set; }

    public string FullName { get; set; }

    public int? NationalityId { get; set; }
    [ForeignKey("NationalityId")]
    public Country Nationality { get; set; }

    public int? CityId { get; set; }
    [ForeignKey("CityId")]
    public City City { get; set; }

    public  ReligionEnum Religion { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? Age { get; set; }

    public string PlaceOfBirth { get; set; }

    public string LivingTown { get; set; }

    public MartialStatusEnum MartialStatus { get; set; }

    public int? NoOfChildren { get; set; }

    public int? Weight { get; set; }

    public decimal? Height { get; set; }

    public string Complexion { get; set; }

    public int? EducationalQualificationsGrade { get; set; }

    public LanguageEnum LanguageArabic { get; set; }

    public LanguageEnum LanguageEnglish { get; set; }

    public string PreviousEmploymentAbroadCountry { get; set; }

    public int? PreviousEmploymentAbroadPeriod { get; set; }

    public string WorkExperience { get; set; }

    public string NumberPassport { get; set; }

    public DateTime? DateOfIssuePassport { get; set; }

    public string? PlaceOfIssuePassport { get; set; }

    public DateTime? DateOfExpiryPassport { get; set; }

    public bool Status { get; set; } = true;

    public DateTime? DeletedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
