using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace RayCaster
{
    internal class Draw
    {
        //Desenha o grid do mapa
        public static void drawMap2d(Mapa mapa)
        {
            Raylib_cs.Color cor = new Raylib_cs.Color();
            for(int y = 0; y < mapa.ALTURA; y++)
            {
                for(int x = 0; x < mapa.LARGURA; x++)
                {
                    if (mapa.Grid[y * mapa.LARGURA + x] == 1)
                    {
                        cor = Raylib_cs.Color.White;
                    }
                    else
                    {
                        cor = Raylib_cs.Color.Black;
                    }
                    Raylib.DrawRectangle(x * mapa.TAMANHO, y * mapa.TAMANHO, mapa.TAMANHO - 1, mapa.TAMANHO - 1, cor);
                 

                    


                }
            }
        }

        //Desenha o Player e seu vetor
        public static void drawPlayer(Player player)
        {
            Console.WriteLine($"x = {player.eixo.X}  y = {player.eixo.Y}");
            Raylib.DrawCircle((int)player.eixo.X, (int)player.eixo.Y, 1, Raylib_cs.Color.Gold);
        }



    }
}
