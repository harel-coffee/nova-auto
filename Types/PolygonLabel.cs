﻿using System.Collections.Generic;
using System.Windows.Media;


namespace ssi
{
    public class PolygonLabel
    {
        private List<PolygonPoint> polygon;
        private string label;
        private Color color;
        private static int sID = 0;
        private readonly int id; 

        public PolygonLabel(List<PolygonPoint> polygon, string label, Color color)
        {
            if (polygon is null)
                this.polygon = new List<PolygonPoint>();
            else
                this.polygon = polygon;
            
            this.label = label;
            this.color = color;

            id = sID;
            sID++;
        }

        public PolygonLabel(List<PolygonPoint> polygon, string label, Color color, int ID)
        {
            if (polygon is null)
                this.polygon = new List<PolygonPoint>();
            else
                this.polygon = polygon;

            this.label = label;
            this.color = color;

            id = ID;
        }

        public List<PolygonPoint> Polygon
        {
            get 
            {
                List<PolygonPoint> polygonClone = new List<PolygonPoint>();
                if (this.polygon is object)
                    foreach (PolygonPoint p in this.polygon)
                        polygonClone.Add(new PolygonPoint(p.X, p.Y));

                return polygonClone; 
            }

            set 
            { 
                this.polygon = value; 
            }
        }

        public List<PolygonPoint> getRealPolygon()
        {
            return this.polygon;
        }



        public void addPoint(PolygonPoint p)
        {
            this.polygon.Add(p);
        }

        public void removeLastPoint()
        {
            this.polygon.RemoveAt(polygon.Count - 1);
        }

        public void removeAt(int pos)
        {
            this.polygon.RemoveAt(pos);
        }

        public void removeAll()
        {
            this.polygon.Clear();
        }

        public string Label { get => this.label; set => this.label = value; }
        public Color Color { get => color; set => color = value; }

        public int ID => id;

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            
            PolygonLabel pl = obj as PolygonLabel;

            if (pl is null)
                return false;

            if (pl.Label == this.label && pl.Color == this.color && pl.Polygon.Count == this.Polygon.Count && this.id == pl.ID)
            {
                for(int i = 0; i < this.Polygon.Count; i++)
                {
                    if (this.polygon[i].X != pl.polygon[i].X || this.polygon[i].Y != pl.polygon[i].Y)
                    {
                        return false;
                    }
                }
            }
            else
                return false;

            return true;
        }
    }
}