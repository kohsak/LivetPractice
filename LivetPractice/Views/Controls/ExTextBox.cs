using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace LivetPractice.Views.Controls
{
    public class ExTextBox:TextBox
    {

        /// <summary>
        /// フォーカスを受け取った時にSelectAllするかどうかを表す値を取得もしくは設定します。
        /// </summary>
        [Category("拡張プロパティ")]
        [Description("フォーカスを受け取った時にSelectAllするかどうかを表す値を取得もしくは設定します。")]
        [DefaultValue(true)]
        public bool DoSelectAllOnGotFocus { get; set; } = true;

        /// <summary>
        /// スタティックコンストラクタ
        /// </summary>
        static ExTextBox()
        {
            //依存関係プロパティのメタデータのオーバーライド
            //IsReadOnlyプロパティが変更された時の動作
            IsReadOnlyProperty.OverrideMetadata(
                typeof(ExTextBox)
                , new FrameworkPropertyMetadata(
                    false
                    , (sender, e) =>
                    {
                        ExTextBox textBox = sender as ExTextBox;
                        if (textBox == null)
                        {
                            return;
                        }
                        MessageBox.Show(textBox.IsReadOnly.ToString());
                    }));
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            this.Background = (SolidColorBrush)this.FindResource("FocusedBackground");
            if (this.DoSelectAllOnGotFocus)
            {
                this.SelectAll();
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            this.Background = (SolidColorBrush)this.FindResource("DefaultBackground");
        }
    }
}
