using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]
    Slider musicSlider;

    [SerializeField]
    Slider SFXSlider;

    [SerializeField]
    AudioClip hitBall;

    [SerializeField]
    AudioClip fallGame;

    [SerializeField]
    AudioClip passLevel;

    [SerializeField]
    AudioSource audioSourceBG;

    [SerializeField]
    AudioSource audioSourceSFX;

    [SerializeField]
    private float volumeSFX;

    [SerializeField]
    private float volumeBG;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSFX = GetComponent<AudioSource>();
    }

    public void PlayOneShotHit()
    {
        this.audioSourceSFX.PlayOneShot(hitBall);
    }

    public void PlayOneShotPassLevel()
    {
        this.audioSourceSFX.PlayOneShot(passLevel);
    }

    public void PlayOneShotFallGame()
    {
        this.audioSourceSFX.PlayOneShot(fallGame);
    }

    private void SetVolumeSFX()
    {
        this.volumeSFX = SFXSlider.value;
        this.audioSourceSFX.volume = volumeSFX;
    }

    private void SetVolumneBG()
    {
        this.volumeBG = musicSlider.value;
        this.audioSourceBG.volume = volumeBG;

    }

    public void UpdateVolume()
    {
        SetVolumeSFX();
        SetVolumneBG();
    }

    public void SetSilder()
    {
        this.SFXSlider.value = this.volumeSFX;
        this.musicSlider.value = this.volumeBG;
    }
}
