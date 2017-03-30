using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // tellu
        private List<Tellu> tellut;

        //skappari
        private Skappari skappari;

        //Rynkky
        private Rynkky rynkky;

        public MainPage()
        {
            this.InitializeComponent();

            skappari = new Skappari
            {
                LocationX = 100,
                LocationY = 10
            };
            rynkky = new Rynkky
            {
                LocationX = MyCanvas.Width / 2,
                LocationY = MyCanvas.Height / 2,
                
            };

            // alustetaan tellulista
            tellut = new List<Tellu>();

            //lisätään skappari canvasiin
            MyCanvas.Children.Add(skappari);

            //lisätään rynkky canvasiin
            MyCanvas.Children.Add(rynkky);

            Window.Current.CoreWindow.PointerPressed += CoreWindow_PointerPressed;
        }

        private void CoreWindow_PointerPressed(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.PointerEventArgs args)
        {
            Tellu tellu = new Tellu();
            tellu.LocationX = args.CurrentPoint.Position.X - tellu.Width / 2;
            tellu.LocationY = args.CurrentPoint.Position.Y - tellu.Width / 2;

            MyCanvas.Children.Add(tellu);
            tellu.SetLocation();

            tellut.Add(tellu);
        }


    }
}