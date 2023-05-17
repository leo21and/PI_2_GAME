using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class FlyingEnemy : MonoBehaviour
{
    public float speed = 5.0f;
    public float attackRange = 10f;
    public float attackInterval = 2f;
    public int attackDamage = 5;
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private bool playerInRange = false;
    private float lastAttackTime = 0.0f;
    private Vector3 lastPlayerPosition;
    public float maxHealth = 30f;
    public float turnSpeed = 5.0f;
    public float currentHealth;
    public GameObject field;
    public TrailRenderer SpellTrail;
    public Transform spawnPoint;
    public Material enemySpell;
    public float stopDistance = 5f;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (playerInRange && !field.activeSelf)
        {
            // Segue o player se estiver no raio do inimigo
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 directionToPlayer = player.transform.position - transform.position;

                //Para nao ficar coladinho ao jogador quando chega à posiçao do mesmo
                directionToPlayer.x += 0f;
                directionToPlayer.y += 6f;
                directionToPlayer.z += 0f;

                if (directionToPlayer.magnitude <= attackRange && Time.time > lastAttackTime + attackInterval)
                {
                    Debug.Log("Pode Disparar");
                    lastAttackTime = Time.time;
                    ShootSpell();
                }




                // Se o player parar no raio do inimigo, o inimigo para à beira dele e continua o ataque
                if (directionToPlayer.magnitude > stopDistance)
                {

                    ////transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, directionToPlayer.z).normalized * speed * Time.deltaTime;
                    ////GetComponent<Rigidbody>().velocity = directionToPlayer.normalized * speed;



                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

                    Vector3 movementDirection = directionToPlayer.normalized;
                    float distance = Mathf.Min(directionToPlayer.magnitude - stopDistance, speed * Time.deltaTime);
                    Vector3 newPosition = transform.position + movementDirection * distance;

                    float newDistanceToPlayer = Vector3.Distance(newPosition, player.transform.position);
                    if (newDistanceToPlayer > stopDistance)
                    {
                        transform.position = newPosition;
                        GetComponent<Rigidbody>().velocity = movementDirection * speed;
                    }
                    else
                    {
                        GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }

                }

                lastPlayerPosition = player.transform.position;
            }
        }
        else
        {
            // Seguir em direçao a cada waypoint, caso o jogador nao esteja no raio
            Vector3 directionToWaypoint = waypoints[currentWaypoint].transform.position - transform.position;
            transform.position += directionToWaypoint.normalized * speed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(directionToWaypoint);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


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


    // Dispara um feitiço contra o player
    void ShootSpell()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - spawnPoint.position;
            directionToPlayer.Normalize();

            RaycastHit hit;
            Debug.DrawRay(spawnPoint.position, directionToPlayer * attackRange, Color.red, 1f);

            if (Physics.Raycast(spawnPoint.position, directionToPlayer, out hit, attackRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Dispara");
                    player.GetComponent<PlayerDamage>().TakeDamage(attackDamage);

                    GameObject spell = new GameObject("EnemySpell");
                    spell.transform.position = spawnPoint.position;

                    TrailRenderer trailRenderer = spell.AddComponent<TrailRenderer>();
                    trailRenderer.time = 1f;
                    trailRenderer.material = enemySpell;

                    Rigidbody spellRigidbody = spell.AddComponent<Rigidbody>();
                    spellRigidbody.velocity = directionToPlayer.normalized * 10;
                    Destroy(spell, 2f);
                }
            }
        }
    }






    //Dano no inimigo
    public void Damage()
    {
        currentHealth -= 10f;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
