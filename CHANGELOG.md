# Change Log

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [0.1.0] 2025/09/03
### Added
- 新機能、`Orbit Wave`を追加。
    - Orbit Variance Zを刷新したものになります。
    - こちらの機能は現状***実験的***なものになっています。将来的に大きな変更が入る可能性があります。
- 新機能、`Spectrum(スペクトラム)`をフラグメント、カラー、ジオメトリ、Orbitに追加。
- ジオメトリの新機能、`Rotation(回転)`を追加。
- 簡易的なアンチエイリアス機能、`Activate AntiAliasing(アンチエイリアスを有効にする)`を追加。
- フラグメントの値を反転するプロパティ、`Fragment Value Inverse(フラグメントの値の反転)`を追加。
- ワイヤーフレームの線を手動で調整するためのトグル、`Manual Line Scaling(線のスケールの手動操作)`を追加。
- 新機能、`Orbit Rotation(Orbit 回転)`を追加。
    - これまでメッシュのOrbit(衛星軌道)への移動はジオメトリの値に依存しており、ジオメトリの他の機能との組み合わせて使うといった応用が難しい課題がありました。
    - 今回新たに参照先として設けることにより、Orbit制御がより自在にできるようになります。
- `Orbit Rotation(Orbit 回転)`に伴い、以下のプロパティが追加されました。
    - `Orbit Rotation Source(Orbit 回転の参照先)`
    - `Orbit Rotation Value(Orbit 回転の値)`
    - `Orbit Rotation Seed(Orbit 回転のシード値)`
- マテリアルの複数選択時の編集に対応しました。

### Fixed
- Directional Lightの処理で参照していたノーマルがワールド空間ではなくモデル空間だった不具合を修正。
- Pixelizationがモデルのスケールと連動しない不具合を修正。
- `着色の区切り`が`Side`の際、適切な色合いにならない問題の改善。
- ワイヤーフレームの描写サイズが、解像度の影響を受けてしまう問題の修正。
- `フラグメントの区切り`の設定によって、値の状態が異なる不具合を修正。

### Changed
- 以下のプロパティがキーワードから変数へ変更。
    - AudioLink VU `Band(帯域)`
    - ノイズ `Curve Type(カーブタイプ)`
    - これにより、アニメーションからの変更が可能になります。
- ジオメトリの機能、`Pull/Push`を`Scale(スケール)`、`Extrude(押し出し)`へリニューアル。
- モデルのスケールに応じてワイヤーフレームの線のサイズが調整されるように変更。
    - `Manual Line Scale(線のスケールの手動操作)`を有効にすると、`Line Scale(線の全体スケール)`が反映されるようになり、上記の挙動が無効になります。
- テクスチャは内部にてSampler2Dではなく、Texture2DとSamplerStateを使用するように変更。
    - パフォーマンスの改善が期待できます。
- `Geometry Messy/Orbit`を`Orbit`へリニューアル。
    - Orbitの遷移が、ジオメトリの値に依存していましたが、別途新たな参照先として`Orbit Source(Orbitの参照先)`を基準とするようになりました。
    - Orbitの回転位置は`Orbit Rotation Source(Orbit Rotationの参照先)`を基準にします。
    - Orbitはマテリアルインスペクター上のMainグループで分類されるようになりました。
- 専用のプロパティドロワーの実装により、より見やすいGUIへ改善。
- マテリアルインスペクターの処理の変更によりパフォーマンスを改善。
- `ノイズの参照先`の`Model_World`は将来的に仕様が変更されるか、削除される予定となりました。

- 以下のプロパティがリネームされました。既存のプロパティ設定やマテリアル上のデータが消失する可能性があります。(ローカライズ時の名前は割愛)
    - `_GeometryMessyToggle`
    - `_GeometryMessySource`
    - `_GeometryMessyValue`
    - `_GeometryMessyMaskControlTex`
    - `_GeometryMessyMaskControl`
    - `_GeometryMessySeed`
    - `_GeometryMessyOrbitRotation`
    - `_GeometryMessyOrbitPosition`
    - `_GeometryMessyReferenceTime`
    - `_GeometryMessyOrbitAudioLinkStrength`

### Removed
- 各ノイズ、GeometryMessyの`Reference Time`は削除されました。
- 以下のプロパティが不要になった、別のプロパティとの統合等により削除されました。(ローカライズ時の名前は割愛)
    - `_GeometryPushPullE`
    - `_GeometryPushPull`
    - `_GeometryPushPullBias`
    - `_GeometryMessyOrbitRotationForward`
    - `_GeometryMessyOrbitRotationRight`
    - `_GeometryMessyOrbitScaleY`
    - `_GeometryMessyOrbitScaleZ`

## [0.0.2] 2025/07/30
### Fixed
- `Geometry Pull/Push`の`Normal_Extrude`が、適切なノーマルを参照していない不具合を修正。
- `Geometry Partition Bias`が表示されていない不具合を修正。

## [0.0.1] 2025/07/21
### Changed
- MeshBoundsEditorのシェーダーパスを変更。

### Fixed
- マテリアルのインスペクターから、MeshHologramが選択できない不具合を修正。
    - MeshBoundsEditorで使用しているシェーダーのパスを変更することで対処。

[0.0.1]: https://github.com/r-delta-c/MeshHologram/compare/0.0.0...0.0.1

<!--
## [Unreleased]

[Unreleased]: https://github.com/r-delta-c/Day-and-Night-SkyboxShader/compare/0.0.0-exp.1...1.0.0

-->