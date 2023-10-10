using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class follow : MonoBehaviour
{

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        bool move = true;
        // transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10f);
        float distance = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, -10f), new Vector3(player.transform.position.x, player.transform.position.y, -10f));
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f,transform.position.y,transform.position.z);
            move = false;
        }

        if (transform.position.x > 11f)
        {
            transform.position = new Vector3(11f, transform.position.y, transform.position.z);
            move = false;
        }

        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
            move = false;
        }
        if (transform.position.y > 6.5f)
        {
            transform.position = new Vector3(transform.position.x, 6.5f, transform.position.z);
            move = false;
        }

        if (move)
        {
            if (distance <= 0.1f)
            {
                transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
            }
            else
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,transform.position.y,-10f), new Vector3(player.transform.position.x,player.transform.position.y,-10f), distance * Time.deltaTime);
            }
        }


    }
}
