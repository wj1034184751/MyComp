using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}