using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 16f;

    Vector3 velocity;

    public float gravity = -9.81f;

    public float JumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayerMask;

    private bool isGrounded;

    public GameObject SteamShot;

    public float switchCount = 0f;

    public GameObject L;
    public GameObject R;

    public GameObject G;

    public bool sprint;

    public float energy = 0f;

    public float Lifetime = 10f;
   
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(switchCount >= 1) 
            {
                switchCount = 0;
            }
            else
            {
                switchCount += 1;
            }
        }
        if (switchCount == 1)
        {
            L.SetActive(false);
            R.SetActive(false);
            G.SetActive(true);
        }
        else if (switchCount == 0)
        {
            L.SetActive(true);
            R.SetActive(true);
            G.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(SteamShot,transform.position,transform.rotation);
                Lifetime -= Time.deltaTime;
            }
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
        else if(energy <= 0)
        {
            energy = 0;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else if(energy >= 0 && sprint == false)
        {
            energy -= 0.1f;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }
}
