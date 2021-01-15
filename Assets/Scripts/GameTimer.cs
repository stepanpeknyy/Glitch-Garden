using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level time in SECONDS")]
    [SerializeField] float levelTime = 10;
    [SerializeField] GameObject handle; 
    bool triggerLevelFinished = false;
    

    // Update is called once per frame
    void Update()
    {
        if (triggerLevelFinished ) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timeFinished = (Time.timeSinceLevelLoad >=levelTime );
        if(timeFinished )
        {
            FindObjectOfType<LevelController>().LevelTimeFinished();
            triggerLevelFinished = true;
            handle.GetComponent<Animator>().enabled = false;           
        }
    }
}
