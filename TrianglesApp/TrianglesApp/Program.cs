using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrianglesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // assuming grid is in pixels starting at top left 0,0 going to 60, 60 and not much else other than size of triangles...
            // and working on the fact it's a grid of squares divided in one direction into triangles...
            //
            // test
            Vertex v1 = new Vertex(50, 50);
            Vertex v2 = new Vertex(50, 50);
            Debug.Assert (v1 == v2);
            
            // test 2
            Vertex v3 = new Vertex (60, 60);
            v2 = new Vertex(60, 50);
            var i = new Triangle(v1, v2, v3);

            // test 3
            // ok vertices work and going for some triangle methods
            //Debug.Assert (1 == i);

            // test 4
            //var j = i.IsNinetyDegreeAngleVertexUpOrDown();

            // test final
            var loc = i.GetCoordinateForTriangle();
            Console.WriteLine("output : " + loc);
            Console.ReadKey();
        }
    }
}
