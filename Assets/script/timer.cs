using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text time;
    public TMP_Text lost;
    public float incretime;
    public int facetime;
    public string secs;
    public GameObject endmenu;
    public GameObject player;
    void Start()
    {
        incretime = 0;
        facetime = 120;
        time.GetComponent<TMP_Text>().text = "2:00";
        lost.gameObject.SetActive(false);
        endmenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        incretime += Time.deltaTime;

        if (incretime >= 1f)
        {
            incretime = 0;
            facetime--;
            int seconds = facetime % 60;
            
            if (seconds == 1)
            {
                secs = "01";
            }
            if (seconds == 2)
            {
                secs = "02";
            }
            if (seconds == 3)
            {
                secs = "03";
            }
            if (seconds == 4)
            {
                secs = "04";
            }
            if (seconds == 5)
            {
                secs = "05";
            }
            if (seconds == 6)
            {
                secs = "06";
            }
            if (seconds == 7)
            {
                secs = "07";
            }
            if (seconds == 8)
            {
                secs = "08";
            }
            if (seconds == 9)
            {
                secs = "09";
            }
            if (seconds == 0)
            {
                secs = "00";
            }

            if (seconds > 9)
            {
                secs = seconds.ToString();
            }

            int minutes = (facetime - seconds)/60;
            time.GetComponent<TMP_Text>().text = minutes + ":" + secs;

            if (facetime <= 0)
            {
                endmenu.SetActive(true);
                Time.timeScale = 0f;
                player.GetComponent<movement>().paused = true;
            }
        }

    }

    public void red(int lose)
    {
        lost.GetComponent<TMP_Text>().text = "-" + lose;
        lost.gameObject.SetActive(true);
        Invoke("gone",0.5f);
    }

    public void gone()
    {
        lost.gameObject.SetActive(false);
    }
}
