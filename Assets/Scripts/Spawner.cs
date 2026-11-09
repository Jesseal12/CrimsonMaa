using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private bool isActive=false;
    [SerializeField] private float mult=1;
    [SerializeField] private GameObject[] enemyTypes;
    public float Timer=1;

    public void UpdateState(float multiplier, bool state) { 
    
    
    mult = multiplier;
    isActive = state;
    
    
    
    
    
    }



    // Update is called once per frame
    void Update()
    {   
        Timer += Time.deltaTime;
      
            
             if (Timer > 10&&isActive==true)
             {
                 float positionX = Random.Range(0, 5);
                 float positionZ = Random.Range(0, 5);
                 var insPos = new Vector3(transform.position.x+positionX, transform.position.y+0.5f,
                     transform.position.z+ positionZ);

                 for (int i = 0; i < 1 * mult; i++)
                 {
                     var enemy = enemyTypes[0];

                     Instantiate(enemy, insPos, Quaternion.identity);


                 }

                 Timer= 0;
             }
             

             





       



    }
}
