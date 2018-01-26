using System;
using System.Collections.Generic;
using UnityEngine;
using UnityModule.KeystoreManager;
#pragma warning disable 649

namespace UnityModule.Settings {

    // ReSharper disable once PartialTypeWithSinglePart
    // ReSharper disable once RedundantExtendsListEntry
    public partial class EnvironmentSetting : Setting<EnvironmentSetting> {

        /// <summary>
        /// Keystore の情報を管理する構造体
        /// </summary>
        [Serializable]
        public struct KeystoreInformation {

            [SerializeField]
            private BuildEnvironment buildEnvironment;

            public BuildEnvironment BuildEnvironment {
                get {
                    return this.buildEnvironment;
                }
            }

            [SerializeField]
            private string path;

            public string Path {
                get {
                    return this.path;
                }
            }

            [SerializeField]
            private string passphrase;

            public string Passphrase {
                get {
                    return this.passphrase;
                }
            }

            [SerializeField]
            private string aliasName;

            public string AliasName {
                get {
                    return this.aliasName;
                }
            }

            [SerializeField]
            private string aliasPassphrase;

            public string AliasPassphrase {
                get {
                    return this.aliasPassphrase;
                }
            }

        }

        /// <summary>
        /// キーストアの設定として環境変数を使うかどうかの実体
        /// </summary>
        [SerializeField]
        private bool shouldKeystoreUseEnvironmentVariable = true;

        /// <summary>
        /// キーストアの設定として環境変数を使うかどうか
        /// </summary>
        public bool ShouldKeystoreUseEnvironmentVariable {
            get {
                return this.shouldKeystoreUseEnvironmentVariable;
            }
        }

        /// <summary>
        /// キーストアのリストの実体
        /// </summary>
        [SerializeField]
        private List<KeystoreInformation> keystoreList;

        /// <summary>
        /// キーストアのリスト
        /// </summary>
        public List<KeystoreInformation> KeystoreList {
            get {
                return this.keystoreList;
            }
        }

    }

}
