using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;

    [SerializeField] float minSpawnDelay=1f;
    [SerializeField] float maxSpawnDelay =2f;
    [SerializeField] Attacker[] attackerPrefabArray;
    // Start is called before the first frame update

    IEnumerator Start()
    {
        while(spawn )
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay ,maxSpawnDelay ));
            SpawnAttacker();
        }
    }

    public void StopSpawn()
    {
        spawn = false;
    }
    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
