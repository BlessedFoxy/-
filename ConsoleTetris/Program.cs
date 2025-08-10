using System;
using System.Threading;

namespace ConsoleTetris
{
    class Tetris
    {
       
    private static int width = 10;
        private static int height = 20;
        private static int[,] grid = new int[height, width];
        private static int[,] currentPiece;
        private static int currentX = width / 2 - 1;
        private static int currentY = 0;
        private static bool gameOver = false;
        private static Random random = new Random();
        private static int score = 0;

        // Все возможные фигуры тетриса
        private static int[][,] pieces = new int[][,]
        {
        new int[,] { {1,1,1,1} },                    // I
        new int[,] { {1,1}, {1,1} },                 // O
        new int[,] { {0,1,0}, {1,1,1} },             // T
        new int[,] { {1,0,0}, {1,1,1} },             // L
        new int[,] { {0,0,1}, {1,1,1} },             // J
        new int[,] { {0,1,1}, {1,1,0} },             // S
        new int[,] { {1,1,0}, {0,1,1} }              // Z
        };

        static void Main()
        {
            Console.Title = "Консольный Тетрис";
            Console.CursorVisible = false;
            Console.WindowHeight = height + 5;
            Console.WindowWidth = width * 2 + 10;

            SpawnPiece();
            DrawGrid();

            // Поток для обработки ввода
            Thread inputThread = new Thread(ProcessInput);
            inputThread.Start();

            // Главный игровой цикл
            while (!gameOver)
            {
                Thread.Sleep(500); // Скорость падения фигур
                if (CanMove(currentPiece, currentX, currentY + 1))
                {
                    currentY++;
                }
                else
                {
                    LockPiece();
                    ClearLines();
                    SpawnPiece();
                    if (!CanMove(currentPiece, currentX, currentY))
                    {
                        gameOver = true;
                    }
                }
                DrawGrid();
            }

            inputThread.Join();
            Console.SetCursorPosition(0, height + 2);
            Console.WriteLine("Игра окончена! Ваш счет: " + score);
            Console.ReadKey();
        }

        private static void SpawnPiece()
        {
            currentPiece = pieces[random.Next(pieces.Length)];
            currentX = width / 2 - currentPiece.GetLength(1) / 2;
            currentY = 0;
        }

        private static void DrawGrid()
        {
            Console.Clear();

            // Рисуем границы
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 0; i < width; i++) Console.Write("══");
            Console.Write("╗");

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write("║");
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] == 1 ||
                        (i >= currentY && i < currentY + currentPiece.GetLength(0) &&
                         j >= currentX && j < currentX + currentPiece.GetLength(1) &&
                         currentPiece[i - currentY, j - currentX] == 1))
                    {
                        Console.Write("██");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write("║");
            }

            Console.SetCursorPosition(0, height + 1);
            Console.Write("╚");
            for (int i = 0; i < width; i++) Console.Write("══");
            Console.Write("╝");

            // Отображаем счет
            Console.SetCursorPosition(width * 2 + 3, 2);
            Console.Write("Счет: " + score);

            // Отображаем управление
            Console.SetCursorPosition(width * 2 + 3, 5);
            Console.Write("Управление:");
            Console.SetCursorPosition(width * 2 + 3, 6);
            Console.Write("← → - движение");
            Console.SetCursorPosition(width * 2 + 3, 7);
            Console.Write("↑ - поворот");
            Console.SetCursorPosition(width * 2 + 3, 8);
            Console.Write("↓ - ускорить");
            Console.SetCursorPosition(width * 2 + 3, 9);
            Console.Write("Пробел - сбросить");
        }

        private static void ProcessInput()
        {
            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (CanMove(currentPiece, currentX - 1, currentY))
                                currentX--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (CanMove(currentPiece, currentX + 1, currentY))
                                currentX++;
                            break;
                        case ConsoleKey.DownArrow:
                            if (CanMove(currentPiece, currentX, currentY + 1))
                                currentY++;
                            break;
                        case ConsoleKey.UpArrow:
                            RotatePiece();
                            break;
                        case ConsoleKey.Spacebar:
                            while (CanMove(currentPiece, currentX, currentY + 1))
                                currentY++;
                            break;
                    }
                    DrawGrid();
                }
                Thread.Sleep(50);
            }
        }

        private static bool CanMove(int[,] piece, int newX, int newY)
        {
            for (int i = 0; i < piece.GetLength(0); i++)
            {
                for (int j = 0; j < piece.GetLength(1); j++)
                {
                    if (piece[i, j] == 1)
                    {
                        int x = newX + j;
                        int y = newY + i;

                        if (x < 0 || x >= width || y >= height)
                            return false;

                        if (y >= 0 && grid[y, x] == 1)
                            return false;
                    }
                }
            }
            return true;
        }

        private static void LockPiece()
        {
            for (int i = 0; i < currentPiece.GetLength(0); i++)
            {
                for (int j = 0; j < currentPiece.GetLength(1); j++)
                {
                    if (currentPiece[i, j] == 1)
                    {
                        int y = currentY + i;
                        int x = currentX + j;
                        if (y >= 0) // Проверка на выход за верхнюю границу
                        {
                            grid[y, x] = 1;
                        }
                    }
                }
            }
        }

        private static void RotatePiece()
        {
            int[,] rotated = new int[currentPiece.GetLength(1), currentPiece.GetLength(0)];

            for (int i = 0; i < currentPiece.GetLength(0); i++)
            {
                for (int j = 0; j < currentPiece.GetLength(1); j++)
                {
                    rotated[j, currentPiece.GetLength(0) - 1 - i] = currentPiece[i, j];
                }
            }

            if (CanMove(rotated, currentX, currentY))
            {
                currentPiece = rotated;
            }
        }

        private static void ClearLines()
        {
            for (int i = height - 1; i >= 0; i--)
            {
                bool lineComplete = true;
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        lineComplete = false;
                        break;
                    }
                }

                if (lineComplete)
                {
                    score += 100;
                    // Сдвигаем все линии выше вниз
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            grid[k, j] = grid[k - 1, j];
                        }
                    }
                    // Очищаем верхнюю линию
                    for (int j = 0; j < width; j++)
                    {
                        grid[0, j] = 0;
                    }
                    // Проверяем текущую строку снова
                    i++;
                }
            }
        }
    }
}
