namespace MAUIsland.Core;

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ColorCode;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Styling;
using System.Collections.Generic;

/// <summary>
/// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
/// </summary>
public class FormattedStringFormatter : CodeColorizerBase
{
    /// <summary>
    /// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
    /// </summary>
    /// <param name="Theme">The Theme to use, determines whether to use Default Light or Default Dark.</param>
    public FormattedStringFormatter(AppTheme Theme, ILanguageParser languageParser = null)
        : this(Theme == AppTheme.Dark ? StyleDictionary.DefaultDark : StyleDictionary.DefaultLight, languageParser)
    {
    }

    /// <summary>
    /// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
    /// </summary>
    /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
    /// <param name="languageParser">The language parser that the <see cref="RichTextBlockFormatter"/> instance will use for its lifetime.</param>
    public FormattedStringFormatter(StyleDictionary Style = null, ILanguageParser languageParser = null) : base(Style, languageParser)
    {
    }

    /// <summary>
    /// Adds Syntax Highlighted Source Code to the provided RichTextBlock.
    /// </summary>
    /// <param name="sourceCode">The source code to colorize.</param>
    /// <param name="language">The language to use to colorize the source code.</param>
    /// <param name="formattedString">The Control to add the Text to.</param>
    public void FormatString(string sourceCode, ILanguage Language, FormattedString formattedString)
    {
        var paragraph = new Span();
        formattedString.Spans.Add(paragraph);
        FormatSpans(sourceCode, Language, formattedString.Spans);
    }

    /// <summary>
    /// Adds Syntax Highlighted Source Code to the provided InlineCollection.
    /// </summary>
    /// <param name="sourceCode">The source code to colorize.</param>
    /// <param name="language">The language to use to colorize the source code.</param>
    /// <param name="spans">InlineCollection to add the Text to.</param>
    public void FormatSpans(string sourceCode, ILanguage Language, IList<Span> spans)
    {
        this.Spans = spans;
        languageParser.Parse(sourceCode, Language, (parsedSourceCode, captures) => Write(parsedSourceCode, captures));
    }

    private IList<Span> Spans { get; set; }

    protected override void Write(string parsedSourceCode, IList<Scope> scopes)
    {
        var styleInsertions = new List<TextInsertion>();

        foreach (Scope scope in scopes)
            GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

        styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

        int offset = 0;

        Scope PreviousScope = null;

        foreach (var styleinsertion in styleInsertions)
        {
            var text = parsedSourceCode.Substring(offset, styleinsertion.Index - offset);
            CreateSpan(text, PreviousScope);
            if (!string.IsNullOrWhiteSpace(styleinsertion.Text))
            {
                CreateSpan(text, PreviousScope);
            }
            offset = styleinsertion.Index;

            PreviousScope = styleinsertion.Scope;
        }

        var remaining = parsedSourceCode.Substring(offset);
        // Ensures that those loose carriages don't run away!
        if (remaining != "\r")
        {
            CreateSpan(remaining, null);
        }
    }

    private void CreateSpan(string text, Scope scope)
    {
        var span = new Span
        {
            Text = text
        };

        // Styles and writes the text to the span.
        if (scope != null) StyleSpan(span, scope);
        //span.Inlines.Add(run);

        Spans.Add(span);
    }

    private void StyleSpan(Span span, Scope scope)
    {
        string foreground = null;
        string background = null;
        bool italic = false;
        bool bold = false;

        if (Styles.Contains(scope.Name))
        {
            ColorCode.Styling.Style style = Styles[scope.Name];

            foreground = style.Foreground;
            background = style.Background;
            italic = style.Italic;
            bold = style.Bold;
        }

        if (!string.IsNullOrWhiteSpace(foreground))
            span.TextColor = Color.FromArgb(foreground);
        //span.TextColor = Color.FromHex("#5598d0");
        if (!string.IsNullOrWhiteSpace(background))
            span.BackgroundColor = Color.FromArgb(background);


        if (italic)
            span.FontAttributes = FontAttributes.Italic;

        if (bold)
            span.FontAttributes = FontAttributes.Bold;
    }

    private void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
    {
        styleInsertions.Add(new TextInsertion
        {
            Index = scope.Index,
            Scope = scope
        });

        foreach (Scope childScope in scope.Children)
            GetStyleInsertionsForCapturedStyle(childScope, styleInsertions);

        styleInsertions.Add(new TextInsertion
        {
            Index = scope.Index + scope.Length
        });
    }
}