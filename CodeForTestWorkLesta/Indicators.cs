using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
internal class Indicators : MonoBehaviour
{
    private protected Image healthBar;
    private protected AudioSource audioSrc;
    private GameObject playerPositionY;
    [SerializeField] private AudioClip[] audioClips;
    private float lastHPPlayer;
    [SerializeField] private GameObject gameOver;


    private bool Bool = true;
    private protected bool Bool2 = true;
    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        playerPositionY = GameObject.Find("mainPlayer");
        audioSrc = GetComponent<AudioSource>();
        healthBar.fillAmount = 1f;
        lastHPPlayer = healthBar.fillAmount;
    }
    private void Update()
    {
        ControllForIndicator();
    }
    private void ControllForIndicator()
    {

        if (healthBar != null && playerPositionY != null)
        {
            if (healthBar.fillAmount <= 0 && Bool)
            {
                Bool = false;

                if (gameOver)
                {
                    gameOver.SetActive(true);
                    SoundsGameOver();
                   
                }

            }
            else if (playerPositionY.transform.position.y < -15)
            {
                healthBar.fillAmount = 0;
            }
            else if (healthBar.fillAmount < lastHPPlayer && Bool2)
            {
                Bool2 = false;
                SoundsPain();
            }
        }
    }
    private void SoundsGameOver()
    {
        if (audioSrc != null)
        {
            audioSrc.pitch = Random.Range(2, 2.5f);
            audioSrc.PlayOneShot(audioClips[0], 1);
        }
    }
    private void SoundsPain()
    {
        if (audioSrc != null)
        {
            lastHPPlayer = healthBar.fillAmount;
            Bool2 = true;
            audioSrc.pitch = Random.Range(2, 2.5f);
            audioSrc.PlayOneShot(audioClips[1], 1);
        }
    }
}
