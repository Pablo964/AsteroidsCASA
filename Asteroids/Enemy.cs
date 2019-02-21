
class Enemy : Sprite
{
    public Enemy()
    {
        LoadImage("data/enemy.png");
        width = 32;
        height = 64;
        xSpeed = 8;
    }

    public override void Move()
    {
        x += xSpeed;

        if (currentDirection == 1 && ((x < -70) || (x > 1000)))
            xSpeed = -xSpeed;
    }
}

