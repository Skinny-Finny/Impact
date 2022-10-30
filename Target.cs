using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{   
    void Start()           //When target is created
    {
      Destroy(gameObject, 1f);  //remove target after some time
    }

    private void OnMouseDown()    //when target is clicked
    {
        GameControl.score += 10;     // increment values by desired amount
        GameControl.targetsHit += 1;
        Destroy(gameObject);         //then delete object
    }
}
