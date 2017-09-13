using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityModule.CommandLine;
using UnityModule.Settings;

namespace KeystoreManager {

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
            EnvironmentSetting.Keystore keystore = Arguments.GetBool(COMMANDLINE_ARGUMENT_DEVELOPMENT_BUILD) ? EnvironmentSetting.Instance.KeystoreDevelopment : EnvironmentSetting.Instance.KeystoreProduction;
            PlayerSettings.Android.keystoreName = Path.GetFullPath(keystore.Path);
            PlayerSettings.Android.keystorePass = keystore.Passphrase;
            PlayerSettings.Android.keyaliasName = keystore.AliasName;
            PlayerSettings.Android.keyaliasPass = keystore.AliasPassphrase;
        }

    }

}