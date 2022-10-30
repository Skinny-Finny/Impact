using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{           
   [SerializeField]
   GameObject target;                         

   [SerializeField]
   Text getReadyText;

   [SerializeField]
   GameObject resultsPanel;

   [SerializeField]
   GameObject LiveInfo;

   [SerializeField]
   GameObject IntroductionMenu;

   [SerializeField]
   Text scoreText, targetsHitText, shotsFiredText, accuracyText;

   [SerializeField]
   Text CountdownText, HitCounterText;

   public static int score, targetsHit;                       // public as they can be manipulated by Target

   float shotsFired;

   float accuracy;

   Vector2 targetRandomPosition;

    // Start is called before the first frame update
    void Start()                                    
    {
        getReadyText.gameObject.SetActive(false);    // stop unwanted objects from appearing initially
        LiveInfo.gameObject.SetActive(false);
        resultsPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotsFired += 1f;                // when mouse is clicked, increment shots fired by 1  
        }
    }

    IEnumerator SpawnTargets()                 // started by 'LaunchSpawnTargets',
    {
        resultsPanel.SetActive(false);               //toggle desired elements
        IntroductionMenu.SetActive(false);
        getReadyText.gameObject.SetActive(true);

        for (int i = 3; i >= 1; i--)          // how long to countdown
        {
            getReadyText.text = "Get Ready!\n" + i.ToString();   //display text and seconds remaining
            yield return new WaitForSeconds(1f);
        }
        getReadyText.text = "Go!";                 
        yield return new WaitForSeconds(1f);

        LiveInfo.gameObject.SetActive(true);
        getReadyText.gameObject.SetActive(false);       //remove get ready text
        score = 0;                                      // reset counters
        shotsFired = 0;
        targetsHit = 0;
        accuracy = 0;

        for (int i = 15; i >= 1; i--)        // dictates how long game is played, currently 15 seconds
        {
            targetRandomPosition = new Vector2(Random.Range(-6f, 7f), Random.Range(-4f, 3f));      // sets range for random target position
            Instantiate(target, targetRandomPosition, Quaternion.identity);                        // spawns a target object at given random position
            CountdownText.text = "TIME REMAINING: " + i;
            HitCounterText.text = "SUCCESFUL HITS: " + targetsHit;

            yield return new WaitForSeconds(1f);
        }

        LiveInfo.gameObject.SetActive(false);
        resultsPanel.SetActive(true);                                     // creates text to be displayed by results panel 
        scoreText.text = "Score: " + score;
        targetsHitText.text = "Targets Hit: " + targetsHit; 
        shotsFiredText.text = "Shots Fired: " + shotsFired;
        accuracy = targetsHit / shotsFired * 100f;                                  
        accuracyText.text = "Accuracy: " + accuracy.ToString("N2") + " %";
    }

    public void LaunchSpawnTargets()       // is called by the button in results panel, used to run spawntargets which is private
    {
        StartCoroutine("SpawnTargets");                 
    }

    public void ReturnToMenu()            // is called by button on results panel
    {
        resultsPanel.SetActive(false);
        IntroductionMenu.SetActive(true);
    }
}
