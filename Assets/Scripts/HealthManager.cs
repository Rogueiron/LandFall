using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float Maxhealth = 10;
    private float knockback = -100f;

    private float health;

    private Follow follow;
    
    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<Follow>();
        health = Maxhealth;
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
        if (other.gameObject.CompareTag("AirBurst"))
        {
            health -= 0.5f;
            follow.agent.Move(transform.position + transform.forward * Time.deltaTime * knockback);
        }
        if(other.gameObject.CompareTag("Punch"))
        {
            health -= Maxhealth/3f;
        }
        
    }
}
