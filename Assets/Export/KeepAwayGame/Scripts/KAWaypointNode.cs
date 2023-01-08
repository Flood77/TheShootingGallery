using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAWaypointNode : KASearchNode
{
    public KAWaypointNode nextWaypoint;

	private void OnTriggerEnter(Collider other)
	{
		KAAgent agent = other.GetComponent<KAAgent>();
		if (agent != null)
		{
			KASearchPath searchPath = agent.GetComponent<KASearchPath>();
			if (searchPath.Node == this)
			{
				searchPath.Node = nextWaypoint;
			}
		}
	}
}
