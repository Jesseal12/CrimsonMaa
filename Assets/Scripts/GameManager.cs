using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager GM;



    // function that adds values from list 2 to list1
    public void CopyArray(GameObject[] list1, GameObject[] list2)
    {


        list1 = list2;
        

    }

    private void Awake()
    {
        if (GM == null)
        {

            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }
}
// Update is called once per frame


