using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _MusicSource;
    [SerializeField] private AudioSource[] _SFXChannels;

    [SerializeField] private AudioClip MusicClip;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);

            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _MusicSource.clip = MusicClip;
        _MusicSource.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        foreach (var channel in _SFXChannels)
        {
            if (!channel.isPlaying)
            {
                channel.PlayOneShot(audioClip);

                return;
            }
        }
    }
}
