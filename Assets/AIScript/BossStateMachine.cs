using SuperPupSystems.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : SimpleStateMachine
{
    //states
    public StageOne stageOne;

    //var
    public Rigidbody2D rb;
    public Transform currentPoint;
    public int index = 0;
    public float speed;
    public List<GameObject> points;
    public int counter = 0;

    public float fireRate = 1f;
    public List<GameObject> firepoints;
    public GameObject Bullet;

    public float centerRotSpeed;

    private Vector3 m_dir;
    private float m_nextFire;
    private GameObject m_target;
    private GameObject m_center;

    private void Awake()
    {
        states.Add(stageOne);

        foreach(SimpleState state in states)
        {
            state.stateMachine = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(nameof(StageOne));

        rb = GetComponent<Rigidbody2D>();
        currentPoint = points[index].transform;
        m_target = GameObject.FindGameObjectWithTag("Player");
        m_center = GameObject.FindGameObjectWithTag("Center");

    }

    // Update is called once per frame
    void Update()
    {
        //m_dir = m_target.transform.position - transform.position;
        //float angle = (Mathf.Atan2(m_dir.y, m_dir.x) * Mathf.Rad2Deg);
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Time.time > m_nextFire)
        {
            m_nextFire = Time.time + fireRate;
            for(int i = 0; i <= firepoints.Count - 1; i++)
            {
                GameObject BulletInsMid = Instantiate(Bullet, firepoints[i].transform.position, firepoints[i].transform.rotation);

            }
        }

        Vector2 dir = currentPoint.position - transform.position;
        rb.velocity = dir * speed;
        /*if (currentPoint == points[index].transform || currentPoint == m_center)
        {
            rb.velocity = dir * speed;
        }*/
    }

    public void RepeatMov(int _num)
    {
        if(counter != _num)
        {
            
            if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == points[index].transform)
            {
                if (counter % 2 == 0)
                {
                    if (index + 1 != points.Count)
                    {
                        index = index += 1;
                    }
                    else
                    {
                        index = 0;
                    }
                
                }
                else 
                {
                    if (index != 0)
                    {
                        index = index -= 1;
                    }
                    else
                    {
                        index = points.Count-1;
                    }

                }

                currentPoint = points[index].transform;
                counter++;
            }

        }
        else
        {
            counter = 0;
            return;
        }

    }

    public void CenterAttack()
    {
        currentPoint = m_center.transform;
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == m_center.transform)
        {
            float rotAmout = centerRotSpeed * Time.deltaTime;
            float curRot = transform.localRotation.eulerAngles.z;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmout));
            Debug.Log("" + curRot);
            if (transform.localRotation.z < 0)
            {
                return;
            }
        }
    }
}