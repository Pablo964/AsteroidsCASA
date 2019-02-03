class Player : Sprite
{
    public Player()
    {
        LoadImage("data/player.png");
        x = 50;
        y = 120;
        xSpeed = ySpeed = 8;
        width = 22;
        height = 15;
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
}

