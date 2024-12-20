using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private GameObject m_target;


    public float maxSpeed;
    public float speed;
    public float nextWaypointDistance;

    Path path;
    int currentWaypoint;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public float flashTime;
    //Color origionalColor;
    public SpriteRenderer image;

    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = speed;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        m_target = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("UpdatePath", 0f, .5f);
        //origionalColor = image.color;
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, m_target.transform.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
    public void FlashRed()
    {
        image.color = Color.red;
        Invoke("ResetColor", flashTime);
    }
    public void ResetColor()
    {
        //image.color = origionalColor;
    }
}
