using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerControler playerHealth;
    ZombieScript zombieHealth;
    Rigidbody2D rb;
    bool playerInRange;
    float timer;
    



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerControler>();
        zombieHealth = GetComponent<ZombieScript>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {

            playerInRange = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && playerHealth.currentHealth > 0)
        {
            Attack();
            anim.SetTrigger("Attack");
        }
        if (playerHealth.currentHealth <= 0)
        {
            zombieHealth.enabled = false;
            anim.SetTrigger("PlayerDeath");
        }
    }
    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
