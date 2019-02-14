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
    static int numEnemies;

    static Enemy[] enemies;
    protected string lastPressed;  
    //NEW
    const int SIZE = 4;
    protected string[] imagesPlayer;
    public static int position = 0;
    protected int acceleration;
    //-----
    protected Room room;

    static bool finished;

    protected Font font18;

    public Game()
    {
        player = new Player();
        player.MoveTo(200, 100);

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
        imagesPlayer[1] = "data/nave_der.png";
        imagesPlayer[2] = "data/nave_down.png";
        imagesPlayer[3] = "data/nave_izq.png";
        //-----
    }



    void UpdateScreen()
    {
        SdlHardware.ClearScreen();

        room.DrawOnHiddenScreen();

        player.DrawOnHiddenScreen();
        for (int i = 0; i < numEnemies; i++)
            enemies[i].DrawOnHiddenScreen();
        SdlHardware.ShowHiddenScreen();
    }


    void CheckUserInput()
    {
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

            SdlHardware.Pause(55);
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

            SdlHardware.Pause(55);
        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {
            if (position == 2)
            {
                player.MoveDown();
            }
            else if (position == 0)
            {
                player.MoveUp();
            }
            else if (position == 3)
            {
                player.MoveLeft();
            }
            else if (position == 1)
            {
               //while (position == 1)
               //{
                    player.MoveRight();
               //}
                
            }

        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;
    }

    static void UpdateWorld()
    {
        // Move enemies, background, etc 
        for (int i = 0; i < numEnemies; i++)
            enemies[i].Move();
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