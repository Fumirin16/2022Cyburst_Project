# 「Cyburst -サイバースト-」
<p align="center">
<img src="image/ConceptArt.PNG" width="300">

# 作品概要
- 2022年度（2年次）に、チームで制作したパズルアクションゲーム「Cyburst」の公開用リポジトリです。
- ジャンル  
3Dスクロールアクションゲーム
- 開発期間  
2022/6/1～2023/1/10
- チーム構成（計8名）  
プランナー3名/プログラマー2名/デザイナー3名  
私はプログラマーとして参加しました。
- 開発環境  
Unity2021.3.9f1  
VisualStudio2022  
GitHub  
VisualStudioCode

# プレイ動画
<video controls src="image/作品実演動画（Cyburst）.mp4" title="Title"></video>
# 担当箇所
インゲーム
 - プレイヤー（移動、打つ、モーション）
 - 敵ドローン（弾発射を除く）
 - 障害物、（コーン、フェンス）
 - バット、バイクモーション
 - ステージ制御
 - UI（スコア、時間制限、ターゲット選択、バリア）
 - ゲームパッド、キーボード対応  
アウトゲーム
  - Scene遷移
  - UI（ボタン選択、ボタンと背景のモーション）
  - サウンド実装
# 担当ソースコード
E_Manager.cs  
BE_Manager.cs  
E_StoneScript.cs  
P_Manager.cs  
BatManager.cs  
StageManager.cs  
S_C_Menu.cs
S_C_SelectMenu.cs  
AnimationUI.cs  
U_GetScore.cs  
U_RuleChange.cs  
U_Score.cs  
U_TimeCounter.cs  
CloseWindow.cs