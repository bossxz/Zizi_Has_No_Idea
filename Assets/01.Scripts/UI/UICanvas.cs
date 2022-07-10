using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
	public Text StageText
	{
		get
		{
			return stageText;
		}
	}
	public RectTransform ChartImage
	{
		get
		{
			return chartImage;
		}
	}
	public SentencePanel SentencePanelPrefab
	{
		get
		{
			return sentencePanelPrefab;
		}
	}
	public List<SentencePanel> SentencePanels
	{
		get
		{
			return sentencePanels;
		}
	}
	public Image UnitScroll
	{
		get
		{
			return unitScroll;
		}
	}
	public InfoImage VerbInfoImage
	{
		get
		{
			return verbInfoImage;
		}
	}
	public CanvasGroup LobbyCanvas
	{
		get
		{
			return lobbyCanvas;
		}
	}
	public CanvasGroup GameCanvas
	{
		get
		{
			return gameCanvas;
		}
	}
	public CanvasGroup SettingCanvas
	{
		get
		{
			return settingCanvas;
		}
	}
	public CanvasGroup EndCanvas
	{
		get
		{
			return endCanvas;
		}
	}



	[SerializeField] private Text stageText;

	[Header("Character Chart")]
	[SerializeField] private RectTransform chartImage;
	[SerializeField] private SentencePanel sentencePanelPrefab;
	private List<SentencePanel> sentencePanels = new List<SentencePanel>();

	[SerializeField] private Image unitScroll;

	[Header("ETC UI")]
	[SerializeField] private InfoImage verbInfoImage;

	[Header("CanvasGroup")]
	[SerializeField] private CanvasGroup lobbyCanvas;
	[SerializeField] private CanvasGroup gameCanvas;
	[SerializeField] private CanvasGroup settingCanvas;
	[SerializeField] private CanvasGroup endCanvas;


}
