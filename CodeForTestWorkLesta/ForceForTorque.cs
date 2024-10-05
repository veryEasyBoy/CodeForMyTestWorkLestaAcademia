using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
internal class ForceForTorque : Indicators
{
    [SerializeField] private GameObject transformPlayer;
    private float powerForce = 300f;
    private void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
    }
    private void OnTriggerStay(Collider trap)
    {
        if (trap.gameObject.CompareTag("ForTriiger"))
        {
            transformPlayer.transform.position = new Vector3(transformPlayer.transform.position.x - powerForce * Time.deltaTime, transformPlayer.transform.position.y + powerForce/2 * Time.deltaTime, transformPlayer.transform.position.z);
            healthBar.fillAmount -= powerForce / 1000f;
        }
    }
}
