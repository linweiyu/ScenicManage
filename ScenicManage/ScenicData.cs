using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenicManage
{
    class ScenicData
    {
    }

    public enum Popularity
    {
        Dislike,
        Normal,
        JustSoSo,
        Like,
        Amazing
    }
    public class ScenicNode
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Popularity welcomeDegree { get; set; }
        public bool CanRest { get; set; }
        public bool IsWC { get; set; }
        public List<Edge> edges = new List<Edge>();
        public ScenicNode(string name,string description,Popularity welcomedegree,bool canrest,bool iswc)
        {
            this.name = name;
            this.description = description;
            welcomeDegree = welcomedegree;
            CanRest = canrest;
            IsWC = iswc;
        }
    }
    public class Edge
    {
        public int dest { get; set; }
        public double hours { get; set; }
        public double distance { get; set; }
        public Edge(int Dest,double Hours,double Distance)
        {
            dest = Dest;
            hours = Hours;
            distance = Distance;
        }
        public ScenicNode GetDest(List<ScenicNode> nodes)
        {
            return nodes.Find(node => node.id == this.dest);
        }
    }

    public class StoreData
    {
        public int NodeCount { get; set; }
        public List<ScenicNode> scenicnode { get; set; }
    }
}
