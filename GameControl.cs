using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{           
   [SerializeField]
   GameObject target;      

   [SerializeField]
   GameObject MovingTarget;  

   [SerializeField]
   GameObject DecoyTarget;                    

   [SerializeField]
   Text getReadyText;

   [SerializeField]
   GameObject resultsPanel;

   [SerializeField]
   GameObject RulesPanel;

   [SerializeField]
   GameObject SettingsPanel;

   [SerializeField]
   GameObject LiveInfo;

   [SerializeField]
   GameObject IntroductionMenu;

    [SerializeField]
    public AudioSource AudioSourceSuccess;

   [SerializeField]
   Text scoreText, targetsHitText, shotsFiredText, accuracyText;

   [SerializeField]
   Text CountdownText, HitCounterText;

   public static int score, targetsHit, misses;                       // public as they can be manipulated by Target

   float shotsFired;

   float accuracy;

   Vector2 targetRandomPosition;

   public static int targetDecoyChance, targetDecoyChance2;

    // Start is called before the first frame update
    void Start()                                    
    {
        getReadyText.gameObject.SetActive(false);    // stop unwanted objects from appearing initially
        LiveInfo.gameObject.SetActive(false);
        resultsPanel.gameObject.SetActive(false);
        RulesPanel.gameObject.SetActive(false);
        SettingsPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotsFired += 1f;                // when mouse is clicked, increment shots fired by 1  
        }
    }

    IEnumerator SpawnTargets()                 // standard mode
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

            for (int j = 30; j >= 1; j--)                                  // j multiplied by wait for seconds below = time between target spawns
            {
                HitCounterText.text = "SUCCESFUL HITS: " + targetsHit;
                yield return new WaitForSeconds(0.033f);                 
            }

            yield return new WaitForSeconds(0.001f);
        }

        LiveInfo.gameObject.SetActive(false);
        resultsPanel.SetActive(true);                                     // creates text to be displayed by results panel 
        misses = (int) shotsFired;
        score = score - misses;
        scoreText.text = "Score: " + score;
        targetsHitText.text = "Targets Hit: " + targetsHit; 
        shotsFiredText.text = "Shots Fired: " + shotsFired;
        accuracy = targetsHit / shotsFired * 100f;                                  
        accuracyText.text = "Accuracy: " + accuracy.ToString("N2") + " %";
    }

        IEnumerator SpawnTargets2()                 // started by 'LaunchSpawnTargets',
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
            Instantiate(MovingTarget, targetRandomPosition, Quaternion.identity);                        // spawns a target object at given random position
            CountdownText.text = "TIME REMAINING: " + i;

            for (int j = 30; j >= 1; j--)                                  // j multiplied by wait for seconds below = time between target spawns
            {
                HitCounterText.text = "SUCCESFUL HITS: " + targetsHit;
                yield return new WaitForSeconds(0.033f);                 
            }

            yield return new WaitForSeconds(0.001f);
        }

        LiveInfo.gameObject.SetActive(false);
        resultsPanel.SetActive(true);                                     // creates text to be displayed by results panel 
        misses = (int) shotsFired;
        score = score - misses;
        scoreText.text = "Score: " + score;
        targetsHitText.text = "Targets Hit: " + targetsHit; 
        shotsFiredText.text = "Shots Fired: " + shotsFired;
        accuracy = targetsHit / shotsFired * 100f;                                  
        accuracyText.text = "Accuracy: " + accuracy.ToString("N2") + " %";
    }

        IEnumerator SpawnTargets3()                 // started by 'LaunchSpawnTargets',
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
            int targetDecoyChance = Random.Range(1,3);
            if (targetDecoyChance >= 2)
            {
            Instantiate(target, targetRandomPosition, Quaternion.identity);
            } 
            else 
            {                       
            Instantiate(DecoyTarget, targetRandomPosition, Quaternion.identity);
            }   
            CountdownText.text = "TIME REMAINING: " + i;

            for (int j = 15; j >= 1; j--)                                  // j multiplied by wait for seconds below = time between target spawns
            {
                HitCounterText.text = "SUCCESFUL HITS: " + targetsHit;
                yield return new WaitForSeconds(0.033f);                 
            }

            targetRandomPosition = new Vector2(Random.Range(-6f, 7f), Random.Range(-4f, 3f));      // sets range for random target position
            int targetDecoyChance2 = Random.Range(1,3);
            
            if (targetDecoyChance2 >= 2)
            {
            Instantiate(target, targetRandomPosition, Quaternion.identity);
            } 
            else 
            {                       
            Instantiate(DecoyTarget, targetRandomPosition, Quaternion.identity);
            } 

            for (int j = 15; j >= 1; j--)                                  // j multiplied by wait for seconds below = time between target spawns
            {
                HitCounterText.text = "SUCCESFUL HITS: " + targetsHit;
                yield return new WaitForSeconds(0.033f);                 
            }

            yield return new WaitForSeconds(0.001f);
        }

        LiveInfo.gameObject.SetActive(false);
        resultsPanel.SetActive(true);                                     // creates text to be displayed by results panel 
        misses = (int) shotsFired;
        score = score - misses;
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

     public void LaunchSpawnTargets2()       // is called by the button in results panel, used to run spawntargets which is private
    {
        StartCoroutine("SpawnTargets2");                 
    }

     public void LaunchSpawnTargets3()       // is called by the button in results panel, used to run spawntargets which is private
    {
        StartCoroutine("SpawnTargets3");                 
    }

    public void ReturnToMenu()            // is called by button on results panel
    {
        resultsPanel.SetActive(false);
        RulesPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        IntroductionMenu.SetActive(true);
    }

    public void GetRules()
    {
        IntroductionMenu.SetActive(false);
        RulesPanel.SetActive(true);
    }

    public void GetSettings()
    {
        IntroductionMenu.SetActive(false);
        SettingsPanel.SetActive(true);
    }

}