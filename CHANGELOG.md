# Change Log

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [0.2.0-exp.2] 2025/10/nn
- 以下の理由で実験的なバージョンを示す`exp.2`を付与しています。
    - 大規模な変更により、不具合が多く含まれている可能性があります。
    - パフォーマンス面で実験的な処理が含まれています。著しい問題を確認した場合は方針を切り替える可能性があります。
### Changed
- **処理構成の大幅な変更。**
    - 内部実装の処理共有化による簡潔な実装を目的としており、GUI上でも分かりやすくエリアを区切りました。
        - **Source(参照先)**
        <br>各機能の入力値として参照する値を指定します。
        - **AudioLink Source(AudioLinkの参照先)**
        <br>入力値へ加えるAuidoLinkの参照する値を指定します。これまでSource(参照先)等に割り当てられていたAudioLinkの機能はこちらに移動されました。
        - **Masks/Offset(マスク/オフセット)**
        <br>入力値に対してマスクやオフセットを与えるテクスチャを設定します。AudioLinkのマスクも含まれます。
        - **Modifiers(モディファイア)**
        <br>最終的な出力値をループ処理、イージング、加算、乗算などの処理を行います。これまでノイズで設定されていた機能はこちらに移動されました。

- **プロパティ、キーワードの大幅なリネーム。**
    - 適切な表現ではない、実態が読みにくいといった問題のあったプロパティ名、キーワード名を多く変更しました。これにより、殆どのプロパティとキーワードの互換性が消失しております。
    - 詳細は[変更されたプロパティ](ChangedProperties)、[変更されたキーワード](ChangedKeywords)からご確認ください。

- **多くのプロパティのキーワード制御の廃止。**
    - これまではキーワード制御により必要な処理の分別などを行ってきましたが、Unityの不具合によりキーワードを取り扱える上限が少ないことから、いくつかのキーワード制御を廃止しました。
    - プロパティに移行された機能はアニメーション等によるプロパティ変更により、瞬時に反映されるようになります。

### Fixed
- マスク/オフセットコントロール機能が正常に動作しなかった不具合の修正。
    - 同時に刷新されました。

### Removed
- いくつかのプロパティ、キーワードを削除。
    - 詳細は[変更されたプロパティ](ChangedProperties)、[変更されたキーワード](ChangedKeywords)からご確認ください。

### 変更されたプロパティ
[ChangedProperties]: ###変更されたプロパティ
<details>
    <summary><b>プロパティ一覧</b></summary>

|変更前|->|変更後|
|:--|---|:--|
|`_BillboardMode`|->|`_BillBoardEnable`|
|`_UseFwidth`|->|`_FwidthEnable`|
|`_ActivateDirectionalLightInfluence`|->|`_DirectionalLightInfluenceEnable`|
|`_ActivateAmbientInfluence`|->|`_AmbientInfluenceEnable`|
|`_ActivateLightVolumesInfluence`|->|`_LightVolumesInfluenceEnable`|
|`_PreviewMode`|->|`_PreviewEnable`|
|`_AntiAliasing`|->|`_AntiAliasingEnable`|
||||
|`_UseAudioLink`|->|`_AudioLinkEnable`|
|`_AudioLinkVUSmooth`|->|`_AudioLinkVUSmoothing`|
|`_AudioLinkChronoTensityScale`|->|`_AudioLinkChronoTensityDivisor`|
|`_AudioLinkChronoTensityType`|->|`_AudioLinkChronoTensityMode`|
||||
|`_TriangleComp`|->|`_FragmentTriangleCompression`|
|`_Fill`|->|`_FragmentFill`|
|`_LineWidth`|->|`_FragmentLineWidth`|
|`_LineGradientBias`|->|`_FragmentLineGradientBias`|
|`_ManualLineScaling`|->|`_FragmentManualLineScalingEnable`|
|`_LineScale`|->|`_FragmentLineScale`|
|`_LineFadeMode`|->|`_FragmentLineAnimationMode`|
|`_PartitionType`|->|`_FragmentPartitionMode`|
|`_FragmentInverse`|->|削除|
|`_FragmentValue`|->|`_FragmentFixedValue`|
||||
|`_ColoringValue`|->|`_ColoringFixedValue`|
|`_ColoringPartitionType`|->|`_ColoringPartitionMode`|
||||
|`_GeometryValue`|->|`_GeometryFixedValue`|
|`_GeometryScale`|->|`_GeometryScaleEnable`|
|`_GeometryScaleRange`|->|`_GeometryScaleBounds`|
|`_GeometryExtrude`|->|`_GeometryPushPullEnable`|
|`_GeometryExtrudeRange`|->|`_GeometryPushPullBounds`|
|`_GeometryRotation`|->|`_GeometryRotationEnable`|
|`_GeometryRotationInfluence`|->|`_GeometryRotationStrength`|
|`_GeometryRotationReverse`|->|`_GeometryRotationInvert`|
|`_GeometryRotationNoiseRepeat`|->|`_GeometryRotationNoiseRepeat`|
|`_GeometryPartitionBias`|->|`_GeometryPushPullPartitionBias`|
|`_PixelizationSpace`|->|`_GeometryPixelizationSpace`|
|`_Pixelization`|->|`_GeometryPixelization`|
||||
|`_ActivateOrbit`|->|`_OrbitEnable`|
|`_OrbitValue`|->|`_OrbitFixedValue`|
|`_OrbitPrimitiveThreshold`|->|`_OrbitPrimitiveRatio`|
|`_OrbitRotation`|->|`_OrbitRotationAngle`|
|`_OrbitRotationTimeMultiplier`|->|`_OrbitRotationSpeed`|
|`_OrbitRotationVariance`|->|`_OrbitRotationSpread`|
|`_OrbitWaveTimeMultiplier`|->|`_OrbitWaveSpeed`|
|`_OrbitRotationRefAudioLink`|->|`_OrbitRotationOffsetAudioLinkSource`|
|`_OrbitRotationAudioLinkStrength`|->|刷新|
||||
|`_OrbitWaveRefAudioLink`|->|`_OrbitWaveAudioLinkSource`|
|`_OrbitWaveAudioLinkStrength`|->|刷新|
|`_OrbitWaveAudioLinkSpectrumType`|->|`_OrbitWaveAudioLinkSpectrumMode`|
|`_OrbitWaveAudioLinkSpectrumRange`|->|`_OrbitWaveAudioLinkSpectrumBounds`|
|`_OrbitWaveAudioLinkSpectrumFrequencyOffset`|->|削除|
||||
|`_AudioLinkMaskControlTex`|->|削除|
|`_AudioLinkMaskControl`|->|削除|
|`_FragmentMaskControlTex`|->|`_FragmentMaskMap`|
|`_FragmentMaskControl`|->|`_FragmentMaskMapStrength`|
|`_ColoringMaskControlTex`|->|`_ColoringMaskMap`|
|`_ColoringMaskControl`|->|`_ColoringMaskMapStrength`|
|`_GeometryMaskControlTex`|->|`_GeometryMaskMap`|
|`_GeometryMaskControl`|->|`_GeometryMaskMapStrength`|
|`_OrbitMaskControlTex`|->|`_OrbitMaskMap`|
|`_OrbitMaskControl`|->|`_OrbitMaskMapStrength`|
|`_Noise1stOffsetControlTex`|->|削除|
|`_Noise1stOffsetControl`|->|削除|
|`_Noise2ndOffsetControlTex`|->|削除|
|`_Noise2ndOffsetControl`|->|削除|
|`_Noise3rdOffsetControlTex`|->|削除|
|`_Noise3rdOffsetControl`|->|削除|
||||
|`_FragmentAudioLinkNoiseSpectrum`|->|削除|
|`_FragmentAudioLinkStrength`|->|刷新|
|`_FragmentAudioLinkSpectrumType`|->|削除|
|`_FragmentAudioLinkSpectrumRange`|->|削除|
|`_ColoringAudioLinkNoiseSpectrum`|->|削除|
|`_ColoringAudioLinkStrength`|->|刷新|
|`_ColoringAudioLinkSpectrumType`|->|削除|
|`_ColoringAudioLinkSpectrumRange`|->|削除|
|`_GeometryAudioLinkNoiseSpectrum`|->|削除|
|`_GeometryAudioLinkStrength`|->|刷新|
|`_GeometryAudioLinkSpectrumType`|->|削除|
|`_GeometryAudioLinkSpectrumRange`|->|削除|
|* `_Noise***~`は各ノイズ枠に当てはまります。|||
|`_Noise***ValueCurve`|->|刷新|
|`_Noise***CurveType`|->|刷新|
|`_Noise***ThresholdMul`|->|刷新|
|`_Noise***ThresholdAdd`|->|刷新|
|`_Noise***TimeMulti`|->|`_Noise***TimeSpeed`|
|`_Noise***PhaseScale`|->|`_Noise***ValueScale`|
|`_Noise***PhaseRefAudioLink`|->|削除|
</details>

<br>

### 変更されたキーワード
[ChangedKeywords]: ###変更されたキーワード
<details>
    <summary><b>キーワード一覧</b></summary>

|変更前|->|変更後|
|:--|---|:--|
|_PREVIEW_MODE|->|_PREVIEW_ENABLE|
|_BILLBOARD_MODE|->|_BILLBOARD_ENABLE|
|_USE_AUDIOLINK|->|_AUDIOLINK_ENABLE|
|_USE_FWIDTH|->|_FWIDTH_ENABLE|
|_ANTI_ALIASING|->|_ANTI_ALIASING_ENABLE|
|_ACTIVATE_DIRECTIONALLIGHT_INFLUENCE|->|_DIRECTIONALLIGHT_INFLUENCE_ENABLE|
|_ACTIVATE_AMBIENT_INFLUENCE|->|_AMBIENT_INFLUENCE_ENABLE|
|_ACTIVATE_LIGHTVOLUMES|->|_LIGHTVOLUMES_ENABLE|
||||
|_LINEFADEMODE_NORMAL|->|_FRAGMENTLINEANIMATIONMODE_NORMAL|
|_LINEFADEMODE_INSTANT|->|_FRAGMENTLINEANIMATIONMODE_INSTANT|
|_LINEFADEMODE_OUTWIDE|->|_FRAGMENTLINEANIMATIONMODE_OUTWIDE|
|_LINEFADEMODE_OUTTHIN|->|_FRAGMENTLINEANIMATIONMODE_OUTTHIN|
|_LINEFADEMODE_BREAK|->|_FRAGMENTLINEANIMATIONMODE_BREAK|
|_LINEFADEMODE_VANISHING|->|_FRAGMENTLINEANIMATIONMODE_VANISHING|
|_LINEFADEMODE_ZOOMIN|->|_FRAGMENTLINEANIMATIONMODE_ZOOMIN|
|_LINEFADEMODE_ZOOMOUT|->|_FRAGMENTLINEANIMATIONMODE_ZOOMOUT|
|_LINEFADEMODE_POWERZOOMIN|->|_FRAGMENTLINEANIMATIONMODE_POWERZOOMIN|
|_LINEFADEMODE_COLLAPSE|->|_FRAGMENTLINEANIMATIONMODE_COLLAPSE|
|_LINEFADEMODE_JOIN1|->|_FRAGMENTLINEANIMATIONMODE_JOIN1|
|_LINEFADEMODE_JOIN2|->|_FRAGMENTLINEANIMATIONMODE_JOIN2|
|_LINEFADEMODE_JOIN3|->|_FRAGMENTLINEANIMATIONMODE_JOIN3|
|_MANUAL_LINE_SCALING|->|_MANUAL_LINE_SCALING_ENABLE|
||||
|_FRAGMENTSOURCE_VALUE|->|`_FragmentSource`に機能を移行|
|_FRAGMENTSOURCE_NOISE1ST|->|`_FragmentSource`に機能を移行|
|_FRAGMENTSOURCE_NOISE2ND|->|`_FragmentSource`に機能を移行|
|_FRAGMENTSOURCE_NOISE3RD|->|`_FragmentSource`に機能を移行|
|_FRAGMENTSOURCE_AUDIOLINK_VU|->|`_FragmentAudioLinkSource`に機能を移行|
|_FRAGMENTSOURCE_AUDIOLINK_CHRONOTENSITY|->|`_FragmentAudioLinkSource`に機能を移行|
|_PARTITIONTYPE_VERTEX|->|_FRAGMENTPARTITIONMODE_VERTEX|
|_PARTITIONTYPE_SIDE|->|_FRAGMENTPARTITIONMODE_SIDE|
|_PARTITIONTYPE_MESH|->|_FRAGMENTPARTITIONMODE_MESH|
||||
|_COLORINGSOURCE_VALUE|->|`_ColoringSource`に機能を移行|
|_COLORINGSOURCE_NOISE1ST|->|`_ColoringSource`に機能を移行|
|_COLORINGSOURCE_NOISE2ND|->|`_ColoringSource`に機能を移行|
|_COLORINGSOURCE_NOISE3RD|->|`_ColoringSource`に機能を移行|
|_COLORINGSOURCE_AUDIOLINK_VU|->|`_ColoringAudioLinkSource`に機能を移行|
|_COLORINGSOURCE_AUDIOLINK_CHRONOTENSITY|->|`_ColoringAudioLinkSource`に機能を移行|
|_COLORINGPARTITIONTYPE_VERTEX|->|_COLORINGPARTITIONMODE_VERTEX|
|_COLORINGPARTITIONTYPE_SIDE|->|_COLORINGPARTITIONMODE_SIDE|
|_COLORINGPARTITIONTYPE_MESH|->|_COLORINGPARTITIONMODE_MESH|
||||
|_GEOMETRYSOURCE_VALUE|->|`_GeometrySource`に機能を移行|
|_GEOMETRYSOURCE_NOISE1ST|->|`_GeometrySource`に機能を移行|
|_GEOMETRYSOURCE_NOISE2ND|->|`_GeometrySource`に機能を移行|
|_GEOMETRYSOURCE_NOISE3RD|->|`_GeometrySource`に機能を移行|
|_GEOMETRYSOURCE_AUDIOLINK_VU|->|`_GeometryAudioLinkSource`に機能を移行|
|_GEOMETRYSOURCE_AUDIOLINK_CHRONOTENSITY|->|`_GeometryAudioLinkSource`に機能を移行|
|_GEOMETRY_SCALE|->|_GEOMETRY_SCALE_ENABLE|
|_GEOMETRY_EXTRUDE|->|_GEOMETRY_PUSHPULL_ENABLE|
|_GEOMETRY_ROTATION|->|_GEOMETRY_ROTATION_ENABLE|
||||
|_ACTIVATE_ORBIT|->|_ORBIT_ENABLE|
|_ORBITSOURCE_VALUE|->|`_OrbitSource`に機能を移行|
|_ORBITSOURCE_PRIMITIVE|->|`_OrbitSource`に機能を移行|
|_ORBITSOURCE_NOISE1ST|->|`_OrbitSource`に機能を移行|
|_ORBITSOURCE_NOISE2ND|->|`_OrbitSource`に機能を移行|
|_ORBITSOURCE_NOISE3RD|->|`_OrbitSource`に機能を移行|
|_ORBITROTATIONSOURCE_VALUE|->|`_OrbitRotationSource`に機能を移行|
|_ORBITROTATIONSOURCE_PRIMITIVE|->|`_OrbitRotationSource`に機能を移行|
|_ORBITROTATIONSOURCE_NOISE1ST|->|`_OrbitRotationSource`に機能を移行|
|_ORBITROTATIONSOURCE_NOISE2ND|->|`_OrbitRotationSource`に機能を移行|
|_ORBITROTATIONSOURCE_NOISE3RD|->|`_OrbitRotationSource`に機能を移行|
||||
|_FRAGMENT_AUDIOLINK_NOISE_SPECTRUM|->|削除|
|_COLORING_AUDIOLINK_NOISE_SPECTRUM|->|削除|
|_GEOMETRY_AUDIOLINK_NOISE_SPECTRUM|->|削除|
||||
|_ORBITROTATIONREFAUDIOLINK_DISABLE|->|`_OrbitRotationOffsetAudioLinkSource`に機能を移行|
|_ORBITROTATIONREFAUDIOLINK_VU|->|`_OrbitRotationOffsetAudioLinkSource`に機能を移行|
|_ORBITROTATIONREFAUDIOLINK_CHRONOTENSITY|->|`_OrbitRotationOffsetAudioLinkSource`に機能を移行|
|_ORBITWAVEREFAUDIOLINK_DISABLE|->|`_OrbitWaveAudioLinkSource`に機能を移行|
|_ORBITWAVEREFAUDIOLINK_VU|->|`_OrbitWaveAudioLinkSource`に機能を移行|
|_ORBITWAVEREFAUDIOLINK_SPECTRUM|->|`_OrbitWaveAudioLinkSource`に機能を移行|
||||
|_NOISE1STPHASEREFAUDIOLINK_DISABLE|->|削除|
|_NOISE1STPHASEREFAUDIOLINK_VU|->|削除|
|_NOISE1STPHASEREFAUDIOLINK_CHRONOTENSITY|->|削除|
|_NOISE2NDPHASEREFAUDIOLINK_DISABLE|->|削除|
|_NOISE2NDPHASEREFAUDIOLINK_VU|->|削除|
|_NOISE2NDPHASEREFAUDIOLINK_CHRONOTENSITY|->|削除|
|_NOISE3RDPHASEREFAUDIOLINK_DISABLE|->|削除|
|_NOISE3RDPHASEREFAUDIOLINK_VU|->|削除|
|_NOISE3RDPHASEREFAUDIOLINK_CHRONOTENSITY|->|削除|
</details>

## [0.1.5] 2025/09/19
### Changed
- `Orbit Wave`のプロパティが持つ要素の変更。
    - `Orbit Wave`に関連する以下のプロパティが対象となります。
        - `_OrbitWaveStrength`
        - `_OrbitWaveFrequency`
        - `_OrbitWavePhase`
        - `_OrbitWaveTimeMultiplier`
    - この変更は、プロパティが持つ機能と、実際に割り当てられるベクトルの要素(x,y,z,w)が一致しないことによる混乱を回避することを目的としています。
    - `YZ(x),X(y)` -> `X(x),YZ(y)`
    - またインスペクター上の表示順も`YZ,X`から`X,YZ`へ変更しました。

### Fixed
- `Orbit Wave YZ`の描写がおかしい問題を修正。

## [0.1.4] 2025/09/18
### Changed
- `Orbit Scale(Orbit スケール)`のプロパティが持つ要素の変更。
    - この変更は、プロパティが持つ機能と、実際に割り当てられるベクトルの要素(x,y,z,w)が一致しないことによる混乱を回避することを目的としています。
    - `Y(x),Z(y),Scale(z)` -> `Y(y),Z(z),Scale(w)`

## [0.1.3] 2025/09/15
### Added
- `Orbit Wave`の`Spectrum`のプロパティに`Spectrum Frequency Offset(スペクトラムの周波域オフセット)`を追加。

### Changed
- `Vertex Pixelization(頂点のモザイク化)`の`Scale(スケール)`のラベル表記を`All`へ変更。
- プロパティのデフォルト値の変更。
- アンチエイリアスの描写を改善。

### Fixed
- `Orbit Source(Orbitの参照先)`でノイズを選択していた際に誤った値を参照している不具合を修正。

### Removed
- `Orbit Rotation Value(Orbit 回転の値)`を削除。

## [0.1.2] 2025/09/07
### Fixed
- `Orbit`のスケーリング計算が誤っていた不具合を修正。

## [0.1.1] 2025/09/04
### Changed
- `Orbit Wave YZ`の表現が想定されていたものに変更。
    - 旧: 回転位置に応じて更に回転が加わるような処理になっていました。イメージとしては丸みのあるデコボコができており、花のように見えます。
    - 新: `Orbit Wave X`と同じ波のような形状になりました。
- `ノイズの参照先`の`Model_World`は現状維持の方針を取ることになりました。

### Fixed
- `Orbit`が、`Orbit Rotation`、トランスフォームの回転等に対応する処理が正しく行われていない問題を修正。
- `Orbit Source`の`Primitive`にて、`_OrbitPrimitiveThreshold`を`0`にしてもOrbitになり切らない不具合を修正。

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

- 以下のプロパティがリネームされました。既存のプロパティ設定やマテリアル上のデータが消失する可能性があります。(ラベル表記は割愛。)
    - `_GeometryMessyToggle`
    - `_GeometryMessySource`
    - `_GeometryMessyValue`
    - `_GeometryMessyMaskMap`
    - `_GeometryMessyMaskMapStrength`
    - `_GeometryMessySeed`
    - `_GeometryMessyOrbitRotation`
    - `_GeometryMessyOrbitPosition`
    - `_GeometryMessyReferenceTime`
    - `_GeometryMessyOrbitAudioLinkStrength`

### Removed
- 各ノイズ、GeometryMessyの`Reference Time`は削除されました。
- 以下のプロパティが不要になった、別のプロパティとの統合等により削除されました。(ラベル表記は割愛。)
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

[0.2.0-exp.1]: https://github.com/r-delta-c/MeshHologram/compare/0.1.5...0.2.0-exp.1
[0.1.5]: https://github.com/r-delta-c/MeshHologram/compare/0.1.4...0.1.5
[0.1.4]: https://github.com/r-delta-c/MeshHologram/compare/0.1.3...0.1.4
[0.1.3]: https://github.com/r-delta-c/MeshHologram/compare/0.1.2...0.1.3
[0.1.2]: https://github.com/r-delta-c/MeshHologram/compare/0.1.1...0.1.2
[0.1.1]: https://github.com/r-delta-c/MeshHologram/compare/0.1.0...0.1.1
[0.1.0]: https://github.com/r-delta-c/MeshHologram/compare/0.0.2...0.1.0
[0.0.2]: https://github.com/r-delta-c/MeshHologram/compare/0.0.1...0.0.2
[0.0.1]: https://github.com/r-delta-c/MeshHologram/compare/0.0.0...0.0.1

<!--
## [Unreleased]

[Unreleased]: https://github.com/r-delta-c/Day-and-Night-SkyboxShader/compare/0.0.0-exp.1...1.0.0

-->