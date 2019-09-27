using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{

    public NavMeshAgent NvMA;
    public Transform[] waypoints;
    int actualPoint;
    // Start is called before the first frame update
    void Start()
    {
        NvMA.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (NvMA.remainingDistance < NvMA.stoppingDistance)
        {
            actualPoint = (actualPoint + 1) % waypoints.Length;
            NvMA.SetDestination(waypoints[actualPoint].position);
        }
    }
}
