using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Side
    {
        public Figure host = null;
        public List<int> points = new List<int>();
        public Pen drawing_pen = new Pen(Color.Black);
        public XYZPoint Normal;

        public Side(Figure h = null)
        {
            host = h;
        }
        public Side(Side s)
        {
            points = new List<int>(s.points);
            host = s.host;
            drawing_pen = s.drawing_pen.Clone() as Pen;
            Normal = new XYZPoint(s.Normal);
        }
        public XYZPoint get_point(int ind)
        {
            if (host != null)
                return host.points[points[ind]];
            return null;
        }

        public static XYZPoint norm(Side S)
        {
            if (S.points.Count() < 3)
                return new XYZPoint(0, 0, 0);
            XYZPoint U = S.get_point(1) - S.get_point(0);
            XYZPoint V = S.get_point(S.points.Count - 1) - S.get_point(0);
            XYZPoint normal = U * V;
            return XYZPoint.norm(normal);
        }
    }
}
