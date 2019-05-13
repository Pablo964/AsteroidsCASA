class CreditsScreen
{
    public void Run()
    {
        Image welcome = new Image("data/credits.png");
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, -100, -90);
        SdlHardware.WriteHiddenText("Asteroids Remake by Pablo",
            390, 630,
            0xCC, 0xCC, 0xCC,
            font18);
        SdlHardware.WriteHiddenText("R " + ChooseLanguage.lenguage["toReturn"],
            20, 20,
            0xBB, 0xBB, 0xBB,
            font18);
        SdlHardware.ShowHiddenScreen();

        do
        {
            SdlHardware.Pause(100); // To avoid using 100% CPU
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}
