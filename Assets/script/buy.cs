using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class buy : MonoBehaviour
{
    public GameObject player;
    public GameObject manager;
    public GameObject enemyspawner;
    public int enemlvl = 1;

    public GameObject closeeenemybuff;
    public GameObject closeinsanity;

    public Button enemy;
    public Button insane;

    public void buyammo()
    {
        if (manager.GetComponent<NormalUI>().gems > 0)
        {
            player.GetComponent<movement>().addbullets(50);
            manager.GetComponent<NormalUI>().addgem(-1);
        }
    }

    public void buytime()
    {
        if (manager.GetComponent<NormalUI>().gems > 6)
        {
            manager.GetComponent<timer>().facetime += 45;
            manager.GetComponent<NormalUI>().addgem(-7);
        }

    }

    public void buyenemboost()
    {
        if (manager.GetComponent<NormalUI>().gems > 3)
        {
            if (enemlvl == 1)
            {
                enemyspawner.GetComponent<enemyspawn>().spawnstart = 1.8f;
                enemyspawner.GetComponent<enemyspawn>().spawnend = 4.4f;

            }
            if (enemlvl == 2)
            {
                enemyspawner.GetComponent<enemyspawn>().spawnstart = 1.5f;
                enemyspawner.GetComponent<enemyspawn>().spawnend = 3.5f;
 
            }
            if (enemlvl == 3)
            {
                enemyspawner.GetComponent<enemyspawn>().spawnstart = 1.2f;
                enemyspawner.GetComponent<enemyspawn>().spawnend = 2.6f;

            }
            if (enemlvl == 4)
            {
                enemyspawner.GetComponent<enemyspawn>().spawnstart = 0.8f;
                enemyspawner.GetComponent<enemyspawn>().spawnend = 1.4f;


            }
            if (enemlvl == 5)
            {
                enemyspawner.GetComponent<enemyspawn>().spawnstart = 0.8f;
                enemyspawner.GetComponent<enemyspawn>().spawnend = 0.9f;
                closeeenemybuff.GetComponent<close>().stopbutton();
                enemy.interactable = false;

            }

            manager.GetComponent<NormalUI>().addgem(-4);
            enemlvl++;
        }
    }

    public void insanity()
    {
        {
            if (manager.GetComponent<NormalUI>().gems > 26)
            {
                player.GetComponent<movement>().moveForce = 0.09f;
                manager.GetComponent<NormalUI>().addgem(-27);
                closeinsanity.GetComponent<close>().stopbutton();
                manager.GetComponent<NormalUI>().force = 3;
                insane.interactable = false;

            }
        }

    }
}
