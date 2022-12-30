namespace MAUIsland;

public class MAUIControlsService : IMAUIControlsService
{

    public Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync()
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
                ControlDetail = "Button displays text and responds to a tap or click that directs the app to carry out a task. A Button usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. When the Button is pressed with a finger or clicked with a mouse it initiates that command."
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
                ControlDetail = "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance."
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
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress."
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
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Date Picker",
                ControlRoute = AppRoutes.DatePickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_calendar_3_day_28_regular
                },
                ControlDetail = "DatePicker invokes the platform's date-picker control and allows you to select a date."
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
                ControlDetail = "ProgressBar indicates to users that the app is progressing through a lengthy activity. The progress bar is a horizontal bar that is filled to a percentage represented by a double value."
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
                ControlDetail = "Picker displays a short list of items, from which the user can select an item."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Slider",
                ControlRoute = AppRoutes.SliderPage,
                ControlIcon = "fluenticon_options_white.png",
                ControlDetail = "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range."
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
                ControlDetail = "RadioButton is a type of button that allows users to select one option from a set. Each option is represented by one radio button, and you can only select one radio button in a group. "
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Refresh View",
                ControlRoute = AppRoutes.RefreshViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_arrow_reset_24_regular
                },
                ControlDetail = "RefreshView is a container control that provides pull to refresh functionality for scrollable content."
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
                ControlDetail = "SearchBar is a user input control used to initiating a search."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Swipe View",
                ControlRoute = AppRoutes.SwipeViewPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_grid_24_regular
                },
                ControlDetail = "SwipeView is a container control that wraps around an item of content, and provides context menu items that are revealed by a swipe gesture."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Check Box",
                ControlRoute = AppRoutes.CheckBoxPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_checkbox_1_24_regular
                },
                ControlDetail = "CheckBox is a type of button that can either be checked or empty. When a checkbox is checked, it's considered to be on. When a checkbox is empty, it's considered to be off."
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
                ControlDetail = "Stepper enables a numeric value to be selected from a range of values. It consists of two buttons labeled with minus and plus signs."
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
                ControlDetail = "Switch control is a horizontal toggle button that can be manipulated by the user to toggle between on and off states, which are represented by a boolean value."
            });

            return controls.AsEnumerable();
        });
    }
}
