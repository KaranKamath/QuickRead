using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace QuickRead
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            string article = "If a device fails to provide a certain format, you " +
            "can supplement the functionality by making it available. Your app can" +
            " use the file-conversion APIs (see the BitmapEncoder and BitmapDecoder" +
            " classes in the Windows.Grapics.Imaging namespace) to convert the scanner’s " +
            "native file type to the desired file type. You can even add text " +
            "recognition features so that your users can scan papers into reconstructed " +
            "documents with formatted, selectable text. You can provide filters or other " +
            "enhancements so that scanned images can be adjusted by a user. Ultimately, you " +
            "should not feel limited by what your users’ devices can or cannot do.";

            string[] words = article.Split(' ');

            foreach (string word in words)
            {
                Run run = new Run();
                run.Text = word + " ";
                myTextBlock.Inlines.Add(run);
            }
        }

        private async void playButton_Click(object sender, RoutedEventArgs e)
        {
            playButton.IsEnabled = false;
            int i = 0;
            foreach (TextElement element in myTextBlock.Inlines)
            {
                if (i > 0)
                    myTextBlock.Inlines[i - 1].FontWeight = FontWeights.Normal;
                element.FontWeight = FontWeights.Bold;
                i++;
                await Task.Delay(500);
            }
            myTextBlock.Inlines[i - 1].FontWeight = FontWeights.Normal;

            playButton.IsEnabled = true;
        }
    }
}
