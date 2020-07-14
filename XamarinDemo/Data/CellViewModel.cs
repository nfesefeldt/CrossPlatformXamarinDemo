using System.Collections.Generic;

namespace XamarinDemo.Data
{
    public class CellViewModel
    {
        public CellViewModel(string title, string subtitle, bool shouldShowDisclosureIndicator)
        {
            this.Title = title;
            this.Subtitle = subtitle;
            this.ShouldShowDisclosureIndicator = shouldShowDisclosureIndicator;
        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public bool ShouldShowDisclosureIndicator = false;

        public List<CellViewModel> ChildCells = new List<CellViewModel>();
    }
}
