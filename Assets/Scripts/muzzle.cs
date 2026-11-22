using UnityEngine;

public class muzzle : MonoBehaviour
{
   [SerializeField] private PlayerControl playerControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    private void OnEnable()
    {
        playerControl.GetTransform();
    }

    private void OnDisable()
    {
        playerControl.GetTransform();
    }
}
