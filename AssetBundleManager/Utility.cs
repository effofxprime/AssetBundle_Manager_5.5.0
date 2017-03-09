using System;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AssetBundles
{
    public class Utility
    {
        // Should figure out a way to make this a NON const string.  that way I can impliment the commeneted out line below.
        //public const string AssetBundlesOutputPath = "Assets/StreamingAssets/";
        //public const string AssetBundlesOutputPath = "file://" + Application.streamingAssetsPath + "/";
        public enum BasePathType
        {
            Streaming=0,
            Data=1,
            PersistentData=1,
            Executable=2,
        }

        public static string GetAssetBundlesBasePath()
        {
#if UNITY_EDITOR
                //EditorPrefs.DeleteKey("AssetBundlesPathType");
            //if (EditorPrefs.HasKey("AssetBundlesPathType"))
            //{
            //    basePathType = (BasePathType)Enum.Parse(typeof(BasePathType), EditorPrefs.GetString("AssetBundlesPathType", BasePathType.Streaming.ToString()));
            //}
            //else
            //{
            //    EditorPrefs.SetString("AssetBundlesPathType", basePathType.ToString());
            //}
#endif

            switch (AssetBundleSettings.AssetBundlesBasePath)
            {
                case AssetBundleSettings.BasePathType.None:
                    return string.Empty;
                case AssetBundleSettings.BasePathType.StreamingAssets:
                    return Application.streamingAssetsPath;
                case AssetBundleSettings.BasePathType.Data:
                    return Application.dataPath;
                case AssetBundleSettings.BasePathType.PersistentData:
                    return Application.persistentDataPath;
                case AssetBundleSettings.BasePathType.Executable:
                    if (Application.isEditor)
                    {
                        return Application.dataPath + "/../";
                    }
                    else if (Application.platform == RuntimePlatform.OSXPlayer)
                    {
                        return Application.dataPath + "/../../";
                    }
                    else if (Application.platform == RuntimePlatform.WindowsPlayer)
                    {
                        return Application.dataPath + "/../";
                    }
                    break;
            }
            return Application.persistentDataPath;
        }


        public static string GetAssetBundlesOutputPath()
        {
            if(AssetBundleSettings.AssetBundlesBasePath==AssetBundleSettings.BasePathType.None)
            {
                return AssetBundleSettings.AssetBundlesPath;
            }
            string path = Path.Combine(GetAssetBundlesBasePath(), AssetBundleSettings.AssetBundlesPath);
            if (!path.EndsWith("/"))
            {
                path += "/";
            }
            return path;
        }

        public static string GetAssetBundlesOutputUrl()
        {
            string outputPath = GetAssetBundlesOutputPath();
            if (outputPath.Contains("//"))
            {
                // URL
                return outputPath;
            }
            else
            {
                return "file://" + outputPath;
            }
        }

        public static string GetPlatformName()
        {
#if UNITY_EDITOR
            return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformForAssetBundles(Application.platform);
#endif
        }

#if UNITY_EDITOR
        private static string GetPlatformForAssetBundles(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
#if UNITY_TVOS
                case BuildTarget.tvOS:
                    return "tvOS";
#endif
                case BuildTarget.iOS:
                    return "iOS";
                case BuildTarget.WebGL:
                    return "WebGL";
#if !UNITY_5_4_OR_NEWER
                case BuildTarget.WebPlayer:
                    return "WebPlayer";
#endif
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    return "Windows";
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                case BuildTarget.StandaloneOSXUniversal:
                    return "OSX";
                // Add more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
                default:
                    return null;
            }
        }
#endif

        private static string GetPlatformForAssetBundles(RuntimePlatform platform)
        {
            switch (platform)
            {
                case RuntimePlatform.Android:
                    return "Android";
                case RuntimePlatform.IPhonePlayer:
                    return "iOS";
#if UNITY_TVOS
                case RuntimePlatform.tvOS:
                    return "tvOS";
#endif
                case RuntimePlatform.WebGLPlayer:
                    return "WebGL";
#if !UNITY_5_4_OR_NEWER
                case RuntimePlatform.OSXWebPlayer:
                case RuntimePlatform.WindowsWebPlayer:
                    return "WebPlayer";
#endif
                case RuntimePlatform.WindowsPlayer:
                    return "Windows";
                case RuntimePlatform.OSXPlayer:
                    return "OSX";
                // Add more build targets for your own.
                // If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
                default:
                    return null;
            }
        }
    }
}
