using System.Collections;

class WelcomeScreen
{
    protected Image welcome;
    protected int option;
    protected Font font24;


    public WelcomeScreen()
    {
        welcome = new Image("data/welcome.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
    }

    public int GetChosenOption()
    {
        return option;
    }


    public void Run()
    {
        option = 0;
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);

        //Menu:
        SdlHardware.WriteHiddenText("1. " + ChooseLanguage.lenguage["play"],
            400, 470,
            0xC0, 0xC0, 0xC0,
            font24);
        SdlHardware.WriteHiddenText("2. " + ChooseLanguage.lenguage["credits"],
            400, 500,
            0xA0, 0xA0, 0xA0,
            font24);
        SdlHardware.WriteHiddenText("Q. " + ChooseLanguage.lenguage["quit"],
            400, 530,
            0x80, 0x80, 0x80,
            font24);

        SdlHardware.ShowHiddenScreen();
        do
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_1))
            {
                option = 1;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
            {
                option = 2;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            {
                option = 3;
            }
            SdlHardware.Pause(100); // To avoid using 100% CPU
        }
        while (option == 0);
    }
}

