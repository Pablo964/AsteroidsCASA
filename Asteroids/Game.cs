/**
 * Game.cs - Nodes Of Yesod, game logic
 * 
 * Changes:
 * 0.03, 14-01-2019: Main & Hardware init moved to NodeOfYesod
 * 0.02, 29-11-2018: Split into functions
 * 0.01, 01-nov-2014: Initial version, drawing player 2, enemies, 
 *   allowing the user to move to the right
 */
using System;

class Game
{

    static Player player;
    static Shot shot;
    static int numEnemies;
    protected int coolDown;

    static Enemy[] enemies;
    //NEW
    const int SIZE = 16;
    protected string[] imagesPlayer;
    public static int position = 0;
    protected string imageShot;

    protected int shotSpeed;

    //-----
    protected Room room;

    static bool finished;

    public Game()
    {
        player = new Player();
        player.MoveTo(200, 100);
        shot = new Shot();

        numEnemies = 2;
        enemies = new Enemy[numEnemies];


        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i] = new Enemy();
        }

        finished = false;

        Random rnd = new Random();
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i].MoveTo(rnd.Next(200, 800),
                rnd.Next(50, 600));
            enemies[i].SetSpeed(rnd.Next(1, 5),
                rnd.Next(1, 5));
        }

        Font font18 = new Font("data/Joystix.ttf", 18);
        

        SdlHardware.WriteHiddenText("Score: ",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        room = new Room();
        //NEW
        imagesPlayer = new string[SIZE];
        imagesPlayer[0] = "data/nave_up.png";
        imagesPlayer[1] = "data/nave_up4.png";
        imagesPlayer[2] = "data/nave_up5.png";
        imagesPlayer[3] = "data/nave_up6.png";
        imagesPlayer[4] = "data/nave_der.png";
        imagesPlayer[5] = "data/nave_down1.png";
        imagesPlayer[6] = "data/nave_down2.png";
        imagesPlayer[7] = "data/nave_down3.png";
        imagesPlayer[8] = "data/nave_down.png";
        imagesPlayer[9] = "data/nave_down4.png";
        imagesPlayer[10] = "data/nave_down5.png";
        imagesPlayer[11] = "data/nave_down6.png";
        imagesPlayer[12] = "data/nave_izq.png";
        imagesPlayer[13] = "data/nave_up1.png";
        imagesPlayer[14] = "data/nave_up2.png";
        imagesPlayer[15] = "data/nave_up3.png";

        imageShot = "data/estrellas3.png";

        shotSpeed = 22;

        coolDown = 0;
        //-----
    }



    void UpdateScreen()
    {
        SdlHardware.ClearScreen();

        room.DrawOnHiddenScreen();

        player.DrawOnHiddenScreen();
        shot.DrawOnHiddenScreen();
        
        for (int i = 0; i < numEnemies; i++)
            enemies[i].DrawOnHiddenScreen();
        SdlHardware.ShowHiddenScreen();
    }


    void CheckUserInput()
    {
        if (coolDown > 0)
        {
            coolDown-= 9;
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;

        if (SdlHardware.KeyPressed(SdlHardware.KEY_X))
        {
            
            shot.MoveTo(player.GetX() + 6, player.GetY() + 2);
            shot.LoadImage(imageShot);

            switch (position)
            {
                case 0:
                    shot.speedY(-shotSpeed);
                    shot.speedX(0);
                    break;

                case 1:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 2:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 3:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 4:
                    shot.speedX(shotSpeed);
                    shot.speedY(0);
                    break;

                case 5:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 6:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 7:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(shotSpeed / 2);
                    break;

                case 8:
                    shot.speedY(shotSpeed);
                    shot.speedX(0);
                    break;

                case 9:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                case 10:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                case 11:
                    shot.speedY(shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                case 12:
                    shot.speedX(-shotSpeed);
                    shot.speedY(0);
                    break;

                case 13:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                case 14:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                case 15:
                    shot.speedY(-shotSpeed / 2);
                    shot.speedX(-shotSpeed / 2);
                    break;

                default:
                    break;
            }
        }

        player.Reduce();
        
        if (SdlHardware.KeyPressed(SdlHardware.KEY_Z))
        {
            switch (position)
            {
                case 0:
                    player.IncSpeedY(-2);
                    break;

                case 1:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;
                    
                case 2:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;

                case 3:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;

                case 4:
                    player.IncSpeedX(6);
                    break;

                case 5:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;

                case 6:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;

                case 7:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(6 / 2);
                    break;

                case 8:
                    player.IncSpeedY(6);
                    break;

                case 9:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                case 10:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                case 11:
                    player.IncSpeedY(6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                case 12:
                    player.IncSpeedX(-6);
                    break;

                case 13:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                case 14:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                case 15:
                    player.IncSpeedY(-6 / 2);
                    player.IncSpeedX(-6 / 2);
                    break;

                default:
                    break;
            }
        }

        
        player.Move();
        shot.Move();

        if (coolDown > 0)
        {
            return;
        }

        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
            position++;
            if (position < 0)
            {
                position = SIZE - 1;
            }
            else if (position > (SIZE - 1))
            {
                position = 0;
            }
            player.LoadImage(imagesPlayer[position]);

            coolDown = 10;

        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
        {

            position--;
            if (position < 0)
            {
                position = SIZE - 1;
            }
            else if (position > (SIZE - 1))
            {
                position--;
            }
            player.LoadImage(imagesPlayer[position]);

            coolDown = 10;
        }
        //NEW
  

    }

    static void UpdateWorld()
    {
        // Move enemies, background, etc 
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i].Move();
            enemies[i].InfiniteScreen();
        }
        player.InfiniteScreen();
        shot.InfiniteScreen();
    }

    static void CheckGameStatus()
    {
        // Check collisions and apply game logic
        for (int i = 0; i < numEnemies; i++)
            if (player.CollisionsWith(enemies[i]))
                finished = true;
    }

    static void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
    }

    static void UpdateHighscore()
    {
        // Save highest score
        // TO DO
    }

    public void Run()
    {
        do
        {
            UpdateScreen();
            CheckUserInput();
            UpdateWorld();
            PauseUntilNextFrame();
            CheckGameStatus();
        }
        while (!finished);

        UpdateHighscore();
    }
}