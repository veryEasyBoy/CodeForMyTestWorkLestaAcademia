using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class WindTrapLeft : MainSettingForWind
{
    [SerializeField] private float PowerWind = 1f;
    [SerializeField] private GameObject transformPlayer;
    [SerializeField] private Rigidbody rb;
    private void OnTriggerStay(Collider Wind)
    {
        if (Wind.gameObject.CompareTag("ForTriiger"))
        {
            StartCoroutine(TimeCoroutine());
            WindLeft();
        }
    }
    private void WindLeft()
    {
        if (!IsBool)
        {
            transformPlayer.transform.position = new Vector3(transformPlayer.transform.position.x - PowerWind * Time.deltaTime, transformPlayer.transform.position.y, transformPlayer.transform.position.z);
        }
    }
}   
