using UnityEngine;

public interface Ishootable
{
    public GameObject Bullet { get; set; }
    public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot();
}
