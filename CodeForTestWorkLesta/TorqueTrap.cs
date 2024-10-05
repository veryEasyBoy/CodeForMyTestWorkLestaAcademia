using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

internal class TorqueTrap : MonoBehaviour
{
   [SerializeField] private protected float rotateSpeed = 10f;


    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime );
    }

}
