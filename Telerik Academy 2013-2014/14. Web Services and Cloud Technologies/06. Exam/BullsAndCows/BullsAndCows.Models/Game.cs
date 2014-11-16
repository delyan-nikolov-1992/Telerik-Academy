namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public ICollection<GuessNumber> guessNumbers;

        public Game()
        {
            this.guessNumbers = new HashSet<GuessNumber>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string RedPlayerID { get; set; }

        public virtual Player RedPlayer { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string RedPlayerNumber { get; set; }

        public string BluePlayerID { get; set; }

        public virtual Player BluePlayer { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string BluePlayerNumber { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<GuessNumber> GuessNumbers
        {
            get
            {
                return this.guessNumbers;
            }

            set
            {
                this.guessNumbers = value;
            }
        }
    }
}