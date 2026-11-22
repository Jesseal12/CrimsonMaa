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
    [SerializeField] Transform currentMuzzle; 
    private Ray ray;
    public GameObject mousePos;
    [SerializeField] private GameObject bulletToBeShot;
    [SerializeField] private gun[] gunScripts;
    [SerializeField] private gun currentGun;
   
    
    [SerializeField] float projectileSpeed;
    
    
    [SerializeField] private LayerMask mask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera Camera;


    



    private void Awake()
    {


        gunScripts[0].gameObject.SetActive(true);
        currentGun = gunScripts[0];
      //  currentMuzzle = gunScripts[0].GetComponentInChildren<Transform>();
        /* I tried using getcomponentinchildren what i noticed that the engine keeps using parent transform.
           current theory is getcomponentinchildren sets values directly to the parent. So I need a function that sets transform
        */
        Camera =FindAnyObjectByType<Camera>();
        rb = GetComponent<Rigidbody>();
        moveAction.action.Enable();
        attackAction.action.Enable();

        
    }



    public void GetTransform()
    {
        if (currentMuzzle == null)
        {
            currentMuzzle = gameObject.transform;
        } else if (currentMuzzle != null)
        {
            currentMuzzle = null;
        }
        else
        {

            print("how did we get here");
        }
          

        /* intention is to have muzzles a mostly empty script that calls this function OnEnable and OnDisable.
         Logically we are disabling and enabling guns. to ensure no problems appear I empty the currentmuzzle
        transform. When we swap guns the gun gets disabled and muzzle gets emptied. When we enable the object once
        more tranform gets set. Maybe there is no problem with muzzle already being assigned.
         
         
         */


    }


    // setting bullet so that we may alter the bullet before firing it. Setting bullet on gun's end would be tricky
    public void SetBullet(GameObject bullet)
    {
        bulletToBeShot = bullet;

    }
    // we have multiple guns so we make sure we have the correct gun active
    public void SwitchGun()
    { // we check which current gun is active on the scene and set it
        if (gunScripts[0].gameObject.activeSelf)
        {
           gunScripts[0].gameObject.SetActive(false);
            gunScripts[1].gameObject.SetActive(true);
        }
        else if (gunScripts[1].gameObject.activeSelf)
        {
            gunScripts[1].gameObject.SetActive(false);
            gunScripts[0].gameObject.SetActive(true);
           
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
           Vector3 positionCorrection = new Vector3(position.x,position.y+0.3f,position.z);
            mousePos.transform.position = positionCorrection;
            
        }
       

      
       
     
        
    }

    public void FixedUpdate()
    {
        if (attack)
        {
            currentGun.setBool(true); 
            currentGun.SpawnBulet();
            currentGun.setBool(false);
            var scale = bulletToBeShot.GetComponent<Transform>();
            var rb = bulletToBeShot.GetComponent<Rigidbody>();
            Vector3 temp = currentMuzzle.transform.forward *projectileSpeed;
            Vector3 shootDir= gameObject.transform.localEulerAngles*projectileSpeed;
            if (shootDir.x == 0) { print("Nopeutta ammuksille ei ole asetettu"); }
            rb.AddForce(temp, ForceMode.Impulse);
            // shoot here!

        }

        Vector3 dir = new(movement.x,0f, movement.y);
        Vector3 velocity = dir * 5f;


        // Vector3 lookDir = new(rotation.x, 0f, rotation.y);
        //Vector3 lookVelocity = lookDir * 0.5f;

        // we set rotation and trough slerp determine the speed at which the player rotates. 0 stops player;
        /* X axis aligned with cross product between forward and upwards. z is aligned with forward and 
         y axis is a cross cross product of x axis and z axis. For this to currently work we can't have the player look up 
        or down. The player objects breaks and will look even with restrictions. Quaternion seems to ignore restrictions.
        so one fix is a rotation function that rotates only horrizontaly or making sure the ball is 
        always on the same level as player.
        for this project I plan to to just have the ball position adjusted so that the player can not turn up or down
        
        */
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
