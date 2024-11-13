using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrapManager : MonoBehaviour
{
    public int scrapCount;
    public TMP_Text ScrapTXT;
    public ScrapManager sm;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ScrapCountTXT.text = "Scrap Count: " + scrapCount.ToString();
    }
}
