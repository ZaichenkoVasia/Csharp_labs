using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static bool CheckIncorrect(edge_t edge1, edge_t edge2)
        {
            return (edge1.vertex1 == edge2.vertex1 && edge1.vertex2 == edge2.vertex2) ||
                   (edge1.vertex1 == edge2.vertex2 && edge1.vertex2 == edge2.vertex1) ||
                   edge1.vertex1 == edge1.vertex2;
        }

        public struct edge_t
        {
            public int vertex1, vertex2;
            public int len;
        }

        public static edge_t[] edges = new edge_t[100];
        public static int[] nodes = new int[100];
        public static int last;

        public static void BubbleSort()
        {
            for (int i = edges.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (edges[j].len < edges[j + 1].len)
                    {
                        edge_t temp = edges[j];
                        edges[j] = edges[j + 1];
                        edges[j + 1] = temp;
                    }
                }
            }
        }

        public static int getColor(int n)
        {
            int c;
            if (nodes[n] < 0)
                return nodes[last = n];
            c = getColor(nodes[n]);
            nodes[n] = last;
            return c;
        }

        static void Main(string[] args)
        {
            int number_vertex, number_edge;
            Console.WriteLine("Write number vertex of graph:");
            number_vertex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write number edge of graph:");
            number_edge = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < number_vertex; i++)
                nodes[i] = -1 - i;
            Random rand = new Random();
            Console.WriteLine("Press 1: Random graph\nPress 2: Write graph\nPress other buttom: exit");
            char choise = Convert.ToChar(Console.ReadLine());
            switch (choise)
            {
                case '1':
                {
                    for (int i = 0; i < number_edge; i++)
                    {
                        edges[i].vertex1 = rand.Next(0, number_vertex);
                        edges[i].vertex2 = rand.Next(0, number_vertex);
                        edges[i].len = rand.Next(1, 50);
                        for (int j = 0; j < i; j++)
                            if (CheckIncorrect(edges[i], edges[j]))
                                i--;
                    }

                    Console.WriteLine("Out of graph (1 vertex -> 2 vertex -> lenght of edge)");
                    for (int i = 0; i < number_edge; i++)
                        Console.WriteLine(edges[i].vertex1 + " " + edges[i].vertex2 + " " + edges[i].len);

                    break;
                }
                case '2':
                {
                    Console.WriteLine("Write graphs: 1 vertex -> 2 vertex -> lenght of edge");
                    for (int i = 0; i < number_edge; i++)
                    {
                        Console.WriteLine("Write 1 vertex for " + (i + 1) + " edge");
                        edges[i].vertex1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write 2 vertex for " + (i + 1) + " edge");
                        edges[i].vertex2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write lenght of edge for " + (i + 1) + " edge");
                        edges[i].len = Convert.ToInt32(Console.ReadLine());
                    }

                    for (int i = 0; i < number_edge; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (CheckIncorrect(edges[i], edges[j]))
                            {
                                Console.WriteLine("Incorrect value of graph!");
                                Console.WriteLine(edges[i].vertex1 + " " + edges[i].vertex2 + " " + edges[i].len);
                                return;
                            }
                        }
                    }

                    break;
                }
                default:
                    return;
            }

            Console.WriteLine("Answer: (1 vertex -> 2 vertex -> lenght of edge)");
            BubbleSort();
            for (int i = 0; i < number_edge; i++)
            {
                int color = getColor(edges[i].vertex2);
                if (getColor(edges[i].vertex1) != color)
                {
                    nodes[last] = edges[i].vertex2;
                    Console.WriteLine(edges[i].vertex1 + " " + edges[i].vertex2 + " " + edges[i].len);
                }
            }

            Console.ReadKey();
        }
    }
}