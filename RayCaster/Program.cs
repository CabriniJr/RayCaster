using RayCaster;
using Raylib_cs;

class Program
{

    static void Main()
    {


        const int screenWidth = 1280;
        const int screenHeight = 720;


        Mapa Mapa1 = new Mapa(8, 8, 64 );
        //Depois fazer o grid do mapa ser assinalado dentro do construtor
        Mapa1.Grid = new int[]
        {
            1,1,1,1,1,1,1,1,
            1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,1,
            1,0,0,0,0,0,0,1,
            1,1,1,1,1,1,1,1,
            
        };

        Player player1 = new Player();
        player1.eixo = (100f, 200f);
        player1.vetor = (-1f, 10f);

     
        Raylib.InitWindow(screenWidth, screenHeight, "raylib-cs • janela cinza");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Gray);
            Draw.drawMap2d(Mapa1);
            Draw.drawPlayer(player1);
            Raylib.EndDrawing();

            
        }

        Raylib.CloseWindow();
    }



}
