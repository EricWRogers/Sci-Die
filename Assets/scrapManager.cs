using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrapManager : MonoBehaviour
{
    public int scrap;
    public TMP_Text scrapText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrapText.text = scrap.ToString();
    }
}
