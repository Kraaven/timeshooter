using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class shop : MonoBehaviour
{
    public bool pause;
    public GameObject player;

    public GameObject gameshop;
    public GameObject normalUI;

    public TMP_Text bulletcounter;
    public GameObject manager;

    public GameObject physshop;

    void Start()
    {
        pause = false;
        gameshop.SetActive(false);
        normalUI.SetActive(true);
    }
    

    public void resumegame()
    {
        Time.timeScale = 1f;
        pause = false;
        player.GetComponent<movement>().paused = false;
        GameObject[] hexagons = GameObject.FindGameObjectsWithTag("hexa");
        foreach (GameObject block in hexagons)
        {
            Destroy(block);
        }
        
        GameObject[] killer = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in killer)
        {
            // Destroy(enemy);
            enemy.GetComponent<enemy_movement>().outshop();

        }

        manager.GetComponent<structurespawn>().spawn();

        player.transform.position = new Vector3(0, 0, 0);
        physshop.SetActive(false);
        gameshop.SetActive(false);

        bulletcounter.GetComponent<TMP_Text>().text = player.GetComponent<movement>().bullets.ToString();
        normalUI.SetActive(true);

        physshop.GetComponent<entershop>().spawn(2, 22);
    }

    public void pausegame()
    {
        Time.timeScale = 0f;
        pause = true;
        player.GetComponent<movement>().paused = true;
        
        gameshop.SetActive(true);
        normalUI.SetActive(false);
    }

}
