using System.Collections.Generic;
using UIKit;
using XamarinDemo.Data;
using XamarinDemo.Models;

namespace XamarinDemo.iOS
{
    public class ChildTableViewController : UITableViewController, ResponderInterface
    {
        NetworkingHelper networkingHelper;

        string parent;
        string clientType;

        public ChildTableViewController(NetworkingHelper networkingHelper, string parent, string clientType)
        {
            this.networkingHelper = networkingHelper;
            this.parent = parent;
            this.clientType = clientType;
        }

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
            List<CellViewModel> tableItems;

            // TODO: Think of a better way to do this, enum/switch? string resource?
            if (parent.Equals("LoginModes"))
            {
                tableItems = networkingHelper.MapLoginModesData();
            }
            else if (parent.Equals("Clients"))
            {
                tableItems = networkingHelper.MapClientTableViewData();
            }
            else if (parent.Equals("Web") || parent.Equals("Android") || parent.Equals("Ios"))
            {
                tableItems = networkingHelper.MapClientChildTableViewData(parent);
            }
            else if (parent.Equals("FeatureFlags"))
            {
                tableItems = networkingHelper.MapFeatureFlagsTableViewData(clientType);
            }
            else if (parent.Equals("ClientActions"))
            {
                tableItems = networkingHelper.MapClientActionsTableViewData(clientType);
            }
            else
            {
                tableItems = new List<CellViewModel>();
            }

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

            ChildTableViewController childController = new ChildTableViewController(networkingHelper, parent, clientType);
            ShowViewController(childController, this);
        }
    }
}
