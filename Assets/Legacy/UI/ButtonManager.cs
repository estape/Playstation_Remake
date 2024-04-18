using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button BtnMemoryCard;
    public Button BtnCDPlayer;
    public Button BtnGames;

    string BtnSelected = null;

    void Start()
    {
        // Certifique-se de que os botões estão atribuídos corretamente no Editor Unity.
        BtnMemoryCard.onClick.AddListener(OnMemoryCardClick);
        BtnCDPlayer.onClick.AddListener(OnCDPlayerClick);
        BtnGames.onClick.AddListener(OnGamesClick);
    }

    void Update()
    {
        string BtnSelected = EventSystem.current.currentSelectedGameObject.name;

        if (BtnSelected == "Btn_MemoryCard")
        {
            BtnMemoryCard.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            BtnCDPlayer.transform.localScale = new Vector3(1f, 1f, 1f);
            BtnGames.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (BtnSelected == "Btn_CDPlayer")
        {
            BtnMemoryCard.transform.localScale = new Vector3(1f, 1f, 1f);
            BtnCDPlayer.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            BtnGames.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (BtnSelected == "Btn_Games")
        {
            BtnMemoryCard.transform.localScale = new Vector3(1f, 1f, 1f);
            BtnCDPlayer.transform.localScale = new Vector3(1f, 1f, 1f);
            BtnGames.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }

    void OnMemoryCardClick()
    {
        // Lógica para Btn_MemoryCard pressionado
        Debug.Log("Btn_MemoryCard pressionado");
    }

    void OnCDPlayerClick()
    {
        // Lógica para Btn_CDPlayer pressionado
        Debug.Log("Btn_CDPlayer pressionado");
    }

    void OnGamesClick()
    {
        // Lógica para Btn_Games pressionado
        Debug.Log("Btn_Games pressionado");
    }
}