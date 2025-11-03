using System.Threading.Tasks;
using UnityEngine;

public class Crocodile : Enemy, Ishootable
{
    [SerializeField] private float atkRange;
    public Player Player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(35);
        DamageHit = 15;
        atkRange = 6.0f;
        Player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0.0f;
        ReloadTime = 1.5f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        //Vector2 distance = transform.position - Player.transform.position;

        //find distance between Croccodile and Player
        if (Player != null)
        {
            Vector2 distance = transform.position - Player.transform.position;
            if (distance.magnitude <= atkRange)
            {
                //Debug.Log($"{Player.name} is in the {this.name}'s atk range!");
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.InitWeapon(30, this);
            WaitTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
