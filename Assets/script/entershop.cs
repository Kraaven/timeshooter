using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class entershop : MonoBehaviour
{
    
    public GameObject market;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            market.GetComponent<shop>().pausegame();
        }
    }

    public void Start()
    {

        gameObject.SetActive(false);
        spawn(0,5);
    }
    
    public void spawn(int a, int b)
    {
        int now = UnityEngine.Random.Range(a, b);
        Invoke("come",now);

    }

    public void come()
    {
        gameObject.SetActive(true);
    }

}
