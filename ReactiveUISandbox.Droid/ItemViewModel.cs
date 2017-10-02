using ReactiveUI;

namespace ReactiveUISandbox.Droid
{
    public class ItemViewModel : ReactiveObject
    {
        #region Private fields

        private string _text;

        #endregion
        #region Properties

        public string Text
        {
            get { return _text; }
            set { this.RaiseAndSetIfChanged(ref _text, value); }
        }

        #endregion
    }
}