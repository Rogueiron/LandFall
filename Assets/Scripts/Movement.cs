using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    private Look look;

    public float speed = 12f;
    public float sprintSpeed = 16f;

    Vector3 velocity;

    public float gravity = -9.81f;

    public float JumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;

    private bool isGrounded;

    public bool sprint;

    public float energy = 0f;

    private GameObject main;
    private GameObject playerbody;


    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        playerbody = GameObject.Find("Player");
        main = Camera.main.gameObject;
        look = gameObject.GetComponent<Look>();
    }
    void Update()
    {
        Camera.main.transform.position = GameObject.Find("CamHolder").transform.position;
        main.SetActive(true);
        playerbody.SetActive(true);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = true;
        }
        else
        {
            sprint = false;
        }

        if (sprint == true && energy <= 10)
        {
            energy += Time.deltaTime;
            controller.Move(move * sprintSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else if (energy <= 0)
        {
            energy = 0;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else if (energy >= 0 && sprint == false)
        {
            energy -= 0.1f;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
}

