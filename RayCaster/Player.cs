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
        public float angulo { get; set; } 
        public float velocidade { get; set; }


        public static void movimento(Player p)
        {
            p.velocidade = 1.0f;
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
            if (Raylib.IsKeyDown(KeyboardKey.W)) { p.eixoY += p.dirY * p.velocidade; p.eixoX += p.dirX * p.velocidade; }
            if (Raylib.IsKeyDown(KeyboardKey.S)) { p.eixoY -= p.dirY * p.velocidade; p.eixoX -= p.dirX * p.velocidade; }
            
            //Strafe 
            if (Raylib.IsKeyDown(KeyboardKey.D)) { p.eixoY += p.dirX * p.velocidade; p.eixoX += -p.dirY * p.velocidade; }
            if (Raylib.IsKeyDown(KeyboardKey.A)) { p.eixoY -= p.dirX * p.velocidade; p.eixoX -= -p.dirY * p.velocidade; }


            Console.WriteLine($"x =\t {p.eixoX}\ty = {p.eixoY}");
            Console.WriteLine($"Dirx =\t {p.dirX}\tDiry = {p.dirY}");
            Console.WriteLine($"Ang \n {p.angulo}");
        }


    }
}
