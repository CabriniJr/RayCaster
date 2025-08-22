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


        Mapa Mapa1 = new Mapa(24, 24, 64 );
        //Depois fazer o grid do mapa ser assinalado dentro do construtor
        Mapa1.Grid = new int[,]
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }, //1
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //2
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //3
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //4
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //5
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //6
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //7
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //8
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //9
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //10
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //11
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //12
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //13
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //14 
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //15
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //16
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //17
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //18
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //19
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //20
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //21
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //22 
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 }, //23
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }  //24

        };


        //Define um novo jogador - necessário atribuir suas propriedades!
        Player player1 = new Player();
        
       

     
        //Abre uma janela e configura o fps para 60
        Raylib.InitWindow(screenWidth, screenHeight, "RayCasting em c#");
        Raylib.SetTargetFPS(60);

        //Loop principal do jogo
        while (!Raylib.WindowShouldClose())
        {
            Player.movimento(player1, Mapa1);
            //Renderizações aqui - classe Draw especializada para isso - meta: inserir o objeto na fuñção e ele renderizar
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Gray);
            
            //Draw.drawMap2d(Mapa1);
            Draw.drawPlayer(player1);
            Draw.raycasting(player1, Mapa1);
            Raylib.DrawFPS(10, 10);
            Raylib.EndDrawing();

            
        }

        Raylib.CloseWindow();
    }



}
