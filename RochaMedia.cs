using System;
using System.Collections.Generic;
using System.Text;

namespace GAME_TRAB
{
    class RochaMedia : Rocha
    {
        public RochaMedia(float x, float y, float r) : base(x, y, r)
        {
            Vida = new Random().Next(10, 15); // colocar a vida em relação ao dano do player
            
        }

        public override void Destruir()
        {
            World.Player_Score++;
            World.Add_Later(new Rocha(X + 0.5f, Y, R / 2));
            World.Add_Later(new Rocha(X - 0.5f, Y, R / 2));
        }
    }
}
