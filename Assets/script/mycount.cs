using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class mycount : MonoBehaviour
{

    public TMP_Text gemcounter;
    public GameObject gemcaller;
    void Update()
    {
        int emeralds = gemcaller.GetComponent<NormalUI>().gems;

        gemcounter.GetComponent<TMP_Text>().text = emeralds.ToString();
    }
}
