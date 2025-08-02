using UnityEngine;

public interface IAudioMeneger
{
    void PlayMusic(string musicName);
    void StopMusic();
    void StopMusic(string musicName);
    void SetMusicVolume(float volume);
    
    void PlaySFX(string soundName);
    void SetSFXVolume(float volume);
}
