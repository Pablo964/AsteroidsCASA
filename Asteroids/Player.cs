﻿using System;

class Player : Sprite
{
    protected int coolDown;
    protected double angleInDegrees;
    protected double cos;


    public Player()
    {
        LoadImage("data/nave_up.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 0;
        width = 22;
        height = 15;

        coolDown = 0;

        angleInDegrees = 0;
        cos = System.Math.Cos(angleInDegrees * (System.Math.PI / 180.0));
    }

    public void SetAngle(double angle)
    {
        angleInDegrees = angle;
    }

    public double GetAngle()
    {
        return angleInDegrees;
    }


    public void SetCos(double angle)
    {
        System.Math.Cos(angle * (System.Math.PI / 180.0));
    }

    public double GetCos()
    {
        return angleInDegrees;
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
    public override void Move()
    {

        MoveX();
        MoveY();
    }

    public void MoveX()
    {
        x += xSpeed;
        
    }

    public void MoveY()
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

