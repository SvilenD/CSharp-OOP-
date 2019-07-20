namespace FamilyTree
{
    public class Relationship
    {
        public Relationship(Person parent, Person child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public Person Parent { get; }
        public Person Child { get; }
    }
}