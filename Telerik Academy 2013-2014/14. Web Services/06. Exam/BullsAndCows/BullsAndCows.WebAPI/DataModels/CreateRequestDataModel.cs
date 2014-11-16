namespace BullsAndCows.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRequestDataModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }
    }
}