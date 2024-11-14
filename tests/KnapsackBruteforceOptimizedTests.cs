namespace tests;

public class KnapsackBruteforceOptimizedTests
{
    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase1()
    {
        // arrange 
        List<KnapsackItem> knapsackItems = [new("Stereo", 3000, 4), new("Laptop", 2000, 3), new("Guitar", 1500, 1)];
        const int knapsackCapacity = 4;
        List<KnapsackItem> expected = [new("Laptop", 2000, 3), new("Guitar", 1500, 1)];

        // act 
        List<KnapsackItem> actual =
            Knapsack.BruteForceOptimized(knapsackCapacity, knapsackItems);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase2()
    {
        // arrange 
        List<KnapsackItem> knapsackItems =
        [
            new("Skis", 200, 4),
            new("Snowboard", 200, 4),
            new("Surfboard", 300, 5),
            new("Skateboard", 100, 2),
            new("Rollerblades", 80, 2),
            new("Scooter", 150, 3),
            new("Electric Scooter", 300, 4),
            new("Motorcycle", 9000, 10),
            new("Car", 40000, 40)
        ];

        const int knapsackCapacity = 50;
        List<KnapsackItem> expected =
        [
            new("Motorcycle", 9000, 10),
            new("Car", 40000, 40)
        ];

        // act 
        List<KnapsackItem> actual =
            Knapsack.BruteForceOptimized(knapsackCapacity, knapsackItems);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase3()
    {
        // arrange 
        List<KnapsackItem> knapsackItems =
        [
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
            new("Car", 2000000, 24)
        ];

        const int knapsackCapacity = 24;
        List<KnapsackItem> expected = [new("Car", 2000000, 24)];

        // act 
        List<KnapsackItem> actual =
            Knapsack.BruteForceOptimized(knapsackCapacity, knapsackItems);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase4()
    {
        // arrange 
        List<KnapsackItem> knapsackItems =
        [
            new("Bicycle", 200, 4)
        ];

        const int knapsackCapacity = 24;
        List<KnapsackItem> expected = [            
            new("Bicycle", 200, 4)
        ];

        // act 
        List<KnapsackItem> actual =
            Knapsack.BruteForceOptimized(knapsackCapacity, knapsackItems);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
    // [Fact]
    // public void KnapsackBruteforce_ShouldReturnCorrectAnswerForSimpleCase4()
    // {
    //     // arrange 
    //     List<KnapsackItem> knapsackItems =
    //     [
    //         new("Bicycle", 200, 4),
    //         new("Helmet", 50, 1),
    //         new("Lock", 20, 1),
    //         new("Pump", 30, 1),
    //         new("Tire Repair Kit", 20, 1),
    //         new("Basketball", 30, 1),
    //         new("Soccer Ball", 30, 1),
    //         new("Tennis Racket", 100, 2),
    //         new("Golf Clubs", 300, 5),
    //         new("Baseball Bat", 50, 2),
    //         new("Hockey Stick", 50, 2),
    //         new("Skis", 200, 4),
    //         new("Snowboard", 200, 4),
    //         new("Surfboard", 300, 5),
    //         new("Skateboard", 100, 2),
    //         new("Rollerblades", 80, 2),
    //         new("Scooter", 150, 3),
    //         new("Electric Scooter", 300, 4),
    //         new("Motorcycle", 2000, 6),
    //         new("Car", 2000000, 24),
    //         new("Stereo", 3000, 4),
    //         new("Laptop", 2000, 3),
    //         new("Guitar", 1500, 1),
    //         new("Camera", 500, 2),
    //         new("Smartphone", 1000, 1),
    //         new("Tablet", 600, 1),
    //         new("Watch", 200, 1),
    //         new("Drone", 800, 3),
    //         new("Printer", 150, 4),
    //         new("Monitor", 300, 5),
    //         new("Keyboard", 100, 1),
    //         new("Mouse", 50, 1),
    //         new("Desk Lamp", 70, 2),
    //         new("Chair", 150, 10),
    //         new("Desk", 300, 20),
    //         new("Bookshelf", 200, 15),
    //         new("Bed", 500, 50),
    //         new("Mattress", 400, 30),
    //         new("Pillow", 50, 2),
    //         new("Blanket", 100, 5),
    //         new("Wardrobe", 600, 40),
    //         new("Dresser", 300, 25),
    //         new("Nightstand", 100, 10),
    //         new("Lamp", 80, 5),
    //         new("Fan", 50, 5),
    //         new("Heater", 100, 10),
    //         new("Air Conditioner", 400, 30),
    //         new("Refrigerator", 800, 50),
    //         new("Microwave", 150, 20)
    //     ];
    //
    //     const int knapsackCapacity = 24;
    //     List<KnapsackItem> expected = [new("Car", 2000000, 24)];
    //
    //     // act 
    //     List<KnapsackItem> actual =
    //         Knapsack.BruteForceOptimized(knapsackCapacity, knapsackItems);
    //
    //     // assert 
    //     actual.Should().BeEquivalentTo(expected);
    // }
}