using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;


namespace RayCaster
{
    internal class Player // classe do jogador, possui propriedades de eixo(suas coordenas), vetor(sua direção), angulo ...
    {
        //Eixos - coordenadas no mapa
        public float eixoX { get; set; }
        public float eixoY { get; set; }
        //Direção do vetor - seno e cosseno   
        public float dirX { get; set; }
        public float dirY { get; set; }

        //Plano da câmera
        public float planoX { get; set; }
        public float planoY { get; set; }
        public float angulo { get; set; } 
        public float velocidade { get; set; }

        public static float fov = 0.80f;

        public Player()
        {
            eixoX = 100f; eixoY = 200f;
           dirX = -1; dirY = 0;
        }


        public static void movimento(Player p, Mapa m)
        {

            //Angulação do vetor
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                p.angulo += 0.1f;
                if (p.angulo > 2 * MathF.PI) p.angulo -= 2 * MathF.PI;
                p.dirX = MathF.Cos(p.angulo); p.dirY = MathF.Sin(p.angulo);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                p.angulo -= 0.1f;
                if (p.angulo < 0) p.angulo += 2 * MathF.PI;
                p.dirX = MathF.Cos(p.angulo); p.dirY = MathF.Sin(p.angulo);
            }
            //Frente e tras
            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                if (m.Grid[(int)(p.eixoY + p.dirY * 10) / m.TAMANHO, (int)p.eixoX / m.TAMANHO] == 0) { p.eixoY += p.dirY * p.velocidade; p.eixoX += p.dirX * p.velocidade; }
                if (m.Grid[(int)p.eixoY / m.TAMANHO, (int)(p.eixoX + p.dirX * 10) / m.TAMANHO] == 0) { p.eixoY += p.dirY * p.velocidade; p.eixoX += p.dirX * p.velocidade; }
            }
            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                if (m.Grid[(int)(p.eixoY - p.dirY * 10) / m.TAMANHO, (int)p.eixoX / m.TAMANHO] == 0) { p.eixoY -= p.dirY * p.velocidade; p.eixoX -= p.dirX * p.velocidade; }
                if (m.Grid[(int)p.eixoY / m.TAMANHO, (int)(p.eixoX - p.dirX * 10) / m.TAMANHO] == 0) { p.eixoY -= p.dirY * p.velocidade; p.eixoX -= p.dirX * p.velocidade; }
            }

            //Strafe 
            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                if (m.Grid[(int)(p.eixoY + p.dirY * 10) / m.TAMANHO, (int)p.eixoX / m.TAMANHO] == 0) { p.eixoY += p.dirX * p.velocidade; p.eixoX += -p.dirY * p.velocidade; }
                if (m.Grid[(int)p.eixoY / m.TAMANHO, (int)(p.eixoX + p.dirX * p.velocidade) / m.TAMANHO] == 0) { p.eixoY += p.dirX * p.velocidade; p.eixoX += -p.dirY * p.velocidade; }
            }
                
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                if (m.Grid[(int)(p.eixoY - p.dirY * p.velocidade) / m.TAMANHO, (int)p.eixoX / m.TAMANHO] == 0){p.eixoY -= p.dirX * p.velocidade; p.eixoX -= -p.dirY * p.velocidade; }
                if (m.Grid[(int)p.eixoY / m.TAMANHO, (int)(p.eixoX - p.dirX * p.velocidade) / m.TAMANHO] == 0){ p.eixoY -= p.dirX * p.velocidade; p.eixoX -= -p.dirY * p.velocidade; }
            }
            

            if (Raylib.IsKeyDown(KeyboardKey.LeftShift)) { p.velocidade = 5f; } else { p.velocidade = 1.0f;  }


            Console.WriteLine($"x =\t {p.eixoX}\ty = {p.eixoY}");
            Console.WriteLine($"x =\t {(p.eixoX/64)+p.dirX*p.velocidade}\ty = {(p.eixoY/64)+p.dirY}");
            Console.WriteLine($"Dirx =\t {p.dirX}\tDiry = {p.dirY}");
            Console.WriteLine($"Ang \n {p.angulo}");

            

            




        }


    }
}
