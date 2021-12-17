namespace Examples.Examples_Av6.Dogs
{   
    public class Dog
    {
        private string name;
        private string breed;
        private int age;

        public Dog(string name, string breed, int age)
        {
            this.name = name;
            this.breed = breed;
            this.age = age;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"Dog {Name} of breed {Breed} is {Age} years old";
        }
    }
}