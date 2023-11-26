using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopDelay : MonoBehaviour
{
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioClip AudioClip;
    [SerializeField] private float Delay;
    [SerializeField] private int LoopAudioAmount;
    [SerializeField] private bool LoopAudioContinues;
    string[] numbers = new string[4]; 

    void Start()
    {
        numbers[0] = "1";
        foreach (string n in numbers) 
        {
            Debug.Log(n);
        }   
    }

    // Loop Audio with delay for a set amount of times
    public void LoopAudioAmountMethod()
    {
        StartCoroutine(cor1());

        IEnumerator cor1()
        {
            for (int i = 0; i < LoopAudioAmount; i++)
            {
                AudioManager.Instance.PlaySound(AudioClip);
                yield return new WaitForSeconds(Delay);
            }
        }
    }

    // Loop Audio with Delay Continuesly
    public void LoopAudioContinuesMethod()
    {
        StartCoroutine(cor2());

        IEnumerator cor2()
        {
            while (LoopAudioContinues)
            {
                AudioManager.Instance.PlaySound(AudioClip);
                yield return new WaitForSeconds(Delay);
            }
        }
    }
}
