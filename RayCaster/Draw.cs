using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
            for (int y = 0; y < mapa.ALTURA; y++)
            {
                for (int x = 0; x < mapa.LARGURA; x++)
                {
                    if (mapa.Grid[y, x] == 1)
                    {
                        cor = Raylib_cs.Color.White;
                    }
                    else
                    {
                        cor = Raylib_cs.Color.Black;
                    }
                    Raylib.DrawRectangle(x * mapa.TAMANHO/4, y * mapa.TAMANHO/4, mapa.TAMANHO/4 - 1, mapa.TAMANHO/4 - 1, cor);





                }
            }
        }

        //Desenha o Player e seu vetor
        public static void drawPlayer(Player player)
        {

            Raylib.DrawCircle((int)player.eixoX/4, (int)player.eixoY/4, 2, Raylib_cs.Color.Gold);
            Raylib.DrawCircle((int)player.eixoX/4 + (int)(player.dirX * 10)/4, (int)player.eixoY/4 + (int)(player.dirY * 10)/4, 2, Raylib_cs.Color.Red);
        }






        //Lode Vandevenne DDA 
        public static void raycasting(Player p, Mapa m)
        {
            p.planoX = - p.dirY * Player.fov;
            p.planoY = p.dirX * Player.fov;


            for(int i = 0; i <Raylib.GetScreenWidth(); i++)
            {
                const float EPS = 1e-6f;

                // posição do jogador em CELULAS
                float posX = p.eixoX / m.TAMANHO;
                float posY = p.eixoY / m.TAMANHO;

                // Valor normalizado da câmera (-1 na esquerda até +1 na direita)
                float cameraX = 2 * i / (float)Raylib.GetScreenWidth() - 1;

                // Direção do raio (combina direção + plano da câmera)
                float dirX = p.dirX + p.planoX * cameraX;
                float dirY = p.dirY + p.planoY * cameraX;

                // célula atual
                int mapX = (int)MathF.Floor(posX);
                int mapY = (int)MathF.Floor(posY);

                // distâncias incrementais
                float deltaDistX = (MathF.Abs(dirX) < EPS) ? float.PositiveInfinity : MathF.Abs(1f / dirX);
                float deltaDistY = (MathF.Abs(dirY) < EPS) ? float.PositiveInfinity : MathF.Abs(1f / dirY);

                // passo e distância até a primeira borda de grade
                int stepX, stepY;
                float sideDistX, sideDistY;

                if (dirX < 0)
                {
                    stepX = -1;
                    sideDistX = (posX - mapX) * deltaDistX;
                }
                else
                {
                    stepX = 1;
                    sideDistX = (mapX + 1f - posX) * deltaDistX;
                }

                if (dirY < 0)
                {
                    stepY = -1;
                    sideDistY = (posY - mapY) * deltaDistY;
                }
                else
                {
                    stepY = 1;
                    sideDistY = (mapY + 1f - posY) * deltaDistY;
                }

                bool hit = false;
                int side = 0;
                int safe = m.LARGURA + m.ALTURA + 16; // limite

                while (!hit && safe-- > 0)
                {
                    if (sideDistX < sideDistY)
                    {
                        sideDistX += deltaDistX;
                        mapX += stepX;
                        side = 0;
                    }
                    else
                    {
                        sideDistY += deltaDistY;
                        mapY += stepY;
                        side = 1;
                    }

                    if (mapX < 0 || mapX >= m.LARGURA || mapY < 0 || mapY >= m.ALTURA)
                        break;

                    if (m.Grid[mapY, mapX] == 1)
                        hit = true;
                }
                if (!hit) return;

                // distância percorrida ao longo do raio (em células)
                float distCells = (side == 0) ? (sideDistX - deltaDistX) : (sideDistY - deltaDistY);

                //Calcula o tamanho da linha que tem que desenhar na tela
                int lineHeight = (int)(Raylib.GetScreenHeight() / distCells);

                //Calcula o menor e maior ponto para pintar a linha
                int drawStart = -lineHeight / 2 + Raylib.GetScreenHeight() / 2;
                if (drawStart < 0) drawStart = 0;
                int drawEnd = lineHeight / 2 + Raylib.GetScreenHeight() / 2;
                if (drawEnd >= Raylib.GetScreenHeight()) drawEnd = Raylib.GetScreenHeight() - 1;
                Raylib_cs.Color Cor = Raylib_cs.Color.Green;
                if(side == 1) Cor = Raylib_cs.Color.DarkGreen;
                Raylib.DrawLine(i, drawStart, i, drawEnd, Cor);





                // ponto de impacto em PIXELS
                float hitX = p.eixoX + dirX * distCells * m.TAMANHO;
                float hitY = p.eixoY + dirY * distCells * m.TAMANHO;

                // desenha a célula atingida (semi-transparente) + linha do raio
                //Raylib.DrawRectangle(mapX * m.TAMANHO/4, mapY * m.TAMANHO/4, m.TAMANHO/4, m.TAMANHO/4, new Raylib_cs.Color(255, 0, 0, 80));
                //Raylib.DrawLine((int)p.eixoX/4, (int)p.eixoY/4, (int)hitX/4, (int)hitY/4, Raylib_cs.Color.Red);
                //Raylib.DrawCircle((int)hitX/4, (int)hitY/4, 2.0f, Raylib_cs.Color.Purple);
                


            }
            
       
            
           
            
        }   

    }

}

