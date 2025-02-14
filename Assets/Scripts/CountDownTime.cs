using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTime : MonoBehaviour
{
    [SerializeField] float maxTime = 100f;
    public float timeLeft;
    public TMP_Text time;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = maxTime-Time.time;
        time.text="Time: " + timeLeft;
    }
}
