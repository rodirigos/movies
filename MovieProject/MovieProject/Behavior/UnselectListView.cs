using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MovieProject.Behavior
{
    public class UnselectListView: Behavior<ListView>
    {
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemSelected += Bindable_ItemSelected;
        }

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listview = (ListView)sender;
            listview.SelectedItem = null;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= Bindable_ItemSelected;

            base.OnDetachingFrom(bindable);
        }
    }
}
