using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    private vector2 movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<RigidBody>();
        moveAction.action.Enable();
        
    }

    // Update is called once per frame
    void Update()
    {
       movement = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {

        Vector3 dir = new(movement.x,0f,movement.y)
        Vector 3 velocity dir*5f;
        rb.linearVelocity = new Vector3(velocity.x,rb.linearVelocity.y)


    }


}
