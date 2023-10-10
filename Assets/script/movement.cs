using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using TMPro;

public class movement : MonoBehaviour
{
    public float moveForce;
    public Rigidbody2D rb; 
    private Vector3 targetPosition;

    public GameObject bullet;
    public GameObject cam;
    public GameObject manager;

    public TMP_Text bulletcounter;

    public int score;
    public int bullets;


    public bool paused;


    

    // Start is called before the first frame update
    void Awake()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        paused = false;

    }

    public void Start()
    {
        transform.position = Vector3.zero;
        bullets = 50;
        bulletcounter.GetComponent<TMP_Text>().text = bullets.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
        
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position in world coordinates
        targetPosition.z = transform.position.z; // make sure z-coordinate is the same as the player's
        transform.up = (targetPosition - transform.position).normalized;


        if (!paused)
        {
            if (Input.GetMouseButtonDown(0)) // check if left mouse button is clicked
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position in world coordinates
                targetPosition.z = transform.position.z; // make sure z-coordinate is the same as the player's
                transform.up = (targetPosition - transform.position).normalized; // face towards the mouse position
                GetComponent<Rigidbody2D>().AddForce(transform.up * moveForce, ForceMode2D.Impulse); // move in the direction faced with a fixed force
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (bullets != 0)
                {
                    Instantiate(bullet,new Vector3(transform.position.x,transform.position.y,1f),Quaternion.identity);
                    bullets--;
                    bulletcounter.GetComponent<TMP_Text>().text = bullets.ToString();
                }
                
            }

            if (Input.GetMouseButtonDown(2))
            {
                cam.GetComponent<Camera>().orthographicSize = 20;
            }

            if (Input.GetMouseButtonUp(2))
            {
                cam.GetComponent<Camera>().orthographicSize = 5;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "gem")
        {
            manager.GetComponent<NormalUI>().addgem(1);
            Destroy(col.gameObject);
        }
    }

    public void addbullets(int x)
    {

        bullets += x;
        bulletcounter.GetComponent<TMP_Text>().text = bullets.ToString();


    }

}
