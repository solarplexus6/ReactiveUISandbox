using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace ReactiveUISandbox.Droid
{
    public class MainViewModel : ReactiveObject
    {
        #region Private fields

        private string _theText = "asd";

        #endregion
        #region Properties

        public IReadOnlyReactiveList<ItemViewModel> Items { get; set; }

        public string TheText
        {
            get { return _theText; }
            set { this.RaiseAndSetIfChanged(ref _theText, value); }
        }

        #endregion
        #region Public methods

        public void Init()
        {
            var items = new ReactiveList<ItemViewModel>();
            Items = items;

            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ =>
                {
                    TheText = Guid.NewGuid().ToString();
                    items.Add(new ItemViewModel {Text = TheText});
                });
        }

        #endregion
    }
}