using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] private Transform muzzle;
    [SerializeField] private bool beingShot;
    [SerializeField] private PlayerControl player;

    private void Awake()
    {
        muzzle = transform.GetComponentInChildren<Transform>();
        player = FindAnyObjectByType<PlayerControl>();
    }

  public  void SpawnBulet()
    {
        if (beingShot==true) {
            var bul = Instantiate(ammo, muzzle.transform.position, Quaternion.identity);
            player.SetBullet(bul);

        }
        
        



    }


 public void setBool(bool b)
    {
        beingShot = b;

    }







}
