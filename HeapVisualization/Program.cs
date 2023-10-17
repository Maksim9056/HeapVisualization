using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapVisualization
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<int> heap = new List<int> { 4, 8, 10, 20, 5, 6, 13, 12, 25, 15, 14, 0, 26, 9, 3, 1, 19, 2, 24, 28, 17, 23, 27, 7, 11, 29, 21, 30, 22, 18, 16 };
            Application.Run(new HeapVisualization(heap));
        }
    }
}
