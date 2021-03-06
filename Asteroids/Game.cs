﻿using System;
using System.Collections.Generic;
using System.IO;

class Game
{

    public static Player player;
    public static List<Shot> shot;
    static int numEnemies;
    protected int coolDownChangeSprite;
    protected int coolDownShot;
    protected int numTeletransportes;
    protected int enfriamientoTeletransporte;

    static Enemy[] enemies;

    const int SIZE = 16;
    protected string[] imagesPlayer;
    public static int position = 0;
    protected string imageShot;

    //protected int shotSpeed;
    protected static bool activeShot;
    static bool[] enemyAlive;
 
    protected Room room;

    static bool finished;
    static protected int score;
    static protected int maxScore;
    static StreamReader inputMaxScore;
    
    Score s;
    static protected string fileMaxScore = "maxScore.txt";
    static protected Font font24;

    protected bool levelUp;
    static protected int maxEnemies;
    protected int maxVelocidad;
    protected int level;

    public Game()
    {
        maxEnemies = 20;
        player = new Player();
        player.MoveTo(200, 100);
        shot = new List<Shot>();
        shot.Add(new Shot());
        numEnemies = 2;
        enemies = new Enemy[maxEnemies];
        //---
        enemyAlive = new bool[maxEnemies];


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

        for (int i = 0; i < numEnemies; i++)
        {
            enemyAlive[i] = true;
        }

        Font font18 = new Font("data/Joystix.ttf", 18);

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

        imageShot = "data/disparo.png";

        //shotSpeed = 22;

        activeShot = false;

        coolDownChangeSprite = 0;
        coolDownShot = 0;
        numTeletransportes = 3;
        enfriamientoTeletransporte = 0;
        //-----
        score = 0;
        s = new Score();
        font24 = new Font("data/Joystix.ttf", 24);

        if (File.Exists(fileMaxScore))
        {
            inputMaxScore = new StreamReader(fileMaxScore);
        }

        levelUp = true;
        maxVelocidad = 5;
        level = 1;
    }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();

        room.DrawOnHiddenScreen();

        player.DrawOnHiddenScreen();

        if (shot.Count > 0 && activeShot == true)
        {
            shot[0].DrawOnHiddenScreen();
        }

        for (int i = 0; i < numEnemies; i++)
        {
            if (enemyAlive[i] != false)
            {
                enemies[i].DrawOnHiddenScreen();
            }
        }

        for (int i = 0; i < numEnemies; i++)
        {
            if (enemyAlive[i] == true)
            {
                levelUp = false;
            }
        }

        if (levelUp == true)
        {
            level += 1;
            if (numEnemies < 20)
            {
                numEnemies += 2;
            }
            if (maxVelocidad < 35)
            {
                maxVelocidad += 2;
            }

            for (int i = 0; i < numEnemies; i++)
            {
                enemies[i] = new Enemy();
            }

            finished = false;

            Random rnd = new Random();

            for (int i = 0; i < numEnemies; i++)
            {
                int randomX = rnd.Next(200, 800);
                int randomY = rnd.Next(50, 600);

                if (randomX > player.GetX() || randomX < player.GetX() ||
                        randomY > player.GetY() || randomY < player.GetY())
                {
                    enemies[i].MoveTo(randomX, randomY);
                }
                enemies[i].SetSpeed(rnd.Next(1, maxVelocidad),
                    rnd.Next(1, maxVelocidad));
            }

            for (int i = 0; i < numEnemies; i++)
            {
                enemyAlive[i] = true;
            }
        }

        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["level"] + " "
                + level,
            400, 10,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText(ChooseLanguage.lenguage["score"] + " " 
                + score,
            400, 40,
            0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.ShowHiddenScreen();

        levelUp = true;
    }


    void CheckUserInput()
    {
        if (coolDownChangeSprite > 0)
        {
            coolDownChangeSprite -= 9;

        }
        if (coolDownShot > 0)
        {
            coolDownShot -= 2;
        }
        if (coolDownShot == 0)
        {
            activeShot = false;
        }
        if (enfriamientoTeletransporte > 0)
        {
            enfriamientoTeletransporte -= 9;
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;


        if (!(coolDownShot > 0))
        {

            if (SdlHardware.KeyPressed(SdlHardware.KEY_X))
            {
                shot.Add(new Shot());

                shot[0].MoveTo(player.GetX() + 12, player.GetY() + 16);
                shot[0].LoadImage(imageShot);

                coolDownShot = 30;
                activeShot = true;

                shot[0].ShotDirection(position);
            }
        }

        player.Reduce();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_Z))
        {
            player.ChangeVelocity(position);
        }

        player.Move();
        shot[0].Move(position);

        if (coolDownChangeSprite > 0)
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

            coolDownChangeSprite = 10;

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

            coolDownChangeSprite = 10;
        }
        if (enfriamientoTeletransporte > 0)
        {
            return;
        }
        //NEW
        if (SdlHardware.KeyPressed(SdlHardware.KEY_C))
        {
            if (!(enfriamientoTeletransporte > 0) && numTeletransportes > 0)
            {
                player.Teletransporte();
                enfriamientoTeletransporte = 70;
                numTeletransportes--;
            }
        }

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
        shot[0].InfiniteScreen();
    }

    static void CheckGameStatus()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            if (player.CollisionsWith(enemies[i]) && enemyAlive[i] == true)
            {
                string line = inputMaxScore.ReadLine();

                maxScore = Convert.ToInt32(line);
                inputMaxScore.Close();

                if (score > maxScore)
                {
                    maxScore = score;
                    File.WriteAllText(fileMaxScore, Convert.ToString(score));

                }
                Score.Run(score, maxScore);
                score = 0;
                finished = true;
                
            }

            if ((shot[0].CollisionsWith(enemies[i]) || shot[0].CollisionsWith(enemies[i]))
                    && enemyAlive[i] == true
                && activeShot == true)
            {
                enemyAlive[i] = false;
                score += 20;
            }
        }
    }

    static void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
    }

    /*static void UpdateHighscore()
    {
        // Save highest score
        // TO DO
    }*/

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


        //UpdateHighscore();
    }
}