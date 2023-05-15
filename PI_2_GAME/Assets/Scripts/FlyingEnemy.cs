using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed = 5.0f;
    public float attackRange = 3.0f;
    public float attackInterval = 1.0f; 
    public int attackDamage = 10;
    public GameObject[] waypoints; 
    private int currentWaypoint = 0;
    private bool playerInRange = false; 
    private float lastAttackTime = 0.0f; 
    private Vector3 lastPlayerPosition; 
    public float maxHealth = 30f;
    public float currentHealth;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (playerInRange)
        {
            // Segue o player se estiver no raio do inimigo
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;

                //Para nao ficar coladinho ao jogador quando chega à posiçao do mesmo
                directionToPlayer.x += 0.5f;
                directionToPlayer.y += 5;
                directionToPlayer.z += 0.5f;

                // Ataca o player se estiver no raio do inimigo
                if (directionToPlayer.magnitude <= attackRange && Time.time > lastAttackTime + attackInterval)
                {
                    lastAttackTime = Time.time;
                    AttackPlayer();
                }

                // Se o player parar no raio do inimigo, o inimigo para à beira dele e continua o ataque
                if (directionToPlayer.magnitude <= attackRange && player.GetComponent<CharacterController>().velocity.magnitude == 0)
                {
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                else
                {
                    transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, directionToPlayer.z).normalized * speed * Time.deltaTime;
                    GetComponent<Rigidbody>().velocity = directionToPlayer.normalized * speed;
                }

                lastPlayerPosition = player.transform.position;
            }
        }
        else
        {
            // Seguir em direçao a cada waypoint, caso o jogador nao esteja no raio
            Vector3 directionToWaypoint = waypoints[currentWaypoint].transform.position - transform.position;
            transform.position += directionToWaypoint.normalized * speed * Time.deltaTime;

            if (directionToWaypoint.magnitude < 1.0f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
        }
    }

    // Colisao com o player e ataque
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            lastPlayerPosition = other.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    // Ataca o player
    void AttackPlayer()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<PlayerDamage>().TakeDamage(attackDamage);
        }
    }

    //Dano no inimigo
    public void Damage()
    {
        currentHealth -= 10f;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
