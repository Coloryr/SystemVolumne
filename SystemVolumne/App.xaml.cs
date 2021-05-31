using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SystemVolumne
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MMDeviceEnumerator deviceEnumerator;
        public static MMDevice device;
        public static AudioEndpointVolumeChannels channels;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            deviceEnumerator = new MMDeviceEnumerator();
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            channels = device.AudioEndpointVolume.Channels;
        }
    }
}
