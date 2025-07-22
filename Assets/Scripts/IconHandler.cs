using UnityEngine;
using UnityEngine.UI;

public class IconHandler : MonoBehaviour
{
    [SerializeField] private Image[] _icons;
    [SerializeField] private Color _usedColor;

    public void UseShot(int shotNumber)
    {
        for (int i = 0; i < _icons.Length; i++)
        {
            if (shotNumber == i +1)
            {
                _icons[i].color = _usedColor;
                return;
            }
        }
    }
}
