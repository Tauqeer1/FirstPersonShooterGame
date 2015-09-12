using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    Rigidbody bullet;
    Transform Spawn;
    float bulletSpeed;
    bool canFire;
    float fireRate;
    int ammo;
    int ammoPerMagzine;
    int magzine;
    float reloadTime;
    GameObject gunObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ammo > 0 && canFire == true)
        {
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
        }
        if (ammo == 0)
        {
            Reload();
        }
	}
    IEnumerator Fire()
    {
        
        canFire = false;
        Rigidbody bullet1 = Instantiate(bullet, Spawn.position, Spawn.rotation) as Rigidbody;
        bullet1.GetComponent<Rigidbody>().AddForce(Spawn.transform.forward * bulletSpeed);
        ammo--;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    IEnumerator Reload()
    {
        if (magzine > 0)
        {
            canFire = false;
            gunObject.GetComponent<Animation>().CrossFade("Reload");
            ammo = ammoPerMagzine;
            magzine -= ammoPerMagzine;
            yield return new WaitForSeconds(reloadTime);
            canFire = true;
        }
    }
}
