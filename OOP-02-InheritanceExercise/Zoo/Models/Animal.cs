namespace Zoo.Models
{
    public class Animal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value !=null)
                {
                    this.name = value;
                }
            }
        }
    }
}