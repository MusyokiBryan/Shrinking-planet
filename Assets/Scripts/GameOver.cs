using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour, IPointerDownHandler
{
public void OnPointerDown(PointerEventData eventData)
{
GameManager.instance.Restart();
}

void Update()
{
    GetComponent<RectTransform>().localScale = Vector3.one * Planet.Size;
}

public void Menu()
{
    SceneManager.LoadScene("Menu");
}
}
