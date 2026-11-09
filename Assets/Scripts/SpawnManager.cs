using NUnit.Framework;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] spawners;
    [SerializeField] private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var obj = spawners[0].GetComponent<Spawner>();
        var obj2 = spawners[1].GetComponent<Spawner>();
        var obj3 = spawners[2].GetComponent<Spawner>();
        var obj4 = spawners[3].GetComponent<Spawner>();
        obj.UpdateState(1, true);
        obj2.UpdateState(1, false);
        obj3.UpdateState(1, false);
        obj4.UpdateState(1, false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10) {

            var obj2 = spawners[1].GetComponent<Spawner>();
            obj2.UpdateState(1, true);

        }

        if (timer > 20) {
            var obj3 = spawners[2].GetComponent<Spawner>();
            obj3.UpdateState(1, true);


        }


        if (timer > 30) {

            var obj4 = spawners[3].GetComponent<Spawner>();
            obj4.UpdateState(1, true);
            



        }



        
    }
}
