using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource effectAudio;
    static private Dictionary<AudioType, AudioClip> audioClipList = new Dictionary<AudioType, AudioClip>(); //사운드 클립 딕셔너리
    static bool isSetting = false; //오디오 클립이 세팅되었는지 여부

    private WaitForSeconds delay01 = new WaitForSeconds(1f);

    private void Awake()
    {
        if(isSetting)
		{
            GetEffectAudioClips();
		}
    }

    /// <summary>
    /// 효과음들 가져오기
    /// </summary>
    private void GetEffectAudioClips()
	{
        var count = (int)AudioType.Count;
        for (int i = 0; i < count; ++i)
		{
            var address = System.Enum.GetName(typeof(AudioType), i);
            audioClipList.Add((AudioType)i, AddressablesManager.Instance.GetResource<AudioClip>(address));
        }
        isSetting = true;

    }

    /// <summary>
    /// 효과음 출력
    /// </summary>
    /// <param name="audioType"></param>
    public void PlayEffectAudio(AudioType audioType)
    {
        if(audioClipList.ContainsKey(audioType))
        {
            effectAudio.Stop();
            effectAudio.clip = audioClipList[audioType];
            effectAudio.Play();
        }
    }

    /// <summary>
    /// 브금 출력
    /// </summary>
    /// <param name="audioType"></param>
    public void PlayBGMAudio(AudioType audioType)
    {
        if (audioClipList.ContainsKey(audioType))
        {
            bgmAudio.Stop();
            bgmAudio.clip = audioClipList[audioType];
            bgmAudio.Play();
        }
    }

    /// <summary>
    /// 이펙트 원샷 사운드 
    /// </summary>
    /// <param name="audioType"></param>
    public void PlayEffectOneShotAudio(AudioType audioType)
    {
        if (audioClipList.ContainsKey(audioType))
        {
            effectAudio.PlayOneShot(audioClipList[audioType]);
        }
    }

    /// <summary>
    /// 브금 원샷 사운드
    /// </summary>
    /// <param name="audioType"></param>
    public void PlayBGMOneShotAudio(AudioType audioType)
    {
        if (audioClipList.ContainsKey(audioType))
        {
            bgmAudio.PlayOneShot(audioClipList[audioType]);
        }
    }

    /// <summary>
    /// 스테이지 클리어 사운드 출력
    /// </summary>
    public void PlayClearSound()
    {
        StartCoroutine(FireworkCoroutine());
    }

    private IEnumerator FireworkCoroutine()
    {
        PlayEffectOneShotAudio(AudioType.fireworkSound);
        yield return delay01;
        PlayEffectOneShotAudio(AudioType.fireworkSound);
        yield return delay01;
        PlayEffectOneShotAudio(AudioType.fireworkSound);
    }
}