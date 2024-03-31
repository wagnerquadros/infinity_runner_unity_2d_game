using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    
    public float speed;
    public float offset;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() //Chamdo de forma mais "suave" em comparação ao update
    {
        Vector3 newCameraPosition = new Vector3(player.position.x + offset, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCameraPosition, speed * Time.deltaTime);
    }
}
