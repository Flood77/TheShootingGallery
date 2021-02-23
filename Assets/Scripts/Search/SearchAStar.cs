using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
using UnityEngine;

public static class SearchAStar
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		bool found = false;

		SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();

		source.Cost = 0;
		source.Heuristic = Vector3.Distance(source.transform.position, destination.transform.position);
		nodes.Enqueue(source, source.Cost + source.Heuristic);

		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			GraphNode node = nodes.Dequeue();

			if (node == destination)
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
					edge.nodeB.Heuristic = Vector3.Distance(edge.nodeB.transform.position, destination.transform.position);

					nodes.Enqueue(edge.nodeB, edge.nodeB.Cost + edge.nodeB.Heuristic);
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
