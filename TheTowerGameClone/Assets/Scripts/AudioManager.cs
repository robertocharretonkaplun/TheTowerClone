using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClips_Names
{
  SONG_1,
  SONG_2
}

public enum AudioClips_Effects
{
  BULLET,
  SPAWN,
  BASE_DAMAGE,
  BASE_DESTRUCTION
}

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance;
  [SerializeField]
  private AudioSource audioSource;
  private AudioSource audioSourceEffectRef;
  [SerializeField]
  public AudioClip[] audioClipsSongs;
  public AudioClip[] audioClipsEffects;

  // Start is called before the first frame update
  void Start()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetAudioClip(AudioClips_Names audioClips_Names)
  {
    audioSource.Stop();
    audioSource.PlayDelayed(.3f);
    audioSource.PlayOneShot(audioClipsSongs[(int)audioClips_Names], 0.3f);
  }

  public void SetAudioClipForEffects(AudioSource audioSource, AudioClips_Effects audioClips_Effects)
  {
    audioSource.PlayOneShot(audioClipsEffects[(int)audioClips_Effects], 0.3f);
    audioSourceEffectRef = audioSource;
  }

  public float ModifyCurrentEffectVolume()
  {
    return audioSourceEffectRef.volume;
  }
}
