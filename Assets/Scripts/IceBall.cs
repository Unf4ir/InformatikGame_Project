using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField]
    private int damage = 20;

    [SerializeField]
    private float fireDistance;

    public GameObject Ice_Orb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyRedCubeTest>(out EnemyRedCubeTest enemyComponent))
        {
            enemyComponent.ApplyDamage(damage);
            Destroy(gameObject);

        }
    }
}
