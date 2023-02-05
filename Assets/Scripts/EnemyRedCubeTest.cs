using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedCubeTest : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField]
    public int currentHealth;
    public Healthbar healthbar;
    private bool dead = false;
    private void Start()
    {
        
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }
    public void ApplyDamage(int damage)
    {
        
        this.currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            dead = true;
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

}
