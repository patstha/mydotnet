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

    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase1()
    {
        // arrange 
        List<KnapsackItem> knapsackItems = [new("Stereo", 3000, 4), new("Laptop", 2000, 3), new("Guitar", 1500, 1)];
        const int knapsackCapacity = 4;
        List<KnapsackItem> expected = [new("Laptop", 2000, 3), new("Guitar", 1500, 1)];
        
        // act 
        List<KnapsackItem> actual = BabysFirstDynamicProgrammingMethods.KnapsackBruteForce(knapsackCapacity, knapsackItems);
        
        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase2()
    {
        // arrange 
        List<KnapsackItem> knapsackItems =
        [
            new("Stereo", 3000, 4),
            new("Laptop", 2000, 3),
            new("Guitar", 1500, 1),
            new("Phone", 800, 1),
            new("Tablet", 600, 1),
            new("Camera", 1200, 2),
            new("Watch", 400, 1),
            new("Headphones", 200, 1),
            new("Speaker", 300, 2),
            new("Monitor", 500, 3),
            new("Keyboard", 100, 1),
            new("Mouse", 50, 1),
            new("Printer", 150, 4),
            new("Scanner", 250, 3),
            new("Router", 100, 1),
            new("Modem", 80, 1),
            new("Hard Drive", 150, 2),
            new("SSD", 200, 1),
            new("USB Drive", 20, 1),
            new("External Battery", 60, 1),
            new("Drone", 1000, 3),
            new("VR Headset", 700, 2),
            new("Smart Light", 50, 1),
            new("Smart Thermostat", 150, 1),
            new("Smart Lock", 200, 1),
            new("Smart Doorbell", 100, 1),
            new("Fitness Tracker", 100, 1),
            new("Electric Toothbrush", 80, 1),
            new("Hair Dryer", 50, 1),
            new("Blender", 100, 2),
            new("Coffee Maker", 150, 3),
            new("Microwave", 200, 4),
            new("Toaster", 50, 2),
            new("Oven", 500, 5),
            new("Refrigerator", 1000, 6),
            new("Dishwasher", 800, 5),
            new("Washing Machine", 700, 6),
            new("Dryer", 600, 6),
            new("Vacuum Cleaner", 300, 4),
            new("Air Purifier", 200, 3),
            new("Fan", 50, 2),
            new("Heater", 100, 3),
            new("Air Conditioner", 400, 5),
            new("Water Heater", 500, 6),
            new("Iron", 50, 2),
            new("Sewing Machine", 200, 3),
            new("Lawn Mower", 300, 5),
            new("Leaf Blower", 100, 3),
            new("Chainsaw", 150, 4),
            new("Drill", 100, 2),
            new("Saw", 150, 3),
            new("Hammer", 50, 1),
            new("Wrench", 30, 1),
            new("Screwdriver", 20, 1),
            new("Pliers", 25, 1),
            new("Tape Measure", 15, 1),
            new("Level", 20, 1),
            new("Flashlight", 30, 1),
            new("Lantern", 40, 2),
            new("Tent", 100, 4),
            new("Sleeping Bag", 50, 3),
            new("Backpack", 80, 2),
            new("Hiking Boots", 120, 2),
            new("Jacket", 100, 2),
            new("Hat", 30, 1),
            new("Gloves", 20, 1),
            new("Sunglasses", 50, 1),
            new("Binoculars", 100, 2),
            new("Compass", 20, 1),
            new("Map", 10, 1),
            new("Water Bottle", 20, 1),
            new("First Aid Kit", 50, 2),
            new("Fire Starter", 15, 1),
            new("Fishing Rod", 100, 3),
            new("Tackle Box", 50, 2),
            new("Kayak", 300, 5),
            new("Life Jacket", 50, 2),
            new("Paddle", 30, 1),
            new("Bicycle", 200, 4),
            new("Helmet", 50, 1),
            new("Lock", 20, 1),
            new("Pump", 30, 1),
            new("Tire Repair Kit", 20, 1),
            new("Basketball", 30, 1),
            new("Soccer Ball", 30, 1),
            new("Tennis Racket", 100, 2),
            new("Golf Clubs", 300, 5),
            new("Baseball Bat", 50, 2),
            new("Hockey Stick", 50, 2),
            new("Skis", 200, 4),
            new("Snowboard", 200, 4),
            new("Surfboard", 300, 5),
            new("Skateboard", 100, 2),
            new("Rollerblades", 80, 2),
            new("Scooter", 150, 3),
            new("Electric Scooter", 300, 4),
            new("Motorcycle", 2000, 6),
            new("Car", 20000, 10)
        ];

        const int knapsackCapacity = 50;
        List<KnapsackItem> expected = [
            new("Stereo", 3000, 4),
            new("Laptop", 2000, 3),
            new("Toaster", 50, 2),
            new("Oven", 500, 5),
            new("Hat", 30, 1),
            new("Gloves", 20, 1),
            new("Motorcycle", 2000, 6),
            new("Car", 20000, 10)
        ];
        
        // act 
        List<KnapsackItem> actual = BabysFirstDynamicProgrammingMethods.KnapsackBruteForce(knapsackCapacity, knapsackItems);
        
        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase3()
{
    // arrange 
    List<KnapsackItem> knapsackItems =
    [
        new("Stereo", 3000, 4),
        new("Laptop", 2000, 3),
        new("Guitar", 1500, 1),
        new("Phone", 800, 1),
        new("Tablet", 600, 1),
        new("Camera", 1200, 2),
        new("Watch", 400, 1),
        new("Headphones", 200, 1),
        new("Speaker", 300, 2),
        new("Monitor", 500, 3),
        new("Keyboard", 100, 1),
        new("Mouse", 50, 1),
        new("Printer", 150, 4),
        new("Scanner", 250, 3),
        new("Router", 100, 1),
        new("Modem", 80, 1),
        new("Hard Drive", 150, 2),
        new("SSD", 200, 1),
        new("USB Drive", 20, 1),
        new("External Battery", 60, 1),
        new("Drone", 1000, 3),
        new("VR Headset", 700, 2),
        new("Smart Light", 50, 1),
        new("Smart Thermostat", 150, 1),
        new("Smart Lock", 200, 1),
        new("Smart Doorbell", 100, 1),
        new("Fitness Tracker", 100, 1),
        new("Electric Toothbrush", 80, 1),
        new("Hair Dryer", 50, 1),
        new("Blender", 100, 2),
        new("Coffee Maker", 150, 3),
        new("Microwave", 200, 4),
        new("Toaster", 50, 2),
        new("Oven", 500, 5),
        new("Refrigerator", 1000, 6),
        new("Dishwasher", 800, 5),
        new("Washing Machine", 700, 6),
        new("Dryer", 600, 6),
        new("Vacuum Cleaner", 300, 4),
        new("Air Purifier", 200, 3),
        new("Fan", 50, 2),
        new("Heater", 100, 3),
        new("Air Conditioner", 400, 5),
        new("Water Heater", 500, 6),
        new("Iron", 50, 2),
        new("Sewing Machine", 200, 3),
        new("Lawn Mower", 300, 5),
        new("Leaf Blower", 100, 3),
        new("Chainsaw", 150, 4),
        new("Drill", 100, 2),
        new("Saw", 150, 3),
        new("Hammer", 50, 1),
        new("Wrench", 30, 1),
        new("Screwdriver", 20, 1),
        new("Pliers", 25, 1),
        new("Tape Measure", 15, 1),
        new("Level", 20, 1),
        new("Flashlight", 30, 1),
        new("Lantern", 40, 2),
        new("Tent", 100, 4),
        new("Sleeping Bag", 50, 3),
        new("Backpack", 80, 2),
        new("Hiking Boots", 120, 2),
        new("Jacket", 100, 2),
        new("Hat", 30, 1),
        new("Gloves", 20, 1),
        new("Sunglasses", 50, 1),
        new("Binoculars", 100, 2),
        new("Compass", 20, 1),
        new("Map", 10, 1),
        new("Water Bottle", 20, 1),
        new("First Aid Kit", 50, 2),
        new("Fire Starter", 15, 1),
        new("Fishing Rod", 100, 3),
        new("Tackle Box", 50, 2),
        new("Kayak", 300, 5),
        new("Life Jacket", 50, 2),
        new("Paddle", 30, 1),
        new("Bicycle", 200, 4),
        new("Helmet", 50, 1),
        new("Lock", 20, 1),
        new("Pump", 30, 1),
        new("Tire Repair Kit", 20, 1),
        new("Basketball", 30, 1),
        new("Soccer Ball", 30, 1),
        new("Tennis Racket", 100, 2),
        new("Golf Clubs", 300, 5),
        new("Baseball Bat", 50, 2),
        new("Hockey Stick", 50, 2),
        new("Skis", 200, 4),
        new("Snowboard", 200, 4),
        new("Surfboard", 300, 5),
        new("Skateboard", 100, 2),
        new("Rollerblades", 80, 2),
        new("Scooter", 150, 3),
        new("Electric Scooter", 300, 4),
        new("Motorcycle", 2000, 6),
        new("Car", 2000000, 10)
    ];

    const int knapsackCapacity = 10;
    List<KnapsackItem> expected = [new("Car", 2000000, 10)];
    
    // act 
    List<KnapsackItem> actual = BabysFirstDynamicProgrammingMethods.KnapsackBruteForce(knapsackCapacity, knapsackItems);
    
    // assert 
    actual.Should().BeEquivalentTo(expected);
}

}