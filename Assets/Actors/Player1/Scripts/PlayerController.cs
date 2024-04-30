using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float upForce = 250f;
    private float force = 10f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        input = playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(input);
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x, 0f, input.y) * force);
    }
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up * upForce);
            Debug.Log(callbackContext.phase);
        }

    }
}
