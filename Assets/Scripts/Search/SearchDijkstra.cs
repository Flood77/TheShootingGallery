using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
using UnityEngine;

public static class SearchDijkstra
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		bool found = false;

        SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();
        source.Cost = 0;
        nodes.Enqueue(source, source.Cost);

        int steps = 0;
        while (!found && nodes.Count > 0 && steps++ < maxSteps)
        {
            GraphNode node = nodes.Dequeue();
            
            if (destination == node)
	        {      
                found = true;
                continue;
            }

            foreach (GraphNode.Edge edge in node.Edges)
            {
                float cost = node.Cost + Vector3.Distance(edge.nodeA.transform.position, edge.nodeB.transform.position);
                
                if (cost < edge.nodeB.Cost)
		        {
                    edge.nodeB.Cost = cost;
                    edge.nodeB.Parent = node;

                    nodes.EnqueueWithoutDuplicates(edge.nodeB, cost);
                }
            }
        }

        path = new List<GraphNode>();
        if (found)
        {
            GraphNode node = destination;
            while (node != null)
            {
                path.Add(node);
                node = node.Parent;
            }

            path.Reverse();
        }
        else
        {
            while (nodes.Count > 0)
            {
                path.Add(nodes.Dequeue());
            }
        }
        return found;

	}
}
