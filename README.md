# MeshHologram
Copyright (c) 2025, DeltaField



## Overview | 概要
Name: MeshHologram<br>
Version: 0.1.1<br>

ワイヤーフレーム描写を拡張した、プロシージャルで高度なコントロールが可能なシェーダーです。<br>

以下の機能を特徴としています。
* ワイヤーフレームの線そのものの高度な制御
* ワイヤーフレームの出現、消滅の**多様なアニメーション**
* 2種類の指定した色を始めとした、**様々なカラーコントロール**
* ジオメトリシェーダーによる、メッシュそのものの変形機能
* メッシュが自在に飛んだり、衛星軌道を描かせる**Messy/Orbit**機能
* 様々な座標を入力として指定できる、**三つのノイズマップ**と**高度なマスクコントロール**
* **AudioLink対応**
* etc...

## Requirements | 環境要件
現在、以下の環境で動作を確認しています。
* Unity 2022.3
* Built-in Render Pipeline
* Unity XR Single-pass Instanced

以下の前提パッケージが必要です。VPMでインストールした場合は自動的にインポートされます。
* [DeltaField-Shader-Commons](https://github.com/r-delta-c/DeltaField-Shader-Commons)



## Caution | 警告
* 動作保証外として、実際に検証ができなかった環境があります。<br>***Pimaxといったステレオ描写が特殊な機器等***<br><br>正常な動作を確認できていないため、保証はできかねます。ご了承ください。



## Installation instructions | インストール方法
インストール方法は以下の三つのやり方があります。どれか一つの方法を実施してください。

### VPM - ***推奨***
[Package Listing WEB](https://r-delta-c.github.io/vpm_repository/)へ移動し、**Add to VCC**というボタンを押して、VRChat Creator Companionを開きます。<br>
リポジトリを加えましたら、導入したいプロジェクトのManage Packagesを開き、一覧に加わっているMeshHologramをインストールしてください。

### Package Manager - ***推奨***
Unityのタブメニューから、**Window -> Package Manager**を押してPackage Managerを開きます。<br>
Package Managerの左上にある**+**ボタンを押して、**Add package from git URL...**を押します。<br>
開かれた入力ダイアログに以下のリンクを張り付けて、**Add**を押して加えてください。<br>
```
https://github.com/r-delta-c/MeshHologram.git
```
**[Requirements | 環境要件]に前提パッケージが記載されていた場合は、先にそちらをインポートしてください。**

### .unitypackage
[リリースデータ](https://github.com/r-delta-c/MeshHologram/releases)から任意のバージョンを探して、Assets内の末尾が **.unitypackage**になっているデータをDLしてください。<br>
DLした.unitypackageは、起動したUnity上へ**ドラッグ&ドロップ**することでインポートできます。



## How to Use | 使い方
[ドキュメントサイト](https://meshhologram-docs.netlify.app/ "https://meshhologram-docs.netlify.app/")をご参照ください。


## License | ライセンス
このシェーダーはMIT Licenseによって提供されます。
[LICENSE.md](https://github.com/r-delta-c/MeshHologram/blob/main/LICENSE.md)の内容に則ってご利用ください。


## Article | 参照記事
コンテンツを作成するに当たって、以下の記事を多く参考致しました。
* [【Unity】ワイヤーフレームシェーダー](https://qiita.com/masamin/items/142b99f139635d19341a) / 有限会社リリテックラボ様<br>
  ワイヤーフレーム描写の基礎から、fwidth関数の活用まで、重要なことを多く学ばせてもらいました。