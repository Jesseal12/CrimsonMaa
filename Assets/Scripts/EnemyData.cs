using UnityEngine;
using UnityEngine.UIElements;

public class EnemyData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public GameObject[] players;
    public float movementSpeed=0.005f;
    void Start()
    {
        players =GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // transform.LookAt(players[0].transform.position);
       // gameObject.transform.position += players[0].transform.position-gameObject.transform.position * movementSpeed * Time.deltaTime;
    }
}
