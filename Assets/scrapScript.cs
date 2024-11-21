using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrapScript : MonoBehaviour
{
    private scrapManager m_scrapManager;
    // Start is called before the first frame update
    void Start()
    {
        m_scrapManager = GameObject.FindWithTag("Player").GetComponent<scrapManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("Pick up Scrap");
            m_scrapManager.scrap += 1;
            Destroy(gameObject);

        }
    }
}
