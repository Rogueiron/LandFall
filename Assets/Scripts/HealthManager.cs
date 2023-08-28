using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float health = 10;
    private float knockback = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    public void TakeDamage()
    {
        health -= 1;
    }
    private void OnParticleTrigger()
    {
        health -= 0.1f;
        gameObject.transform.position += transform.forward * Time.deltaTime * knockback;
    }
}
