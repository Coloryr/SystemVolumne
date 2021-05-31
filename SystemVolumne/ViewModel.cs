using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemVolumne
{
    class ViewModel : NotificationObject
    {
        private int sound;
        private int left;
        private int right;
        public int Sound
        {
            get => sound;
            set
            {
                SetProperty(ref sound, value);
                App.device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)sound / 100;
                SetProperty(ref left, (int)(App.channels[0].VolumeLevelScalar * 100), "Left");
                SetProperty(ref right, (int)(App.channels[1].VolumeLevelScalar * 100), "Right");
            }
        }
        public int Left
        {
            get => left;
            set
            {
                SetProperty(ref left, value);
                App.device.AudioEndpointVolume.Channels[0].VolumeLevelScalar = (float)left / 100;
                SetProperty(ref sound, (int)(App.device.AudioEndpointVolume.MasterVolumeLevelScalar * 100), "Sound");
            }
        }
        public int Right
        {
            get => right;
            set
            {
                SetProperty(ref right, value);
                App.device.AudioEndpointVolume.Channels[1].VolumeLevelScalar = (float)right / 100;
                SetProperty(ref sound, (int)(App.device.AudioEndpointVolume.MasterVolumeLevelScalar * 100), "Sound");
            }
        }

        public ViewModel()
        {
            Sound = (int)(App.device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            Left = (int)(App.channels[0].VolumeLevelScalar * 100);
            Right = (int)(App.channels[1].VolumeLevelScalar * 100);
        }
    }
}
