using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] float RandomObjectSpawnX_Range;
    [SerializeField] GameObject CoinPrefab, Meteorprefab, shieldprefab;
    [SerializeField] float TimeToSpawnNextCoin;
    [SerializeField] float TimeToSpawnNextShield;
    [SerializeField] float TimeToSpawnNextmeteor;

    private void OnEnable()
    { 

        StartCoroutine(SpawnCoinCoroutine());
        StartCoroutine(SpawnMeteorCoroutine());
        StartCoroutine(SpawnShieldCoroutine());
    }


    // spawn object such as coin, meteor using coroutine
    IEnumerator SpawnCoinCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(TimeToSpawnNextCoin);

        while(true)
        {
            SpawnObject(CoinPrefab);
            yield return wait;
        }
    }
    IEnumerator SpawnMeteorCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(TimeToSpawnNextmeteor);

        while (true)
        {
            SpawnObject(Meteorprefab);
            yield return wait;
        }
    }
    IEnumerator SpawnShieldCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(TimeToSpawnNextShield);

        while (true)
        {
            SpawnObject(shieldprefab);
            yield return wait;
        }
    }
    void SpawnObject(GameObject objecttospawn)
    {
        if( objecttospawn != null )
        {
            Vector2 SpawnPosition = transform.position;
            SpawnPosition.x = Random.Range(-RandomObjectSpawnX_Range, RandomObjectSpawnX_Range);

            Instantiate(objecttospawn, SpawnPosition, Quaternion.identity);
        }
    }


}
