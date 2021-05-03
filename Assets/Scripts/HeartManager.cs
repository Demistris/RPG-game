using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _halfFullHeart;
    [SerializeField] private Sprite _emptyHeart;
    [SerializeField] private FloatValue _heartsContainter;
    [SerializeField] private FloatValue _playerCurrentHealth;

    private void Start()
    {
        InitHearts();
    }

    private void InitHearts()
    {
        for (int i = 0; i < _heartsContainter.InitialValue; i++)
        {
            _hearts[i].gameObject.SetActive(true);
            _hearts[i].sprite = _fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = _playerCurrentHealth.RuntimeValue / 2;

        for (int i = 0; i < _heartsContainter.InitialValue; i++)
        {
            if(i <= tempHealth - 1)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else if(i >= tempHealth)
            {
                _hearts[i].sprite = _emptyHeart;
            }
            else
            {
                _hearts[i].sprite = _halfFullHeart;
            }
        }
    }
}
