using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float velocity = 7f;
    private CharacterController control; 
    private float horizontalMove;
    private float verticalMove;

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
        Vector3 direccion = new Vector3 (horizontalMove, 0, verticalMove);
        control.Move(direccion * velocity * Time.deltaTime);
    }

}
