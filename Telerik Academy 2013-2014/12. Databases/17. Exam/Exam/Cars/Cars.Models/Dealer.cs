namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Dealer
    {
        private ICollection<Car> cars;
        private ICollection<City> cities;

        public Dealer()
        {
            this.cars = new HashSet<Car>();
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars
        {
            get
            {
                return this.cars;
            }

            set
            {
                this.cars = value;
            }
        }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }

            set
            {
                this.cities = value;
            }
        }
    }
}