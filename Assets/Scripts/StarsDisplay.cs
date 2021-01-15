using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text textStars;
    void Start()
    {
        textStars = GetComponent<Text>();
        UptadeStarsDisplay();
    }

    private void UptadeStarsDisplay()
    {
        textStars.text = stars.ToString();
    }
    public void AddStars(int amout)
    {
        stars += amout;
        UptadeStarsDisplay();
    }
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
    public void SpendStars(int amout)
    {
        if (stars >= amout )
        {
            stars -= amout;
            UptadeStarsDisplay();
        }

    }
}
