namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const string InvalidDoughType = "Invalid type of dough.";
        private const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> validFlourTypes;
        private Dictionary<string, double> validBakingTechniques;

        public Dough(string flour, string baking, double weight)
        {
            this.validFlourTypes = new Dictionary<string, double>();
            this.validBakingTechniques = new Dictionary<string, double>();
            this.ValidFlours();
            this.ValidBakings();

            this.FlourType = flour;
            this.BakingTechnique = baking;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }

            private set
            {
                if (this.validFlourTypes.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException(InvalidDoughType);
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }

            private set
            {
                if (this.validBakingTechniques.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException(InvalidDoughType);
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return BaseCaloriesPerGram
                    * this.weight
                    * this.validFlourTypes[this.FlourType]
                    * this.validBakingTechniques[this.BakingTechnique];
            }
        }

        private void ValidFlours()
        {
            this.validFlourTypes.Add("white", 1.5);
            this.validFlourTypes.Add("wholegrain", 1.0);
        }

        private void ValidBakings()
        {
            this.validBakingTechniques.Add("crispy", 0.9);
            this.validBakingTechniques.Add("chewy", 1.1);
            this.validBakingTechniques.Add("homemade", 1.0);
        }
    }
}