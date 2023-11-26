using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int CoinSpawnAmount;
    [SerializeField] private GameObject CoinInstantiateOBJ;
    [SerializeField] private Vector3 offset = new Vector3(0f, 4f, 0f);
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Animator Chest_Open = null;
    [SerializeField] private Animator ChestUnlock = null;
    [SerializeField] private Animator ChestFullyOpen = null;
    [SerializeField] private AudioClip ChestOpen_SND;
    [SerializeField] private AudioClip TaDa_SND;
    [SerializeField] private AudioClip TaDa_Bad_SND;
    [SerializeField] private bool CoinChest = false;
    [SerializeField] private bool CrystalChest = false;
    [SerializeField] private bool KeyChest = false;
    [SerializeField] private bool MysteryChest = false;
    [SerializeField] private bool EmptyChest = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        
        if (CoinChest)
        {
            CoinChest = false;
            AudioManager.Instance.PlaySound(ChestOpen_SND);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(TaDa_SND);         
                for (int i = 0; i < CoinSpawnAmount; i++)
                    {
                        offset = new Vector3(Random.Range(0, 6), 0, Random.Range(0, 6));
                        GameObject obj = Instantiate(CoinInstantiateOBJ, spawnLocation.position + offset, Quaternion.identity);
                        obj.GetComponent<Rigidbody>().velocity = new Vector3 (Random.Range(0,20),0, Random.Range(0, 20));
                    }
                }
            }
        else if (CrystalChest)
        {
            CrystalChest = false;
            AudioManager.Instance.PlaySound(ChestOpen_SND);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(TaDa_SND);
            }
        }
        else if (KeyChest)
        {
            KeyChest = false;
            AudioManager.Instance.PlaySound(ChestOpen_SND);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(TaDa_SND);
            }
        }
        else if (MysteryChest)
        {
            MysteryChest = false;
            AudioManager.Instance.PlaySound(ChestOpen_SND);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(TaDa_SND);
            }
        }
        else if (EmptyChest)
        {
            EmptyChest = false;
            AudioManager.Instance.PlaySound(ChestOpen_SND);
            Chest_Open.Play("Chest_Open", 0, 0.0f);

            StartCoroutine(openChest());

            IEnumerator openChest()
            {
                yield return new WaitForSeconds(1);
                AudioManager.Instance.PlaySound(TaDa_Bad_SND);
            }
        }
    }
}
}
