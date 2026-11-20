using UnityEngine;


public class Player_Controller : MonoBehaviour
{
    public float velocity = 7f;
    private CharacterController control; 
    private float horizontalMove;
    private float verticalMove;

    public float gravity = -9.81f;
    public float verticalSpeed;

    public Game_Manager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (control.isGrounded == true)
        {
            verticalSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = 5f;
            }
        }

        verticalSpeed += gravity * Time.deltaTime;

        Vector3 direccion = new Vector3 (horizontalMove, verticalSpeed, verticalMove);
        control.Move(direccion * velocity * Time.deltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Collided with: " + hit.gameObject.name);
        Collectable_Controller collectable = hit.gameObject.GetComponent<Collectable_Controller>();
        if (collectable.isCollected == false) 
        {
            collectable.isCollected = true;
            manager.coins++;
            Debug.Log("Coins:" + manager.coins);
            Destroy(hit.gameObject);
        }
    }
}

