using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownEffect : MonoBehaviour
{
    public GameObject player;
    PlayerMovement playerMovement;
    Image img;

    float cooldown;
    float timer = 0;
    bool inProgress;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        img = GetComponent<Image>();
        cooldown = playerMovement.boostCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartEffect()
    {
        if (!inProgress)
        {
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        inProgress = true;
        img.fillAmount = 1f;
        while (timer < cooldown)
        {
            img.fillAmount -= 1f / cooldown * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        inProgress = false;
    }
}
