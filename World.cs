using System;
using System.Collections.Generic;
using System.Text;

namespace GAME_TRAB
{
    static class World
    {
        public enum Player_estado
        {
            VIVO,
            MORTO
        }
        public static Player_estado player_Estado;
        public static float DeltaTime { get; set; }
        public static float Bala_speed { get; set; }
        public static int Bala_Dano { get; set; }
        public static int Player_Score { get; set; }
        public static float Velocidade_de_ataque { get; set; } // quantidades de balas que serão lançadas pelo player pro segundo Começando em 1 por segundo 
        public static float Player_MOVE { get; set; }
        public static bool Player_Moveu { get; set; }
        public static  float Player_Speed  { get; set; }
    public static float Width {get;set; }
        public static float Height {get;set; }
        public static float X_lower { get; set; }
        public static float X_Upper { get; set; }
        public static float Y_lower { get; set; }
        public static float Y_Upper { get; set; }
        private static float Timer_rocha { get; set; }

        private static float Span_rocha { get; set; }
        private static int Span_rocham { get; set; }
        private static int Span_rochag { get; set; }
        private static int Span_bonus { get; set; }
        private static QuadTree qt;

        private static bool preenchida = false;


        public static readonly float Gravidade = -0.05f;

        private static List<IObjeto> obj;
        private static List<IObjeto> Obj_Removidos;
        private static List<IObjeto> Obj_LaterADD;
        public static void Init()
        {
            obj = new List<IObjeto>();
            Obj_Removidos = new List<IObjeto>();
            Obj_LaterADD = new List<IObjeto>();
            Bala_speed = 10f;
            Bala_Dano = 1;
            Velocidade_de_ataque = 0.25f;
            Player_Score = 0;
            Timer_rocha = 0;

            Span_rocha = 20;
            Span_rocham = 0;
            Span_rochag = 0;
            Player_Speed = 15f;
            Span_bonus = 0;
            for (int i = 0; i < 5; i++)
            {
                World.add(new Rocha((float)new Random().Next(0, 500), (float)new Random().Next(400, 700), 15f));
            }
            
            World.add(new Player(500 / 2, 25, 25, 100));
            player_Estado = Player_estado.VIVO;
        }

        public static void add(IObjeto objeto)
        {
            obj.Add(objeto);
        }
        public static void Add_Later(IObjeto objeto)
        {
            Obj_LaterADD.Add(objeto);
        }

        public static void Remove(IObjeto objeto)
        {
            Obj_Removidos.Add(objeto);
        }

        internal static void cleanAll()
        {
            obj.Clear();
            Obj_Removidos.Clear();
            Obj_LaterADD.Clear();
            Init();
        }

        private static void ADD_obj()
        {
            obj.AddRange(Obj_LaterADD);
            Obj_LaterADD.Clear();
        }


        private static void Remove_obj()
        {
            foreach(var objeto in Obj_Removidos)
            {
                obj.Remove(objeto);
            }
            Obj_Removidos.Clear();
        }


        public static void Update()
        {
            Timer_rocha += DeltaTime;

            if(Timer_rocha >= Span_rocha)
            {
                World.add(new Rocha((float)new Random().Next(0, 500), (float)new Random().Next(500, 700), 15f));
                World.add(new Rocha((float)new Random().Next(0, 500), (float)new Random().Next(500, 700), 15f));
                Timer_rocha = 0f;
                Span_rocham++;
            }
            if (Span_rocham >= 3)
            {
                World.add(new RochaMedia((float)new Random().Next(0, 500), (float)new Random().Next(500, 700), 30f));
                Span_rochag++;
                Span_bonus++;
                Span_rocham = 0;
            }
            if (Span_rochag >= 3)
            {
                World.add(new RochaGrande((float)new Random().Next(0, 500), (float)new Random().Next(600, 700), 60f));
                Span_bonus++;
                Span_rochag = 0;
            }
            if(Span_bonus >= 2)
            {
                World.add(new RochaBonus((float)new Random().Next(0, 500), (float)new Random().Next(600, 700)));
                Span_bonus = 0;
            }

            Draw.Fill(0, 0, 0);
            Draw.Texto(20f, 750f, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_18, "Pontos: " + Player_Score.ToString());
            Draw.Texto(20f, 730f, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_18, "Ataque: " + Bala_Dano.ToString());
            Draw.Texto(20f, 710f, 0, Draw.FONTES.GLUT_BITMAP_HELVETICA_18, "Vel_Mov: " + Player_Speed.ToString());


            Retangulo boundary = new Retangulo(Width/2, Height/2, Width / 2, Height / 2);
            qt = new QuadTree(boundary, 4);


            foreach (var objeto in obj)
            {

                if (objeto is Rocha obRocha)
                {
                    Point point = new Point(obRocha.X, obRocha.Y, obRocha);
                    qt.Insert(point);
                }
                else if (objeto is Retangulo obRetangulo)
                {

                        Point point = new Point(obRetangulo.X, obRetangulo.Y, obRetangulo);
                        qt.Insert(point);


                }
                else
                {
                    if(objeto is Bala obala)
                    {
                        Point point = new Point(obala.X, obala.Y, obala);
                        qt.Insert(point);
                    }
                }

            }
            foreach (var objeto in obj)
            {

                if (objeto is Rocha obRocha)
                {

                    obRocha.Update();
                    obRocha.Render();
                }
                else if (objeto is Retangulo obRetangulo)
                {


                    obRetangulo.Update();
                    obRetangulo.Render();

                }
                else
                {
                    if (objeto is Bala obala)
                    {
                        obala.Update();
                        obala.Render();
                    }
                }
            }
            Remove_obj();
            ADD_obj();
            if(player_Estado == Player_estado.MORTO)
            {
                cleanAll();
            }
            
        }
        public static List<Point> Colisoes(Retangulo area)
        {

                return qt.Query(area,null);


        }
    }
}
