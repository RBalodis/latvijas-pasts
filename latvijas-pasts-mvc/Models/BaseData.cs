using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace latvijas_pasts_mvc.Models;


public class BaseData
{
    public enum StudyStatus
    {
        NotApplicable,
        Finished,
        CurrentlyInProgress,
        Stopped
    }
    
    public enum AreaOfEducation
    {
        ComputerScience,
        Biology,
        Arts,
        Engineering,
        Business,
        Law,
        Medicine,
        Mathematics,
        Education,
        Psychology,
        SocialSciences,
        Philosophy,
        Physics,
        Chemistry,
        History,
        Literature,
        Music,
        EnvironmentalScience
    }
    
    public enum LevelOfEducation
    {
        None,
        HighSchool,
        AssociateDegree,
        BachelorDegree,
        MasterDegree,
        Doctorate,
        Diploma,
        Certification
    }
    
    public int Id { get; set; }
    
    [MinLength(3)]
    public string FirstName { get; set; }
    [MinLength(3)]
    public string LastName { get; set; }
    [MinLength(7)]
    public string Email { get; set; }
    [MinLength(8)]
    public string Phone { get; set; }
    
    
    [MinLength(4)]
    public string Country { get; set; }
    [MinLength(3)]
    public string City { get; set; }
    [MinLength(5)]
    public string PostalCode { get; set; }
    [MinLength(5)]
    public string Street { get; set; }
    [MinLength(1)]
    public string StreetNumber { get; set; }
    
    
    [Required]
    public string InstitutionName { get; set; }
    
    public AreaOfEducation EducationArea { get; set; }
    public LevelOfEducation EducationLevel { get; set; }

    public StudyStatus EducationStatus {get; set;} // finished/paused/stopped
    public string TimeSpent { get; set; }
    

    public string JobTitle { get; set; }
    public string JobDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string JobCategory { get; set; }
    public string JobAchievements { get; set; }
    public string JobSkills { get; set; }
    public string JobAdditionalInformation { get; set; }
}


