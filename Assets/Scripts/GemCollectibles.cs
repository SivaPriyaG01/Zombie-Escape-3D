using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemCollectibles : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerCtr playerCtr;
    
    void Start()
    {
        playerCtr=GameObject.Find("Player").GetComponent<PlayerCtr>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerCtr.KeyCountUpdate();
            Destroy(gameObject);
        }
        
    }
}
