using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class structurespawn : MonoBehaviour
{
    public GameObject blocks;
    public NavMeshSurface Surface2D;

    public int total;
    // Start is called before the first frame update
    void Start()
    {
        
        spawn();
        
        
        
    }

    public void spawn()
    {
        total = UnityEngine.Random.Range(10, 25);
        for (int i = 0; i < total; i++)
        {
            int rx = UnityEngine.Random.Range(-16, 19);
            int ry = UnityEngine.Random.Range(-12, 8);

            if (rx == 0 && ry == 0)
            {
                rx = UnityEngine.Random.Range(-16, 19);
                ry = UnityEngine.Random.Range(-12, 8);
            }

            Instantiate(blocks, new Vector3(rx, ry, 0),quaternion.identity);
        }
        
        Surface2D.BuildNavMeshAsync();
    }
    
}
