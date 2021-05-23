using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _pressedSprite;
    [SerializeField] private Sprite _unPressedSprite;
    [SerializeField] private GameObject _rocky;
    [SerializeField] private Sign _rockyText;
    [SerializeField] private string _newText;
    private string _oldText;

    private void Start()
    {
        _oldText = _rockyText._dialog;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetSwitchActivity(collision, _pressedSprite, 2, _newText);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetSwitchActivity(collision, _unPressedSprite, -2, _oldText);
    }

    private void SetSwitchActivity(Collider2D collision, Sprite sprite, int posValue, string text)
    {
        if (!collision.isTrigger)
        {
            _spriteRenderer.sprite = sprite;
            _rocky.transform.position = new Vector2(_rocky.transform.position.x, _rocky.transform.position.y + posValue);
            _rockyText._dialog = text;
        }
    }
}
