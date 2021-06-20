using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GAME_TRAB
{
    class RochaBonus:Rocha
    {
        private float vida_inicial { get; set; }
        public RochaBonus(float x, float y, float r=30f) : base(x, y, r)
        {
            Vida = 5;
            vida_inicial = Vida;
        }
        public override void Render()
        {
            Draw.Fill(255, 255, 255);
            Draw.Circle(new Vector2(X, Y), R, Draw.TEXTURE_MODE.ON, choice);
            Draw.Fill(255, 255, 255);
            Draw.Texto(X - (R * .25f), Y, 0, Draw.FONTES.GLUT_BITMAP_TIMES_ROMAN_24, "?");
        }

        public override void Destruir()
        {
            double rng = new Random().NextDouble();
            if (rng >= 0.5)
            {
                World.Add_Later(new Bonus(X, Y, 20f, 20f, "ATK"));
            }
            else
            {
                World.Add_Later(new Bonus(X, Y, 20f, 20f, "VEL"));
            }
            World.Remove(this);
        }
    }
}
