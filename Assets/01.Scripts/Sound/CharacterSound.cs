using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    public void PlayWalkSound()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.walkSound);
    }

    public void PlaySelectSound()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.selectSound);
    }

    public void PlayFallSound()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.failSound);
    }

    public void PlayLandingSound()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.landingSound);
    }
}
