using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BLL
{
    public class IdentifyingCode
    {
        /// <summary>
        /// Generate identifying code
        /// </summary>
        /// <returns>Identifying code</returns>
        public string IdentifyingCodeStringGenerate()
        {
            int number;
            char code;
            string identifyingCode = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                identifyingCode += "" + code.ToString();
            }
            return identifyingCode;
        }

        /// <summary>
        /// Generate identifying code image
        /// </summary>
        /// <param name="identifyingCode"></param>
        /// <returns>Identifying code bitmap</returns>
        public Bitmap IdentifyingCodeImageGenerate(string identifyingCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling((identifyingCode.Length * 20.0)), 32);
            Graphics g = Graphics.FromImage(image);//创建Graphics对象
            if (!string.IsNullOrEmpty(identifyingCode.Trim()))
            {
                Random random = new Random();//生成随机生成器
                g.Clear(Color.White);//清空图片背景色
                for (int i = 0; i < 5; i++)//画图片的背景噪音线
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);//把两点坐标用线连接起来
                }
                Font font = new Font("Arial", 20, (System.Drawing.FontStyle.Bold));//指定字体大小和样式
                g.DrawString(identifyingCode, font, new SolidBrush(Color.Red), 2, 2);//绘制文本字符串
                for (int i = 0; i < 150; i++)//画图片的前景噪点
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));//设置像素
                }
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);//绘制矩形
            }
            return image;
        }
    }
}
