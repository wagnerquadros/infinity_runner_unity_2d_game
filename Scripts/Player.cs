using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;

    public float speed;
    public float junpForce;
    private bool isJumping;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate() // chamado pela fisicca da unity.
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping) 
        {
            rig.AddForce(new Vector2(0, junpForce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Detecta a colisão entre dois GameObjects
    {
        if(collision.gameObject.layer == 6)
        {
            anim.SetBool("jumping", false);
            isJumping = false;
        }
    }
}
