using System;
using System.Collections.Generic;
using System.Text;

namespace GAME_TRAB
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public IObjeto UserData { get; set; }
        public Point(float x, float y, IObjeto userData)
        {
            X = x;
            Y = y;
            UserData = userData;
        }

    }
}
