using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public int bulletDamage = 10;
    public Rigidbody2D rb;

    private Transform gunTip;

    // Start is called before the first frame update
    void Start()
    {
        gunTip = GameObject.Find("/Player/gunTip").transform;
        rb.velocity = gunTip.up * bulletSpeed;
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            ZombieScript zombie = collision.gameObject.GetComponent<ZombieScript>();
            if (zombie != null)
            {
                zombie.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
        
    }
}
