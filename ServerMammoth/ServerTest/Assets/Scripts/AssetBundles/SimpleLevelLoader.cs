using UnityEngine;
using System.Collections;

public class SimpleLevelLoader : MonoBehaviour {

    [SerializeField]
    string path;
    [SerializeField]
    string sceneName;

    IEnumerator Start()
    {
        using (WWW www = WWW.LoadFromCacheOrDownload(path, 0))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield break;
            }
           // Instantiate((GameObject)www.assetBundle.LoadAsset("Player")); // loading asset from the asset bundle

            Application.LoadLevel(sceneName);
            yield return null;

            www.assetBundle.Unload(false);
        }
    }
}