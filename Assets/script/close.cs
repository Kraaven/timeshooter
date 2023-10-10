using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
   public void Start()
   {
      gameObject.SetActive(false);
   }

   public void stopbutton()
   {
      gameObject.SetActive(true);
   }
}
