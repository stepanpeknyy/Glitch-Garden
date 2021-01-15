using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject gameWorkArea;
    [SerializeField] GameObject buttons;
    int numberOfAttackers = 0;
    bool levelTimeFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        Time.timeScale = 1;
        gameWorkArea.GetComponent<BoxCollider2D>().enabled = true;
        buttons.SetActive(true);
    }


    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        buttons.SetActive(false);
        Time.timeScale = 0;
        gameWorkArea.GetComponent<BoxCollider2D>().enabled = false;
    }

    
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1f);
        winLabel.SetActive(true);
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }
    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <=0 && levelTimeFinished )
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        StartCoroutine(ExecuteAfterTime());        
        GetComponent<AudioSource>().Play();
        buttons.SetActive(false);
        gameWorkArea.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }
    public void LevelTimeFinished()
    {
        levelTimeFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray=FindObjectsOfType <AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawn();          
        }
    }

}
