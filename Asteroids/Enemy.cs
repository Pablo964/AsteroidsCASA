
using System;

class Enemy : Sprite
{
    private static Random rnd = new Random();

    private int negativeX;
    private int negativeY;


    public Enemy()
    {
        LoadImage("data/enemy.png");
        width = 32;
        height = 64;
        xSpeed = rnd.Next(0, 9);
        ySpeed = rnd.Next(0, 9);
        negativeX = rnd.Next(0, 2);
        negativeY = rnd.Next(0, 2);
    }

    public override void Move()
    {
        if (negativeX == 0)
        {
            x -= xSpeed;
        }
        else
        {
            x += xSpeed;
        }
        if (negativeY == 0)
        {
            y -= ySpeed;
        }
        else
        {
            y += ySpeed;
        }
    }
}

