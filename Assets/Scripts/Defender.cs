using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
[SerializeField] int  costStar=100;

    public int GetStarCost ()
    {
        return costStar;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }
}
