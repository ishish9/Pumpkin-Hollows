using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private AudioClip SeedCollectedSound;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private int AddAmount;

    void Update()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter()
    {
        AudioManager.Instance.PlaySound(SeedCollectedSound);      
        Instantiate(Prefab, transform.position, transform.rotation);     
        score.ScoreAdd1(AddAmount);
        gameObject.SetActive(false);
    }
}
