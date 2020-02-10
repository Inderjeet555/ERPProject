using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace ERPProject.Extensions
{
    public static class KendoCustomHelper
    {

        //public static MvcHtmlString IfValidationFail(
        //   this HtmlHelper html,
        //   string message = "Before you continue, correct the errors identified",
        //   string className = "validation-summary-errors")
        //{
        //    string result = String.Empty;
        //    if (html.ViewData.ModelState.IsValid == false)
        //    {
        //        result = String.Format("<span class=\"{0}\">{1}</span>", className, message);
        //    }
        //    MvcHtmlString formError = html.ValidationMessage(ModelStateDictionaryExtensions.ErrorMessageKey);
        //    result += String.Format(
        //        "<span class=\"{0}\">{1}</span>",
        //        "field-validation-error",
        //        formError != null ? formError.ToHtmlString() : String.Empty);
        //    return MvcHtmlString.Create(result);
        //}
        public static MvcHtmlString KendoInputFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return KendoInputHelper(htmlHelper,
                                 null,
                                 metadata,
                                 metadata.Model,
                                 ExpressionHelper.GetExpressionText(expression),
                                 htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString KendoPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return KendoInputHelper(htmlHelper,
                                 "Password",
                                 metadata,
                                 metadata.Model,
                                 ExpressionHelper.GetExpressionText(expression),
                                 htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }


        private static MvcHtmlString KendoInputHelper(this HtmlHelper htmlHelper, string kInputType, ModelMetadata metadata, object model, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper,
                               kInputType,
                               metadata,
                               expression,
                               model,
                               setId: true,
                               htmlAttributes: htmlAttributes);
        }



        private static MvcHtmlString InputHelper(HtmlHelper htmlHelper, string kInputType, ModelMetadata metadata, string name, object value, bool setId, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            if (kInputType != null)
                tagBuilder.MergeAttribute("type", kInputType, true);
            tagBuilder.MergeAttribute("name", fullName, true);
            tagBuilder.GenerateId(fullName);

            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));

        }
    


    }
}