using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float health = 10;
    private float knockback = -100f;

    private Follow follow;
    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<Follow>();
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
    private void OnTriggerEnter(Collider other)
    {
        health -= 0.5f;
        follow.agent.Move(transform.position + transform.forward * Time.deltaTime * knockback);
        
    }
}
