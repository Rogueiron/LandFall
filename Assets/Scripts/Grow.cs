using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{

    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(0,0,particleSystem.time * 17f);
        gameObject.transform.localScale = new Vector3(particleSystem.time * 0.2f, particleSystem.time * 0.2f, particleSystem.time * 0.2f) + new Vector3(0.04f, 0.04f, 0.04f);
    }
}
