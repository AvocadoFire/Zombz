using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float moveSpeed = 8;
    [SerializeField] float jumpHeight = 1;
    [SerializeField] float groundedCheck = .01f;
    [SerializeField] float gravity = -50f;
	CharacterController playerController;
    Vector3 velocity;
    bool isGrounded;
    float horizontalInput;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontalInput = 1; //endless runner

        //face forward
        transform.forward = new Vector3(horizontalInput, 0, Mathf.Abs(horizontalInput) - 1);

        //IsGrounded
        isGrounded = Physics.CheckSphere(transform.position, 
            groundedCheck, groundLayers, 
            QueryTriggerInteraction.Ignore);

        //only apply gravity if hero is not grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
        //add gravity
        velocity.y += gravity * Time.deltaTime;
        }

        //horizontal movement
        playerController.Move(new Vector3(horizontalInput * moveSpeed, 0, 0) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //vertical velocity        
        playerController.Move(velocity * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        FindObjectOfType<LevelControl>().Loser();
    }
}
