using System;
using System.Numerics;
using Gravity;


// Simple gravity (no air resistance, no friction)

Vector2 objectVelocity = new Vector2(5f, -5f);
Vector2 planetVelocity = new Vector2(0f, 5f);

//center of grid (object)
Vector2 objectPosition = new Vector2(30f,15f);
Vector2 planetPosition = new Vector2(50f,5f);
float planetMass = 150f;
float objectMass = 10f;
float G = 1f;


string[,] grid = new string[35, 150];
// create the grid with empty elements
for (int x = 0; x < grid.GetLength(0); x++)
{
    for (int y = 0; y < grid.GetLength(1); y++)
    {
        if (x == 15 && y == 75)
        {
            grid[x, y] = "█";
        }
        grid[x, y] = " ";
    }
}

float deltaTime = 0.5f;
int steps = 1000;
float time = 0f;


for (int i = 0; i < steps; i++)
{
    
    
    Vector2 direction = planetPosition - objectPosition;
    float distance = direction.Length();
    Vector2 unitDirection = Vector2.Normalize(direction);

    float gravitationalForce = G * (planetMass * objectMass) / (distance * distance);

    Vector2 gravity = gravitationalForce * unitDirection;
    
    objectVelocity += gravity * deltaTime;
    objectPosition += objectVelocity * deltaTime;
    
    planetVelocity -= gravity * deltaTime;
    planetPosition += planetVelocity * deltaTime;
    
    int objectposX = (int)Math.Round(objectPosition.X);
    int objectposY = (int)Math.Round(objectPosition.Y);
    
    int planetposX = (int)Math.Round(planetPosition.X);
    int planetposY = (int)Math.Round(planetPosition.Y);
    
    Console.WriteLine(objectposX);
    Console.WriteLine(objectposY);
    
    Console.WriteLine(planetposX);
    Console.WriteLine(planetposY);
    

    // output the grid
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        Console.WriteLine();
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (30 - x == objectposY && y == objectposX)
            {
                Console.Write(grid[x, y] = "█");
            }
            else if (30 - x == planetposY && y == planetposX)
            {
                Console.Write(grid[x, y] = "X");
            }
            else
            {
                Console.Write(grid[x, y] = " ");
            }
        }
    }
    time += deltaTime;
    Thread.Sleep(500);
    Console.Clear();

        
        // Console.WriteLine($"Position of object: {position}, Time: {Math.Round(time,2)}s");

}

// Planets with mass and radius

Planet planet1 = new Planet(100, 2);

// create a visual on the grid according to radius



Console.ReadLine();
