class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

/*class Program
{
    static void Main()
    {
        Animal animal = new Dog();

        animal.Sound();
    }
}*/