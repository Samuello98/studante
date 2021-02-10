using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoatMovement: MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public CharacterController controller;
    public float speed = 12f;
    public Animator animator; 


    float xRotation = 0f;   

   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Movement();
        Rotation();

    }
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if( x == 0 && z == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        controller.Move(move * speed * Time.deltaTime);
    }
    void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = -mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
   

   




}
