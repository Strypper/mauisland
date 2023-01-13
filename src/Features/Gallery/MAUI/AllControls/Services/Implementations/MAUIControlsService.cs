using static System.Net.WebRequestMethods;

namespace MAUIsland;

public class ControlsService : IControlsService
{
    private readonly IControlInfo[] controlInfos;

    public ControlsService(IEnumerable<IControlInfo> controlInfos)
    {
        this.controlInfos = controlInfos.ToArray();
    }

    private readonly IList<ControlGroupInfo> controlGroupInfos = new List<ControlGroupInfo>()
    {
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.MauiBuiltInControls,
        },
        new ControlGroupInfo
        {
            Name = ControlGroupInfo.SyncfusionControls,
        },
    };

    public Task<IEnumerable<ControlInfo>> GetControlsAsync()
    {
        return Task.Run(() =>
        {
            var controls = new List<ControlInfo>();

            controls.Add(new ControlInfo()
            {
                ControlName = "Button",
                ControlRoute = AppRoutes.ButtonPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_add_circle_32_regular
                },
                ControlDetail = "Button displays text and responds to a tap or click that directs the app to carry out a task. A Button usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. When the Button is pressed with a finger or clicked with a mouse it initiates that command.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Button",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/button?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Image Button",
                ControlRoute = AppRoutes.ImageButtonPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_image_add_24_regular
                },
                ControlDetail = "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/ImageButton",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/imagebutton?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Activity Indicator",
                ControlRoute = AppRoutes.ActivityIndicatorPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
                },
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/ActivityIndicator",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/activityindicator?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Label Page",
                ControlRoute = AppRoutes.LabelPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_text_case_title_24_regular
                },
                ControlDetail = "Label displays single-line and multi-line text. Text displayed by a Label can be colored, spaced, and can have text decorations."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Editor",
                ControlRoute = AppRoutes.EditorPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_code_text_edit_20_regular
                },
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Editor",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/editor?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Date Picker",
                ControlRoute = AppRoutes.DatePickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_calendar_ltr_24_regular
                },
                ControlDetail = "DatePicker invokes the platform's date-picker control and allows you to select a date.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/DatePicker",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/datepicker?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Progress Bar",
                ControlRoute = AppRoutes.ProgressBarPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_battery_2_24_regular
                },
                ControlDetail = "ProgressBar indicates to users that the app is progressing through a lengthy activity. The progress bar is a horizontal bar that is filled to a percentage represented by a double value.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/ProgressBar",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/progressbar?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Picker",
                ControlRoute = AppRoutes.PickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_time_picker_24_regular
                },
                ControlDetail = "Picker displays a short list of items, from which the user can select an item.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Picker",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/picker?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Slider",
                ControlRoute = AppRoutes.SliderPage,
                ControlIcon = "fluenticon_options_white.png",
                ControlDetail = "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Slider",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/slider?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Radio Button",
                ControlRoute = AppRoutes.RadioButtonPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_radio_button_24_regular
                },
                ControlDetail = "RadioButton is a type of button that allows users to select one option from a set. Each option is represented by one radio button, and you can only select one radio button in a group. ",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/RadioButton",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/radiobutton?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Refresh View",
                ControlRoute = AppRoutes.RefreshViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_arrow_sync_24_regular
                },
                ControlDetail = "RefreshView is a container control that provides pull to refresh functionality for scrollable content.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/RefreshView",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/refreshview?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Search Bar",
                ControlRoute = AppRoutes.SearchBarPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_search_24_regular
                },
                ControlDetail = "SearchBar is a user input control used to initiating a search.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/SearchBar",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/searchbar?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Swipe View",
                ControlRoute = AppRoutes.SwipeViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_swipe_right_24_regular
                },
                ControlDetail = "SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/SwipeView",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/swipeview?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Check Box",
                ControlRoute = AppRoutes.CheckBoxPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_checkbox_checked_24_regular
                },
                ControlDetail = "CheckBox is a type of button that can either be checked or empty. When a checkbox is checked, it's considered to be on. When a checkbox is empty, it's considered to be off.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/CheckBox",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/checkbox?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Stepper",
                ControlRoute = AppRoutes.StepperPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_add_24_regular
                },
                ControlDetail = "Stepper enables a numeric value to be selected from a range of values. It consists of two buttons labeled with minus and plus signs.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Stepper",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/stepper?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Switch",
                ControlRoute = AppRoutes.SwitchPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_toggle_left_24_regular
                },
                ControlDetail = "Switch control is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Switch",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/switch?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Time Picker",
                ControlRoute = AppRoutes.TimePickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_clock_24_regular
                },
                ControlDetail = "TimePicker invokes the platform's time-picker control and allows you to select a time.",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/TimePicker",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/timepicker?view=net-maui-7.0&tabs=windows"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Entry",
                ControlRoute = AppRoutes.EntryPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_text_field_24_regular
                },
                ControlDetail = "Entry allows you to enter and edit a single line of text. In addition, the Entry can be used as a password field.\r\n\r\n",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/Entry",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Carousel View",
                ControlRoute = AppRoutes.CarouselViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_app_recent_24_regular
                },
                ControlDetail = "CarouselView will display its items in a horizontal orientation. A single item will be displayed on screen, with swipe gestures resulting in forwards and backwards navigation through the collection of items. ",
                GitHubUrl = "https://github.com/Strypper/MAUIsland/tree/main/MAUIsland/Features/Gallery/MAUI/CarouselView",
                DocumentUrl = "https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/carouselview/?view=net-maui-7.0"
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Collection View",
                ControlRoute = AppRoutes.CollectionViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_apps_24_regular
                },
                ControlDetail = "CollectionView is a view for presenting lists of data using different layout specifications.  "
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Indicator View",
                ControlRoute = AppRoutes.IndicatorViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_apps_24_regular
                },
                ControlDetail = " IndicatorView is a control that displays indicators that represent the number of items, and current position, in a CarouselView"
            });

            return controls.AsEnumerable();
        });
    }

    public Task<IEnumerable<ControlGroupInfo>> GetControlGroupsAsync()
    {
        return Task.Run(() =>
        {
            return (IEnumerable<ControlGroupInfo>)controlGroupInfos;
        });
    }

    public Task<IEnumerable<IControlInfo>> GetControlsAsync(string groupName)
    {
        return Task.Run(() =>
        {
            IEnumerable<IControlInfo> result = controlInfos
                .Where(x => x.GroupName == groupName);

            return string.IsNullOrWhiteSpace(groupName)
                    ? controlInfos
                    : controlInfos
                        .Where(x => x.GroupName == groupName);
        });
    }
}
