using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // libreria cambio de escena

public class PlayerController : MonoBehaviour
{
    public Vida vida;
    public bool Vida0;
    [Header("Referenes")]
    public Camera playerCamera;
    [Header("General")]

    public float gravityScale = -20f;
    public AudioClip[] efectos;
    public AudioSource volumen;
    public AudioSource andar;
    [Header("Movement")]

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    [Header("Rotation")]
    public float rotationSensibility;
    [Header("Jump")]
    public bool isGrounded;
    private bool moviendose;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float jumpHeight = 2f;

    private float cameraVerticalAngle;

    [SerializeField] Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;

    Rigidbody rb;

    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        vida = GetComponent<Vida>();   
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        RevisarVida();
        Look();
        Move();
       
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            Cursor.lockState = CursorLockMode.None;
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
    }
    void RevisarVida()
    {
        if (Vida0) return;
        if (vida.valor <= 0)
        {
            Vida0 = true;
            Invoke("GameOverMenu", 2f);
            //cambiar escena a game over
        }
    }
    void GameOverMenu() //pasar a menu de gamover
    {
        Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Move()
    {
        

            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            
            if (moveInput !=  Vector3.zero){
                andar.Play();
            }
            else{
                
                andar.Stop();
            }
            
            
          
        if (Input.GetButton("Sprint"))
        {
            
            transform.Translate(moveInput * runSpeed*Time.deltaTime);
        }
        else
        {
            transform.Translate(moveInput * walkSpeed * Time.deltaTime);
            
        }

   

        if (Input.GetButtonDown("Jump") /* && isGrounded*/)
        {
            volumen.PlayOneShot(efectos[2]);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, - transform.up, out hit, 1f))
            {
                    Debug.Log(hit.transform);
            rb.AddForce(0,1000,0, ForceMode.Impulse);
            }
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
