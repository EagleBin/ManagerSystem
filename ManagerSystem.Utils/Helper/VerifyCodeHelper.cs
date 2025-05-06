using System;
using System.Drawing;
using System.Text;

namespace ManagerSystem.Utils.Helper
{
    public class VerifyCodeHelper
    {
        public static Bitmap CreateVerifyCode(out string code, int width, int height)
        { //建立Bitmap对象，绘图 
            var random = new Random(Guid.NewGuid().GetHashCode());
            Bitmap bitmap = new Bitmap(width, height); Graphics graph = Graphics.FromImage(bitmap);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            Font font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            Random r = new Random(); string letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            //添加随机的五个字母
            for (int x = 0; x < 5; x++)
            {
                string letter = letters.Substring(r.Next(0, letters.Length - 1), 1);
                sb.Append(letter);
                graph.DrawString(letter, font, new SolidBrush(Color.Black), x * 38, r.Next(0, 15));
            }
            code = sb.ToString();
            //混淆背景
            Pen linePen = new Pen(new SolidBrush(Color.Black), 2);
            for (int x = 0; x < 6; x++) graph.DrawLine(linePen, new Point(r.Next(0, width - 1), r.Next(0, height - 1)), new Point(r.Next(0, width - 1), r.Next(0, height - 1)));
            return bitmap;
        }
    }
}
