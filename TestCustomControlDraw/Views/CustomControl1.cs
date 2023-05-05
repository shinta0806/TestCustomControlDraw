// ============================================================================
// 
// Win2D で楕円を描画するカスタムコントロール
// 
// ============================================================================

// ----------------------------------------------------------------------------
// 
// ----------------------------------------------------------------------------

using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TestCustomControlDraw.Views;

internal class CustomControl1 : Grid
{
    // ====================================================================
    // コンストラクター
    // ====================================================================

    /// <summary>
    /// メインコンストラクター
    /// </summary>
    public CustomControl1()
    {
        // イベント
        Loaded += CustomControl1Loaded;
        Unloaded += CustomControl1Unloaded;
    }

    // ====================================================================
    // private 変数
    // ====================================================================

    // Win2D キャンバス
    private CanvasControl? _canvasControl;

    // ====================================================================
    // private 関数
    // ====================================================================

    /// <summary>
    /// イベントハンドラー：描画が必要な時に呼ばれる
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void CanvasControlDraw(CanvasControl canvasControl, CanvasDrawEventArgs args)
    {
        args.DrawingSession.Clear(Colors.Black);
        Single x = (Single)ActualWidth / 2;
        Single y = (Single)ActualHeight / 2;
        args.DrawingSession.FillEllipse(x, y, x, y, Colors.Red);
    }

    /// <summary>
    /// イベントハンドラー
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void CustomControl1Loaded(Object sender, RoutedEventArgs args)
    {
        // キャンバス準備
        _canvasControl = new();
        _canvasControl.Draw += CanvasControlDraw;
        Children.Add(_canvasControl);
    }

    /// <summary>
    /// イベントハンドラー
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void CustomControl1Unloaded(Object sender, RoutedEventArgs args)
    {
        // キャンバス後片付け
        _canvasControl?.RemoveFromVisualTree();
        _canvasControl = null;
    }
}
