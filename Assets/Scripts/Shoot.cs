using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Trail;
    public float range = 50f;
    [SerializeField]
    private float duration = 0.1f;
    public float fireRate = 1f;

    LineRenderer line;

    float fireTimer;

    private bool sprint;
    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        line.SetPosition(0, Trail.position);
        if (Input.GetMouseButton (0) && fireTimer > fireRate) 
        {
            fireTimer = 0f;
            
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin,Camera.main.transform.forward, out hit) )
            {
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(1, rayOrigin + (Camera.main.transform.forward * range));
            }
            StartCoroutine(Shoot1());
        }
        
    }

    IEnumerator Shoot1()
    {
        line.enabled = true;
        yield return new WaitForSeconds(duration);
        line.enabled = false;
    }
}
