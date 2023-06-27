namespace SimpleCalculator;

public partial class MainPage : ContentPage
{
    string number = "";
    double firstNumber = 0;
    double secondNumber = 0;
    double result = 0;
    int state = 1;
    char operation = '\0';

    public MainPage()
	{
		InitializeComponent();
        this.ResultField.Text = "0";
    }

    void OnNumberClick(Object sender, EventArgs e)
    {
        Button button = (Button)sender;

        number += button.Text;
        if (number.All(res => res == '0'))
        {
            number = "";
            this.ResultField.Text = "0";
        }
        else
        {
            this.ResultField.Text = number;
        }
    }

    void OnClearResultField(Object sender, EventArgs e)
    {
        number = "";
        this.ResultField.Text = "0";
        state = 1;
    }

    void OnActionClick(Object sender, EventArgs e)
    {
        Button button = (Button)sender;

        if (state == 1)
        {
            firstNumber = double.Parse(this.ResultField.Text);
            operation = button.Text[0];
            number = "";
            state++;
        }
        else if (state > 1)
        {
            secondNumber = double.Parse(this.ResultField.Text);
            result = CalculateResult(firstNumber, secondNumber, operation);
            this.ResultField.Text = result.ToString();
            firstNumber = result;
            operation = button.Text[0];
            secondNumber = 0;
            number = "";
            state++;
        }
    }

    void OnResultClick(Object sender, EventArgs e)
    {
        secondNumber = double.Parse(this.ResultField.Text);
        result = CalculateResult(firstNumber, secondNumber, operation);
        this.ResultField.Text = result.ToString();
        firstNumber = result;
        firstNumber = 0;
        secondNumber = 0;
        number = "";
        state = 1;
    }

    double CalculateResult(double firstNumber, double secondNumber, char operation)
    {
        return Calculate.CalculateResult(firstNumber, secondNumber, operation);
    }

    void getNegative(Object sender, EventArgs e)
    {
        if (this.ResultField.Text != "0")
        {
            this.ResultField.Text = (double.Parse(this.ResultField.Text) * -1).ToString();
        }
    }

    void getPercent(Object sender, EventArgs e)
    {
        this.ResultField.Text = (double.Parse(this.ResultField.Text) / 100).ToString();
    }

    void showError()
    {
        this.ResultField.Text = "ERR";
    }
}

