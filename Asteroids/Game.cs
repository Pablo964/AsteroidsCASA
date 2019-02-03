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
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
            player.MoveRight();
            /*if (room.CanMoveTo(player.GetX() + player.GetSpeedX(),
                    player.GetY(),
                    player.GetX() + player.GetWidth() + player.GetSpeedX(),
                    player.GetY() + player.GetHeight()))
                player.MoveRight();*/
        }    

        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
            player.MoveLeft();
        /*if (room.CanMoveTo(player.GetX() - player.GetSpeedX(),
                player.GetY(),
                player.GetX() + player.GetWidth() - player.GetSpeedX(),
                player.GetY() + player.GetHeight()))
            player.MoveLeft();*/

        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
            player.MoveUp();
        /*if (room.CanMoveTo(player.GetX(),
                player.GetY() - player.GetSpeedY(),
                player.GetX() + player.GetWidth(),
                player.GetY() + player.GetHeight() - player.GetSpeedY()))
            player.MoveUp();*/

        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
            player.MoveDown();
        /*if (room.CanMoveTo(player.GetX(),
                player.GetY() + player.GetSpeedY(),
                player.GetX() + player.GetWidth(),
                player.GetY() + player.GetHeight() + player.GetSpeedY()))
            player.MoveDown();*/

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