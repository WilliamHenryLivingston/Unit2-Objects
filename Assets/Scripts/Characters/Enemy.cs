using UnityEngine;

public class Enemy : Character
{
    [SerializeField] public float distanceToStop = 2f;
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] protected float damage = 1f; //added so that I can change the damage that each enemy can deal

    [SerializeField] private GameObject[] powerUpPrefabs; //Need to define my two prefabs here

    private float attackTimer;
    protected Player target; // private to protected, allows me to create a new enemy

    protected override void Start()
    {
        base.Start();
        target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (!target) return;

        Vector2 destination = target.transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 direction = destination - currentPosition;

        if (Vector2.Distance(destination, currentPosition) > distanceToStop)
        {
            Move(direction.normalized);
        }
        else
        {
            Attack();
        }

        Look(direction.normalized);
    }

    public override void Attack()
    {
        base.Attack();

        if (attackTimer >= attackCooldown)
        {
            target.healthValue.DecreaseHealth(damage);
            attackTimer = 0;
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }

    public override void PlayDeadEffect()
    {
        GameManager.instance.RemoveEnemyFromList(this);
        base.PlayDeadEffect();
    }

    public void DropPowerUp()
    {
        if (powerUpPrefabs.Length == 0) return; 

        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject powerUp = powerUpPrefabs[randomIndex];

        Instantiate(powerUp, transform.position, Quaternion.identity);
    }


}