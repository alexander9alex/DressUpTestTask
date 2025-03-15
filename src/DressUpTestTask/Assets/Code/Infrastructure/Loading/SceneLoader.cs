using System;
using System.Collections;
using Code.Infrastructure.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.Loading
{
  public class SceneLoader : ISceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
      _coroutineRunner = coroutineRunner;

    public void LoadScene(string scene, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(LoadSceneCoroutine(scene, onLoaded));

    private static IEnumerator LoadSceneCoroutine(string scene, Action onLoaded)
    {
      AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scene);

      while (!sceneLoading.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}
