using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference attackAction;
   // [SerializeField] private PlayerControlSettingsSo settingsSo;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotatePlayer;
    private Vector2 movement;
    private bool attack;
    private Vector2 rotation;
    private Ray ray;
    public GameObject mousePos;
    [SerializeField] private GameObject bulletToBeShot;
    [SerializeField] private gun gunScript;

    [SerializeField] private LayerMask mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera Camera;
    private void Awake()
    {
        gunScript = transform.Find("gun").gameObject.GetComponent<gun>();
        Camera =FindAnyObjectByType<Camera>();
        rb = GetComponent<Rigidbody>();
        moveAction.action.Enable();
        attackAction.action.Enable();

        
    }

    // setting bullet so that we may alter the bullet before firing it. Setting bullet on gun's end would be tricky
    public void SetBullet(GameObject bullet)
    {
        bulletToBeShot = bullet;

    }
    // we have multiple guns so we make sure we have the correct gun active
    public void SwitchGun()
    { // we check which current gun is active on the scene and set it
        if (transform.Find("gun").gameObject.activeSelf)
        {
            var nextGun = transform.Find("gun").gameObject.GetComponent<gun>();
            gunScript = nextGun;
        }
        else if (transform.Find("gun2").gameObject.activeSelf)
        {

            var nextGun = transform.Find("gun2").gameObject.GetComponent<gun>();
            gunScript = nextGun;
        }
           
        
    }


    // Update is called once per frame
    void Update()
    {
       movement = moveAction.action.ReadValue<Vector2>();
       attack = attackAction.action.IsPressed();
       ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 position=hit.point;
            mousePos.transform.position = position;
        }
       

      
       
     
        
    }

    public void FixedUpdate()
    {
        if (attack)
        {
            gunScript.setBool(true); 
           gunScript.SpawnBulet();
            gunScript.setBool(false);
            var scale = bulletToBeShot.GetComponent<Transform>();
            var rb = bulletToBeShot.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 500f, ForceMode.Impulse);
            // shoot here!

        }

        Vector3 dir = new(movement.x,0f, movement.y);
        Vector3 velocity = dir * 5f;


        // Vector3 lookDir = new(rotation.x, 0f, rotation.y);
        //Vector3 lookVelocity = lookDir * 0.5f;

  // we set rotation and trough slerp determin the speed at which the player rotates. 0 stops player;
        var rotation = Quaternion.LookRotation(mousePos.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,
            rotation, Time.deltaTime * rotatePlayer);
        rb.linearVelocity= new Vector3(velocity.x,0, velocity.z);
     


    }

    // objecti jolla on t‰‰ script tuhoutuu niin
    private void OnDestroy()
    {
        
    }

    private void OnDisable()
    {
        // kun halutaan avata xp ui menu disablataan object
        moveAction.action.Disable();
        attackAction.action.Disable();
    }
}
