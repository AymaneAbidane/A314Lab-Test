using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip coinCollectSound;
    [SerializeField] AudioClip lossingSoundEfect;

    public void PlayCoinSoundPickUP()
    {
        GetComponent<AudioSource>().PlayOneShot(coinCollectSound);
    }

    public void PlayLossingSoundEffect()
    {
        GetComponent<AudioSource>().PlayOneShot(lossingSoundEfect);
    }
}
