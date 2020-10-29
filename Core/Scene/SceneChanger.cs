using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DifferentPlanetSession.Core.Scene
{
    public class SceneChanger : MonoBehaviour
    {
        public static SceneChanger instance;

        [SerializeField] private AssetReference gameplayUIScene;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            GameObject obj = new GameObject("SceneChanger");
            SceneChanger sceneChanger = obj.AddComponent<SceneChanger>();
            instance = sceneChanger;
            DontDestroyOnLoad(obj);
            instance.LoadScene(instance.gameplayUIScene);
        }

        /*private void Awake()
        {
            instance = this;
        }*/


        public void LoadScene(AssetReference scene)
        {
            Addressables.LoadSceneAsync(scene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            Debug.Log("Loading scene");
        }

        /*public void UnloadScene(AssetReference scene)
        {
            Addressables.UnloadSceneAsync(scene)
        }*/
    }
}