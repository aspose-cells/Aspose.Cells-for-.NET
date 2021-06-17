using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.Cells.Common.Models
{
    public class OtherFeaturesModel
    {
        public string Title { get; set; }
        public string TitleSub { get; set; }
        public string UlClass { get; set; }

        public OtherFeaturesItem[] Items { get; set; }

        public ViewModel Parent;
        private FlexibleResources Resources => Parent.Resources;
        public string AppName => Parent.AppName;
        public string Product => Parent.Product;
        public string ProductAppName => Parent.ProductAppName;
        public string Extension => Parent.Extension;

        public OtherFeaturesModel(ViewModel parent)
        {
            Parent = parent;

            var appUrl = $"/{Product}/{AppName.ToLower()}";

            var items = new GeneratedPage(appUrl, true).GetByAppUrl().Select(x => new OtherFeaturesItem(x)).ToArray();

            var dic = new Dictionary<string, OtherFeaturesItem>();
            foreach (var item in items)
            {
                if (!dic.ContainsKey(item.Title))
                    dic.Add(item.Title, item);
                else if (item.Url.Contains(Parent.Product))
                {
                    dic.Remove(item.Title);
                    dic.Add(item.Title, item);
                }
            }

            var title = Resources[ProductAppName + "OtherFeaturesTitle"];
            var titleSub = string.Format(Resources[ProductAppName + "OtherFeaturesTitleSub"],
                Parent.IsCanonical ? "" : Extension.ToUpper());

            if (dic.Count == 0)
                throw new Exception($"No other features for extension {Extension}");

            Title = title;
            TitleSub = titleSub;
            Items = dic.Values.ToArray();

            if (Items.Length > 15)
                Items = Items.OrderBy(d => Guid.NewGuid()).Take(15).ToArray();

            switch (Items.Length)
            {
                case 1:
                    UlClass = "onebox";
                    break;
                case 2:
                    UlClass = "twobox";
                    break;
                default:
                    UlClass = "threebox";
                    break;
            }
        }
    }
}