class Room
{
    protected Image stars1, stars2;

    protected int mapHeight = 14, mapWidth = 35;
    protected int tileWidth = 51, tileHeight = 38;
    protected int leftMargin = 0, topMargin = 0;
    
    //aumentar array
    protected string[] levelData =
    {
        "      1                                ",
        "                                       ",
        "         1                             ",
        "                                       ",
        "                                       ",
        "           2                           ",
        "                                       ",
        "                                       ",
        "                                       ",
        "                                       ",
        "        2                              ",
        "                                       ",
        "                                 1     ",
        "                                       "};

    public Room()
    {
        stars1 = new Image("data/estrellas3.png");
        stars2 = new Image("data/estrellas4.png");
        
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * tileWidth + leftMargin;
                int posY = row * tileHeight + topMargin;
                switch (levelData[row][col])
                {
                    case '1': SdlHardware.DrawHiddenImage(stars1, posX, posY); break;
                    case '2': SdlHardware.DrawHiddenImage(stars2, posX, posY); break;

                }
            }
        }
    }

   /* public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        for (int column = 0; column < mapWidth; column++)
        {
            for (int row = 0; row < mapHeight; row++)
            {
                char tile = levelData[row][column];
                if (tile != ' ')  // Space means a tile can be crossed
                {
                    int x1tile = leftMargin + column * tileWidth;
                    int y1tile = topMargin + row * tileHeight;
                    int x2tile = x1tile + tileWidth;
                    int y2tile = y1tile + tileHeight;
                    if ((x1tile < x2) &&
                        (x2tile > x1) &&
                        (y1tile < y2) &&
                        (y2tile > y1) // Collision as bouncing boxes
                        )
                        return false;
                }
            }
        }
        return true;
    }*/

}
