namespace E01_EventImplementation
{
    using System;

    public class Dispatcher
    {
        private string name;

        public event EventHandler<NameChangeEventArgs> NameChange;

        public string Name
        {
            get => this.name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnNameChange(new NameChangeEventArgs(value));
                }
            }
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }
}