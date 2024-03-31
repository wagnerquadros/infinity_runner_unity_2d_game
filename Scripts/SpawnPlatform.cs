using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();          // lista dos prefabs das plataformas
    private List<Transform> currentPlatforms = new List<Transform>();   // listas de plataformas geradas na cena
    public float offset;                                               // variavel para armazenar a posição de criação e reciclagem das plataformas

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < platforms.Count; i++)
        {
            // Para instanciar um objeto temos que passar uma posição e uma rotação
            Transform clonePlatform = Instantiate(platforms[i], new Vector2(i * 30,0), transform.rotation).transform;
            currentPlatforms.Add(clonePlatform);
            offset += 30;
        }
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, 0f);
        offset += 30;
    }
}
