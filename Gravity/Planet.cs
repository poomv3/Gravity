using System.Numerics;

namespace Gravity;

public class Planet
{
    public float mass;
    public float radius;
    public Vector2 position = new Vector2(15f, 15f); // start in the middle

    public Planet(float aMass, float aRadius)
    {
        
        mass = aMass;
        radius = aRadius;

    }
    
    
    
}