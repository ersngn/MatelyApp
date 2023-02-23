using System.ComponentModel.DataAnnotations;

namespace Mately.Common.Enumeration;

public enum EducationLevel
{
    [Display(Name = "Primary School", Description = "İlkokul")]
    Primary = 0,

    [Display(Name = "High School", Description = "Lise")]
    High = 1,
    
    [Display(Name = "Bachelors", Description = "Üniversite")]
    Bachelors = 1,
    
    [Display(Name = "Masters", Description = "Yüksek Lisans")]
    Masters = 1,
    
    [Display(Name = "Doctoral", Description = "Doktora")]
    Doctoral = 1,
    
    
}