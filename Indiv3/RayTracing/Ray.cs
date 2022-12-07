using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Ray
    {
        public XYZPoint start, direction;

        public Ray(XYZPoint st, XYZPoint end)
        {
            start = new XYZPoint(st);
            direction = XYZPoint.norm(end - st);
        }

        public Ray() { }

        public Ray(Ray r)
        {
            start = r.start;
            direction = r.direction;
        }

        // отражение
        public Ray reflect(XYZPoint hit_point, XYZPoint normal)
        {
            XYZPoint reflect_dir = direction - 2 * normal * XYZPoint.scalar(direction, normal);
            return new Ray(hit_point, hit_point + reflect_dir);
        }

        // преломление
        public Ray refract(XYZPoint hit_point, XYZPoint normal, float eta)
        {
            Ray res_ray = new Ray();
            float sclr = XYZPoint.scalar(normal, direction);

            float k = 1 - eta * eta * (1 - sclr * sclr);

            if (k >= 0)
            {
                float cos_theta = (float)Math.Sqrt(k);
                res_ray.start = new XYZPoint(hit_point);
                res_ray.direction = XYZPoint.norm(eta * direction - (cos_theta + eta * sclr) * normal);
                return res_ray;
            }
            else
                return null;
        }
    }
}
