using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    public GameObject player;
    
    private int cd = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cd > 0)
        {
            cd -= 1;
        }
    }



    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "spike" && cd <= 0){
            cd = 60;
            transform.position = new Vector3(-24, 16, 0);
            PlayerStats.Instance.TakeDamage(1f);
        }

    }
}
