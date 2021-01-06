using System;
using System.Collections.Generic;

namespace Aspose.Cells.UI.Models
{
    public class HowToModel
    {
        public string Title { get; set; }
        public List<HowToItem> List { get; set; }

        public ViewModel Parent;
        private FlexibleResources Resources => Parent.Resources;
        public string AppName => Parent.AppName;

        public HowToModel(ViewModel parent)
        {
            Parent = parent;
            var extension = Parent.Extension?.ToUpper();
            var extension2 = Parent.Extension2?.ToUpper();
            if (string.IsNullOrEmpty(extension) || Parent.IsCanonical)
            {
                extension = Resources["cellsDocument"];
            }

            if (string.IsNullOrEmpty(extension2))
            {
                extension2 = Resources["cellsReplacementExtension2"];
            }

            List = new List<HowToItem>();
            var title = Resources[$"{Parent.Product}Howto{AppName}Title"];
            var titleEnd = title.EndsWith("file.") ? extension : Parent.PageProductTitle + " " + AppName;
            var k = title.IndexOf("using", StringComparison.Ordinal) - 1;
            if (k > 0)
                title = title.Substring(0, k);
            if (string.IsNullOrEmpty(Parent.Extension2))
                Title = string.Format(title, extension, titleEnd);
            else
                switch (Parent.AppName)
                {
                    case "Conversion":
                    case "Merger":
                        k = title.IndexOf("files", StringComparison.Ordinal) - 1;
                        if (k > 0)
                            title = title.Substring(0, k);
                        Title = string.Format(title, $"{extension} to {extension2}", titleEnd);
                        break;
                    case "Comparison":
                        Title = string.Format(title, $"{extension} with {extension2}", titleEnd);
                        break;
                    case "Chart":
                        Title = string.Format(title, extension, titleEnd);
                        break;
                }

            var hwName = Parent.Product + "HowtoName" + Parent.AppName + "Feature";
            var hwUrlPath = Parent.Product + "HowtoUrlPath" + Parent.AppName + "Feature";
            var hwImageUrl = Parent.Product + "HowtoImageUrl" + Parent.AppName + "Feature";
            var hw = Parent.Product + "Howto" + Parent.AppName + "Feature";
            var i = 1;
            while (Resources.ContainsKey(hw + i))
            {
                var item = new HowToItem();
                if (Resources.ContainsKey(hwName + i))
                    item.Name = string.Format(Resources[hwName + i], extension, extension2);
                if (Resources.ContainsKey(hwUrlPath + i))
                    item.UrlPath = string.Format(Resources[hwUrlPath + i], extension, extension2);
                if (Resources.ContainsKey(hwImageUrl + i))
                    item.ImageUrl = string.Format(Resources[hwImageUrl + i], Parent.Product.ToLower(), extension, extension2);
                item.Text = string.Format(Resources[hw + i], extension, extension2);
                List.Add(item);
                i++;
            }
        }
    }

    public class HowToItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string UrlPath { get; set; }
    }
}