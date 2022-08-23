using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject _menu;
    [SerializeField] private Image _image;
    [SerializeField] private Color _colorOfFade;
    [SerializeField] private AnimationCurve _fadeCurve;

    private void Start()
    {
        Application.targetFrameRate = 120;
        Time.timeScale = 1;
        Fade();
    }

    private IEnumerator FadeIn()
    {
        float time = 1f;
        float curve;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            curve = _fadeCurve.Evaluate(time);
            _image.color = new Color(_colorOfFade.r, _colorOfFade.g, _colorOfFade.b, curve);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(int scene)
    {
        float time = 0f;
        float curve;

        while (time < 1f)
        {
            time += Time.unscaledDeltaTime;
            curve = _fadeCurve.Evaluate(time);
            _image.color = new Color(_colorOfFade.r, _colorOfFade.g, _colorOfFade.b, curve);
            yield return 0;
        }

        SceneManager.LoadSceneAsync(scene);
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    public void Fade()
    {
        StartCoroutine(FadeIn());
    }

    public void StopGame() 
    {
        FadeIn();
        Time.timeScale = 0;
        _menu.SetActive(true);
    }
    public void Resume() 
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
