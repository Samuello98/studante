using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetDestination : MonoBehaviour
{
    public List<Transform> _waypoints;
    public NavMeshAgent _navMeshAgent;
    public int _currentWayPointIndex = 0;

    void Update()
    {
        SetWayPointsDestination();
    }

    void SetWayPointsDestination()
    {
        _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
        Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
        _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
    }

}


