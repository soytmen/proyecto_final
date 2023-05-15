using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Referenes")]
    public Camera playerCamera;
    [Header("General")]

    public float gravityScale = -20f;
    public int vida;

    [Header("Movement")]

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    [Header("Rotation")]
    public float rotationSensibility;
    [Header("Jump")]
    public bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 2f;

    private float cameraVerticalAngle;
    private Vector3 velocity;

    [SerializeField] Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;

    void Start()
    {
        vida = 100;    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {

        Look();
        Move();
    }
    private void Move()
    {
        
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            Debug.Log(moveInput);
            //moveInput = Vector3.ClampMagnitude(moveInput, 1f);
        if (Input.GetButton("Sprint"))
        {
            moveInput = transform.TransformDirection(moveInput) * runSpeed;
        }
        else
        {
            moveInput = transform.TransformDirection(moveInput) * walkSpeed;
        }

        velocity.y += gravityScale * Time.deltaTime;


        if (Input.GetButtonDown("Jump"))
        {
            moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
        }
        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityScale);
        }
    }
    
    private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle,0f,0f);
    }
}
