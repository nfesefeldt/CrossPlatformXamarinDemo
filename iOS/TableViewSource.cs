using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using XamarinDemo.Data;

namespace XamarinDemo.iOS
{
    public class TableViewSource : UITableViewSource
    {
        string cellIdentifier = "NewCustomTableViewCell";
        List<CellViewModel> tableItems;

        ResponderInterface responder;

        public TableViewSource(List<CellViewModel> items, ResponderInterface responder)
        {
            this.tableItems = items;
            this.responder = responder;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var shouldShowLottie = false;
            var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath) as NewCustomTableViewCell;
            CellViewModel item = tableItems[indexPath.Row];

            cell.UserInteractionEnabled = false;

            if (item.ShouldShowDisclosureIndicator == true)
            {
                shouldShowLottie = true;
                cell.UserInteractionEnabled = true;
            }

            cell.UpdateCell(item.Title, item.Subtitle, shouldShowLottie);

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            responder.ShowChildTableViewController(tableItems[indexPath.Row].Title);
        }
    }
}
