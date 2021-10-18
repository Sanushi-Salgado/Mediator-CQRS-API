using System.ComponentModel.DataAnnotations;

namespace NETDemo.Data.Models.RequestModels
{
    public class AddCustomerModel
    {

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 2)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 7)]
        public string ContactNo { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }

    }
}
