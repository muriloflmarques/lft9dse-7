namespace Scm.Infra.CrossCutting.Enum
{
    public enum GenderEnum
    {
        [EnumValueAsText("Rather Not To Say")]
        RatherNotToSay = 100,

        [EnumValueAsText("Female")]
        Female = 0,

        [EnumValueAsText("Male")]
        Male = 1,

        [EnumValueAsText("Nonbinary")]
        Nonbinary = 2,

        [EnumValueAsText("Queer")]
        Queer = 3,

        [EnumValueAsText("Trans")]
        Trans = 4,

        [EnumValueAsText("Other")]
        Other = 5
    }
}