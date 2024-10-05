using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class ColorForTrap : Indicators, ISounds
{
    private Renderer renderTrap;
    private Color startColor;
    private Coroutine coroutine;
    [SerializeField] private AudioClip[] soundsCollections;
    private new AudioSource audioSrc;
    private bool triggerTrap = true;
    private float damage = 0.20f;
    private bool FindPlayer = true;
    private bool ActiveForStay = false;
   
    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        renderTrap = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;
        Sounds();
    }
    private void OnTriggerEnter(Collider trap)
    {
        if (trap.gameObject.CompareTag("ForTriiger") && triggerTrap && !ActiveForStay)
        {
            EnterTrap();
        }
    }
    private void OnTriggerStay(Collider trap)
    {
        if ((trap.gameObject.CompareTag("ForTriiger") && ActiveForStay && triggerTrap))
        {
            triggerTrap = false;
            ActiveForStay = false;
            EnterTrap();
        } 
        else if (trap.gameObject.CompareTag("ForTriiger"))
        {
            FindPlayer = true;
        }
    }
    private void OnTriggerExit(Collider trap)
    {
        if (trap.gameObject.CompareTag("ForTriiger"))
        {
            FindPlayer = false;
            StopCoroutine(TrapCoroutine());
        }
    }

    private void Sounds()
    {
       audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySounds()
    {
       audioSrc.PlayOneShot(soundsCollections[0],1f);
    }

    private void PlaySoundsBoomTrap()
    {
        audioSrc.PlayOneShot(soundsCollections[1],0.3f);
    }
    private void EnterTrap()
    {
        ActiveForStay = true;
        triggerTrap = false;
        coroutine = StartCoroutine(TrapCoroutine());
        StartCoroutine(TrapCoroutine());
    }
    
    private IEnumerator TrapCoroutine()
    {

        PlaySounds();
        renderTrap.material.color = new Color(1, 0.6588f, 0);
        Debug.Log(FindPlayer);
        yield return new WaitForSeconds(1);
        if (healthBar != null)
        {
            if (FindPlayer)
            {
                healthBar.fillAmount -= damage ;
            }
            else
            {
                healthBar.fillAmount -= 0;
            }
        }
        PlaySoundsBoomTrap();
        renderTrap.material.color = Color.red;
        yield return new WaitForSeconds(5);
        renderTrap.material.color = startColor;
        triggerTrap = true;
    }
}
