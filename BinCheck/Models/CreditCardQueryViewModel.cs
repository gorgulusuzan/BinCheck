using System.ComponentModel.DataAnnotations;

namespace BinCheck.Models
{
    public class CreditCardQueryViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [RegularExpression(@"^[0-9]{6,8}", ErrorMessage = "Lütfen geçerli bir kart numarası yazınız")]
        public string CardNumber { get; set; }

    }
}