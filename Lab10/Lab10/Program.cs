Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

int width = 60;
int height = 25;
char[,] buffer = new char[width, height];

int BallX = width / 2;
int BallY = height / 2;
int BallDirX = 1;
int BallDirY = 1;

int PlayerY = height / 2;
int AiY = height / 2;

int PlayerScore = 0;
int AiScore = 0;

int GameSpeed = 50;
int AiDifficulty = 95;

Console.CursorVisible = false;
Console.SetWindowSize(width + 1, height + 2);

SelectDifficulty();

while (true)
{
ClearBuffer();
UpdateBall();
UpdatePlayers();
DrawBorders();
DrawPaddles();
DrawBall();
DrawScores();
RenderBuffer();

Thread.Sleep(GameSpeed);
}


void SelectDifficulty()
{
    Console.WriteLine("Виберіть складність гри:");
    Console.WriteLine("1. Легко (Повільна швидкість, точність AI - 94%)");
    Console.WriteLine("2. Середньо (Середня швидкість, точність AI - 96%)");
    Console.WriteLine("3. Важко (Швидка гра, точність AI - 98%)");

    while (true)
    {
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.D1)
        {
            GameSpeed = 15;
            AiDifficulty = 94;
            break;
        }
        else if (key == ConsoleKey.D2)
        {
            GameSpeed = 10;
            AiDifficulty = 96;
            break;
        }
        else if (key == ConsoleKey.D3)
        {
            GameSpeed = 5;
            AiDifficulty = 98;
            break;
        }
    }
    Console.Clear();
}

void ClearBuffer()
{
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            buffer[x, y] = ' ';
        }
    }
}

void DrawToBuffer(int x, int y, char symbol)
{
    if (x >= 0 && x < width && y >= 0 && y < height)
    {
        buffer[x, y] = symbol;
    }
}

void RenderBuffer()
{
    Console.SetCursorPosition(0, 0);
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            Console.Write(buffer [x, y]);
        }
        Console.WriteLine();
    }
}

void UpdateBall()
{
    int nextX = BallX + BallDirX;
    int nextY = BallY + BallDirY;

    if (nextY <= 0 || nextY >= height - 1)
    {
        BallDirY *= -1;
    }

    if (nextX == 5 && nextY >= PlayerY - 1 && nextY <= PlayerY + 1)
    {
        BallDirX *= -1;
    }
    else if (nextX == width - 6 && nextY >= AiY - 1 && nextY <= AiY + 1)
    {
        BallDirX *= -1;
    }

    if (nextX <= 0)
    {
        AiScore++;
        ResetBall();
    }
    else if (nextX >= width - 1)
    {
        PlayerScore++;
        ResetBall();
    }

    BallX += BallDirX;
    BallY += BallDirY;
}

void UpdatePlayers()
{
    while (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.W && PlayerY > 2) PlayerY -= 2;
        if (key == ConsoleKey.S && PlayerY < height - 3) PlayerY += 2;
    }

    if (BallDirX > 0)
    {
        if (BallY < AiY && AiY > 2 && new Random().Next(1, 101) < AiDifficulty) AiY--;
        if (BallY > AiY && AiY < height - 3 && new Random().Next(1, 101) < AiDifficulty) AiY++;
    }
}

void DrawBorders()
{
    for (int x = 0; x < width; x++)
    {
        DrawToBuffer(x, 0, '-');
        DrawToBuffer(x, height - 1, '-');
    }
}

void DrawPaddles()
{
    DrawToBuffer(5, PlayerY - 1, '|');
    DrawToBuffer(5, PlayerY, '|');
    DrawToBuffer(5, PlayerY + 1, '|');

    DrawToBuffer(width - 6, AiY - 1, '|');
    DrawToBuffer(width - 6, AiY, '|');
    DrawToBuffer(width - 6, AiY + 1, '|');
}

void DrawBall()
{
    DrawToBuffer(BallX, BallY, 'O');
}

void DrawScores()
{
    string score = $"{PlayerScore} : {AiScore}";
    int ScoreX = (width - score.Length) / 2;
    for (int i = 0; i < score.Length; i++)
    {
        DrawToBuffer(ScoreX + i, 0, score[i]);
    }
}

void ResetBall()
{
    Random rand = new Random();

    BallX = width / 2;
    BallY = height / 2;

    BallDirX = rand.Next(0, 2) == 0 ? -1 : 1;
    BallDirY = rand.Next(0, 2) == 0 ? -1 : 1;
}


