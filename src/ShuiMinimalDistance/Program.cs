using System;

namespace ShuiMinimalDistance
{
    public class Program
    {
        const int n = 10;
        const double inf = double.MaxValue;
        public static readonly double[,] Graph = new double[n, n]
        {
            { 0,    0.94, inf,  inf,  inf,  inf,  1.88, inf,  inf,  inf},
            { 0.94, 0,    0.66, inf,  inf,  inf,  1.2,  inf,  inf,  inf},
            { inf,  0.66, 0,    1.04, inf,  1.7,  inf,  inf,  inf,  inf},
            { inf,  inf,  1.04, 0,    inf,  0.77, inf,  inf,  inf,  inf},
            { inf,  inf,  inf,  inf,  0,    1.92, inf,  inf,  inf,  inf},
            { inf,  inf,  1.7,  0.77, 1.92, 0,    inf,  inf,  inf,  1.52},
            { 1.88, 1.2,  inf,  inf,  inf,  inf,  0,    0.53, inf,  inf},
            { inf,  inf,  inf,  inf,  inf,  inf,  0.53, 0,    1.54, inf},
            { inf,  inf,  inf,  inf,  inf,  inf,  inf,  1.54, 0,    0.86},
            { inf,  inf,  inf,  inf,  inf,  1.52, inf,  inf,  0.86, 0}
        };

        static void Main(string[] args)
        {
            int source = 0;
            int destination = 0;

            bool isInputValid = false;
            while (!isInputValid)
            {
                Console.WriteLine("Введите номер начального пункта (начиная с 1): ");
                var inputSource = Console.ReadLine();
                Console.WriteLine("Введите номер конечного пункта (начиная с 1): ");
                var inputDestination = Console.ReadLine();

                isInputValid = ParseAndValidateInput(inputSource, inputDestination, out source, out destination);
                if (!isInputValid)
                {
                    Console.WriteLine("Ошибка. Номера пунктов должны быть в диапазоне [1, 10]");
                }
                Console.WriteLine();
            }

            var result = FindMinDistanceToVertice(Graph, source - 1, destination - 1);

            Console.WriteLine($"Кратчайшее расстояние из пункта {source} в пункт {destination}: {result:0.00} км");
            Console.WriteLine("Нажмите Enter для завершения программы");
            Console.ReadLine();
        }

        public static bool ParseAndValidateInput(string inputSource, string inputDestination, out int source, out int destination)
        {
            var isInputSourceValid = int.TryParse(inputSource, out source) && (source >= 1 && source <= 10);
            var isInputDestinationValid = int.TryParse(inputDestination, out destination) && (destination >= 1 && destination <= 10);
            return isInputSourceValid && isInputDestinationValid;
        }
        public static double FindMinDistanceToVertice(double[,] graph, int source, int destination)
        {
            var distances = Dijkstra(graph, source);
            return distances[destination];
        }

        private static double[] Dijkstra(double[,] a, int v0)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = Double.MaxValue;
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
    }
}