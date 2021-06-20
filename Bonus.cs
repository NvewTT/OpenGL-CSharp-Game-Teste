using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace GAME_TRAB
{
    class Bonus:Retangulo
    {
        public string tipo { get; set; }
        public float acc { get; set; }
        public float Speedy { get;  set; }

        public Bonus(float x, float y, float w,float h,string tipo) : base(x, y, w, h)
        {
            this.tipo = tipo;
            acc = 0;
            Speedy = 0;
        }

        public override void Update()
        {
            AplllyForce(World.Gravidade);
            Speedy += acc;
            Y += Speedy;
            ColiderWall();
        }

        public override void Render()
        {
            Draw.Fill(54, 54, 54);
            Draw.Quad(new Vector2(X, Y), W, H, Draw.QUAD_MODE.CENTER, "bonus");
            Draw.Fill(0, 0, 0);
            Draw.Texto(X - 3f , Y + W, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_10, tipo+"++");
        }
        public void ColiderWall()
        {
            if (X + W/2 >= World.X_Upper)
            {
                X = World.X_Upper - W/2;    
            }
            else if (X - W / 2 <= World.X_lower)
            {
                X = World.X_lower + W / 2;
                
            }
            else if (Y - H/2 < World.Y_lower)
            {
                Y = World.Y_lower + H / 2;
                Speedy = 0;
            }

        }
        public void AplllyForce(float force)
        {
            acc = force;
        }
    }
}
