using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_TRAB
{
    class RochaGrande : Rocha
    {
        public RochaGrande(float x, float y, float r) : base(x, y, r)
        {
            Vida = new Random().Next(15, 20); // colocar a vida em relação ao dano do player
        }

        public override void Destruir()
        {
            World.Player_Score++;
            World.Add_Later(new RochaMedia(X + 0.5f, Y, R / 2));
            World.Add_Later(new RochaMedia(X - 0.5f, Y, R / 2));
        }
    }
}
