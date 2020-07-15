using System;
using Foundation;
using System.Collections.Generic;
using UIKit;
using XamarinDemo.Data;

namespace XamarinDemo.iOS
{
	public partial class Child2ViewController : UIViewController, ResponderInterface
	{
		public Child2ViewController (IntPtr handle) : base (handle)
		{
		}

        public string parent { get; set; }
        public string clientType { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = parent;
            FetchTableData(parent);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private void FetchTableData(string parent)
        {
            if (parent.Equals("Web") || parent.Equals("Android") || parent.Equals("Ios"))
            {
                clientType = parent;
            }

            List<CellViewModel> tableItems = NetworkingHelper.Instance.FetchChildTableViewData(parent, clientType);
            PopulateUI(tableItems);
        }

        private void PopulateUI(List<CellViewModel> tableItems)
        {
            var tableView = this.TableView;
            tableView.Source = new TableViewSource(tableItems, this);
        }

        public void ShowChildTableViewController(string parent)
        {
            if (parent.Equals("Web") || parent.Equals("Android") || parent.Equals("Ios"))
            {
                clientType = parent;
            }

            var sb = UIStoryboard.FromName("ChildTableViewController", null);
            var vc = sb.InstantiateViewController("Child2ViewController") as Child2ViewController;
            vc.parent = parent;
            vc.clientType = clientType;

            ShowViewController(vc, this);
        }
    }
}
