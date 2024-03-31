using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>();          // lista dos prefabs das plataformas
    private List<Transform> currentPlatforms = new List<Transform>();   // listas de plataformas geradas na cena
    public float offset;                                               // variavel para armazenar a posição de criação e reciclagem das plataformas

    private Transform player;

    private Transform currentPlatformPoint;
    private int platformIndex;

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

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint; //Pega o ponto final da plataforma atual
    }

    private void Update()
    {
        Move();
    }

    public void Recycle(GameObject platform)
    {
        platform.transform.position = new Vector2(offset, 0f);
        offset += 30;
    }

    void Move()
    {
        float distance = player.position.x - currentPlatformPoint.position.x;  // mede a distancia entre o player e o final da plataforma

        if (distance >= 1)
        {
            Recycle(currentPlatforms[platformIndex].gameObject);               // Passando da plataforma ela é reciclada
            platformIndex++;                                                  // Incrementamos o index da plataforma atual
            
            if (platformIndex > currentPlatforms.Count - 1)                 // 
            {
                platformIndex = 0;
            }

            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint; //Pega o ponto final da plataforma atual
        }
    }
}
