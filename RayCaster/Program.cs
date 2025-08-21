using System.Numerics;
using RayCaster;
using Raylib_cs;

class Program
{
    /*
     * TO DO
     * - Movimentação do player (manipulação das suas variaveis)
     * - Estudar e aplicar os Raios com DDA (foda)
     * - Renderizar em pseudo 3d
     * - Seguir os estudos
     * 
    */
    static void Main()
    {


        const int screenWidth = 1280;
        const int screenHeight = 720;


        Mapa Mapa1 = new Mapa(8, 10, 30 );
        //Depois fazer o grid do mapa ser assinalado dentro do construtor
        Mapa1.Grid = new int[,]
        {
            { 1,1,1,1,1,1,1,1,1,1 },
            { 1,0,1,0,0,0,0,0,0,1 },
            { 1,0,1,0,0,0,0,0,0,1 },
            { 1,0,1,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,1,0,0,0,0,1 },
            { 1,0,0,0,1,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1 }
            
        };


        //Define um novo jogador - necessário atribuir suas propriedades!
        Player player1 = new Player();
        player1.eixoX = 100f; player1.eixoY = 200f;
       

     
        //Abre uma janela e configura o fps para 60
        Raylib.InitWindow(screenWidth, screenHeight, "RayCasting em c#");
        Raylib.SetTargetFPS(60);

        //Loop principal do jogo
        while (!Raylib.WindowShouldClose())
        {
            Player.movimento(player1);
            //Renderizações aqui - classe Draw especializada para isso - meta: inserir o objeto na fuñção e ele renderizar
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Gray);
            
            Draw.drawMap2d(Mapa1);
            Draw.drawPlayer(player1);
            Draw.raycasting(player1, Mapa1);
            Raylib.DrawFPS(10, 10);
            Raylib.EndDrawing();

            
        }

        Raylib.CloseWindow();
    }



}
