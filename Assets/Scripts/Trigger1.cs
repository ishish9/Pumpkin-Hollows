using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] private Animator MainGateRight = null;
    [SerializeField] private Animator MainGateLeft = null;
    [SerializeField] private AudioClip CloseSound_Clip;
    [SerializeField] private bool openTrig = false;
    [SerializeField] private bool closeTrig = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (openTrig)
            {
                // PlaneBehaviour Cut() = new DynamicMeshCutter.PlaneBehaviour();
                MainGateRight.Play("Gate_Main_Right_Open", 0, 0.0f);
                MainGateLeft.Play("Gate_Main_Left_Open", 0, 0.0f);
                AudioManager.Instance.PlaySound(CloseSound_Clip);
                gameObject.SetActive(false);
            }

            else if (closeTrig)
            {
                MainGateRight.Play("Gate_Main_Right_Close", 0, 0.0f);
                MainGateLeft.Play("Gate_Main_Left_Close", 0, 0.0f);
                AudioManager.Instance.PlaySound(CloseSound_Clip);
                gameObject.SetActive(false);
            }
        }
    }
}
