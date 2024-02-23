using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 2f);
    }

    void Spawn()
    {
        Vector3 trans = transform.position;

        int lane = Random.RandomRange(0, 2);


        GameObject obj = ObjectPool.Instance.GetPooledObjectFirst();

        obj.SetActive(true);

        if (obj != null)
        {
            if (lane == 0)
            {
                obj.transform.position = new Vector3(0, 0, trans.z);
            }
            else if (lane == 1)
            {
                obj.transform.position = new Vector3(5.6f, 0, trans.z);
            }
            else
            {
                obj.transform.position = new Vector3(6.2f, 0, trans.z);
            }
        }
    }
}
