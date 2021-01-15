using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj : MonoBehaviour
{
    [SerializeField] GameObject projPrefab;
    [SerializeField] float projMovementSpeed;
    [SerializeField] float damage = 50;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * projMovementSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        health.DealDamage(damage);
    }
}




