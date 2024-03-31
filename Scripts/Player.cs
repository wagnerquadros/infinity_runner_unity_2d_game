using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;

    public float speed;
    public float junpForce;

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
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            rig.AddForce(new Vector2(0, junpForce), ForceMode2D.Impulse);
        }
    }
}
