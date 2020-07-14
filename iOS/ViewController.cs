using System;
using System.Collections.Generic;
using UIKit;
using XamarinDemo.Data;

namespace XamarinDemo.iOS
{
    public partial class RootViewController : UITableViewController, ResponderInterface
    {
        NetworkingHelper networkingHelper = new NetworkingHelper();

        public RootViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            FetchData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private async void FetchData()
        {
            var tableItems = await networkingHelper.FetchData();
            PopulateUI(tableItems);
        }

        private void PopulateUI(List<CellViewModel> tableItems)
        {
            var tableView = new UITableView(View.Frame);
            tableView.Source = new TableViewSource(tableItems, this);
            Add(tableView);
        }

        public void ShowChildTableViewController(string parent)
        {
            ChildTableViewController childController = new ChildTableViewController(networkingHelper, parent, "");
            ShowViewController(childController, this);
        }
    }
}
