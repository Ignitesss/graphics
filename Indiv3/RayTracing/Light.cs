using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Light: Figure
    {
        public XYZPoint point_light;       // точка, где находится источник света
        public XYZPoint color_light;       // цвет источника света

        public Light(XYZPoint p, XYZPoint c)
        {
            point_light = new XYZPoint(p);
            color_light = new XYZPoint(c);
        }

        // вычисление локальной модели освещения
        public XYZPoint shade(XYZPoint hit_point, XYZPoint normal, XYZPoint color_obj, float diffuse_coef)
        {
            XYZPoint dir = point_light - hit_point;
            dir = XYZPoint.norm(dir);                // направление луча из источника света в точку удара

            XYZPoint diff = diffuse_coef * color_light * Math.Max(XYZPoint.scalar(normal, dir), 0);
            return new XYZPoint(diff.x * color_obj.x, diff.y * color_obj.y, diff.z * color_obj.z);
        }
    }
}
