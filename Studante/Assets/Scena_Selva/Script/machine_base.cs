using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class FiniteStateMachine : MonoBehaviour
{
    public enum GuardState
    {
        Patrol,
        Chase,
        Attack
    }

    [SerializeField] private List<Transform> _waypoints;
    //[SerializeField] private GameObject _target;
    [SerializeField] private float _minChaseDistance = 3f;
    [SerializeField] private float _minAttackDistance = 2f;
    [SerializeField] private float _stoppingDistance = 1f;

    private GuardState _currentGuardState;
    private NavMeshAgent _navMeshAgent;
    public Transform transformToFollow;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentGuardState = GuardState.Patrol;

    }

    void Update()
    {

        Debug.Log(_currentGuardState);
        UpdateState(); //cosa fare
        CheckTransition(); //come cambiare 
    }

    private void UpdateState()
    {
        switch (_currentGuardState)
        {
            case GuardState.Patrol:
                
                break;
            case GuardState.Chase:
                _navMeshAgent.destination = transformToFollow.position;
                break;
            case GuardState.Attack:
                Attack();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CheckTransition()
    {
        GuardState newGuardState = _currentGuardState;

        switch (_currentGuardState)
        {
            case GuardState.Patrol:
                if (IsTargetWithinDistance(_minChaseDistance))
                    newGuardState = GuardState.Chase;
                break;

            case GuardState.Chase:
                if (!IsTargetWithinDistance(_minChaseDistance))
                {
                    newGuardState = GuardState.Patrol;
                    break;
                }

                if (IsTargetWithinDistance(_minAttackDistance))
                {
                    newGuardState = GuardState.Attack;
                    break;
                }
                break;

            case GuardState.Attack:
                if (!IsTargetWithinDistance(_stoppingDistance))
                    newGuardState = GuardState.Chase;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newGuardState != _currentGuardState)
        {
            Debug.Log($"Changing State FROM:{_currentGuardState} --> TO:{newGuardState}");
            _currentGuardState = newGuardState;
        }
    }

    private void Attack()
    {
        if (IsTargetWithinDistance(_stoppingDistance))
        {
            _navMeshAgent.isStopped = true;

            Vector3 targetDirection = transformToFollow.position - transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
        }
        else
            FollowTarget();
    }

    private void FollowTarget()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(transformToFollow.position);
    }

    /*private void SetWayPointDestination()
    {
        _navMeshAgent.isStopped = false;
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0f)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    } */

    private bool IsTargetWithinDistance(float distance)
    {
        return (transformToFollow.position - transform.position).sqrMagnitude <= distance * distance;
    }


}