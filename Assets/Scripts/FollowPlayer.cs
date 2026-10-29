using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPosition = new Vector3(target.transform.position.x,
           gameObject.transform.position.y,target.transform.position.z);

      gameObject.transform.position = newPosition; 
    }
}
