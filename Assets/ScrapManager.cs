using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapManager : MonoBehaviour
{
    public int scrapCount;
    public Text scrapText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrapText.text = "Scrap Amount: " + scrapCount.ToString();
    }
}
