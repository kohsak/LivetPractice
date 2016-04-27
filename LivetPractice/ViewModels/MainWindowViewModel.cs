using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using LivetPractice.Models;

namespace LivetPractice.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */

        #region InputType変更通知プロパティ
        private LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType _InputType1;
        public LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType InputType1
        {
            get
            { return _InputType1; }
            set
            { 
                if (_InputType1 == value)
                    return;
                _InputType1 = value;
                RaisePropertyChanged(nameof(InputType1));
            }
        }
        #endregion

        #region InputType変更通知プロパティ
        private LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType _InputType2;
        public LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType InputType2
        {
            get
            { return _InputType2; }
            set
            {
                if (_InputType2 == value)
                    return;
                _InputType2 = value;
                RaisePropertyChanged(nameof(InputType2));
            }
        }
        #endregion

        #region Time変更通知プロパティ
        private string _time;

        public string Time
        {
            get
            { return _time; }
            set
            { 
                if (_time == value)
                    return;
                _time = value;
                RaisePropertyChanged("Time");
            }
        }
        #endregion

        #region Name変更通知プロパティ
        private string _Name = "名前を入力してください。";

        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }
        #endregion

        public void Initialize()
        {
            this.Time = DateTime.Now.ToString();
            this.InputType1 = LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType.On;
            this.InputType2 = LivetPractice.Views.Behaviors.TextInputBehavior.InputModeType.Off;
        }
    }
}
