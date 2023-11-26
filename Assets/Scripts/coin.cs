
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class coin : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollectSND;
    public UnityEvent AddCoin;
    private void Start()
    {

    }
    void Update()
    {
        transform.Rotate(0f , 0f, 400f * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            AudioManager.Instance.PlaySound(coinCollectSND);
           // CoinCounter.addCoinDelegate +=
            gameObject.SetActive(false);
        }
    }
}
