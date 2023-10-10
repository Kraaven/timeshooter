using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyspawn : MonoBehaviour
{
    public float spawntime;
    public GameObject enemy;

    public float spawn;
    public float spawnstart;
    public float spawnend;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        spawntime = Random.Range(0.5f, 1.5f);
        spawnstart = 2f;
        spawnend = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        spawn += Time.deltaTime;
        
        if (spawn >= spawntime)
        {
            int enex = Random.Range(-16,19);
            int eney = Random.Range(-12, 8);

            if (Mathf.Abs(player.transform.position.x - enex) < 6 || Mathf.Abs(player.transform.position.y - eney) < 6)
            {
                enex = Random.Range(-16,19);
                eney = Random.Range(-12, 8);
            }


            Instantiate(enemy, new Vector3(enex, eney, 0),quaternion.identity);
            spawntime = Random.Range(spawnstart, spawnend);
            spawn = 0;
        }
    }
}
