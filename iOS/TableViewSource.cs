using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using XamarinDemo.Data;

namespace XamarinDemo.iOS
{
    public class TableViewSource : UITableViewSource
    {
        string cellIdentifier = "tableCell";
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
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            CellViewModel item = tableItems[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
            }

            cell.TextLabel.Text = item.Title;
            cell.DetailTextLabel.Text = item.Subtitle;
            cell.UserInteractionEnabled = false;

            if (item.ShouldShowDisclosureIndicator == true)
            {
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                cell.UserInteractionEnabled = true;
            }

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            responder.ShowChildTableViewController(tableItems[indexPath.Row].Title);
        }
    }
}
