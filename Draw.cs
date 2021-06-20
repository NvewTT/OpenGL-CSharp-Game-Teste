using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Numerics;
using System.Drawing;


namespace GAME_TRAB
{
    static class Draw
    {

        private static float RED;
        private static float GREEN;
        private static float BLUE;
        public static uint[] texture_player;
        public static uint[] textura_pedras1;
        public static uint[] textura_pedras2;
        public static uint[] textura_pedras3;
        public static uint[] textura_pedras4;
        public static uint[] textura_bonus;

        public static int cont; 

        public enum FONTES
        {
            GLUT_BITMAP_8_BY_13,
            GLUT_BITMAP_9_BY_15,
            GLUT_BITMAP_TIMES_ROMAN_10,
            GLUT_BITMAP_TIMES_ROMAN_24,
            GLUT_BITMAP_HELVETICA_10,
            GLUT_BITMAP_HELVETICA_12,
            GLUT_BITMAP_HELVETICA_18
        }


        public enum TEXTURE_MODE
        {
            ON,
            OFF
        }


        public  enum QUAD_MODE
        {
            CENTER,
            LEFT_CONER,
            TOP_CONER
        }

        public static void LoadTexture(string Path_image)
        {
            //Gl.glEnable(Gl.GL_TEXTURE_2D);

            texture_player = new uint[1];
            Bitmap image = new Bitmap(Path_image);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // storage for texture for one picture

            Gl.glGenTextures(0, texture_player);
            
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture_player[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            
            image.UnlockBits(bitmapdata);
            image.Dispose();
            cont++;
        }

        public static void LoadTextureB(string Path_image)
        {
            //Gl.glEnable(Gl.GL_TEXTURE_2D);

            textura_bonus = new uint[1];
            Bitmap image = new Bitmap(Path_image);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // storage for texture for one picture

            Gl.glGenTextures(3, textura_bonus);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textura_bonus[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

            image.UnlockBits(bitmapdata);
        }
        public static void LoadTexture_Pedras1(string Path_image)
        {
            //Gl.glEnable(Gl.GL_TEXTURE_2D);

            textura_pedras1 = new uint[1];
            Bitmap image = new Bitmap(Path_image);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // storage for texture for one picture

            Gl.glGenTextures(1, textura_pedras1);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textura_pedras1[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

            image.UnlockBits(bitmapdata);
            image.Dispose();

        }
        public static void LoadTexture_Pedras2(string Path_image)
        {
            //Gl.glEnable(Gl.GL_TEXTURE_2D);

            textura_pedras2 = new uint[1];
            Bitmap image = new Bitmap(Path_image);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // storage for texture for one picture

            Gl.glGenTextures(2, textura_pedras2);

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textura_pedras2[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

            image.UnlockBits(bitmapdata);
            image.Dispose();

        }
        //public static void LoadTexture_Pedras3(string Path_image)
        //{
        //    //Gl.glEnable(Gl.GL_TEXTURE_2D);

        //    textura_pedras3 = new uint[1];
        //    Bitmap image = new Bitmap(Path_image);
        //    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //    System.Drawing.Imaging.BitmapData bitmapdata;
        //    Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

        //    bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
        //        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        //    // storage for texture for one picture

        //    Gl.glGenTextures(3, textura_pedras3);

        //    Gl.glBindTexture(Gl.GL_TEXTURE_2D, textura_pedras3[0]);
        //    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
        //                        0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

        //    image.UnlockBits(bitmapdata);
            

        //}
        //public static void LoadTexture_Pedras4(string Path_image)
        //{
        //    //Gl.glEnable(Gl.GL_TEXTURE_2D);

        //    textura_pedras4 = new uint[1];
        //    Bitmap image = new Bitmap(Path_image);
        //    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //    System.Drawing.Imaging.BitmapData bitmapdata;
        //    Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

        //    bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
        //        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        //    // storage for texture for one picture

        //    Gl.glGenTextures(4, textura_pedras4);

        //    Gl.glBindTexture(Gl.GL_TEXTURE_2D, textura_pedras4[0]);
        //    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
        //                        0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

        //    image.UnlockBits(bitmapdata);
            

        //}
        internal static void Initi()
        {
            cont = 0;
            
            LoadTexture("test.jpg");
            LoadTexture_Pedras1("rocha_roxa.jpg");
            LoadTexture_Pedras2("rocha_roxa_escuro.jpg");
            //LoadTextureB("bonus.jpg");
            //LoadTexture_Pedras3("rocha_rosa_estranha.jpg");
            //LoadTexture_Pedras4("rocha_metal.jpg");


        }

        public static void Quad(Vector2 center, float w, float h, QUAD_MODE mode,string Path_image)
        {
            if(Path_image == "test")
            {
                
                
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture_player[0]);
              
                // Linear Filtering

                
                if (mode == QUAD_MODE.LEFT_CONER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glTexCoord2f(0, 0); Gl.glVertex2f(center.X, center.Y);
                    Gl.glTexCoord2f(0, 1); Gl.glVertex2f(center.X, center.Y + h);
                    Gl.glTexCoord2f(1, 1); Gl.glVertex2f(center.X + w, center.Y + h);
                    Gl.glTexCoord2f(1, 0); Gl.glVertex2f(center.X + w, center.Y);
                    Gl.glEnd();
                }
                else if (mode == QUAD_MODE.CENTER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glTexCoord2f(0, 0); Gl.glVertex2f(center.X - w / 2, center.Y - h / 2); //baixo esquerda
                    Gl.glTexCoord2f(0, 1); Gl.glVertex2f(center.X - w / 2, center.Y + h / 2); //alto esquerda
                    Gl.glTexCoord2f(1, 1); Gl.glVertex2f(center.X + w / 2, center.Y + h / 2); //alto direito
                    Gl.glTexCoord2f(1, 0); Gl.glVertex2f(center.X + w / 2, center.Y - h / 2); //baixo direita
                    Gl.glEnd();
                }
                else if (mode == QUAD_MODE.TOP_CONER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glTexCoord2f(0, 0); Gl.glVertex2f(center.X, center.Y - h);
                    Gl.glTexCoord2f(0, 1); Gl.glVertex2f(center.X, center.Y);
                    Gl.glTexCoord2f(1, 1); Gl.glVertex2f(center.X + w, center.Y);
                    Gl.glTexCoord2f(1, 0); Gl.glVertex2f(center.X + w, center.Y - h);
                    Gl.glEnd();
                }
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                
            }
            else
            {
                if (mode == QUAD_MODE.LEFT_CONER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glVertex2f(center.X, center.Y);
                    Gl.glVertex2f(center.X, center.Y + h);
                    Gl.glVertex2f(center.X + w, center.Y + h);
                    Gl.glVertex2f(center.X + w, center.Y);
                    Gl.glEnd();
                }
                else if (mode == QUAD_MODE.CENTER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glVertex2f(center.X - w / 2, center.Y - h / 2); //baixo esquerda
                    Gl.glVertex2f(center.X - w / 2, center.Y + h / 2); //alto esquerda
                    Gl.glVertex2f(center.X + w / 2, center.Y + h / 2); //alto direito
                    Gl.glVertex2f(center.X + w / 2, center.Y - h / 2); //baixo direita
                    Gl.glEnd();
                }
                else if (mode == QUAD_MODE.TOP_CONER)
                {
                    Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
                    Gl.glBegin(Gl.GL_POLYGON);
                    Gl.glVertex2f(center.X, center.Y - h);
                    Gl.glVertex2f(center.X, center.Y);
                    Gl.glVertex2f(center.X + w, center.Y);
                    Gl.glVertex2f(center.X + w, center.Y - h);
                    Gl.glEnd();
                }
            }

            
        }

        public static void Fill(int R, int G, int B)
        {
            RED = (float)R / 255.0f;
            GREEN = (float)G / 255.0f;
            BLUE = (float)B / 255.0f;
            Gl.glColor3f(RED,GREEN,BLUE);
        }



        public static void Texto(float x, float y, float z,FONTES fonte  ,string text)   
        {
            IntPtr currentFont;
            switch (fonte)
            {
                case FONTES.GLUT_BITMAP_8_BY_13:
                    currentFont = Glut.GLUT_BITMAP_8_BY_13;
                    break;
                case FONTES.GLUT_BITMAP_9_BY_15:
                    currentFont = Glut.GLUT_BITMAP_9_BY_15;
                    break;
                case FONTES.GLUT_BITMAP_HELVETICA_10:
                    currentFont = Glut.GLUT_BITMAP_HELVETICA_10;
                    break;
                case FONTES.GLUT_BITMAP_HELVETICA_12:
                    currentFont = Glut.GLUT_BITMAP_HELVETICA_12;
                    break;
                case FONTES.GLUT_BITMAP_HELVETICA_18:
                    currentFont = Glut.GLUT_BITMAP_HELVETICA_18;
                    break;
                case FONTES.GLUT_BITMAP_TIMES_ROMAN_10:
                    currentFont = Glut.GLUT_BITMAP_TIMES_ROMAN_10;
                    break;
                case FONTES.GLUT_BITMAP_TIMES_ROMAN_24:
                    currentFont = Glut.GLUT_BITMAP_TIMES_ROMAN_24;
                    break;
                default:
                    currentFont = Glut.GLUT_BITMAP_TIMES_ROMAN_24;
                    break;

            }
            // Save the current matrix
            //Gl.glPushMatrix();

            // Translate to the appropriate starting point
            Gl.glRasterPos2f(x, y);

            // Note: We could change the line width with 
            
            //Gl.glScalef(3f, 0.2f, 1f);
            // Render the characters
            foreach(char c in text)
            {
                Glut.glutBitmapCharacter(currentFont, c);
            }

            // Another useful function
            // int glutStrokeWidth(void *font, int character);

            // Retrieve the original matrix
            //Gl.glPopMatrix();
            //Gl.glPopMatrix();
        }

        private static uint GetTex(int choice)
        {
            switch (choice)
            {
                case 1:
                    return textura_pedras1[0];
                                       
                case 2:               
                    return textura_pedras2[0];
                case 3:                 
                    return textura_pedras3[0];
                case 4:                 
                    return textura_pedras4[0];

                default:
                    return textura_pedras1[0];
            }

        }


        public static void Circle(Vector2 center, float r, TEXTURE_MODE texture,int choice =0)
        {
            if(texture == TEXTURE_MODE.ON && choice !=0)
            {
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, GetTex(choice));
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);

                for (int i = 0; i < 360; i++)
                {
                    float angle = (i * MathF.PI) / 180;
                    float xcos = MathF.Cos(angle);
                    float ysin = MathF.Sin(angle);
                    float x = center.X + (r * xcos);
                    float y = center.Y + (r * MathF.Sin(angle));
                    float tx = xcos * 0.5f + 0.5f;
                    float ty = ysin * 0.5f + 0.5f;
                    Gl.glTexCoord2f(tx, ty);
                    Gl.glVertex2f(x, y);
                }
                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            }
            else
            {
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);

                for (int i = 0; i < 360; i++)
                {
                    float angle = (i * MathF.PI) / 180;
                    float xcos = MathF.Cos(angle);
                    float ysin = MathF.Sin(angle);
                    float x = center.X + (r * xcos);
                    float y = center.Y + (r * MathF.Sin(angle));
                    float tx = xcos * 0.5f + 0.5f;
                    float ty = ysin * 0.5f + 0.5f;
                    Gl.glTexCoord2f(tx, ty);
                    Gl.glVertex2f(x, y);
                }
                Gl.glEnd();
            }

        }
    }

}
