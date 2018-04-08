using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Linq;

public class BundleBuilder : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundle")]
    public static void BuildAssetBundle()
    {
        //= 번들이 묶여서 export 되는 위치
        string outputPath = Application.dataPath;
        outputPath = outputPath.Replace("Assets", "ExportBundles");

        if (!Directory.Exists(outputPath))
            Directory.CreateDirectory(outputPath);

        //var assets = Selection.objects.Where(o => !string.IsNullOrEmpty(AssetDatabase.GetAssetPath(o))).ToArray();
        //var e = assets.GetEnumerator();
        //while (e.MoveNext() == true)
        //{
        //    UnityEngine.Object obj = e.Current as UnityEngine.Object;
        //    string str = AssetDatabase.GetAssetPath(obj);
        //    string[] split = str.Split('/');


        //    Debug.Log(str);
        //}

        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}