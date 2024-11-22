using UnityEngine;

public class Enemy : Character
{
    [SerializeField] public float distanceToStop = 2f;
    [SerializeField] private float attackCooldown = 3f;

    private float attackTimer;
    protected Player target; // Changed from private to protected

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
            target.healthValue.DecreaseHealth(1);
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
}