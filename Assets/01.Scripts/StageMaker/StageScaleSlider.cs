using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������� ũ�⸦ �����ϴ� �����̴� ��ũ��Ʈ
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
	/// �������� ũ�� ������Ʈ
	/// </summary>
	/// <param name="value"></param>
	private void ScaleUpdate(float value)
	{
		stage.localScale = Vector3.one * (value + 1.0f);
	}
}
