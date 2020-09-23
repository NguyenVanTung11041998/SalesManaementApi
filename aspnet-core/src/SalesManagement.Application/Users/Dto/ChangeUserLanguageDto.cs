using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}