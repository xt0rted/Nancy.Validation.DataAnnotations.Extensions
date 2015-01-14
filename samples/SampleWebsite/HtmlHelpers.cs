namespace SampleWebsite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Nancy.Validation;
    using Nancy.ViewEngines.Razor;

    public static class HtmlHelpers
    {
        public static IHtmlString ValidationSummary<TModel>(this HtmlHelpers<TModel> helper, string header = null)
        {
            var validationResult = helper.RenderContext.Context.ModelValidationResult;
            if (validationResult.IsValid)
            {
                return null;
            }

            var summaryBuilder = new StringBuilder();
            summaryBuilder.Append("<div class=\"validation validation-summary\">");

            if (header != null)
            {
                summaryBuilder.AppendFormat("<h4>{0}</h4>", header);
            }

            summaryBuilder.Append("<ul class=\"validation-summary-errors\">");

            foreach (var errorText in FlattenErrors(validationResult))
            {
                summaryBuilder.AppendFormat("<li>{0}</li>", errorText);
            }

            summaryBuilder.Append("</ul>");

            summaryBuilder.Append("</div>");

            return new NonEncodedHtmlString(summaryBuilder.ToString());
        }

        private static IEnumerable<string> FlattenErrors(ModelValidationResult validationResult)
        {
            var errors = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var error in validationResult.Errors)
            {
                foreach (var validationError in error.Value)
                {
                    errors.Add(validationError.ErrorMessage);
                }
            }

            return errors;
        }
    }
}