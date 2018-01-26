using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityModule.Settings;

namespace UnityModule.KeystoreManager {

    public class PreprocessBuild : IPreprocessBuild {

        /// <summary>
        /// コマンドライン引数: 開発ビルドかどうか
        /// </summary>
        private const string COMMANDLINE_ARGUMENT_DEVELOPMENT_BUILD = "developmentBuild";

        public int callbackOrder {
            get {
                return 100;
            }
        }

        public void OnPreprocessBuild(BuildTarget target, string path) {
            if (target != BuildTarget.Android) {
                return;
            }
            EnvironmentSetting.KeystoreInformation keystoreInformation = EnvironmentSetting.Instance.KeystoreList.Find(x => x.BuildEnvironment == (EditorUserBuildSettings.development ? BuildEnvironment.Development : BuildEnvironment.Production));
            PlayerSettings.Android.keystoreName = Path.GetFullPath(keystoreInformation.Path.Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.Personal)));
            PlayerSettings.Android.keystorePass = keystoreInformation.Passphrase;
            PlayerSettings.Android.keyaliasName = keystoreInformation.AliasName;
            PlayerSettings.Android.keyaliasPass = keystoreInformation.AliasPassphrase;
        }

    }

}