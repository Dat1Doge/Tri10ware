using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite deselectedSprite;
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private UnityEngine.UI.Image image;
    private void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = selectedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = deselectedSprite;
    }
}
