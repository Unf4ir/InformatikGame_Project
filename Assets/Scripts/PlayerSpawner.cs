using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        transform.position = spawnPoint.position;
    }
}
