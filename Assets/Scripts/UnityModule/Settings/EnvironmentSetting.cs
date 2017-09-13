using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityModule.Settings {

    // ReSharper disable once PartialTypeWithSinglePart
    // ReSharper disable once RedundantExtendsListEntry
    public partial class EnvironmentSetting : Setting<EnvironmentSetting> {

        /// <summary>
        /// Keystore の情報を管理する構造体
        /// </summary>
        [Serializable]
        public struct Keystore {

            public string Path;

            public string Passphrase;

            public string AliasName;

            public string AliasPassphrase;

        }

        /// <summary>
        /// 開発向けのキーストアの実体
        /// </summary>
        [SerializeField]
        private Keystore keystoreDevelopment;

        /// <summary>
        /// 開発向けのキーストア
        /// </summary>
        public Keystore KeystoreDevelopment {
            get {
                return this.keystoreDevelopment;
            }
            set {
                this.keystoreDevelopment = value;
            }
        }

        /// <summary>
        /// 本番向けのキーストアの実体
        /// </summary>
        [SerializeField]
        private Keystore keystoreProduction;

        /// <summary>
        /// 本番向けのキーストア
        /// </summary>
        public Keystore KeystoreProduction {
            get {
                return this.keystoreProduction;
            }
            set {
                this.keystoreProduction = value;
            }
        }

    }

}
