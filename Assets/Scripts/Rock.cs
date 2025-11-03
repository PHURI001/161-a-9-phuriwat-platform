using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rd;
    public Vector2 force;

    public override void Move()
    {
        rd.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        if (obj is Player)
            obj.TakeDamage(this.Damage);
    }

    private void Start()
    {
        Damage = 20;
        force = new Vector2(GetShootDirection() * 90, 400);
        Move();
    }
}
