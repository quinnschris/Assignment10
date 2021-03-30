using System;
using System.Collections.Generic;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Assignment10.Infrastructure
{

    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PageTagHelper : TagHelper
    {

        private IUrlHelperFactory _urlInfo;

        public PageTagHelper (IUrlHelperFactory urlInfo)
        {
            _urlInfo = urlInfo;
        }

        public PageNumberingInfo PageInfo { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]

        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.NumPages; i++)
            {

                IUrlHelper urlHelp = _urlInfo.GetUrlHelper(ViewContext);

                TagBuilder individualTag = new TagBuilder("a");

                KeyValuePairs["pageNum"] = i;
                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);
                individualTag.InnerHtml.Append(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);
            }

            output.Content.AppendHtml(finishedTag.InnerHtml);

            base.Process(context, output);
        }
    }
}
