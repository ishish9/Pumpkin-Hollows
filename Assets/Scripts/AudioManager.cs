using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource MusicSource, EffectsSource;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.PlayOneShot(clip);
    }
    public void PlaySound(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }
    public void PlaySoundDelayed(AudioClip clip, float delay)
    {
        EffectsSource.clip = clip;
        EffectsSource.PlayDelayed(delay);
    }

    public void MasterVolumeControl(float volumeLevel)
    {
        AudioListener.volume = volumeLevel;
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }

    public void ToggleEffects()
    {
        EffectsSource.mute = !EffectsSource.mute;
    }

    public void MusicOn()
    {
        MusicSource.mute = false;
    }

    public void MusicOff()
    {
        MusicSource.mute = true;
    }
}

