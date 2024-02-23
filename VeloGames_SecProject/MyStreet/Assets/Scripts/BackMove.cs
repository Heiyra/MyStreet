using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMove : MonoBehaviour
{
    public int gameSpeed = 10;
    public int barrage = 10;
    private void Start()
    {
        barrage = 10;
        gameSpeed = 10;
    }
    private void Update()
    {
        if (!GameManager.Instance.isDeath)
        {
            ProcessSpeed();
        }
    }

    public void ProcessSpeed()
    {
        if (GameManager.Instance.score > barrage)
        {
            barrage += barrage;

            gameSpeed += 3;
        }

        transform.Translate(Vector3.back * gameSpeed * Time.deltaTime);
    }
}
