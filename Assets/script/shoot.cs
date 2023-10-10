using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private Vector3 targetPosition;
    public float moveForce;

    private float time;

    public GameObject manager;



    void Start()
    {
        manager = GameObject.Find("Gamemanager");
        moveForce = manager.GetComponent<NormalUI>().force;
        rb = gameObject.GetComponent<Rigidbody2D>();
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position in world coordinates
        targetPosition.z = transform.position.z; // make sure z-coordinate is the same as the player's
        transform.up = (targetPosition - transform.position).normalized; // face towards the mouse position
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveForce,ForceMode2D.Impulse);
        Debug.Log("Shot");
        time = 0;
        
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Edge")
        {
            Destroy(gameObject);
            
        }

        if (col.gameObject.tag == "Player")
        {
            if (time > 0.7)
            {
                manager.GetComponent<timer>().facetime -= 7;
                manager.GetComponent<timer>().red(7);

            }
        }


    }

    private void Update()
    {
        time += Time.deltaTime;

        

        if (time >= 12)
        {
            Destroy(gameObject);
        }
    }
}

