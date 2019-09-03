namespace E01_EventImplementation
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs eventArgs);

    public class Dispatcher
    {
        private string name;

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

        public event NameChangeEventHandler NameChange;

        private void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }
}