namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Department
    {
        private const int capacity = 20;
        private int roomsIndex;

        public Department(string name)
        {
            this.Name = name;
            this.roomsIndex = 1;
            this.Rooms = new Dictionary<int, Room>(capacity);
            Rooms.Add(roomsIndex, new Room());
        }

        public string Name { get; }

        public Dictionary<int, Room> Rooms { get; }

        public void AddPatient(string patient)
        {
            if (this.Rooms[roomsIndex].HasFreeBed())
            {
                this.Rooms[roomsIndex].Add(patient);
            }
            else if (this.Rooms.Count <= capacity)
            {
                var room = new Room();
                roomsIndex++;
                this.Rooms.Add(roomsIndex, room);
                this.Rooms[roomsIndex].Add(patient);
            }
        }

        public bool IsNotFull()
        {
            if (this.roomsIndex <= capacity || this.Rooms[capacity - 1].HasFreeBed())
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"{string.Join(Environment.NewLine, this.Rooms.Values)}");
            return result.ToString().TrimEnd();
        }
    }
}