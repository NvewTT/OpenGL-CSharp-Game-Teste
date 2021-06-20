using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Tao.OpenGl;
using Tao.FreeGlut;
namespace GAME_TRAB
{
    class Retangulo:IObjeto
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float W { get; set; }
        public float H { get; set; }


        public virtual string Name => "RETANGULO";

        public Retangulo(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;

        }



        public bool Contains(Point point)
        {
            return (point.X >= this.X - this.W && point.X <= this.X + this.W && point.Y >= this.Y - this.H && point.Y <= this.Y + this.H);
        }

        public bool Intersect(Retangulo range)
        {
            return !(range.X - range.W > this.X + this.W || range.X + range.W < this.X - this.W || range.Y - range.H > this.Y + this.H || range.Y + range.H < this.Y - this.H);
        }


        // TERMINAR

        public bool IntersectsCircle(Rocha other)
        {
            float cdx = Math.Abs(other.X - X);
            float cdy = Math.Abs(other.Y - Y);
            if (cdx > (W / 2 + other.R)) { return false; }
            if (cdy > (H / 2 + other.R)) { return false; }

            if (cdx <= (W / 2)) { return true; }
            if (cdy <= (H / 2)) { return true; }

            float cornerDist_sq = (((cdx - W / 2) * (cdx - W / 2)) + ((cdy - H / 2) * (cdy - H / 2)));
            return (cornerDist_sq <= (other.R * other.R));
        }
        //inplementar
        public bool IntersectsRectangle(Retangulo outher)
        {
            // collision x-axis?
            bool collisionX = X + W >= outher.X &&
                outher.X + outher.W >= X;
            // collision y-axis?
            bool collisionY = Y + H >= outher.Y &&
                outher.Y + outher.H >= Y;
            // collision only if on both axes
            return collisionX && collisionY;
        }


        public virtual void Render()
        {
        }

        public virtual void Update()
        {

        }
    }
}
