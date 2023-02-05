using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Ttorial: https://www.youtube.com/watch?v=anHxFtiVuiE
    [SerializeField]
    private int damage = 10;

    [SerializeField]
    private float fireDistance;

    public GameObject fire_Orb;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyRedCubeTest>(out EnemyRedCubeTest enemyComponent))
        {
            enemyComponent.ApplyDamage(damage);
            Destroy(gameObject);
            
        }
    }
    
}
