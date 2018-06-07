using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.Build;
#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif
using UnityModule.Settings;

namespace UnityModule.KeystoreManager
{
#if UNITY_2018_1_OR_NEWER
    [PublicAPI]
    public class PreprocessBuild : IPreprocessBuildWithReport
    {
#else
    [PublicAPI]
    public class PreprocessBuild : IPreprocessBuild
    {
#endif
        private const int PreprocessBuildCallbackOrder = 100;

        private const string EnvironmentVariableNameKeystorePath = "KEYSTORE_PATH";

        private const string EnvironmentVariableNameKeystorePassphrase = "KEYSTORE_PASSPHRASE";

        private const string EnvironmentVariableNameKeystoreAliasName = "KEYSTORE_ALIAS_NAME";

        private const string EnvironmentVariableNameKeystoreAliasPassphrase = "KEYSTORE_ALIAS_PASSPHRASE";

        public int callbackOrder => PreprocessBuildCallbackOrder;

#if UNITY_2018_1_OR_NEWER
        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android)
            {
                return;
            }
#else
        public void OnPreprocessBuild(BuildTarget target, string path)
        {
            if (target != BuildTarget.Android)
            {
                return;
            }
#endif
            if (KeyStoreSetting.GetOrDefault().ShouldKeystoreUseEnvironmentVariable)
            {
                PlayerSettings.Android.keystoreName = Environment.GetEnvironmentVariable(EnvironmentVariableNameKeystorePath);
                PlayerSettings.Android.keystorePass = Environment.GetEnvironmentVariable(EnvironmentVariableNameKeystorePassphrase);
                PlayerSettings.Android.keyaliasName = Environment.GetEnvironmentVariable(EnvironmentVariableNameKeystoreAliasName);
                PlayerSettings.Android.keyaliasPass = Environment.GetEnvironmentVariable(EnvironmentVariableNameKeystoreAliasPassphrase);
            }
            else
            {
                var keystoreInformation = KeyStoreSetting
                    .GetOrDefault()
                    .KeystoreInformationList
                    .FirstOrDefault(x => x.BuildEnvironment == (EditorUserBuildSettings.development ? BuildEnvironment.Development : BuildEnvironment.Production));
                PlayerSettings.Android.keystoreName = Path.GetFullPath(keystoreInformation.Path.Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.Personal)));
                PlayerSettings.Android.keystorePass = keystoreInformation.Passphrase;
                PlayerSettings.Android.keyaliasName = keystoreInformation.AliasName;
                PlayerSettings.Android.keyaliasPass = keystoreInformation.AliasPassphrase;
            }
        }
    }
}