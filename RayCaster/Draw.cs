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
                    if (mapa.Grid[x,y] == 1)
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
            
            Raylib.DrawCircle((int)player.eixoX, (int)player.eixoY, 3, Raylib_cs.Color.Gold);
            Raylib.DrawCircle((int)player.eixoX + (int)(player.dirX*50), (int)player.eixoY + (int)(player.dirY * 50), 2, Raylib_cs.Color.Red);
        }



    }
}
