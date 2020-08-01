using System.ComponentModel.DataAnnotations;

namespace Scm.Infra.CrossCutting.Enum
{
    public enum GenderEnum
    {
        [Display(Name = "Rather Not To Say")]
        [EnumValueAsText("Rather Not To Say")]
        RatherNotToSay = 0,

        [Display(Name = "Female")]
        [EnumValueAsText("Female")]
        Female = 1,

        [Display(Name = "Male")]
        [EnumValueAsText("Male")]
        Male = 2,

        [Display(Name = "Nonbinary")]
        [EnumValueAsText("Nonbinary")]
        Nonbinary = 3,

        [Display(Name = "Queer")]
        [EnumValueAsText("Queer")]
        Queer = 4,

        [Display(Name = "Trans")]
        [EnumValueAsText("Trans")]
        Trans = 5,

        [Display(Name = "Other")]
        [EnumValueAsText("Other")]
        Other = 6
    }
}