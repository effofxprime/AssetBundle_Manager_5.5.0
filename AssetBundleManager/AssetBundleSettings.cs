using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetBundles
{
    ////[ExecuteInEditMode]
    public class AssetBundleSettings : MonoBehaviour
    {
        public enum BasePathType
        {
            /// <summary>
            /// Use this for complete URL
            /// </summary>
            None,
            StreamingAssets,
            Data,
            PersistentData,
            Executable,
        }

        [Tooltip("If this is true then the instance of the AssetBundleSettings won't be destroyed on every scene load.")]
        public bool persistOnLoad = false;

        [Tooltip("Base path type (actual path determined at run time).\nSelect None for complete URL")]
        [SerializeField]
        private BasePathType assetBundlesBasePath = BasePathType.StreamingAssets;

        [Tooltip("Asset bundles URL or path (relative to the asset bundles base path)")]
        [SerializeField]
        private string assetBundlesPath = string.Empty;

        /// <summary>
        /// The singleton instance to access the AssetBundleSettings.
        /// </summary>
        private static AssetBundleSettings instance = null;

        public static BasePathType AssetBundlesBasePath
        {
            get
            {
                GetInstance();
                if (instance == null)
                {
                    //Debug.Log("AssetBundleSettings component not available, using default settings.");
                    return BasePathType.StreamingAssets;
                }

                return instance.assetBundlesBasePath;
            }
        }

        public static string AssetBundlesPath
        {
            get
            {
                GetInstance();
                if(instance == null)
                {
                    return string.Empty;
                }

                return instance.assetBundlesPath;
            }
        }

        public static AssetBundleSettings GetInstance()
        {
            if(instance == null)
            {
                instance = FindObjectOfType<AssetBundleSettings>();
                if(instance != null)
                {
                    instance.SetInstance();
                }
            }
            return instance;
        }

        protected virtual void Awake()
        {
            SetInstance();
        }

        private void SetInstance()
        {
            if (instance == null)
            {
                instance = this;
                Debug.Log("AssetBundleSettings instance created");
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            if (persistOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
