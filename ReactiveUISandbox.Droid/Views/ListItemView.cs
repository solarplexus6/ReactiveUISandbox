using Android.Content;
using Android.Views;
using Android.Widget;
using ReactiveUI;

namespace ReactiveUISandbox.Droid.Views
{
    public class ListItemView : ReactiveViewHost<ItemViewModel>
    {
        #region Properties

        public TextView ItemTextView { get; private set; }

        #endregion
        #region Ctors

        public ListItemView(ItemViewModel viewModel, Context ctx, ViewGroup parent) :
            base(ctx, Resource.Layout.item, parent)
        {
            ViewModel = viewModel;
            this.OneWayBind(ViewModel, vm => vm.Text, v => v.ItemTextView.Text);
        }

        #endregion
    }
}