using System;
using Airbnb.Lottie;
using Foundation;
using XamarinDemo.Attributes;
using UIKit;

namespace XamarinDemo.iOS
{
    public partial class NewCustomTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("NewCustomTableViewCell");
        public static readonly UINib Nib;

        [Font(Font = FontEnum.BOLD, Color = ColorEnum.BLACK)]
        UILabel TitleLabelPass => this.TitleLabel;

        static NewCustomTableViewCell()
        {
            Nib = UINib.FromName("NewCustomTableViewCell", NSBundle.MainBundle);
        }

        protected NewCustomTableViewCell(IntPtr handle) : base(handle)
        {
        }

        public void UpdateCell(string title, string subtitle, bool shouldShowLottie)
        {
            FontUtil.ApplyFontAttribute(this);
            this.TitleLabel.Text = title;
            this.SubtitleLabel.Text = subtitle;

            if (shouldShowLottie)
            {
                LOTAnimationView animation = LOTAnimationView.AnimationNamed("RightArrow");
                animation.Frame = this.ImageView.Bounds;
                animation.LoopAnimation = true;
                this.ImageView.AddSubview(animation);
                animation.Play();
            } 
        }
    }
}
