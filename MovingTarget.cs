using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{  

      private float speed = 10.0f;
      private Vector2 targetRandomDestination;
      private Vector2 position;

      void Start()           //When target is created
    {
      Destroy(gameObject, 1f);  //remove target after some time
      targetRandomDestination = new Vector2(Random.Range(-6f, 7f), Random.Range(-4f, 3f));
      
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetRandomDestination, step);
    }

    private void OnMouseDown()    //when target is clicked
    {
        GameControl.score += 6;     // increment values by desired amount
        GameControl.targetsHit += 1;
        Destroy(gameObject);         //then delete object
    }
}
