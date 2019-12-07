using DiceRoller.Models;
using DiceRoller.Services.Rolling;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace DiceRoller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> logger;
        private readonly IMediator mediator;

        public MainWindow(ILogger<MainWindow> logger, IMediator mediator)
        {
            // this logging component isn't created with a 'new', it's injected
            // by the host, which allows us a lot of freedom and reduces coupling
            this.logger = logger;
            this.mediator = mediator;

            InitializeComponent();
        }

        private async void roll_Click(object sender, RoutedEventArgs e)
        {
            var result = await mediator.Send(new RollDieRequest { Die = new SixSidedDie() });

            logger.LogDebug("User clicked the roll button");

            if(result != null)
            {
                output.Text += $"We rolled a {result.Die.NumberOfSides} sided die, with a result of { result.Value }\n";
            }
            else
            {
                MessageBox.Show("There was an error rolling the die, please see the logs");
            }
        }
    }
}