using UnityEngine;
using UnityEditor;
using System.Collections;

public class SimpleBundleBuilder
{
    [MenuItem("Simple Bundles/Build")]
    static void BuildBundles()
    {
        string path = EditorUtility.SaveFolderPanel("Save Bundle", "", "");
        if (path.Length != 0)
        {
            BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        }
    }
}
