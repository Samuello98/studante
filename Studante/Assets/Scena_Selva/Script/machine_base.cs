using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class machine_base : MonoBehaviour
{
    public enum GuardState
    {
        Patrol,
        Chase,
     //   Attack
    }

    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] public GameObject _target;
    [SerializeField] private float _minChaseDistance;
    [SerializeField] private float _minAttackDistance;
    [SerializeField] private float _stoppingDistance;
    public GameObject Virgilio;
    public Canvas canvas;
   

    private GuardState _currentGuardState;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private bool chased = false;
    public GameObject target2;
    private bool canvasNotActivated = true;
    private bool alreadyPlayed;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentGuardState = GuardState.Patrol;
        _animator = GetComponent<Animator>();
        canvas.enabled = false;


    }

    void FixedUpdate()
    {

        Debug.Log(_currentGuardState);
        
        UpdateState(); //cosa fare
        CheckTransition(); //come cambiare 
        Debug.Log("posizione fiera" + transform.position + "posizione target " + _target.transform.position);
        
        
        
    }

    private void UpdateState()
    {
        switch (_currentGuardState)
        {
            case GuardState.Patrol:
                Stop();
                break;
            case GuardState.Chase:
                FollowTarget();
                chased = true;
                StartCoroutine(activateVirgilio());
                break;
          /*  case GuardState.Attack:
                Attack();
                break; */
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
                {
                    newGuardState = GuardState.Chase;
                    _animator.SetBool("walk", true);

                    //audio
                    if (alreadyPlayed == false) 
                    {
                        FindObjectOfType<AudioManager>().FadeIn("VistaFiere");
                        FindObjectOfType<AudioManager>().Play("VistaFiereHit");
                        alreadyPlayed = true;
                    }
                }
                break;
                
            case GuardState.Chase:
                if (!IsTargetWithinDistance(_minChaseDistance))
                {
                    newGuardState = GuardState.Patrol;
                    _animator.SetBool("walk", false);

                    
                }
                break;
                

          /*      if (IsTargetWithinDistance(_minAttackDistance))
                {
                    newGuardState = GuardState.Attack;
                    _navMeshAgent.speed = 10f;
                    
                }
                   break; */

          /*  case GuardState.Attack:
                if (!IsTargetWithinDistance(_stoppingDistance))
                {
                    newGuardState = GuardState.Chase;
                    _navMeshAgent.speed = 3.5f;
                }
                break; */

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newGuardState != _currentGuardState)
        {
            Debug.Log($"Changing State FROM:{_currentGuardState} --> TO:{newGuardState}");
            _currentGuardState = newGuardState;
        }
    }

    /*private void Attack()
    {
        if (IsTargetWithinDistance(_stoppingDistance))
        {
            

            Vector3 targetDirection = _target.transform.position - transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
        }
        else
            FollowTarget();
    }*/

    private void FollowTarget()
    {
        
        _navMeshAgent.SetDestination(_target.transform.position);
    }

    public IEnumerator activateVirgilio()
    {
        if (chased)
        {
            

            yield return new WaitForSeconds(10f);
            if (canvasNotActivated)
            {
                canvas.enabled = true;
                canvasNotActivated = false;
            }
            Virgilio.SetActive(true);
            _target = target2;
            StartCoroutine(ViaDialogo());

            //audio
            yield return new WaitForSeconds(3f);
            FindObjectOfType<AudioManager>().Stop("VistaFiere");

        }

       
    }
    public IEnumerator ViaDialogo()
    {
        yield return new WaitForSeconds(3f);
        canvas.enabled = false;
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
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }

    private void Stop()
    {
        
    }


}