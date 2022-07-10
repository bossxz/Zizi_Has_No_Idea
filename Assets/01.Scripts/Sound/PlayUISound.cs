using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayUISound : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private bool isAutoDown = true;
    [SerializeField] private bool isAutoUp = true;
    [SerializeField] private bool isAutoEnter = true;
    [SerializeField] private bool isAutoExit = true;
    [SerializeField] private bool isAutoSelect = true;
    [SerializeField] private bool isAutoBeginDrag = true;

    public void PlayDownClip()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.playSound);
    }

    public void PlayUpClip()
    {
        //SoundManager.Instance.PlayOneShotAudio(AudioType.EffectSound, upClip);
    }

    public void PlayEnterClip()
    {
        //SoundManager.Instance.PlayOneShotAudio(AudioType.EffectSound, enterClip);
    }

    public void PlayExitClip()
    {
        //SoundManager.Instance.PlayOneShotAudio(AudioType.EffectSound, exitClip);
    }

    public void PlaySelectClip()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.selectSound);
    }

    public void PlayBeginDragClip()
    {
        SoundManager.Instance.PlayEffectOneShotAudio(AudioType.buttonDragSound);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (isAutoDown)
        {
            PlayDownClip();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isAutoUp)
        {
            PlayUpClip();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isAutoEnter)
        {
            PlayEnterClip();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isAutoExit)
        {
            PlayExitClip();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isAutoBeginDrag)
        {
            PlayBeginDragClip();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}