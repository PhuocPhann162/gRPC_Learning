using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System.Text;
using System.Windows;
using GrpcGreeterClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrpcGreeterClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSendMessages_Click(object sender, RoutedEventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7201");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");

            txtMessageReceive.Text = "Greeting: " + reply.Message;

        }

        private async void btnListPersons_Click(object sender, RoutedEventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7201");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.ListPersonsAsync(new Empty { });

            lstPersons.ItemsSource = reply.Persons;
        }
    }
}