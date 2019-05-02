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
    public void Move(int position)
    {
        MoveRight(position);
        MoveDown(position);
    }

    public void MoveRight(int position)
    {
        switch (position)
        {
            case 1:
                x += xSpeed + 1;
                break;
            default:
                x += xSpeed;
                break;
        }
        
    }

    public void MoveDown(int position)
    {
        switch (position)
        {
            case 1:
                y += ySpeed + 5;
                break;
            default:
                y += ySpeed;
                break;
        } 
    }

}


