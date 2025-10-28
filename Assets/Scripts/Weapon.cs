using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int Damage;
    public Ishootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Character character);

    public void InitWeapon(int newDamage, Ishootable newShooter)
    {
        Damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;

        if (value > 0) return 1;
        else return -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            OnHitWith(character);
            Destroy(this.gameObject, 5f);
        }
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
