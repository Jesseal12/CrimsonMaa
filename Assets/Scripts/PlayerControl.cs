using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private Rigidbody rb;
    private Vector2 movement;
    private Vector2 rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.action.Enable();
        lookAction.action.Enable();
    }


    // Update is called once per frame
    void Update()
    {
       movement = moveAction.action.ReadValue<Vector2>();
       rotation = lookAction.action.ReadValue<Vector2>();

    }

    public void FixedUpdate()
    {

        Vector3 dir = new(movement.x,0f, movement.y);
        Vector3 lookDir = new(rotation.x,0f, rotation.y);
        Vector3 velocity = dir * 5f;
        rb.linearVelocity= new Vector3(velocity.x,0, velocity.z);
        rb.MoveRotation(Quaternion.Euler(lookDir.x,0,lookDir.y));


    }


}
