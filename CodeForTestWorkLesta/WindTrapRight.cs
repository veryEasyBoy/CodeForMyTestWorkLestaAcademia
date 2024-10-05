using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

internal class WindTrapRight : MainSettingForWind
{
    [SerializeField] private float PowerWind = 1f;
    [SerializeField] private GameObject transformPlayer;
    [SerializeField] private Rigidbody rb;
    private void OnTriggerStay(Collider Wind)
    {
        if (Wind.gameObject.CompareTag("ForTriiger"))
        {
            StartCoroutine(TimeCoroutine());
            WindRight();
        }
    }
    private void WindRight()
    {
        if(IsBool)
        {
            transformPlayer.transform.position = new Vector3(transformPlayer.transform.position.x + PowerWind * Time.deltaTime, transformPlayer.transform.position.y, transformPlayer.transform.position.z);
        }
    }
}
