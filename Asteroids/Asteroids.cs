class Asteroids
{
    static void Main()
    {
        bool fullScreen = false;
        SdlHardware.Init(1024, 700, 24, fullScreen);

        WelcomeScreen w = new WelcomeScreen();

        do
        {
            w.Run();
            if (w.GetChosenOption() == 1)
            {
                Game g = new Game();
                g.Run();
                /*Score s = new Score();
                do
                {
                    s.Run();
                } while (s.GetExit() != 0);*/
               
            }
            else if (w.GetChosenOption() == 2)
            {
                CreditsScreen credits = new CreditsScreen();
                credits.Run();
            }
        }
        while (w.GetChosenOption() != 3);
         
    }
}
