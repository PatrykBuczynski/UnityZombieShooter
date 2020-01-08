using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    public float health = 100f;
    public float currentHealth;
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject blood;
    GameObject player;
    GameObject score;
    Animator anim;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        score = GameObject.Find("HUDCanvas/Score/ScoreValue");
        anim = GetComponent<Animator>();
        currentHealth = health;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
    }
    void facePlayer()
    {
        Vector3 playerPosition = player.transform.position - transform.position;
        float angle = Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        playerPosition.Normalize();
        movement = playerPosition;
    }
    private void FixedUpdate()
    {
        moveZombie(movement);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameObject clone = (GameObject)Instantiate(blood, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(clone, 2f);
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }
    public void Die()
    {
        isDead = true;
        Debug.Log("Zombie is Dead!!!!!!!!!!!!!!!!!");
        Debug.Log(health);
        float currentScore = float.Parse(score.GetComponent<Text>().text);
        Debug.Log("Current score is" + currentScore);
        Debug.Log("Health + currentScore is:" + currentScore + health);
        score.GetComponent<Text>().text = (currentScore + health).ToString();
        Destroy(gameObject);
    }
    void moveZombie(Vector2 direction)
    {
        anim.SetBool("isWalking", true);
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));

    }
}
