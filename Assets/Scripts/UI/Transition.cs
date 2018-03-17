using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : Singleton<Transition>
{
    public Animator m_FaderAnimator;

    public void LoadScene(string sceneName, bool loading = true)
    {
        StartCoroutine(Loading(sceneName, loading));
    }

    private IEnumerator Loading(string sceneName, bool loading)
    {
        m_FaderAnimator.SetTrigger("FadeOut");
        yield return new WaitUntil(() => m_FaderAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        SceneManager.LoadScene(sceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        m_FaderAnimator.SetTrigger("FadeIn");
    }
}
