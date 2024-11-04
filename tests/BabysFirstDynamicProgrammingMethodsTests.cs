namespace tests;

public class BabysFirstDynamicProgrammingMethodsTests
{
    [Fact]
    public void Fibonnacci_ShouldReturn1For1()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(1);
        withRecursion.Should().Be(1);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(1);
        withoutRecursion.Should().Be(1);
    }
    
    [Fact]
    public void Fibonnacci_ShouldReturn0For0()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(0);
        withRecursion.Should().Be(0);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(0);
        withoutRecursion.Should().Be(0);
    }
    [Fact]
    public void Fibonnacci_ShouldReturn1For2()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(2);
        withRecursion.Should().Be(1);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(2);
        withoutRecursion.Should().Be(1);
    }
    [Fact]
    public void Fibonnacci_ShouldReturn2For3()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(3);
        withRecursion.Should().Be(2);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(3);
        withoutRecursion.Should().Be(2);
    }
    [Fact]
    public void Fibonnacci_ShouldReturn3For4()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(4);
        withRecursion.Should().Be(3);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(4);
        withoutRecursion.Should().Be(3);
    }
    [Fact]
    public void Fibonnacci_ShouldReturn8For6()
    {
        // arrange, act 
        int withRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithRecursion(6);
        withRecursion.Should().Be(8);
        int withoutRecursion = BabysFirstDynamicProgrammingMethods.FibonacciWithoutRecursion(6);
        withoutRecursion.Should().Be(8);
    }
}