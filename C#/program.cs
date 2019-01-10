using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace TerrainGen
{
    public class Line
    {
        decimal x0, y0, x1, y1;
        
        public Line(int x0, int y0, int x1, int y1)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
        }
        
        public int PlotY(int x)
        {
            decimal yRaw = (y1 - y0) / (x1 - x0) * (x - x0) + y0;
            int y = decimal.ToInt32(Math.Round(yRaw));
            //Console.WriteLine("({0} - {1}) / ({2} - {3}) * ({4} - {3}) + {1} = {5}", y1, y0, x1, x0, x, y);
            return y;
        }
    }

    public class Vector2
    {
        public decimal x, y;
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Shape
    {
        Vector2[] pointCoOrds;
        Vector2[] raster;
        int index = 0;
        decimal x0, y0, x1, y1, dX, dY, m, x, y;
        public Shape(params Vector2[] CoOrds)
        {
            foreach (var item in CoOrds)
            {
                pointCoOrds = CoOrds;
                
            }
        }

        public void DrawLines()
        {
            for(int i = 0; i < pointCoOrds.Length; i++)
            {
                x0 = pointCoOrds[i].x;
                y0 = pointCoOrds[i].y;
                x1 = pointCoOrds[i + 1].x;
                y1 = pointCoOrds[i + 1].y;

                dX = x1 - x0;
                dY = y1 - y0;

                if (dX > dY)
                {
                    m = dY / dX;
                    for (int j = 0; j < dX; j++)
                    {
                        y = m * j + y0;
                        raster[index].x = j;
                        raster[index].y = y;
                        index++;
                    }
                }
                else
                {
                    for (int j = 0; j < dY; j++)
                    {

                    }
                }
                
            }
        }

        public void DrawToBitMap ()
        {

        }
        //public Bitmap DrawLine(Bitmap bitmap, int x0, int y0, int x1, int y1, Color color)
        //{
        //    int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
        //    int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
        //    int err = (dx > dy ? dx : -dy) / 2, e2;
        //    for (; ; )
        //    {
        //        bitmap.SetPixel(x0, y0, color);
        //        if (x0 == x1 && y0 == y1) break;
        //        e2 = err;
        //        if (e2 > -dx) { err -= dy; x0 += sx; }
        //        if (e2 < dy) { err += dx; y0 += sy; }
        //    }
        //    return bitmap;
        //}
    } 
    public class Gen
    {
        static void Main(string[] args)
        {
            Bitmap bitmap = new Bitmap(1000, 1000);
            
            int[,] foo = new int[50, 50];
            Line line = new Line(11, 15, 1, 1);
            for (int i = 1; i <= 20; i++)
            {
                foo[i, line.PlotY(i)] = 1;
                //Console.WriteLine(i + ", " + line.PlotY(i)
            }
            for (int y = 0; y < foo.GetLength(1); y++)
            {
                for (int x = 0; x < foo.GetLength(0); x++)
                {
                    Console.Write(foo[x, y]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}