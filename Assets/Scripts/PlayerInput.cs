using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Joystick joystick;
    public Vector2 InputVector { get; private set; }

    public int maxHealth = 100;
    [SerializeField]
    public int currentHealth;
    public Healthbar healthbar;

    private void Start()
    {
        healthbar.SetHealth(maxHealth);
        currentHealth = maxHealth;

    }
    private void Update()
    {
        var h = joystick.Horizontal;
        var v = joystick.Vertical;
        InputVector = new Vector2(h, v);

        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }
    public void TakeDamage(int amount)
    {
        this.currentHealth -= amount;

        healthbar.SetHealth(currentHealth);

        
    }
    public void Heal (int amount)
    {
        //check if this would be over max Health
        if(currentHealth + amount > maxHealth)
        {
            this.currentHealth = maxHealth;
        }
        else
        {
            this.currentHealth += amount;
        }
        healthbar.SetHealth(currentHealth);
    }
}
