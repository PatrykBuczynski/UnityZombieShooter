using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    AudioManager audioManager;
    public GameObject bullet;
    public Transform gunTip;

    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }
    void Fire()
    {
        FindObjectOfType<AudioManager>().Play("BulletSound");
        Instantiate(bullet, gunTip.position, gunTip.rotation);
    }

}
