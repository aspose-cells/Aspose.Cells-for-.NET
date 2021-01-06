using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Cells.UI.Controllers;

namespace Aspose.Cells.UI.Models
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

            string appUrlId;

            if (Parent.GeneratedPage != null)
                appUrlId = Parent.GeneratedPage.App_URL_ID;
            else
            {
                var strUrl = AppName != "Conversion"
                    ? $"/{Product}/{AppName.ToLower()}/xlsx"
                    : $"/{Product}/{AppName.ToLower()}/xlsx-to-pdf";
                appUrlId = GeneratedPage.GetByURL(strUrl).App_URL_ID;
            }

            var ext = Extension.IsNullOrEmpty() ? "xlsx" : Extension;

            var items = AppName != "Conversion"
                ? new GeneratedPage(ext, appUrlId, true).GetByAppIDandNotExtension().Select(x => new OtherFeaturesItem(x)).ToArray()
                : new OtherFeaturesItem[0];
            //: new GeneratedPage(ext, Parent.Extension2).GetByExtensions().Select(x => new OtherFeaturesItem(x)).ToArray();

            var newItems = new List<OtherFeaturesItem>();
            switch (AppName)
            {
                case "Conversion":
                {
                    var genPage = new GeneratedPage(ext, Parent.Extension2);

                    var apps = ((CellsController) Parent.Controller).SupportedFormats;
                    foreach (var app in apps)
                    {
                        if (!app.Key.Equals(ext, StringComparison.InvariantCultureIgnoreCase)) continue;
                        foreach (var ext2 in app.Value)
                        {
                            if (!app.Key.Equals(ext, StringComparison.InvariantCultureIgnoreCase)
                                && !app.Key.Equals(Parent.Extension2, StringComparison.InvariantCultureIgnoreCase)) continue;
                            var otherFit = new OtherFeaturesItem(new GeneratedPage(ext, ext2))
                            {
                                Title = $"{app.Key.ToUpper()} to {Parent.DesktopAppNameByExtension(ext2, ext2.ToUpper())}"
                            };
                            //otherFit.TitleSub = $"Convert {app.Key.ToUpper()} to {Parent.DesktopAppNameByExtension(ext2, ext2.ToUpper())} ";
                            var titleSub1 = genPage.GetExtensionDescription(ext2);
                            otherFit.TitleSub = string.IsNullOrEmpty(titleSub1)
                                ? $"Convert {app.Key.ToUpper()} to {Parent.DesktopAppNameByExtension(ext2, ext2.ToUpper())} "
                                : titleSub1;

                            otherFit.URL = $"/cells/conversion/{app.Key}-to-{ext2}";
                            newItems.Add(otherFit);
                        }
                    }

                    break;
                }
                case "Merger":
                {
                    var apps = ((CellsController) Parent.Controller).SupportedMergerFormats;
                    newItems.AddRange(from app in apps
                        from ext2 in app.Value
                        where app.Key.Equals(ext, StringComparison.InvariantCultureIgnoreCase)
                              || app.Key.Equals(Parent.Extension2, StringComparison.InvariantCultureIgnoreCase)
                        select new OtherFeaturesItem(new GeneratedPage(ext, ext2))
                        {
                            Title = $"{app.Key.ToUpper()} to {Parent.DesktopAppNameByExtension(ext2, ext2.ToUpper())}",
                            TitleSub = $"Merge {app.Key.ToUpper()} to {Parent.DesktopAppNameByExtension(ext2, ext2.ToUpper())}",
                            URL = $"/cells/merger/{app.Key}-to-{ext2}"
                        });
                    break;
                }
            }

            if (newItems.Count > 0)
            {
                items = items.Concat(newItems).ToArray();
            }

            var dic = new Dictionary<string, OtherFeaturesItem>();
            foreach (var item in items)
            {
                if (!dic.ContainsKey(item.Title))
                    dic.Add(item.Title, item);
                else if (item.URL.Contains(Parent.Product))
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