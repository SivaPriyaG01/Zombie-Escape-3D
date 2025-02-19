using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    PlayerCtr playerCtr;
    void Start()
    {
        playerCtr=GameObject.Find("Player").GetComponent<PlayerCtr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(playerCtr.keyCount==playerCtr.maxKeyCount)
            {
                playerCtr.messages.text="You Won";
            }
            else
            {
                playerCtr.messages.text="Collect all keys";
            }
        }
    }
}
