using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using LivetPractice.Views.Controls;

namespace LivetPractice.Views.Behaviors
{
    public class TextInputBehavior:Behavior<TextBoxBase>
    {
#region "入力モード"
        /// <summary>
        /// テキストボックスへの入力モード
        /// </summary>
        public enum InputModeType : int
        {
            None
            , On
            , Off
        }
        /// <summary>
        /// テキストの入力モードを表す値を取得もしくは設定します。
        /// </summary>
        [Category("拡張プロパティ")]
        [Description("テキストの入力モードを表す値を取得もしくは設定します。")]
        [DefaultValue(InputModeType.None)]
        public InputModeType InputMode
        {
            get { return GetInputMode(this); }
            set { SetInputMode(this,value); }
        }

        /// <summary>
        /// テキスト入力モードのGetter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static InputModeType GetInputMode(DependencyObject obj)
        {
            return (InputModeType)obj.GetValue(InputModeProperty);
        }

        /// <summary>
        /// テキスト入力モードのSetter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static void SetInputMode(DependencyObject obj, InputModeType value)
        {
            obj.SetValue(InputModeProperty, value);
        }

        /// <summary>
        /// テキスト入力モード添付プロパティ
        /// </summary>
        public static readonly DependencyProperty InputModeProperty =
            DependencyProperty.RegisterAttached("InputMode", typeof(InputModeType), typeof(TextBoxBase), new PropertyMetadata(InputModeType.None,OnInputModeChanged));

        private static void OnInputModeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ExTextBox textBox = obj as ExTextBox;
            if (textBox == null)
            {
                return;
            }
            SetImeState(textBox, (InputModeType)e.NewValue);
        }

        private static void SetImeState(DependencyObject target, InputModeType inputMode)
        {
            switch (inputMode)
            {
                case InputModeType.None:
                    InputMethod.SetPreferredImeState(target, InputMethodState.DoNotCare);
                    break;
                case InputModeType.On:
                    InputMethod.SetPreferredImeState(target, InputMethodState.On);
                    break;
                case InputModeType.Off:
                    InputMethod.SetPreferredImeState(target, InputMethodState.Off);
                    break;

            }
        }
#endregion
    }
}
