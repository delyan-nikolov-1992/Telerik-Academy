namespace TicTacToe.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserInfoDataModel
    {
        [Required]
        public string UserName { get; set; }

        [Range(0, int.MaxValue)]
        public int Wins { get; set; }

        [Range(0, int.MaxValue)]
        public int Looses { get; set; }
    }
}