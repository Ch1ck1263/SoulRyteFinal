using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int soulCount;
    public Sprite newSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soulCount = GameObject.FindGameObjectsWithTag("Collectable").Length;

        if(soulCount == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && soulCount == 0)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
