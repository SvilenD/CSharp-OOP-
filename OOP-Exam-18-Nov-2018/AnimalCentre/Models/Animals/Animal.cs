namespace AnimalCentre.Models.Animals
{
    using System;
    using AnimalCentre.Models.Contracts;

    public abstract class Animal : IAnimal
    {
        private const string DEFAULT_OWNER = "Centre";

        private int energy;
        private int happiness;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = DEFAULT_OWNER;
        }

        public string Name { get; private set; }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Invalid {nameof(Energy).ToLower()}");
                }
                this.energy = value;
            }
        }

        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Invalid {nameof(Happiness).ToLower()}");
                }
                this.happiness = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return $" - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}