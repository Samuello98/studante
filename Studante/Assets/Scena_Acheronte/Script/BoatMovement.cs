using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoatMovement : MonoBehaviour
{
    public float mouseSensitivity = 3f;
    public Transform playerBody;
    public CharacterController controller;
    public float speed = 12f;
    public Animator animator;
    public GameObject remo;
    private AudioSource audioRemo;

    float xRotation = 0f;
    float yRotation = 90f;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yRotation = playerBody.localEulerAngles.y;
        audioRemo = remo.GetComponent<AudioSource>();
        audioRemo.mute = false;
    }
    void Update()
    {
        Rotation();
        Movement();


    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (move.x + move.z < 0.01)
        {
            animator.SetBool("isMoving", false);
            audioRemo.mute = true;
        }
        else
        {
            animator.SetBool("isMoving", true);
            audioRemo.mute = false;
        }

        controller.Move(move * speed * Time.deltaTime);
    }
    void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        Debug.Log("valore mouseX: " + mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        Debug.Log("valore mouseY: " + mouseY);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.Rotate(Vector3.up, mouseX);
        //playerBody.Rotate(playerBody.transform.right * xRotation);
    }







}