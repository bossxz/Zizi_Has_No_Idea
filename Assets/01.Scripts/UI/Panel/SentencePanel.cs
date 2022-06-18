using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SentencePanel : PanelBase
{
    public Item item;
    public Verb verb;

    private ChangeUISprite worldImage;

    [SerializeField] private Text unitText;
    [SerializeField] private Text subjectText;
    [SerializeField] private Text verbText;

    [SerializeField] private RectTransform unitRect;
    private RectTransform verbRect;
    private RectTransform panelRect;

    private readonly float offset = 410f;
    private Vector2 originalSizeDelta;

    [SerializeField] private UnityEvent onSelected;
    [SerializeField] private UnityEvent onFailToSelected;

    public void Init(Item item)
    {
        SetData(item);
        SetUI();

        EventManager<EventParam>.StartListening(Constant.CLICK_PLAYER_EVENT, UpdateUI);
        EventManager.StartListening(Constant.SELECT_VERB_WORD_EVENT, ChangeVerbType);
    }

    public void SetData(Item item)
    {
        this.item = item;

        verb = GameManager.Instance.Data.Verbs.verbs.Find(x => x.verbType == VerbType.None);

        UpdateUI();
    }

    private void UpdateUI(EventParam param = new EventParam())
    {
        if (param.character == null || item == null || param.character?.characterName == item?.Name)
        {
            gameObject.SetActive(false);
            return;
        }

        UpdateUI(param.character);
    }

    private void UpdateUI(Character character)
    {
        if (character == null || item == null || character?.characterName == item?.Name)
        {
            gameObject.SetActive(false);
            return;
        }

        verb = item.verbPairs[VerbSystemController.CurrentCharacter];
        string oPostposition = "��";

        if (verb.postposition == "��" || verb.postposition == "��")
            oPostposition = (item.Name[item.Name.Length - 1] - 0xAC00) % 28 > 0 ? "��" : "��";

        else if (verb.postposition == "��")
            oPostposition = verb.postposition;

        string sPostposition = (character?.characterName[character.characterName.Length - 1] - 0xAC00) % 28 > 0 ? "��" : "��";
        subjectText.text = $"{character?.characterName}{sPostposition} {item.Name}{oPostposition} ";

        if (item.verbPairs.ContainsKey(VerbSystemController.CurrentCharacter))
        {
            worldImage.SetSprite(item.verbPairs[VerbSystemController.CurrentCharacter].verbSprites);
        }

        gameObject.SetActive(true);

        AdjustTextDetail();
    }

    public void ChangeVerbType()
    {
        if (!worldImage.IsInPointer())
        {
            onFailToSelected.Invoke();
            return;
        }
        if (VerbSystemController.CurrentVerb == null) return;

        verb.ChangeData(VerbSystemController.CurrentVerb);
        item.verbPairs[VerbSystemController.CurrentCharacter] = verb;
        VerbSystemController.CurrentVerb = null;

        ItemObject itemObj = GameManager.Instance.CurrentItems.Find(x => x.Item.Name == item.Name);
        ParabolaController.GenerateParabola(VerbSystemController.CurrentCharacter, itemObj, verb.verbType);

        worldImage.SetSprite(item.verbPairs[VerbSystemController.CurrentCharacter].verbSprites);

        UpdateUI(VerbSystemController.CurrentCharacter);

        onSelected.Invoke();
    }

    public void SetUnitType(UnitType unitType)
    {
        Debug.Log(verb.verbName + ", " + unitType);
        verb.unitType = unitType;
        unitText.text = Constant.UNITS_NAME[(int)unitType];
    }

    void AdjustTextDetail()
    {
        Vector2 startPoint = subjectText.rectTransform.anchoredPosition;
        startPoint.x += subjectText.text.Length * subjectText.fontSize;

        Vector2 nextPos = new Vector2(46f, subjectText.rectTransform.anchoredPosition.y - 75f);

        if (verb == null)
        {
            Debug.LogError("verb: NULL");
            return;
        }

        if (verb.hasUnit)
        {
            ArrangeText(startPoint, unitRect, ref nextPos);

            startPoint = unitRect.anchoredPosition;
            startPoint.x = unitRect.anchoredPosition.x + unitRect.rect.width;

            SetUnitType(verb.unitType);
        }

        ArrangeText(startPoint, verbRect, ref nextPos, true);

        unitRect.gameObject.SetActive(verb.hasUnit);
    }

    private void ArrangeText(Vector3 startPoint, RectTransform transform, ref Vector2 nextPos, bool isSetRect = false)
    {
        Vector2 pos = startPoint;
        transform.anchoredPosition = pos;

        if (transform.anchoredPosition.x > offset)
        {
            transform.anchoredPosition = nextPos;
            nextPos = transform.anchoredPosition;
            nextPos.x += unitRect.rect.width;

            if (isSetRect)
            {
                panelRect.sizeDelta = originalSizeDelta + Vector2.up * 75f;
            }
        }
    }

    private void SetUI()
    {
        verbRect = verbText.transform.parent.GetComponent<RectTransform>();

        panelRect = GetComponent<RectTransform>();
        originalSizeDelta = panelRect.sizeDelta;
        worldImage = GetComponentInChildren<ChangeUISprite>();
    }

    private void OnDestroy()
    {
        EventManager<EventParam>.StopListening(Constant.CLICK_PLAYER_EVENT, UpdateUI);
        EventManager.StopListening(Constant.SELECT_VERB_WORD_EVENT, ChangeVerbType);
    }
}
