using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimedDestory : MonoBehaviour
{
    private float timer = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Delete), timer);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void Delete()
    {
        Destroy(gameObject);
    }
}
