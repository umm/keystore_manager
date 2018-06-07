using System;
using System.Collections.Generic;
using UnityEngine;
using UnityModule.KeystoreManager;

#pragma warning disable 649

namespace UnityModule.Settings
{
    public class KeyStoreSetting : Setting<KeyStoreSetting>
    {
        [Serializable]
        public struct KeystoreInformation
        {
            [SerializeField] private BuildEnvironment buildEnvironment;

            public BuildEnvironment BuildEnvironment => buildEnvironment;

            [SerializeField] private string path;

            public string Path => path;

            [SerializeField] private string passphrase;

            public string Passphrase => passphrase;

            [SerializeField] private string aliasName;

            public string AliasName => aliasName;

            [SerializeField] private string aliasPassphrase;

            public string AliasPassphrase => aliasPassphrase;
        }

        [SerializeField] private bool shouldKeystoreUseEnvironmentVariable = true;

        public bool ShouldKeystoreUseEnvironmentVariable => shouldKeystoreUseEnvironmentVariable;

        [SerializeField] private List<KeystoreInformation> keystoreInformationList;

        public IEnumerable<KeystoreInformation> KeystoreInformationList => keystoreInformationList;

#if UNITY_EDITOR
        [UnityEditor.MenuItem("Assets/Create/Settings/KeyStore Setting")]
        public static void CreateSettingAsset()
        {
            CreateAsset(true);
        }
#endif
    }
}