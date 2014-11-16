namespace BullsAndCows.Models
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.Wins = 0;
            this.Looses = 0;
        }

        public int Id { get; set; }

        public string PlayerID { get; set; }

        public virtual Player Player { get; set; }

        public uint Looses { get; set; }

        public uint Wins { get; set; }

        public uint Rank
        {
            get
            {
                return (this.Wins * 100) + (this.Looses * 15);
            }
        }
    }
}