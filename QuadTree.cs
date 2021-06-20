using System;
using System.Collections.Generic;
using System.Text;

namespace GAME_TRAB
{
    class QuadTree
    {
        public Retangulo boundary;
        public int capacity;
        public List<Point> points;
        public bool divided;
        public QuadTree northeast;
        public QuadTree northwest;
        public QuadTree southeast;
        public QuadTree southwest;
        public QuadTree(Retangulo boundary, int capacity)
        {
            this.boundary = boundary;
            this.capacity = capacity;
            points = new List<Point>();
            divided = false;
        }

        public void Subdivide()
        {
            Retangulo ne = new Retangulo(boundary.X + boundary.W / 2, boundary.Y - boundary.H / 2, boundary.W / 2, boundary.H / 2);
            northeast = new QuadTree(ne, capacity);
            Retangulo nw = new Retangulo(boundary.X - boundary.W / 2, boundary.Y - boundary.H / 2, boundary.W / 2, boundary.H / 2);
            northwest = new QuadTree(nw, capacity);
            Retangulo se = new Retangulo(boundary.X + boundary.W / 2, boundary.Y + boundary.H / 2, boundary.W / 2, boundary.H / 2);
            southeast = new QuadTree(se, capacity);
            Retangulo sw = new Retangulo(boundary.X - boundary.W / 2, boundary.Y + boundary.H / 2, boundary.W / 2, boundary.H / 2);
            southwest = new QuadTree(sw, capacity);
            divided = true;
        }

        public bool Insert(Point point)
        {
            if (!boundary.Contains(point)){
                return false;
            }
            if (points.Count < capacity)
            {
                points.Add(point);
                Console.WriteLine(points.Count);
                return true;
            }
            
            if (!divided)
            {
                Subdivide();
            }
            return (this.northeast.Insert(point) ||
                northwest.Insert(point) ||
                southeast.Insert(point) ||
                southwest.Insert(point));
            
        }

        public List<Point> Query(Retangulo range, List<Point> found)
        {
            if(found == null)
            {
                found = new List<Point>();
            }
            if (!boundary.Intersect(range))
            {
                return found;
            }
            else
            {
                foreach (var p in points)
                {
                    if (range.Contains(p))
                    {
                        found.Add(p);
                    }
                }
            
                if (divided)
                {
                    northeast.Query(range, found);
                    

                    northwest.Query(range, found);
                    

                    southeast.Query(range, found);
                    

                    southwest.Query(range, found);
                    
                }

                return found;
            }
        }


    }
}
