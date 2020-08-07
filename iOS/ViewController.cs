using System;
using System.Collections.Generic;
using UIKit;
using XamarinDemo.Data;

namespace XamarinDemo.iOS
{
    public partial class RootViewController : UITableViewController, ResponderInterface
    {
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
            var tableItems = await NetworkingHelper.Instance.FetchData();
            PopulateUI(tableItems);
        }

        private void PopulateUI(List<CellViewModel> tableItems)
        {
            var tableView = new UITableView(View.Frame);
            tableView.RegisterNibForCellReuse(NewCustomTableViewCell.Nib, "NewCustomTableViewCell");
            tableView.Source = new TableViewSource(tableItems, this);
            Add(tableView);
        }

        public void ShowChildTableViewController(string parent)
        {
            var sb = UIStoryboard.FromName("ChildTableViewController", null);
            var vc = sb.InstantiateViewController("Child2ViewController") as Child2ViewController;
            vc.parent = parent;
            vc.clientType = "";

            ShowViewController(vc, this);
        }
    }
}
