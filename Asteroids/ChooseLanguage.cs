using System;

class ChooseLanguage
{
    protected int option;
    protected Font font24;
    protected Image pointer;
    protected Image shot;
    protected int pointerY;
    protected int shotX;
    protected bool activeShot;

    public ChooseLanguage()
    {
        pointer = new Image("data/nave_izq.png");
        shot = new Image("data/disparo.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
        pointerY = 200;
        shotX = 500;
        
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

        

        SdlHardware.WriteHiddenText("ESPAÑOL",
            300, 200,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("INGLÉS",
            300, 300,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("RUSO",
            300, 400,
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

        if (activeShot && shotX > 320)
        {
            shotX -= 10;
        }
        else if (shotX <= 320)
        {
            switch (pointerY)
            {
                case 200:

                    break;
                case 300:

                    break;

                case 400:

                    break;
            }
        }

        SdlHardware.Pause(150); // To avoid using 100% CPU        
    }
}

