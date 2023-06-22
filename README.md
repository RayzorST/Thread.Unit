# Unit
Unit will help you manage threads on .NET

### Class Progaram
```
internal class Program
{
    static List<Unit.Unit> Units = new();
    static void Main()
    {
        Units.Add(new A());
        Units.Add(new B());
        Units.Add(new Unit.Unit(C, "C", true));
    }

    static void C()
    {
        Console.WriteLine("method C");
        Thread.Sleep(2000);
    }
}
```
### Class A
```
internal class A : Unit.Unit
{
    public A() : base(methodA, "A", false)
    { }

    private static void methodA()
    {
        Console.WriteLine("method A");
        Thread.Sleep(1000);
    }
}
```
### Class B
```
internal class B : Unit.Unit
{
    public B() : base(new List<Action> { methodB1, methodB2 }, "B", new List<string> { "methodB1", "methodB2" }, false)
    { }

    public static void methodB1()
    {
        Console.WriteLine("method B1");
        Thread.Sleep(1500);
    }

    public static void methodB2()
    {
        Console.WriteLine("method B2");
        Thread.Sleep(1000);
    }
}
```
# Installation
### .NET CLI
```
> dotnet add package Thread.Unit --version 1.0.1
```
### Package Manager
```
PM> NuGet\Install-Package Thread.Unit -Version 1.0.1
```
