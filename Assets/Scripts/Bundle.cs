﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bundle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }   
    }
    public void BundleDestroy()
    {
        Destroy(gameObject);
    }
}
