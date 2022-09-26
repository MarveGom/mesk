using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private float jumpHeight = 200f;
    private float runningSpeed = 8f;
    private Rigidbody rb;
    private Vector2 movementInput;
    private bool sprinting;
    private AudioSource source;



    [Range(0.5f, 10f)] public float speed;

    float initialDuration;

    void Start()
    {
        source= GetComponent<AudioSource>();

        rb = gameObject.GetComponent<Rigidbody>();

        Cursor.visible = false;
    }
    
    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (sprinting == false)
            {
                movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (sprinting == true)
                {
                    sprinting = false;
                }
                else if (sprinting == false)
                {
                    sprinting = true;

                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            Movement();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight);
    }

    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result = Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 0.9f);
        return result;
    }

    private void Movement()
    {
        if(sprinting == false)
        {
            rb.MovePosition(transform.position + (transform.right * speed * Time.fixedDeltaTime * movementInput.x + transform.forward * speed * Time.deltaTime * movementInput.y));
        }
        else
        {
            rb.MovePosition(transform.position + (transform.right * runningSpeed * Time.fixedDeltaTime * movementInput.x + transform.forward * runningSpeed * Time.deltaTime * movementInput.y));
        }
        
    }

}