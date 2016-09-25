using UnityEngine;
using System.Collections;

public class EnemyProps : MonoBehaviour {

    private NavMeshAgent navComponent;

    public Enemy enemy;
    float currentHealth;

    [SerializeField]
    Transform target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null) {
            Debug.LogError("No Target found");
        }

        currentHealth = enemy.health;

        navComponent = gameObject.GetComponent<NavMeshAgent>();
        navComponent.speed = enemy.speed;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null) {
            return;
        }

        float dist = Vector3.Distance(target.position, transform.position);
        navComponent.SetDestination(target.position);

        //LookAtPlayer();

        if (currentHealth <= 0) {
            Dead();
        }
	}

    public void takeDamage(float _damageAmt)
    {
        currentHealth -= _damageAmt;
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}
