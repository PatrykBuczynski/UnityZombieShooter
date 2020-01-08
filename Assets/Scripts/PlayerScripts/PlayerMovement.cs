using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;
    private Rigidbody2D rigidBody;
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        rigidBody.MovePosition((Vector2)transform.position + (new Vector2(horizontalMovement, verticalMovement) * speed * Time.deltaTime));
        //rigidBody.velocity = new Vector2(horizontalMovement * speed, verticalMovement * speed);
        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
    public void DisableMovement()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
