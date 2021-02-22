﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public NavMeshAgent TheNPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    public Animator animator;
   
    
    //audio
    private AudioSource audio;

    private void Start()
    {
    audio = GetComponent<AudioSource>();
    }
    //audioEnd
     

    private void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 0.07f;
                animator.SetBool("walk", true);
                transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, FollowSpeed);

                //audio
                audio.mute = false;
                
            }
            else
            {
                FollowSpeed = 0;
                animator.SetBool("walk", false);


                //audio
                audio.mute = true;
                
            }
        }
    }
}
