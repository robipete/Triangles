using System;

using System.Collections.Generic;

namespace TrianglesApp
{
    public class Triangle
    {
        // ok i'm going to a lot of trouble here to make sure we are not assuming V1 is the ninety degree vertex
        // like the verticies could be passed in any order
        Vertex V1, V2, V3;
        public Triangle (Vertex v1, Vertex v2, Vertex v3)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.V3 = v3;
        }

        private void Validate()
        {
            if (this.V1 == null || this.V2 == null || this.V3 == null)
                throw new Exception("Not Properly Initialized!");
        }

        protected int TopVertex() // x == y
        {
            Validate();
            // relying on equality of fourty five degree verticies equality of pixel coordintates
            var l = new List<int> { this.V1.X, this.V2.X, this.V3.X };
            l.Sort();
            return l[0];
        }

        public int BottomVertex() // x == y
        {
            Validate();
            // relying on equality of fourty five degree verticies equality of pixel coordintates
            var l = new List<int> { this.V1.Y, this.V2.Y, this.V3.Y };
            l.Sort();
            return l[2];
        }

        private bool IsNinetyDegreeAngleVertexUpOrDown()
        {
            Validate();
            // See if the ninety degree triangle vertex is up or down noting validate could be better more restrictive
            // from the problem statement we know that the top v2 is x==y and bottom v3 is x==y so ninety is x<>y
            // follows that ninety down is x == top x and ninety up is y == top y (or x <> top x)
            if (this.V1 != new Vertex(this.BottomVertex(), this.BottomVertex()) // ruling out vertex not ninety angle
                && this.V1 != new Vertex(this.TopVertex(), this.TopVertex())) // is V1 the right angle corner?
                return V1.X == this.TopVertex();
            else
              if (this.V2 != new Vertex(this.BottomVertex(), this.BottomVertex()) // ruling out vertex not ninety angle
                && this.V2 != new Vertex(this.TopVertex(), this.TopVertex())) // is V2 the right angle corner?
                return V2.X == this.TopVertex();
            else
              if (this.V3 != new Vertex(this.BottomVertex(), this.BottomVertex()) // ruling out vertex not ninety angle
                && this.V3 != new Vertex(this.TopVertex(), this.TopVertex())) // is V3 the right angle corner?
                return V3.X == this.TopVertex();
            // true = down
            throw new Exception("Something is seriously messed up!!!");  // we should never get here
        }

        private string GetX()
        {
            //minus one since starting at 'A'
            return ((char)((int)'A' + (int)(this.BottomVertex() / 10) - 1)).ToString();
        }

        private string GetY()
        {
            // here the minus is a flip/flop for direction of triangle
            return ((this.BottomVertex() / 5) - (this.IsNinetyDegreeAngleVertexUpOrDown() ? 1 : 0)).ToString();
        }

        public string GetCoordinateForTriangle()
        {
            var x = GetX();
            var y = GetY();
            return GetX() + GetY();
        }
    }
}
