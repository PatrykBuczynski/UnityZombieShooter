using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float health = 100f;
    public float currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
   
    //Death Audio Clip - public Audio deathClip;

    bool isDamaged;
    bool isDead;

    Animator anim;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    FaceMouse faceMouse;





    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
        faceMouse = GetComponent<FaceMouse>();
        anim = GetComponent<Animator>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        isDamaged = false;
    }

    public void TakeDamage(int amount)
    {
        isDamaged = true;
        currentHealth -= amount;

        healthSlider.value = currentHealth;
        FindObjectOfType<AudioManager>().Play("HurtSound");
        //Play hurt sound;
        if (currentHealth <= 0 && !isDead)
        {
            FindObjectOfType<AudioManager>().Play("DeathSound");
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.DisableMovement();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
        faceMouse.enabled = false;
        StartCoroutine(LoadMainMenu()); //Loads main menu after 10s
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }

}
