using UnityEditor;
using UnityEngine;
using Unity.Netcode;

[InitializeOnLoad]
public class NetworkShutdownHandler : MonoBehaviour
{
    static NetworkShutdownHandler()
    {
        EditorApplication.playModeStateChanged += ShutdownNetworkOnExitPlayMode;
    }

    private static void ShutdownNetworkOnExitPlayMode(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsListening)
            {
                NetworkManager.Singleton.Shutdown();
            }
        }
    }
}
