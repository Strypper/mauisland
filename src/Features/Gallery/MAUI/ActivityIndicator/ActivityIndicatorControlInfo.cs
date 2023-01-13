namespace MAUIsland;

class ImageButtonControlInfo : IControlInfo
{
    public string ControlName => nameof(ImageButton);
    public string ControlRoute => typeof(ImageButtonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_image_add_24_regular
    };
    public string ControlDetail => "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class ActivityIndicatorControlInfo : IControlInfo
{
    public string ControlName => nameof(ActivityIndicator);
    public string ControlRoute => typeof(ActivityIndicatorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
    public string ControlDetail => "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class LabelControlInfo : IControlInfo
{
    public string ControlName => nameof(Label);
    public string ControlRoute => typeof(LabelPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_text_case_title_24_regular
    };
    public string ControlDetail => "Label displays single-line and multi-line text. Text displayed by a Label can be colored, spaced, and can have text decorations.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class EditorControlInfo : IControlInfo
{
    public string ControlName => nameof(Editor);
    public string ControlRoute => typeof(EditorPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_code_text_edit_20_regular
    };
    public string ControlDetail => "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class DatePickerControlInfo : IControlInfo
{
    public string ControlName => nameof(DatePicker);
    public string ControlRoute => typeof(DatePickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_calendar_ltr_24_regular
    };
    public string ControlDetail => "DatePicker invokes the platform's date-picker control and allows you to select a date.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class ProgressBarControlInfo : IControlInfo
{
    public string ControlName => nameof(ProgressBar);
    public string ControlRoute => typeof(ProgressBarPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_battery_2_24_regular
    };
    public string ControlDetail => "ProgressBar indicates to users that the app is progressing through a lengthy activity. The progress bar is a horizontal bar that is filled to a percentage represented by a double value.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class PickerControlInfo : IControlInfo
{
    public string ControlName => nameof(Picker);
    public string ControlRoute => typeof(PickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_time_picker_24_regular
    };
    public string ControlDetail => "Picker displays a short list of items, from which the user can select an item.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class SliderControlInfo : IControlInfo
{
    public string ControlName => nameof(Slider);
    public string ControlRoute => typeof(SliderPage).FullName;
    public ImageSource ControlIcon => "fluenticon_options_white.png";
    public string ControlDetail => "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class RadioButtonControlInfo : IControlInfo
{
    public string ControlName => nameof(RadioButton);
    public string ControlRoute => typeof(RadioButtonPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_radio_button_24_regular
    };
    public string ControlDetail => "RadioButton is a type of button that allows users to select one option from a set. Each option is represented by one radio button, and you can only select one radio button in a group. ";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class RefreshViewControlInfo : IControlInfo
{
    public string ControlName => nameof(RefreshView);
    public string ControlRoute => typeof(RefreshViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_arrow_sync_24_regular
    };
    public string ControlDetail => "RefreshView is a container control that provides pull to refresh functionality for scrollable content.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class SearchBarControlInfo : IControlInfo
{
    public string ControlName => nameof(SearchBar);
    public string ControlRoute => typeof(SearchBarPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_search_24_regular
    };
    public string ControlDetail => "SearchBar is a user input control used to initiating a search.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class SwipeViewControlInfo : IControlInfo
{
    public string ControlName => nameof(SwipeView);
    public string ControlRoute => typeof(SwipeViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_swipe_right_24_regular
    };
    public string ControlDetail => "SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class CheckBoxControlInfo : IControlInfo
{
    public string ControlName => nameof(CheckBox);
    public string ControlRoute => typeof(CheckBoxPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_checkbox_checked_24_regular
    };
    public string ControlDetail => "CheckBox is a type of button that can either be checked or empty. When a checkbox is checked, it's considered to be on. When a checkbox is empty, it's considered to be off.";
    public string GitHubUrl => "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/CheckBox";
    public string DocumentUrl => "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/checkbox?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class StepperControlInfo : IControlInfo
{
    public string ControlName => nameof(Stepper);
    public string ControlRoute => typeof(StepperPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_add_24_regular
    };
    public string ControlDetail => "Stepper enables a numeric value to be selected from a range of values. It consists of two buttons labeled with minus and plus signs.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class SwitchControlInfo : IControlInfo
{
    public string ControlName => nameof(Switch);
    public string ControlRoute => typeof(SwitchPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_toggle_left_24_regular
    };
    public string ControlDetail => "Switch control is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class TimePickerControlInfo : IControlInfo
{
    public string ControlName => nameof(TimePicker);
    public string ControlRoute => typeof(TimePickerPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_clock_24_regular
    };
    public string ControlDetail => "TimePicker invokes the platform's time-picker control and allows you to select a time.";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class EntryControlInfo : IControlInfo
{
    public string ControlName => nameof(Entry);
    public string ControlRoute => typeof(EntryPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_text_field_24_regular
    };
    public string ControlDetail => "Entry allows you to enter and edit a single line of text. In addition, the Entry can be used as a password field.\r\n\r\n";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class CarouselViewControlInfo : IControlInfo
{
    public string ControlName => nameof(CarouselView);
    public string ControlRoute => typeof(CarouselViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_app_recent_24_regular
    };
    public string ControlDetail => "CarouselView will display its items in a horizontal orientation. A single item will be displayed on screen, with swipe gestures resulting in forwards and backwards navigation through the collection of items. ";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class CollectionViewControlInfo : IControlInfo
{
    public string ControlName => nameof(CollectionView);
    public string ControlRoute => typeof(CollectionViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_apps_24_regular
    };
    public string ControlDetail => "CollectionView is a view for presenting lists of data using different layout specifications.  ";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}

class IndicatorViewControlInfo : IControlInfo
{
    public string ControlName => nameof(IndicatorView);
    public string ControlRoute => typeof(IndicatorViewPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_apps_24_regular
    };
    public string ControlDetail => " IndicatorView is a control that displays indicators that represent the number of items, and current position, in a CarouselView";
    public string GitHubUrl => $"https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/{ControlName}/?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.MauiBuiltInControls;
}