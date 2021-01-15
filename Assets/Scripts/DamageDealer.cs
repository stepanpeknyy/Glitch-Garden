using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField ] public int damage = 100;
    [SerializeField] GameObject hitVFX;

    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        
        Destroy(gameObject);
        GameObject explosion = Instantiate(hitVFX, transform.position , transform.rotation);
        
    }
}
