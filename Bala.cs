using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
namespace GAME_TRAB
{
    class Bala:IObjeto
    {
        public Bala(float x, float y, float r)
        {
            X = x;
            Y = y;
            R = r;
        }

        public string Name => "BALA";
        public float X { get; set; }
        public float Y { get; set; }
        public float R { get; set; }


        public  void Update()
        {
            Y += World.Bala_speed;
            if (Y >= World.Y_Upper)
            {
                World.Remove(this);
                //close();
            }
        }
        public void Render()
        {
            Draw.Fill(54, 54, 54);
            Draw.Circle(new Vector2(X, Y), R, Draw.TEXTURE_MODE.OFF);
        }



       
    }
}
