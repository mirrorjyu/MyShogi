﻿using System.Windows.Forms;
using MyShogi.App;

namespace MyShogi.View.Win2D.Setting
{
    public partial class DisplaySettingDialog : Form
    {
        public DisplaySettingDialog()
        {
            InitializeComponent();

            InitViewModel();

            FontUtility.ReplaceFont(this, TheApp.app.Config.FontManager.SettingDialog);
        }

        private void InitViewModel()
        {
            var config = TheApp.app.Config;

            // RichSelectorに丸投げできるので、ここではBindの設定をするだけで良い。

            // -- 「盤面」のタブ

            // 段・筋の表示
            richSelector1.Bind(config, "BoardNumberImageVersion");

            // 盤面画像
            richSelector4.ViewModel.SelectionOffset = 1;
            richSelector4.Bind(config, "BoardImageVersion");

            // 盤の色味
            richSelector22.Bind(config, "BoardImageColorVersion");

            // 畳画像
            richSelector5.ViewModel.SelectionOffset = 1;
            richSelector5.Bind(config, "TatamiImageVersion");

            // 畳の色味
            richSelector23.Bind(config, "TatamiImageColorVersion");

            // -- 「駒」のタブ

            // 駒画像
            richSelector6.ViewModel.SelectionOffset = 1;
            richSelector6.Bind(config, "PieceImageVersion");

            // 成駒の色
            richSelector21.Bind(config, "PieceImageColorVersion");

            // 成駒の色
            richSelector7.Bind(config, "PromotePieceColorType");

            // 移動方角マーカー
            richSelector8.Bind(config, "PieceAttackImageVersion");

            // 駒を掴む表現
            richSelector18.Bind(config, "PickedMoveDisplayStyle");

            // -- 「升」のタブ

            // 最終手の移動元の升
            richSelector9.Bind(config, "LastMoveFromColorType");

            // 最終手の移動先の升
            richSelector10.Bind(config, "LastMoveToColorType");

            // 駒を掴んだ時の移動元の升
            richSelector11.Bind(config, "PickedMoveFromColorType");

            // 駒を掴んだ時の移動候補の升
            richSelector12.Bind(config, "PickedMoveToColorType");

            // -- 「操作」のタブ

            richSelector19.Bind(config, "EnableMouseDrag");

            // -- 「手番」のタブ

            // 駒を掴んだ時の移動候補の升
            richSelector13.Bind(config, "TurnDisplay");

            // 対局者名の先頭の手番記号
            richSelector14.Bind(config, "DisplayNameTurnVersion");

            // -- 「棋譜」のタブ

            // 棋譜ウインドウの棋譜の記法
            richSelector2.ViewModel.WarningRestart = true;
            richSelector2.Bind(config, "KifuWindowKifuVersion");

            // 検討ウインドウの棋譜の記法
            richSelector3.ViewModel.WarningRestart = true;
            richSelector3.Bind(config, "ConsiderationWindowKifuVersion");

            // -- 「エフェクト」のタブ

            // 対局開始・終了エフェクト
            richSelector16.Bind(config, "EnableGameGreetingEffect");

            // 振り駒のエフェクト
            richSelector17.Bind(config, "EnablePieceTossEffect");

            // -- 「評価値」のタブ

            // 後手番のCPUの評価値をどちらから見た値にするか
            richSelector15.ViewModel.SelectionTypeIsBool = true;
            richSelector15.Bind(config, "NegateEvalWhenWhite");

            // 形勢を評価値のところに表示するか
            richSelector20.Bind(config, "DisplayEvalJudgement");

            // -- 「フォント」のタブ

            var font = TheApp.app.Config.FontManager;
            fontSelectionConrol1.Bind(font.MenuStrip);
            fontSelectionConrol2.Bind(font.MainToolStrip);
            fontSelectionConrol3.Bind(font.SubToolStrip);
            fontSelectionConrol4.Bind(font.MainWindow);
            fontSelectionConrol5.Bind(font.SettingDialog);
            fontSelectionConrol6.Bind(font.MessageDialog);
            fontSelectionConrol7.Bind(font.KifuWindow);
            fontSelectionConrol8.Bind(font.ConsiderationWindow);
            fontSelectionConrol9.Bind(font.ToolTip);
            fontSelectionConrol10.Bind(font.DebugWindow);

        }

    }
}
