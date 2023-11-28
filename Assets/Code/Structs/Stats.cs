using System;

[Serializable]
public struct Stats
{
    public int health;
    public float speed;

    public void SumStats(Stats toSum)
    {
        health += toSum.health;
        speed += toSum.speed;
    }
}
