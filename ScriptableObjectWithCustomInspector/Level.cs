using System;

[Serializable]
public class Level
{
    public int rows = 3;
    public int columns = 4;
    public GameMode gameMode;
    public int timeLimit = 60;
}
