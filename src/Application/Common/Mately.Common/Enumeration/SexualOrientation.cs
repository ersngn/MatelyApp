using System.ComponentModel.DataAnnotations;

namespace Mately.Common.Enumeration;

public enum SexualOrientation
{
    [Display(Name = "Heterosexual", Description = "Heteroseksüel")]
    Heterosexual = 0,

    [Display(Name = "Homosexual", Description = "Homoseksüel")]
    Homosexual = 1,
    
    [Display(Name = "Pansexual", Description = "Panseksüel")]
    Pansexual = 2,
    
    [Display(Name = "Asexual", Description = "Aseksüel")]
    Asexual = 3,
    
    [Display(Name = "Gay", Description = "Gey")]
    Gay = 4,
    
    [Display(Name = "Lesbian", Description = "Lezbiyen")]
    Lesbian = 5,
    
    [Display(Name = "Bisexual", Description = "Biseksüel")]
    Bisexual = 6,
    
    [Display(Name = "Demisexual", Description = "Demiseksüel")]
    Demisexual = 7,
}