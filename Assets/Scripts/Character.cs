using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //abtrribute
    private int health;
    public int Health 
    { get => health; 
        set => health = (value <= 0) ? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;

    public HealthBar HealthBar;

    //method
    public void Intialize(int startHealth)
    {
        HealthBar.SetMaxHealth(startHealth);
        Health = startHealth;
        Debug.Log($"Name: {this.name}, Health: {this.Health}.");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //method
    public void TakeDamage(int damage)
    {
        Health-= damage;
        Debug.Log($"{this.name} took damage: {damage}. Current Health: {Health}.");
        HealthBar.SetHealth(Health);
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead! and destroy.");
            return true;
        }
        return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
