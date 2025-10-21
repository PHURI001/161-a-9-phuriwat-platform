using System.Threading.Tasks;
using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] private float atkRange;
    public Player Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(30);
        DamageHit = 15;
        atkRange = 6.0f;
        Player = GameObject.FindFirstObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    public override void Behavior()
    {
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
        Debug.Log($"{this.name} is throwing rock to {Player.name}.");
        new WaitForSeconds(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
