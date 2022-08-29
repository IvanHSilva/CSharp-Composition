namespace Composition.Entities {
    public class Department {
        //attributes
        public string Name { get; set; }

        //constructors
        public Department() { }

        public Department(string name) {
            Name = name;
        }
    }
}
