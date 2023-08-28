using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimedDestory : MonoBehaviour
{
    private float timer = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0) 
        {
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
