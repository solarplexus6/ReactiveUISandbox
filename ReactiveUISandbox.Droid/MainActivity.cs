using Android.App;
using Android.OS;
using Android.Widget;
using ReactiveUI;
using ReactiveUISandbox.Droid.Views;

namespace ReactiveUISandbox.Droid
{
    [Activity(Label = "ReactiveUISandbox.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ReactiveActivity<MainViewModel>
    {
        #region Properties

        public ListView TheListView { get; private set; }
        public TextView TheTextView { get; private set; }

        #endregion
        #region Overrides

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.WireUpControls();

            ViewModel = new MainViewModel();
            ViewModel.Init();
            // this.Bind(viewModel, x => x. , x => x.TheTextView.Text);
            this.OneWayBind(ViewModel, vm => vm.TheText, activity => activity.TheTextView.Text);
            var adapter = new ReactiveListAdapter<ItemViewModel>(ViewModel.Items, (model, viewGroup) =>
            {
                return new ListItemView(model, this, viewGroup);
            });
            TheListView.Adapter = adapter;
        }

        #endregion
    }
}