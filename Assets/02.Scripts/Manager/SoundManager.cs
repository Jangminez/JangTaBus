using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {get => instance;}

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioClip basicBgm;

    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;
    [SerializeField][Range(0f, 1f)] private float musicVolume;

    public SoundSource soundSourcePrefab;

    void Awake()
    {
        instance = this;
    }
    
    public void SetBasicBGM()
    {
        ChangeBgm(basicBgm);
    }

    public void ChangeBgm(AudioClip clip)
    {
        bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public static void PlaySFX(AudioClip clip)
    {
        SoundSource soundSource = Instantiate(instance.soundSourcePrefab);
        soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
    }
    
}
