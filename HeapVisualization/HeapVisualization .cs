using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapVisualization
{
    public partial class HeapVisualization : Form
    {
        private List<int> heap;
        private int numLevels;
        private int maxElements;
        private int  width;
       private int height;
        private float deltaX;
        private float deltaY;
      
    public HeapVisualization(List<int> heap)
    {
        this.heap = heap;
        numLevels = (int)Math.Ceiling(Math.Log(heap.Count + 1, 2));
        maxElements = (int)Math.Pow(2, numLevels) - 1;
        width = 800;
        height = 600;
        deltaX = width / (float)(numLevels + 1);
        deltaY = height / (float)(heap.Count + 1);

            InitializeForm();
    }

        private void InitializeForm()
        {
            ClientSize = new Size(width, height);
            Paint += OnPaint;
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);

            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Red;
            Font font = new Font("Helvetica", 8);
            Pen pen = Pens.Black;

            for (int i = 0; i < heap.Count; i++)
            {
                int level = (int)Math.Floor(Math.Log(i + 1, 2) + 1);
                float x = deltaX * level;
                float y = height - (deltaY * (i + 1));

                //   graphics.FillEllipse(brush, x - 10, y - 10, 20, 20);
                graphics.FillEllipse(brush, x - 10, y - 10, 20, 20);
                graphics.DrawEllipse(pen, x - 10, y - 10, 20, 20);
                x -= 5;
                y -= 6;
                graphics.DrawString(heap[i].ToString(), font, Brushes.Black, x, y);

                if (i > 0)
                {
                    int parent = (int)Math.Floor((i - 1) / 2f);
                    int parentLevel = (int)Math.Floor(Math.Log(parent + 1, 2) + 1);
                    float parentX = deltaX * parentLevel;
                    float parentY = height - (deltaY * (parent + 1));

                    graphics.DrawLine(pen, parentX, parentY, x, y);
                }
            }
        }

        private void HeapVisualization_Load(object sender, EventArgs e)
        {

        }
    }
 
}
