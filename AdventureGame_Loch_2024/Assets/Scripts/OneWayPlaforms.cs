using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlaforms : MonoBehaviour
{

    public bool isUp;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<TarodevController.PlayerController>()._interact && player.GetComponent<TarodevController.PlayerController>()._grounded) 
        {
            transform.parent.GetComponent<Collider2D>().enabled = false;
                Debug.Log("I am falling");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            transform.parent.GetComponent<Collider2D>().enabled = isUp;

    }
    
}
