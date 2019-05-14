using System;

class Player : Sprite
{
    protected int coolDown;

    public Player()
    {
        LoadImage("data/nave_up.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 22;
        height = 15;

        coolDown = 0;
    }

    public void ChangeVelocity(int positionSprite)
    {
        switch (positionSprite)
        {
            case 0:
                Game.player.IncSpeedY(-2);
                break;

            case 1:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 2:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 3:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 4:
                Game.player.IncSpeedX(6);
                break;

            case 5:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 6:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 7:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(6 / 2);
                break;

            case 8:
                Game.player.IncSpeedY(6);
                break;

            case 9:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;

            case 10:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;

            case 11:
                Game.player.IncSpeedY(6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;

            case 12:
                Game.player.IncSpeedX(-6);
                break;

            case 13:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;

            case 14:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;

            case 15:
                Game.player.IncSpeedY(-6 / 2);
                Game.player.IncSpeedX(-6 / 2);
                break;
        }
    }

    public void  Reduce()
    {
        if (coolDown > 0)
        {
            coolDown--;
        }

        if (coolDown > 0)
        {
            return;
        }
       
        if (xSpeed > 0)
        {
            xSpeed -= 1;
           
        }
        else if (xSpeed < 0)
        {
            xSpeed += 1;
        }

        if (ySpeed > 0)
        {
            ySpeed -= 1;

        }
        else if (ySpeed < 0)
        {
            ySpeed += 1;
        }

        coolDown = 6;

    }
    public void IncSpeedY(int speed)
    {
        this.ySpeed += +speed;

        if (ySpeed > 20)
        {
            ySpeed = 20;
        }
        if (ySpeed < -20)
        {
            ySpeed = -20;
        }
    }

    public void IncSpeedX(int speed)
    {
        this.xSpeed += speed;

        if (xSpeed > 20)
        {
            xSpeed = 20;
        }
        if (xSpeed < -20)
        {
            xSpeed = -20;
        }
    }
    public void Move()
    {
        MoveRight();
        MoveDown();
    }

    public void MoveRight()
    {
        x += xSpeed;
    }

    public void MoveLeft()
    {
        x -= xSpeed;
    }

    public void MoveUp()
    {
         y -= ySpeed;
    }

    public void MoveDown()
    {
        y += ySpeed;
    }

    public void Teletransporte()
    {
        Random aleatorio = new Random();
        int numAleatorio = aleatorio.Next(-70, 1000);

        x = numAleatorio;

        numAleatorio = aleatorio.Next(-20, 750);

        y = numAleatorio;
    }
}

