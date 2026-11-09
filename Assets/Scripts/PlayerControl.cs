using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
   // [SerializeField] private PlayerControlSettingsSo settingsSo;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotatePlayer;
    private Vector2 movement;
    private Vector2 rotation;
    [SerializeField] private Ray ray;
    [SerializeField]Transform target;
    public GameObject mousePos;
    [SerializeField] private LayerMask mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera Camera;
    private void Awake()
    {
         Camera =FindAnyObjectByType<Camera>();
        rb = GetComponent<Rigidbody>();
        moveAction.action.Enable();
        lookAction.action.Enable();
    }


    // Update is called once per frame
    void Update()
    {
       movement = moveAction.action.ReadValue<Vector2>();
        // rotation = lookAction.action.ReadValue<Vector2>();
       ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        mousePos.transform.position = ray.direction;

        target = mousePos.transform;
        
       
        print(ray);
        
    }

    public void FixedUpdate()
    {

        Vector3 dir = new(movement.x,0f, movement.y);
        Vector3 velocity = dir * 5f;


        // Vector3 lookDir = new(rotation.x, 0f, rotation.y);
        //Vector3 lookVelocity = lookDir * 0.5f;

        
        var rotation = Quaternion.LookRotation(mousePos.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            rotation, Time.deltaTime * rotatePlayer);

        

        
        rb.linearVelocity= new Vector3(velocity.x,0, velocity.z);
        // rb.AddForce(velocity.x, 0, velocity.z, ForceMode.Impulse);
       // rb.MoveRotation(Quaternion.Euler(lookVelocity.z, lookVelocity.x,0));
       // transform.LookAt(target);
        


    }

    // objecti jolla on t‰‰ script tuhoutuu niin
    private void OnDestroy()
    {
        
    }

    private void OnDisable()
    {
        // kun halutaan avata xp ui menu disablataan object
        moveAction.action.Disable();
        lookAction.action.Disable();
    }
}
