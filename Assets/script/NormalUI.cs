using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NormalUI : MonoBehaviour
{


    public TMP_Text emerald;

    
    public int gems;

    public int force;



    // Start is called before the first frame update
    void Start()
    {
        




        gems = 0;
        force = 1;


        emerald.GetComponent<TMP_Text>().text = gems.ToString();


    }

    public void addgem(int a)
    {
        gems+= a;
        emerald.GetComponent<TMP_Text>().text = gems.ToString();
    }

    public void endgame()
    {
        SceneManager.LoadScene("start");
    }




}
