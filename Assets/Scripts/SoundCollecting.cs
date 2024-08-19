using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollecting : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            soundManager.PlayCoinSoundPickUP();
        }
    }
}
