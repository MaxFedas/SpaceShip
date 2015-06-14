using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    static class Map
    {
        static private int _height;
        static private int _width;
        static private int _infoWidth;
        static Map()
        {
            _height = 60;
            _width = 80;
            _infoWidth = 25;
        }
        public static int InfoWidth
        {
            get { return _infoWidth; }
        }
        public static int Height
        {
            set { _height = value;}
            get { return _height; }
        }
        public static int Width
        {
            set { _width = value; }
            get { return _width; }
        }
    }
}
