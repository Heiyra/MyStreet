using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; set; }

    public GameObject[] objects;

    [SerializeField] private int Poolsize;

    public Queue<GameObject> pooledObjects;

    [SerializeField] private Transform poolPosition;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        InitializePooledObjects();
    }

    void InitializePooledObjects()
    {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < Poolsize; i++)
        {
            int randomIndex = Random.Range(0, objects.Length);
            GameObject obj1 = Instantiate(objects[randomIndex]);
            obj1.transform.position = poolPosition.position;
            obj1.SetActive(false);
            pooledObjects.Enqueue(obj1);
        }
    }
    public GameObject GetPooledObjectFirst()
    {
        GameObject obj1 = pooledObjects.Dequeue();

        pooledObjects.Enqueue(obj1);

        foreach (Transform child in obj1.transform)
        {
                child.gameObject.SetActive(true);
        }

        return obj1;
    }
}

