using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class SlimeScript : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent; // its navigation
    [SerializeField] public Transform player; // so it knows where player is
    [SerializeField] public float distance; // to know how far player is
    [SerializeField] public Animator anim; // to control animations
    [SerializeField] public bool moving; // to know if the slime is moving
    public bool dying; // to know and control movement when dying
    public bool chasing; // to know when chasing the player
    public float timer; // for wandering
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position); // find distance to player
        if(distance <= 20 && dying == false) // within 20 units of player start chasing and its alive
        {
            agent.SetDestination(player.position); // make enemy go to player position
        }
        if(distance > 20 && dying == false)
        {
            // slime will wander around
            if(timer > 2)
            {
                float x = Random.Range(transform.position.x - 5, transform.position.x + 5);
                float z = Random.Range(transform.position.z - 5, transform.position.z + 5);
                Vector3 wanderPosition = new Vector3(x, transform.position.y, z); // find a new wander position
                agent.SetDestination(wanderPosition); // set new destination
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        if(agent.destination != null) // if slime has a desitnation
        {
            moving = true;
        }
        else // it doesnt
        {
            moving = false;
        }

        // Animations
        anim.SetBool("moving", moving); // handle moving animations
    }

    public void StartDying()
    {
        StartCoroutine(Dying());
        dying = true;
    }

    IEnumerator Dying()
    {
        SoundEffectManager.instance.enemyHurt.Play(); // play the enemy hurt sound
        GetComponent<SphereCollider>().enabled = false; // disable colliders that hurt the player
        anim.SetBool("dying", true); // set the animation to dying
        moving = false;
        agent.ResetPath(); // reset its path so it stops chaing player
        yield return new WaitForSeconds(1); // wait for the animation to finish
        Destroy(gameObject); // slime is no more
    }
}
