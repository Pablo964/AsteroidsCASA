using System;
using System.Collections;

class ChooseLanguage
{
    protected int option;
    protected Font font24;
    protected Image pointer;
    protected Image shot;
    protected int pointerY;
    protected int shotX;
    protected bool activeShot;
    public static Hashtable lenguage;

    public ChooseLanguage()
    {
        pointer = new Image("data/nave_izq.png");
        shot = new Image("data/disparo.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
        pointerY = 200;
        shotX = 500;

        lenguage = new Hashtable();
        
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void Run()
    {
        option = 0;
        SdlHardware.ClearScreen();

        SdlHardware.DrawHiddenImage(pointer, 500, pointerY);
        SdlHardware.DrawHiddenImage(shot, shotX, pointerY + 13);

        SdlHardware.WriteHiddenText("CHOOSE YOUR LENGUAGE:",
            400, 100,
            0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.WriteHiddenText("SPANISH",
            300, 200,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("ENGLISH",
            300, 300,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("FRENCH",
            310, 400,
           0xC0, 0xC0, 0xC0,
            font24);

        SdlHardware.ShowHiddenScreen();

        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN) && pointerY < 400)
        {
            pointerY += 100;
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP) && pointerY > 200)
        {
            pointerY -= 100;
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {
            activeShot = true;
        }

        if (activeShot && shotX > 400)
        {
            shotX -= 10;
        }
        else if (shotX <= 400)
        {
            switch (pointerY)
            {
                case 200:
                    option = 1;
                    lenguage.Add("play", "Jugar");
                    lenguage.Add("credits", "Creditos");
                    lenguage.Add("quit", "Salir");
                    lenguage.Add("score", "Puntuación:");
                    lenguage.Add("maxScore", "Máxima puntuación:");
                    lenguage.Add("level", "Nivel:");
                    lenguage.Add("toReturn", "Para volver");
                    break;
                case 300:
                    option = 2;
                    lenguage.Add("play", "Play");
                    lenguage.Add("credits", "Credits");
                    lenguage.Add("quit", "Quit");
                    lenguage.Add("score", "Score:");
                    lenguage.Add("maxScore", "Max score:");
                    lenguage.Add("level", "Level:");
                    lenguage.Add("toReturn", "To return");
                    break;

                case 400:
                    option = 3;
                    lenguage.Add("play", "jouer");
                    lenguage.Add("credits", "crédits");
                    lenguage.Add("quit", "sortir");
                    lenguage.Add("score", "ponctuation:");
                    lenguage.Add("maxScore", "note maximale:");
                    lenguage.Add("level", "niveau:");
                    lenguage.Add("toReturn", "pour revenir");
                    break;
            }
            shotX = 500;
            activeShot = false;
        }

        SdlHardware.Pause(120); // To avoid using 100% CPU        
    }
}

