using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Drawing;

namespace GAME_TRAB
{
    class Player:Retangulo
    {


        public static int pontos;


        
        private float totalTime = 0;

        public override string Name => "PLAYER";
        
        public Player(float x, float y, float w, float h) : base(x, y, w, h)
        {
            pontos = 0;

            
            World.Player_MOVE = X;

        }

        public override void Update()
        {
            if(World.player_Estado == World.Player_estado.VIVO)
            {
                totalTime += World.DeltaTime;
                X = World.Player_MOVE;
                colliderWall();
                Colissoes(World.Colisoes(new Retangulo(X, Y, W, H)));
                if (totalTime > World.Velocidade_de_ataque)
                {
                    World.Add_Later(new Bala(X, Y + 50f, 2f));
                    totalTime = 0;
                }
            }


            //
        }

        private void colliderWall()
        {
            if(X + W/2 >= World.X_Upper)
            {
                X = World.X_Upper - W / 2;
                World.Player_MOVE = X;
            }
            if (X - W / 2 <= World.X_lower)
            {
                X = World.X_lower + W / 2;
                World.Player_MOVE = X;
            }
        }


        public override void Render()
        {
            Draw.Fill(255, 255, 255);

             
            Draw.Quad(new Vector2(X, Y), W, H, Draw.QUAD_MODE.CENTER,"test");
        }



        public void Colissoes(List<Point> pontos)
        {
            if (pontos == null)
            {
                return;
            }
            else
            {
                foreach(var p in pontos)
                {
                    if(p.UserData is Rocha outher){
                        if (outher.Name == "ROCHA")
                        {
                            if (IntersectsCircle(outher))
                            {
                                World.player_Estado = World.Player_estado.MORTO;
                                Draw.Fill(0, 0, 0);
                                Draw.Texto(World.Width/2, World.Height/2, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_18, "Game Over");
                                

                            }
                        }
                    }
                    else if (p.UserData is Bonus bon)
                    {

                            if (IntersectsRectangle(bon))
                            {
                                if(bon.tipo == "ATK")
                                {
                                    World.Bala_Dano++;
                                }
                                else if(bon.tipo == "VEL")
                                {
                                    World.Player_Speed += 5f;
                                }
                                World.Remove(bon);

                            }

                    }
                }
            }
        }
    }
}
