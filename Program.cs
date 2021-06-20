// C# program that uses Tao framework to call
// OpenGL, GLU and FreeGLUT functions.
//
// Steps:
// 1. Install Tao framework. Its .Net assemblies will be added to GAC.
// 2. Create an empty C# console application project in Visual Studio
// 3. Add references to Tao.OpenGL.dll and Tao.FreeGLUT.dll to the project.
//    These files are in C:\Program Files (x86)\TaoFramework\bin
// 4. Paste this source code into the C# source file
// 5. Copy FreeGLUT.dll from C:\Program Files (x86)\TaoFramework\lib to
//    directory of the generated EXE file
// 6. Run. You should see a grey teapot.
//
// Copyright (c) 2013 Ashwin Nanjappa
// Released under the MIT License

using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Numerics;
using System;
using System.Collections.Generic;

namespace GAME_TRAB
{
    class Program
    {


        static DateTime time1 = DateTime.Now;
        static DateTime time2 = DateTime.Now;
        static void Main()
        {

            World.Init();


            
            World.Width = 500;
            World.Height = 800;
            World.X_lower = 0.0f;
            World.X_Upper = 500.0f;
            World.Y_lower = 0.0f;
            World.Y_Upper = 800.0f;
            Glut.glutInit();
            Glut.glutInitWindowSize((int)World.Width, (int)World.Height);
            Glut.glutInitWindowPosition(500, 100);
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH); 
            Glut.glutCreateWindow("Game");
            Draw.Initi();
            Glut.glutDisplayFunc(on_display);
            Glut.glutKeyboardFunc(keyboard);
            Glut.glutTimerFunc(1000, Timer, 0);
            Gl.glClearColor(1f, 1f, 1f, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_ACCUM_BUFFER_BIT);
            Glu.gluOrtho2D(World.X_lower, World.X_Upper, World.Y_lower, World.Y_Upper);
            Glut.glutMainLoop();



        }

        private static void keyboard(byte key, int x, int y)
        {
            
            switch (key)
            {
                case (byte)'a':
                    World.Player_MOVE -=  World.Player_Speed;
                    break;
                case (byte)'d':
                    World.Player_MOVE += World.Player_Speed;
                    break;


            }
        }

        static void on_display()
        {
            time2 = DateTime.Now;
            World.DeltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            World.Update();
            Glut.glutSwapBuffers();
            time1 = time2;
        }

        static void Timer(int a)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1000 / 60, Timer, 0);
        }


    }
}