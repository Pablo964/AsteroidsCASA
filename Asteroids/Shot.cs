using System;

class Shot : Sprite
{
    protected int coolDown;

    public Shot()
    {
        LoadImage("data/disparo.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 2;
        height = 2;

        coolDown = 0;
    }

    public void speedY(int speed)
    {
        this.ySpeed = speed;
    }

    public void speedX(int speed)
    {
        this.xSpeed = speed;
    }
    public override void Move()
    {
        MoveRight();
        MoveDown();
    }

    public void MoveRight()
    {
        x += xSpeed;
    }

    public void MoveDown()
    {
        y += ySpeed;
    }
}

