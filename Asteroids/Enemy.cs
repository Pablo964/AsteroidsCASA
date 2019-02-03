
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

        if ((x < 50) || (x > 970))
            xSpeed = -xSpeed;
    }
}

