using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraTracker : MonoBehaviour
{
    private GameObject m_target;
    private void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            transform.position = new Vector3(m_target.transform.position.x, m_target.transform.position.y, transform.position.z);
        }
    }
}
