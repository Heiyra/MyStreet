using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Way : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndWay"))
        {
            other.gameObject.transform.position = new Vector3(0f, 70f, 30f);
        }
        else if (other.gameObject.CompareTag("ReSpawn"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
