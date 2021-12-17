namespace Examples.Examples_Av6.Dogs
{
    public static class Example1_1
    {
        public static void Run()
        {
            DogShelter original = new DogShelter();
            original.Add(new Dog("Rex", "German sheperd", 3));
            original.Add(new Dog("Fido", "Golden retriever", 6));
            original.Add(new Dog("Max", "Border collie", 6));
            
            DogShelter copy = new DogShelter(original);
            
            System.Console.WriteLine("Shelter:");
            System.Console.WriteLine(original);
            System.Console.WriteLine();

            System.Console.WriteLine("Copy:");
            System.Console.WriteLine(copy);
            System.Console.WriteLine();

            copy.Adopt("Fido");            

            System.Console.WriteLine("Shelter:");
            System.Console.WriteLine(original);
            System.Console.WriteLine();

            System.Console.WriteLine("Copy:");
            System.Console.WriteLine(copy);
            System.Console.WriteLine();
        }
    }
}
