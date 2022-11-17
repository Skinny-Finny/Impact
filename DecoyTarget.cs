using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyTarget : MonoBehaviour
{   
    void Start()           //When target is created
    {
      Destroy(gameObject, 1f);  //remove target after some time
    }

    private void OnMouseDown()    //when target is clicked
    {
        GameControl.score -= 9;     // increment values by desired amount
        Destroy(gameObject);         //then delete object
    }
}
