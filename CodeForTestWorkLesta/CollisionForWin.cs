using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CollisionForWin : MonoBehaviour
{
    [SerializeField] private GameObject gameWin;
    private AudioSource audioSrc;
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider win)
    {
        if (win.gameObject.CompareTag("ForTriiger"))
        {
            gameWin.SetActive(true);
            audioSrc.Play();
        }
    }
}
