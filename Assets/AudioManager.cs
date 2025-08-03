using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _MusicSource;
    [SerializeField] private AudioSource _BackgroundSource;
    [SerializeField] private AudioSource[] _SFXChannels;

    [SerializeField] private AudioClip MusicClip;
    [SerializeField] private AudioClip BackgroundClip;

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
        
        PlayBackgroundAmbience(BackgroundClip);
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
    
    public void PlayBackgroundAmbience(AudioClip clip, bool loop = true)
    {
        if (_BackgroundSource.clip != clip)
        {
            _BackgroundSource.clip = clip;
        }

        _BackgroundSource.loop = loop;
        _BackgroundSource.Play();
    }
}
