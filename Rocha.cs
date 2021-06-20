using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Tao.OpenGl;
using Tao.FreeGlut;
namespace GAME_TRAB
{
    class Rocha:IObjeto
    {


        public float R { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public int Vida { get; set; }
        public float Speedx { get; set; }
        public float Speedy { get; set; }

        public virtual string Name => "ROCHA";

        public float acc { get; set; }

        public int choice { get; set; }

        public Rocha(float x, float y, float r){

            R = r;
            X = x;
            Y = y;
      

            Speedx = (float)new Random().NextDouble() * (2 - 1) * 2f;
            this.Speedy = 0.0f;
            Vida = new Random().Next(5, 10); // colocar a vida em relação ao dano do player
            acc = 0.0f;
            double rng = new Random().NextDouble();
            if(rng > 0.5)
            {
                choice = 1;
            }
            else
            {
                choice = 2;
            }


        }

        public virtual void Render()
        {

            Draw.Fill(255, 255, 255);            
            Draw.Circle(new Vector2(X, Y), R,Draw.TEXTURE_MODE.ON, choice);
            Draw.Fill(255, 255, 255);
            Draw.Texto(X - (R*.25f), Y, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_18, Vida.ToString());
        }

        public virtual void Update()
        {


            X += Speedx;
            //Y += World.Gravidade * Speedy;
            AplllyForce(World.Gravidade);
            Speedy += acc;
            Y += Speedy ;
            ColiderWall();
            Intersect(World.Colisoes(new Retangulo(X, Y, R, R)));
        }
        public void AplllyForce(float force)
        {
            acc = force;
        }


        public void ColiderWall()
        {
            if (X + R >= World.X_Upper) {
                X = World.X_Upper - R;
                Speedx *= -1;
                

            }else if( X - R <= World.X_lower)
            {
                X = World.X_lower + R;
                Speedx *= -1;
            }
            else if(Y - R < World.Y_lower)
            {
                Y = World.Y_lower + R;
                Speedy *= -1;
                
            }
            
        }



        public void Intersect(List<Point> points)
        {
            if (points == null)
            {
                return ;
            }
            else
            {
                foreach (var p in points)
                {

                    if(p.UserData is Bala other)
                    {
                        float distancia = Vector2.Distance(new Vector2(X, Y), new Vector2(other.X, other.Y));
                        bool acertou = (distancia < R + other.R);
                        if (acertou)
                        {
                            World.Remove(other);
                            Vida -= World.Bala_Dano;
                            if (Vida <= 0)
                            {
                                Destruir();
                                World.Player_Score++;
                                World.Remove(this);
                            }

                        }
                    }

                }
            }
            
        }
        //inplementar
        public bool IntersectsRectangle(Retangulo retangulo)
        {
            float cdx = Math.Abs(X - retangulo.X);
            float cdy = Math.Abs(Y - retangulo.Y);
            if(cdx > (retangulo.W/2 + R)) { return false; }
            if(cdy > (retangulo.H/2 + R)) { return false; }

            if(cdx <= (retangulo.W / 2)) { return true; }
            if(cdy <= (retangulo.H / 2)) { return true; }

            float cornerDist_sq = (((cdx - retangulo.W/2)* (cdx - retangulo.W / 2)) + ((cdy - retangulo.H/2)* (cdy - retangulo.H / 2)));
            return (cornerDist_sq <= (R * R));  
        }



        public virtual void Destruir()
        {
            
        }

        public virtual void LevaDano()
        {

        }


    }
}
