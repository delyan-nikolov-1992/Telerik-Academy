namespace BullsAndCows.Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameResult
    {
        [Required]
        public GameResultType GameResultType { get; set; }

        [Range(0, 4)]
        public int Cows { get; set; }

        [Range(0, 4)]
        public int Bulls { get; set; }
    }
}