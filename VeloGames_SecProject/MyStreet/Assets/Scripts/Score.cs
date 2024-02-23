using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.score += 2;
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void IncreaseScore()
    {
        GameManager.Instance.score ++;
    }
}
