using System.ComponentModel.DataAnnotations;

namespace Mately.Common.Enumeration;

public enum Horoscope
{
    [Display(Name = "Koç", Description = "Koç")]
    Aries = 0,

    [Display(Name = "Leo", Description = "Aslan")]
    Leo = 1,

    [Display(Name = "Sagittarius", Description = "Yay")]
    Sagittarius = 2,

    [Display(Name = "Taurus", Description = "Boğa")]
    Taurus = 3,

    [Display(Name = "Virgo", Description = "Başak")]
    Virgo = 4,

    [Display(Name = "Capricorn", Description = "Oğlak")]
    Capricorn = 0,

    [Display(Name = "Gemini", Description = "Ikizler")]
    Gemini = 0,

    [Display(Name = "Libra", Description = "Terazi")]
    Libra = 0,

    [Display(Name = "Aquarius", Description = "Kova")]
    Aquarius = 0,

    [Display(Name = "Cancer", Description = "Yengeç")]
    Cancer = 0,

    [Display(Name = "Scorpio", Description = "Akrep")]
    Scorpio = 0,

    [Display(Name = "Pisces", Description = "Balık")]
    Pisces = 0,
}