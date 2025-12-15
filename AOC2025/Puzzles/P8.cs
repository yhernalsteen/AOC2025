namespace AOC2025.Puzzles;

public static class P8
{
    public static long Solve1()
    {
        var lines = Utils.ConvertFileToListString(nameof(P8));
        var points = new List<Point>();

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i].Trim();
            var coordinates = line.Split(",");
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            var z = int.Parse(coordinates[2]);
            points.Add(new Point(x, y, z, i));
        }

        var graph = new Graph(points.Count);
        for (var i = 0; i < points.Count; i++)
        {
            for (var j = i + 1; j < points.Count; j++)
            {
                var point = points[i];
                var point2 = points[j];
                var distance = Distance(point, point2);
                
                graph.AddEdge(point, point2, distance);
            }
        }
        

        return graph.KruskalAlgorithm(1000);
    }

    private static long Distance(Point point1, Point point2)
    {
        var dx = (long) point2.X - point1.X;
        var dy = (long) point2.Y - point1.Y;
        var dz = (long) point2.Z - point1.Z;
        // skipping the sqrt for optimal time
        return (dx * dx) + (dy * dy) + (dz * dz);
    }

    public static long Solve2()
    {
        return 0;
    }

    private struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        
        public int Id { get; set; }

        public Point(int x, int y, int z, int id)
        {
            X = x;
            Y = y;
            Z = z;
            Id = id;
        }
    }

    private struct Edge
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
        public long Distance { get; set; }
    }

    private class DisjointSet
    {
        private readonly int[] _parents;
        private readonly int[] _ranks;

        public DisjointSet(int size)
        {
            _parents = new int[size];
            _ranks = new int[size];

            for (var i = 0; i < size; i++)
            {
                _parents[i] = i; // all items are their own parent
                _ranks[i] = 1; // as they are their own parent, rank is now 1
            }
        }

        public int GetSumXBiggestSetMembers(int x)
        {
            var sizes = new Dictionary<int, int>();
            for (var i = 0 ; i < _parents.Length ; i++)
            {
                var root = Find(i);
                if (!sizes.ContainsKey(root))
                {
                    sizes[root] = 1;
                } else
                {
                    sizes[root]++;
                }
            }

            var biggest =  sizes.Values.OrderDescending().Take(x).ToList();
            var result = 1;
            
            foreach (var big in biggest)
            {
                result *= big;
            }
            
            return result;

        }
        public int Find(int p)
        {
            if (_parents[p] != p)
            {
                _parents[p] =  Find(_parents[p]);
            }
            
            return _parents[p];
        }

        public void Union(int x, int y)
        {
            int s1 = Find(x);
            int s2 = Find(y);

            if (s1 != s2)
            {
                if (_ranks[s1] < _ranks[s2])
                {
                    _parents[s1] = s2;
                } else if (_ranks[s2] < _ranks[s1])
                {
                    _parents[s2] = s1;
                }
                else
                {
                    _parents[s2] = s1;
                    _ranks[s1]++;
                }
            }
        }
    }

    private class Graph
    {
        private readonly int _vertexCount;
        private List<Edge> _edges;

        public Graph(int vertexCount)
        {
            _vertexCount = vertexCount;
            _edges = new List<Edge>();
        }

        public void AddEdge(Point p1, Point p2, long distance)
        {
            _edges.Add(new Edge { P1 = p1.Id, P2 = p2.Id, Distance = distance});
        }

        private void SortEdges()
        {
            _edges = _edges.OrderBy(e => e.Distance).ToList();
        }

        public long KruskalAlgorithm(int maxSteps)
        {
            SortEdges();
            
            var disjointSet = new DisjointSet(_vertexCount);
            
            var topXEdges = _edges.Take(maxSteps).ToList();
            foreach (var edge in topXEdges)
            {
                var x = edge.P1;
                var y = edge.P2;

                if (disjointSet.Find(x) != disjointSet.Find(y))
                {
                    disjointSet.Union(x, y);
                }
                
            }

            return disjointSet.GetSumXBiggestSetMembers(3);
        }
            
    }
}