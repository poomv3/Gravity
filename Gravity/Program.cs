using System;
using System.Numerics;
using Gravity;


// Simple gravity (no air resistance, no friction)

Vector2 velocity = new Vector2(5f, 0f);

//center of grid (object)
Vector2 objectPosition = new Vector2(70f,25f);
Vector2 planetPosition = new Vector2(75f,15f);
float planetMass = 100000000f;
float objectMass = 100000f;
float G = 0.000000000066743f;


string[,] grid = new string[35, 150];
// create the grid with empty elements
for (int x = 0; x < grid.GetLength(0); x++)
{
    for (int y = 0; y < grid.GetLength(1); y++)
    {
        if (x == 15 && y == 75)
        {
            grid[x, y] = "X";
        }
        grid[x, y] = " ";
    }
}

float deltaTime = 0.1f;
int steps = 1000;
float time = 0f;


for (int i = 0; i < steps; i++)
{
    Vector2 direction = planetPosition - objectPosition;
    float distance = direction.Length();
    Vector2 unitDirection = Vector2.Normalize(direction);

    float gravitationalForce = G * (planetMass * objectMass) / (distance * distance);

    Vector2 gravity = gravitationalForce * unitDirection;
    
    velocity += gravity * deltaTime;
    objectPosition += velocity * deltaTime;
    
    int posX = (int)Math.Round(objectPosition.X);
    int posY = (int)Math.Round(objectPosition.Y);
    
    // output the grid
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        Console.WriteLine();
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (30 - x == posY && y == posX)
            {
                Console.Write(grid[x, y] = "O");
            }
            else if (30 - x == 15 && y == 75)
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
    Thread.Sleep(100);
    Console.Clear();
        
        // Console.WriteLine($"Position of object: {position}, Time: {Math.Round(time,2)}s");

}

// Planets with mass and radius

Planet planet1 = new Planet(100, 2);

// create a visual on the grid according to radius



Console.ReadLine();
