# What?

* Android の Keystore を管理します。

# Why?

* ビルド時に環境依存な設定としての Keystore 情報を必要とするため実装しました。

# Install

```shell
$ npm install github:umm/keystore_manager
```

# Usage

1. `Assets` &gt; `Create` &gt; `Setting` &gt; `EnvironmentSetting` から環境依存設定用ファイルを作成します
1. `Keystore` の項目を設定します
1. ビルド時に自動的に反映されます

# License

Copyright (c) 2017 Tetsuya Mori

Released under the MIT license, see [LICENSE.txt](LICENSE.txt)

