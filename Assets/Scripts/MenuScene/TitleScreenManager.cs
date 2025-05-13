using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject pressAnyText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Button newGameButton;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartNetworkAsHost();
            pressAnyText.SetActive(false);
            mainMenu.SetActive(true);
            newGameButton.Select();
        }
    }
    public void StartNetworkAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }
    public void StartNewGame()
    {
        StartCoroutine(WorldSaveGameManager.instance.LoadNewGame());
    }

}
