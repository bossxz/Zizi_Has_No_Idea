using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스테이지의 크기를 조절하는 슬라이더 스크립트
/// </summary>
public class StageScaleSlider : MonoBehaviour
{
	[SerializeField] private Slider sizeSlider = null;
	[SerializeField] private Transform stage = null;

	private void Start()
	{
		sizeSlider.onValueChanged.AddListener((value) => ScaleUpdate(value));
	}

	/// <summary>
	/// 스테이지 크기 업데이트
	/// </summary>
	/// <param name="value"></param>
	private void ScaleUpdate(float value)
	{
		stage.localScale = Vector3.one * (value + 1.0f);
	}
}
