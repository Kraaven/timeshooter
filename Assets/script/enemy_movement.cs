using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class enemy_movement : MonoBehaviour
{
    private NavMeshAgent agent;

    public ParticleSystem burst = default; 

    public GameObject player;
    public GameObject bullet;
    public GameObject gem;

    public float life;

    public Texture2D red;
    public Texture2D yellow;
    public Texture2D green;

    private Sprite redskin;
    private Sprite yellowskin;
    private Sprite greenskin;

    public int gemchance;

    public bool touch;
    public GameObject manager;


    public GameObject redflash;
    float touchtime = 0;





    // Start is called before the first frame update
    void Start()
    {



        gemchance = 3;
        redflash = GameObject.Find("red");
        player = GameObject.Find("player");
        manager = GameObject.Find("Gamemanager");


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        life = 3;
        


        greenskin = Sprite.Create(green, new Rect(0.0f, 0.0f, green.width, green.height), new Vector2(0.5f, 0.5f), 35.5f);
        yellowskin = Sprite.Create(yellow, new Rect(0.0f, 0.0f, yellow.width, yellow.height), new Vector2(0.5f, 0.5f), 35.5f);
        redskin = Sprite.Create(red, new Rect(0.0f, 0.0f, red.width, red.height), new Vector2(0.5f, 0.5f), 35.5f);
        
        GetComponent<SpriteRenderer>().sprite = greenskin;
        touch = true;


    }

    // Update is called once per frame
    void Update()
    {
        float playerx = player.transform.position.x;
        float playery = player.transform.position.y;
        
        agent.SetDestination(new Vector3(playerx,playery, 0f));
        
        Vector3 direction = (agent.destination - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            burst.Play();
        }

    }

    


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            life--;

            if (life == 2)
            {
                GetComponent<SpriteRenderer>().sprite = yellowskin;
            }

            if (life == 1)
            {
                GetComponent<SpriteRenderer>().sprite = redskin;
            }

            if (life == 0)
            {
                int chance = Random.Range(0, 10);
                if (chance > gemchance)
                {
                    Instantiate(gem, new Vector3(transform.position.x,transform.position.y,0f),quaternion.identity);
                    
                }

                burst.Play();
                Destroy(gameObject);
            }
        }

        if (col.tag == "bullet")
        {
            
            Destroy(col.gameObject);
        }

        if (col.tag == "Player")
        {

            if (touch)
            {
                manager.GetComponent<timer>().facetime -= 25;
                manager.GetComponent<timer>().red(-25);
                touch = false;
                Destroy(gameObject);
            }
        }
    }

    public void outshop()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        Invoke("go",0.05f);
        Debug.Log("repositioned");
    }

    public void go()
    {
        int position = Random.Range(-16, 19);
        gameObject.transform.position = new Vector3(position, -11, 0);
        gameObject.GetComponent<Renderer>().enabled = true;
        Debug.Log("repositioned successful");
    }


}
