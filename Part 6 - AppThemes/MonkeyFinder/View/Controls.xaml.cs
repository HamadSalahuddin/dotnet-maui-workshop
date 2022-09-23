using System.Security.Cryptography;

namespace MonkeyFinder.View;

public partial class Controls : ContentPage
{
    //IDispatcherTimer timer;
    //Stopwatch stopwatch = new Stopwatch();

    //int clickTotal;
    public Controls()
	{
		InitializeComponent();

        //timer = Dispatcher.CreateTimer();
  //      timer.Interval = TimeSpan.FromMilliseconds(16);
		//timer.Tick += (s, e) =>
		//{
		//	label.Rotation = 360 * (stopwatch.Elapsed.TotalSeconds % 1);
  //      };
    }

    //void OnButtonPressed(object sender, EventArgs args)
    //{
    //    stopwatch.Start();
    //    timer.Start();
    //}

    //void OnButtonReleased(object sender, EventArgs args)
    //{
    //    stopwatch.Stop();
    //    timer.Stop();
    //}

    //async void OnButtonClicked(object sender, EventArgs e)
    //{
    //	await label.RelRotateTo(360,1000);
    //}

    //void OnImageButtonClicked(object sender, EventArgs e)
    //{
    //    clickTotal += 1;
    //    label.Text = $"{clickTotal} ImageButton click{(clickTotal == 1 ? "" : "s")}";
    //}

    //void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    //{
    //    // Perform required operation
    //}

    //void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    //{
    //    double value = args.NewValue;
    //    rotatingLabel.Rotation = value;
    //    displayLabel.Text = String.Format("The Slider value is {0}", value);
    //}

    //void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    double value = e.NewValue;
    //    _rotatingLabel.Rotation = value;
    //    _displayLabel.Text = string.Format("The Stepper value is {0}", value);
    //}

    //void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    //{
    //    string oldText = e.OldTextValue;
    //    string newText = e.NewTextValue;
    //    string myText = entry.Text;
    //}

    //void OnEntryCompleted(object sender, EventArgs e)
    //{
    //    string text = ((Entry)sender).Text;
    //}
}