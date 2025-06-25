using System;
using System.Numerics;


// Simple gravity

Vector2 position = new Vector2(15f,30f);
Vector2 velocity = new Vector2(0f, 0f);
Vector2 gravity = new Vector2(0f, -9.81f);

string[,] grid = new string[30, 30];
// create the grid with empty elements
for (int x = 0; x < grid.GetLength(0); x++)
{
    for (int y = 0; y < grid.GetLength(1); y++)
    {
        grid[x, y] = " ";
    }
}


float deltaTime = 0.1f;
int steps = 200;
float time = 0f;


for (int i = 0; i < steps; i++)
{
    
    velocity += gravity * deltaTime;
    position += velocity * deltaTime;
    if (position.Y < 0)
    {
        position.Y = 0;
        velocity.Y *= -0.8f;
    }

    int posX = (int)Math.Round(position.X);
    int posY = (int)Math.Round(position.Y);
    
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

Console.ReadLine();

// Projectile motion

// Vector2 position = new Vector2(0f,20f);
// Vector2 velocity = new Vector2(5f, 0f);
// Vector2 gravity = new Vector2(0f, -9.81f);
//
// float deltaTime = 0.1f;
// int steps = 200;
// float time = 0f;
//
// for (int i = 0; i < steps; i++)
// {
//     position += velocity * deltaTime;
//     velocity += gravity * deltaTime;
//     
//     Console.WriteLine($"Position is {position}");
//     
// }