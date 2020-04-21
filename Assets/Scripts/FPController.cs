using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    private CharacterController controller;
    public Transform groundDetector;
    public LayerMask groundLayer;
    public GameManager gameManager;

    public float sensitivity = 100f;
    public float speed = 10f;
    public bool isDead = false;


    private float rotation = 0f;
    private Vector3 velocity = Vector3.zero;
    private float gravity = -9.81f;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        ////Mouse input
        //float x = Input.GetAxis(InputStrings.MouseX) * sensitivity * Time.deltaTime;
        //float y = Input.GetAxis(InputStrings.MouseY) * sensitivity * Time.deltaTime;

        //controller.transform.Rotate(Vector3.up * x);

        //rotation += y;

        //rotation = Mathf.Clamp(rotation, -88f, 90f);
      
        //Movement
        float moveX = Input.GetAxis(InputStrings.HorizontalAxis);
        float moveZ = Input.GetAxis(InputStrings.VerticalAxis);

        Vector3 moveVector = controller.transform.forward * moveZ +
            controller.transform.right * moveX;

        moveVector *= speed * Time.deltaTime;

        controller.Move(moveVector);

        //gravity
        if (IsOnGround() && velocity.y < 0)
        {
            velocity.y = 0;
        }

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;

        //jumping
        if (Input.GetButtonDown(InputStrings.Jump) && IsOnGround()) {
            velocity.y = 0.1f;
        }


        controller.Move(velocity);
    }

    private bool IsOnGround()
    {
        return Physics.CheckSphere(groundDetector.position, 0.5f, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameManager.CollisionDetected(collision, this);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        gameManager.ColliderDetected(hit.collider, this);
    }
}

public struct InputStrings
{
    public static string MouseX = "Mouse X";
    public static string MouseY = "Mouse Y";
    public static string HorizontalAxis = "Horizontal";
    public static string VerticalAxis = "Vertical";
    public static string Jump = "Jump";
}
