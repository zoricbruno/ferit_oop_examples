using System;
using System.Collections.Generic;

namespace Examples.Examples_Av6.Dogs
{
    public class DogShelter
    {
        private List<Dog> dogs;

        public DogShelter()
        {
            this.dogs = new List<Dog>();
        }

        public DogShelter(DogShelter shelter): this()
        {
            // Shallow copy:
            // this.dogs = shelter.dogs

            // Deep copy:
            foreach (Dog dog in shelter.dogs)
            {
                Dog copy = new Dog(dog.Name, dog.Breed, dog.Age);
                this.dogs.Add(copy);
            }
        }

        public void Add(Dog dog)
        {
            this.dogs.Add(dog);
        }

        public void Adopt(string name)
        {            
            int adoptableDogs = 0;
            int adoptableDogIndex = 0;
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs[i].Name == name) 
                {
                    adoptableDogs++;
                    adoptableDogIndex = i;
                }
            }
            if (adoptableDogs == 0)
                throw new ArgumentException($"Cannot adopt dog with name {name}, no such dog.");
            if (adoptableDogs > 1)
                throw new ArgumentException($"Cannot adopt dog with name {name}, multiple such dogs.");
            dogs.RemoveAt(adoptableDogIndex);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, dogs);
        }
    }
}
