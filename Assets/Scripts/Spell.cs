using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=wrwHAgRez3g
    [SerializeField]
    private int damage;
    
    [SerializeField]
    private float fireDistance;

    [SerializeField]
    private Transform shootingPoint;

    private bool fireCooldown;
    private RaycastHit hit;
    
    public void magic(string enemyTag)
    {
        if (fireCooldown == true)
        {
            return;
        }
        Ray ray = new Ray();
        ray.origin = shootingPoint.position;
        ray.direction = shootingPoint.TransformDirection(Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction*fireDistance, Color.red);
        if (Physics.Raycast(ray, out hit, fireDistance))
        {
            if (hit.collider.CompareTag("enemyTag"))
            {
                var spellController = hit.collider.GetComponent<EnemyRedCubeTest>();
                spellController.ApplyDamage(damage);
                fireCooldown = false;
            }
        }
        
        
    }
    
}