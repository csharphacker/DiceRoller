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

        public MainWindow(ILogger<MainWindow> logger)
        {
            // this logging component isn't created with a 'new', it's injected
            // by the host, which allows us a lot of freedom and reduces coupling
            this.logger = logger;

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // if you enable the output window (View > Output) when you run you will see that
            // you are getting an information message logged, which proves
            // that the dependancy injection is working
            logger.LogInformation("button clicked");
        }
    }
}