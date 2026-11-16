using UnityEngine;

public class ammoScript : MonoBehaviour
{
    [SerializeField] private float lifeTime = 8f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);
        }
    }


    private void Update()
    {
        lifeTime-= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(this);
        }
    }


}
