using Raylib_cs;

class Program
{

    static void Main()
    {


        const int screenWidth = 1280;
        const int screenHeight = 720;

        Raylib.InitWindow(screenWidth, screenHeight, "raylib-cs • janela cinza");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Gray); 
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
