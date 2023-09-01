using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject PunchHand;
    public float switchCount = 0f;
    public GameObject G;
    public GameObject[] hands;
    public float Lifetime = 10f;
    public GameObject SteamShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            PunchHand.GetComponent<Animator>().Play("Punch");
            PunchHand.GetComponentInChildren<BoxCollider>().enabled = true;
            StartCoroutine(EndPunch());
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (switchCount >= 1)
            {
                switchCount = 0;
            }
            else
            {
                switchCount += 1;
            }
        }
        if (switchCount == 1)
        {
            G.SetActive(true);
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i].SetActive(false);
            }
        }
        else if (switchCount == 0)
        {
            G.SetActive(false);
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(SteamShot, transform.position, transform.rotation);
                Lifetime -= Time.deltaTime;
            }
        }

    }
    IEnumerator EndPunch()
    {
        yield return new WaitForSeconds(2f);
        PunchHand.GetComponentInChildren<BoxCollider>().enabled = false;
    }
}
