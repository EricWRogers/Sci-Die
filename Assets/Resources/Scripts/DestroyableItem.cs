using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableItem : MonoBehaviour
{
    public int MaxHealth;
    public Sprite[] Sprites;

    private int Health; 
    
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int dmg) // item get damage
    {
        Health -= dmg;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
        else  // item is still alive, change sprite
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[Health - 1];
        }
    }
}