using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float  baseLives = 3;
    [SerializeField] int damage = 1;
    float lives;
    Text liveText;

    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        liveText = GetComponent<Text>();
        UptadeLivesDisplay();
    }

    private void UptadeLivesDisplay()
    {
        liveText .text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeLives()
    {
        lives -= damage;
        GetComponent<AudioSource>().Play();
        UptadeLivesDisplay();
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }

    }
}
