using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Лаба2._2Нетворк
{
    public interface ILibDll
    {
        double CalTheFunc(double x);
        string CalFuncName();
    }

    public class LibDll_1 : ILibDll
    {
        [DllImport("Lib.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {

            try
            {
                return TheFunc(x);

            }
            catch
            {
                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }
    public class LibDll_2 : ILibDll
    {
        [DllImport("Lib2-2-1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-1.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {
            try
            {
                return TheFunc(x);

            }
            catch
            {

                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }
    public class LibDll_3 : ILibDll
    {
        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-2.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {
            try
            {
                return TheFunc(x);

            }
            catch
            {

                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }
    public class LibDll_4 : ILibDll
    {
        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-3-1.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {
            try
            {
                return TheFunc(x);

            }
            catch
            {

                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }
    public class LibDll_5 : ILibDll
    {
        [DllImport("Lib2-2-3-2.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-3-2.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {
            try
            {
                return TheFunc(x);

            }
            catch
            {

                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }
    public class LibDll_6 : ILibDll
    {
        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double TheFunc(double x);
        [DllImport("Lib2-2-3.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern IntPtr FuncName();

        public double CalTheFunc(double x)
        {
            try
            {
                return TheFunc(x);

            }
            catch
            {

                throw new Exception("Ошибка построения графика.");
            }

        }
        public string CalFuncName()
        {
            try
            {
                return Marshal.PtrToStringAnsi(FuncName());

            }
            catch
            {

                return "-";
            }

        }
    }



    class Program
    {
        public static void GetGraph(ILibDll dll)
        {
            const double Step = 0.5;
            const double MinX = 0;
            const double MaxX = 10;
            const string Img = "Graphic.png";
            var xList = new List<double>();
            var yList = new List<double>();

            for (var xx = MinX; xx <= MaxX; xx += Step)
            {
                var res = dll.CalTheFunc(xx);
                xList.Add(xx);
                yList.Add(res);

            }


            //рисуем график

            using (Bitmap bmp = new Bitmap(1000, 1000))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    font = new Font("Arial", 18);
                    SolidBrush Brush = new SolidBrush(Color.Black);
                    Pen blackPen = new Pen(Color.Black, 3);
                    Pen redPen = new Pen(Color.Red, 3);

                    int centre = bmp.Width / 2;
                    g.TranslateTransform(centre, centre);
                    g.DrawString(dll.CalFuncName(), font, Brush, new PointF(50.0f, 50.0f));
                    g.ScaleTransform(1, -1);

                    g.DrawLine(blackPen, 0, centre, 0, -centre);
                    g.DrawLine(blackPen, -centre, 0, centre, 0);


                    var PointList = new PointF[yList.Count];


                    for (int i = 0; i < yList.Count; i++)
                    {
                        var p = new PointF((float)xList[i] * 5, (float)yList[i] * 5);
                        PointList[i] = p;

                    }

                    g.DrawLines(redPen, PointList);


                }
                bmp.Save("D:\\" + Img, System.Drawing.Imaging.ImageFormat.Png);

            }

            Console.WriteLine("График успешно построен. Место нахождения: диск D");


        }
        static void Main(string[] args)
        {


            List<ILibDll> dllList = new List<ILibDll>
            {
                new LibDll_1(),new LibDll_2(),new LibDll_3(),new LibDll_4(),new LibDll_5(),new LibDll_6()
            };
            List<int> IsFunc = new List<int>();

            for (int i = 0; i < dllList.Count; i++)
            {
                if (dllList[i].CalFuncName() != "-")
                {
                    IsFunc.Add(i);
                }
            }
            Console.WriteLine(IsFunc.Count);
            Console.WriteLine("Выберите название функции из списка и напишите её номер\n(" +
                "Пропущены библиотеки, где не удалось загрузить функции)");
            if (IsFunc.Count == 0)
            {
                Console.WriteLine("Нет ни одной рабочей функции.");

            }
            for (int j = 0; j < IsFunc.Count; j++)
            {

                Console.WriteLine($"{IsFunc[j]}) {dllList[IsFunc[j]].CalFuncName()}");
            }

            try
            {
                int k = Convert.ToInt32(Console.ReadLine());
                GetGraph(dllList[k]);

            }
            catch
            {

                throw new Exception("Под таким номером нет функций либо не нашлось ни одной рабочей функции");
            }
        }
    }
}