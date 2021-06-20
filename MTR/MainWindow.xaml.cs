namespace MTR
{
    using System;
    using System.Windows;
    using ToastNotifications;
    using ToastNotifications.Lifetime;
    using ToastNotifications.Position;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // tried to implement serialization on all objects on closing the window, but was not able
            // TODO Implement writing the info in the xml files
            // Can't figure out how to pass the itemPool here, so it can be serialized
            // var temp = new MeetingViewModel();
            // DataTranslator<MeetingViewModel>.Serialize(temp.Items);
            // MessageBox.Show("Wow");
        }
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
    }
}
