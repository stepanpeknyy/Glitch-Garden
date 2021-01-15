using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDisplay : MonoBehaviour
{
    Text levelText;
    float level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex -1;
        levelText = GetComponent<Text>();
        UptadeLevelDisplay();        
    }

    private void UptadeLevelDisplay()
    {
        levelText.text ="Level " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
