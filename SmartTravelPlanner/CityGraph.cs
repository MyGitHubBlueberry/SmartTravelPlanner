using System.Collections.Generic;
using System.IO;

namespace Travelling;

public class CityGraph
{
    private Dictionary<TNode, List<TEdge>> adjacencyList = new Dictionary<TNode, List<TEdge>>();
    private List<(TNode, TEdge)> print = new List<(TNode, TEdge)>();

    // Loads a bidirectional graph from a file and returns an instance.
    public static CityGraph LoadFromFile(string filePath) {
        CityGraph graph = new CityGraph();
        foreach (string line in File.ReadAllLines(filePath)) {
            string[] arr = line.Split(',');
            string[] nodeAndEdge = arr[0].Split('-');
            TNode node = new TNode(nodeAndEdge[0]);
            TEdge edge = new TEdge(nodeAndEdge[1], int.Parse(arr[1]));
            AddPair(graph, node, edge);
            node = new TNode(nodeAndEdge[1]);
            edge = new TEdge(nodeAndEdge[0], int.Parse(arr[1]));
            AddPair(graph, node, edge);
        }
        return graph;
    }


    public List<string> FindShortestPath(string from, string to) {
        HashSet<string> visited = new HashSet<string>(adjacencyList.Count);
        Dictionary<string, int> distances = new Dictionary<string, int>(adjacencyList.Count);
        Queue<string> toVisit = new Queue<string>([from]);
        List<string> path = new List<string>();

        //exit with empty list if nodes aren't present
        if (!adjacencyList.Keys.Contains(new TNode(from)) 
                || !adjacencyList.Keys.Contains(new TNode(to)))
            return new List<string>();

        foreach (var node in adjacencyList.Keys) {
            distances.Add(node.n, int.MaxValue);
        }
        distances[from] = 0;

        while (toVisit.Count != 0) {
            //step 1: mark the node as visited
            TNode curr = new TNode(toVisit.Dequeue());
            visited.Add(curr.n);
            //step 2: update distance to nodes; distance = distance to the node + edge distance (pick minimal availible)
            foreach (var edge in adjacencyList[curr]) {
                distances[edge.e] = int.Min(distances[edge.e], 
                        distances[curr.n] + edge.weight);
                //step 3: queue edges for visit (avoid visited)
                if (!visited.Contains(edge.e))
                    toVisit.Enqueue(edge.e);
            }
        }

        //exit with empty list if there is no path
        if (!visited.Contains(to)) return new List<string>();

        //step 4: when all nodes are visited, start resonstructing the path: add the 'node' to the list
        string current = to;
        while (current != from) {
            //step 5: find an edge, distance to which = distance to the node - distance between the edge and the node
            path.Add(current);
            foreach (var edge in adjacencyList[new TNode(current)]) {
                if (distances[current] != distances[edge.e] + edge.weight)
                    continue;

                //step 6: add the edge to the list, repeat step 5, untill the 'from' node is found
                current = edge.e;
                break;
            }
        }
        //step 7: add 'from' and reverse the path
        path.Add(from);
        path.Reverse();
        return path;
    }


    public int GetPathDistance(List<string> path) {
        if (path == null || path.Count <= 1) return 0;
        int dist = 0;

        for (int curr = 0, next = 1; curr < path.Count - 1; curr++, next++)
        {
            foreach (var edge in adjacencyList[new TNode(path[curr])]) {
                if (edge.e == path[next]) {
                    dist += edge.weight;
                    break;
                }
            }
        }
        return dist;
    }

    public override string ToString() {
        List<string> output = new List<string>(print.Capacity);
        foreach (var (node, edge) in print) {
            output.Add($"{node.n}-{edge}");
        }
        return string.Join('\n', output);
    }

    private class TNode
    {
        public string n;
        public TNode(string s) => n = s;

        public override bool Equals(object? obj) {
            return obj is TNode node &&
                node.n == this.n;
        }

        public override int GetHashCode() {
            return n.GetHashCode();
        }
    }

    private class TEdge
    {
        public string e;
        public int weight;
        public TEdge(string edge, int weight) {
            this.e = edge;
            this.weight = weight;
        }
        public override string ToString() {
            return e + ',' + weight.ToString();
        }

        public override bool Equals(object? obj) {
            return (obj is TEdge edge) 
                && edge.e == this.e 
                && edge.weight == this.weight;
        }

        public override int GetHashCode() {
            return System.HashCode.Combine(e, weight);
        }
    }

    static void AddPair(CityGraph graph, TNode node, TEdge edge) {
        if (!graph.adjacencyList.ContainsKey(node)) {
            graph.adjacencyList.Add(node, new List<TEdge>());
        } 
        if (!graph.adjacencyList[node].Contains(edge)) {
            graph.adjacencyList[node].Add(edge);
            graph.print.Add((node, edge));
        }
    }
}
