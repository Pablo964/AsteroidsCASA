using System;

class Shot : Sprite
{
    protected int coolDown;
    protected int shotSpeed;

    public Shot()
    {
        LoadImage("data/disparo.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 2;
        height = 2;

        coolDown = 0;

        shotSpeed = 45;
    }

    public void ShotDirection(int position)
    {
        switch (position)
        {

            case 0:
                Game.shot[0].speedY(-shotSpeed);
                Game.shot[0].speedX(0);
                break;

            case 1:
                //TOCADO
                Game.shot[0].speedY(((-shotSpeed)) / 2);
                Game.shot[0].speedX((shotSpeed) / 2);
                break;

            case 2:
                Game.shot[0].speedY(-shotSpeed / 2);
                Game.shot[0].speedX(shotSpeed / 2);
                break;

            case 3:
                Game.shot[0].speedY(-shotSpeed / 2);
                Game.shot[0].speedX(shotSpeed / 2);
                break;

            case 4:
                Game.shot[0].speedX(shotSpeed);
                Game.shot[0].speedY(0);
                break;

            case 5:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(shotSpeed / 2);
                break;

            case 6:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(shotSpeed / 2);
                break;

            case 7:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(shotSpeed / 2);
                break;

            case 8:
                Game.shot[0].speedY(shotSpeed);
                Game.shot[0].speedX(0);
                break;

            case 9:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;

            case 10:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;

            case 11:
                Game.shot[0].speedY(shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;

            case 12:
                Game.shot[0].speedX(-shotSpeed);
                Game.shot[0].speedY(0);
                break;

            //probar con Yspeed en -4
            case 13:
                Game.shot[0].speedY(-shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;

            case 14:
                Game.shot[0].speedY(-shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;

            case 15:
                Game.shot[0].speedY(-shotSpeed / 2);
                Game.shot[0].speedX(-shotSpeed / 2);
                break;
        }
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


