using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

internal class MainSettingForWind : MonoBehaviour
{
    protected private static bool IsBool;
    private float randomTime;
    private GameObject child;
    private Vector3 rotate;
    private bool Bool = true;
    private void Start()
    {
        child = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }
    private void OnTriggerStay(Collider Wind)
    {
        if (Wind.gameObject.CompareTag("ForTriiger") && Bool)
        {
            Bool = false;
            StartCoroutine(TimeCoroutine());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ForTriiger"))
        {
            StopCoroutine(TimeCoroutine());
        }
    }
    protected private IEnumerator TimeCoroutine()
    {
        while (!Bool)
        {
            randomTime = Random.Range(0,2);
            if (randomTime == 0)
            {
                IsBool = false;
                rotate = transform.eulerAngles;
                rotate.y = -180;
                child.transform.rotation = Quaternion.Euler(rotate);
                yield return new WaitForSeconds(2);
                Bool = true;
            }
            else
            {
                IsBool = true;
                rotate = transform.eulerAngles;
                rotate.y = 0;
                child.transform.rotation = Quaternion.Euler(rotate);
                yield return new WaitForSeconds(2);
                Bool = true;
            }
        }
    }
}
