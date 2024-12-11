using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrapManager : MonoBehaviour
{
    public int scrapCount = 0;
    public TMP_Text ScrapTXT;
    public GameManger gameManger;

    void Awake()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManger>();
        scrapCount = gameManger.scrap;
    }

    
    void Update()
    {
        ScrapTXT.text = "Scrap Count: " + scrapCount.ToString();
    }
}
