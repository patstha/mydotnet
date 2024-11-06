namespace tests;

public class KnapsackBruteforceTests
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
            Knapsack.BruteForce(knapsackCapacity, knapsackItems);

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
            Knapsack.BruteForce(knapsackCapacity, knapsackItems);

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
            Knapsack.BruteForce(knapsackCapacity, knapsackItems);

        // assert 
        actual.Should().BeEquivalentTo(expected);
    }
}