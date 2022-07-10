using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource effectAudio;
    static private Dictionary<AudioType, AudioClip> audioClipList = new Dictionary<AudioType, AudioClip>(); //���� Ŭ�� ��ųʸ�
    static bool isSetting = false; //����� Ŭ���� ���õǾ����� ����

    private WaitForSeconds delay01 = new WaitForSeconds(1f);

    private void Awake()
    {
        if(isSetting)
		{
            GetEffectAudioClips();
		}
    }

    /// <summary>
    /// ȿ������ ��������
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
    /// ȿ���� ���
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
    /// ��� ���
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
    /// ����Ʈ ���� ���� 
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
    /// ��� ���� ����
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
    /// �������� Ŭ���� ���� ���
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