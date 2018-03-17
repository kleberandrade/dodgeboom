using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        Transition.Instance.LoadScene(sceneName);
    }
}
