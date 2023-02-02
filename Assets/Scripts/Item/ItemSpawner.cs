using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject bluePotionPrefab;
    public GameObject RedPotionPrefab;
    public GameObject orangePotionPrefab;

    private void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 11));
        Instantiate(bluePotionPrefab, randomSpawnPosition, Quaternion.identity);
        Instantiate(RedPotionPrefab, randomSpawnPosition, Quaternion.identity);
        Instantiate(orangePotionPrefab, randomSpawnPosition, Quaternion.identity);
    }
}
