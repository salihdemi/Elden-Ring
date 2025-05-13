using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;
    private void Awake()
    { if (instance == null) { instance = this; } /*else { Destroy(gameObject); }*/ }

    [Header("Network Join")]
    [SerializeField] bool startGameAsClient;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            // We must first shut down, becausewe have started as a host during the title screen
            NetworkManager.Singleton.Shutdown();
            // Then restart as client
            NetworkManager.Singleton.StartClient();
        }
    }
}
