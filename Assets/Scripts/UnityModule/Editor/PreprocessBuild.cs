using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif
using UnityModule.Settings;

namespace UnityModule.KeystoreManager {

#if UNITY_2018_1_OR_NEWER
    public class PreprocessBuild : IPreprocessBuildWithReport {
#else
    public class PreprocessBuild : IPreprocessBuild {
#endif

        private const string ENVIRONMENT_VARIABLE_NAME_KEYSTORE_PATH             = "KEYSTORE_PATH";

        private const string ENVIRONMENT_VARIABLE_NAME_KEYSTORE_PASSPHRASE       = "KEYSTORE_PASSPHRASE";

        private const string ENVIRONMENT_VARIABLE_NAME_KEYSTORE_ALIAS_NAME       = "KEYSTORE_ALIAS_NAME";

        private const string ENVIRONMENT_VARIABLE_NAME_KEYSTORE_ALIAS_PASSPHRASE = "KEYSTORE_ALIAS_PASSPHRASE";

        /// <summary>
        /// コマンドライン引数: 開発ビルドかどうか
        /// </summary>
        private const string COMMANDLINE_ARGUMENT_DEVELOPMENT_BUILD = "developmentBuild";

        public int callbackOrder {
            get {
                return 100;
            }
        }

#if UNITY_2018_1_OR_NEWER
        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android) {
                return;
            }
#else
        public void OnPreprocessBuild(BuildTarget target, string path) {
            if (target != BuildTarget.Android) {
                return;
            }
#endif
            if (EnvironmentSetting.Instance.ShouldKeystoreUseEnvironmentVariable) {
                PlayerSettings.Android.keystoreName = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME_KEYSTORE_PATH);
                PlayerSettings.Android.keystorePass = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME_KEYSTORE_PASSPHRASE);
                PlayerSettings.Android.keyaliasName = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME_KEYSTORE_ALIAS_NAME);
                PlayerSettings.Android.keyaliasPass = Environment.GetEnvironmentVariable(ENVIRONMENT_VARIABLE_NAME_KEYSTORE_ALIAS_PASSPHRASE);
            } else {
                EnvironmentSetting.KeystoreInformation keystoreInformation = EnvironmentSetting.Instance.KeystoreList.Find(x => x.BuildEnvironment == (EditorUserBuildSettings.development ? BuildEnvironment.Development : BuildEnvironment.Production));
                PlayerSettings.Android.keystoreName = Path.GetFullPath(keystoreInformation.Path.Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.Personal)));
                PlayerSettings.Android.keystorePass = keystoreInformation.Passphrase;
                PlayerSettings.Android.keyaliasName = keystoreInformation.AliasName;
                PlayerSettings.Android.keyaliasPass = keystoreInformation.AliasPassphrase;
            }
        }

    }

}