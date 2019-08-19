using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MSVidCtlLib;
using Panacea.Modularity;
using Panacea.Modularity.Media;
using Panacea.Modularity.Media.Channels;
using TunerLib;

namespace Panacea.Modules.AtscMediaPlayer
{
    /// <summary>
    /// Interaction logic for AtscMediaPlayer.xaml
    /// </summary>
    public partial class AtscMediaPlayerControl : System.Windows.Controls.UserControl, IMediaPlayerPlugin,IMediaPlayer
    {
        public AtscMediaPlayerControl()
        {
            InitializeComponent();
           
            video.axMSVidCtl1.ClickEvent += (sender, args) => Click?.Invoke(this, null);           
        }


        public event EventHandler Click;
        public event EventHandler<bool> IsSeekableChanged;
        public event EventHandler<float> PositionChanged;
        public event EventHandler<bool> HasNextChanged;
        public event EventHandler<bool> HasPreviousChanged;
        public event EventHandler<bool> IsPausableChanged;
        public event EventHandler<TimeSpan> DurationChanged;
        public event EventHandler<bool> HasSubtitlesChanged;
        public event EventHandler Opening;
        public event EventHandler Playing;
        public event EventHandler<string> NowPlaying;
        public event EventHandler Stopped;
        public event EventHandler Paused;
        public event EventHandler Ended;
        public event EventHandler<Exception> Error;

        public bool CanPlayChannel(MediaItem item)
        {
            return item is AtscMedia;
        }

        public bool IsSeekable
        {
            get { return false; }
        }

        public float Position
        {
            get { return 0; }
            set { }
        }

       
        public bool IsPlaying
        {
            get { return video.axMSVidCtl1.CtlState == MSVidCtlStateList.STATE_PLAY; }
            protected set { }
        }

        public TimeSpan Duration
        {
            get { return new TimeSpan(); }
        }

        public bool IsPausable
        {
            get { return false; }
        }

        public Task Play(MediaItem channel)
        {
            if (!(channel is AtscMedia)) return Task.CompletedTask;
            var atsc = channel as AtscMedia;
            var tuningSpaces2 = new SystemTuningSpaces();
            var tuningSpaces = (ITuningSpaceContainer)new SystemTuningSpaces();

            var atscTuningSpace = new ATSCTuningSpace
            {
                NetworkType = "{0DAD2FDD-5FD7-11D3-8F50-00C04F7971E2}",
                CountryCode = 1,
                MaxChannel = 999,
                MaxMinorChannel = 99,
                UniqueName = "ATSC"
            };
            var tuneRequest = (IATSCChannelTuneRequest)atscTuningSpace.CreateTuneRequest();

            var locator = new ATSCLocator { PhysicalChannel = 19 };
            tuneRequest.Channel = 19;
            tuneRequest.MinorChannel = 1;

            tuneRequest.Locator = (Locator)locator;
            var objTuneRequest = (object)tuneRequest;
            video.axMSVidCtl1.View(ref objTuneRequest);
            video.axMSVidCtl1.Run();
            Playing?.Invoke(this, null);
            return Task.CompletedTask;
        }

        public void Play()
        {
            try
            {
                video.axMSVidCtl1.Run();
            }
            catch
            {
            }
        }

        public void Stop()
        {
            try
            {
                video.axMSVidCtl1.Stop();
            }
            catch
            {
            }
            Stopped?.Invoke(this, null);
        }

        public void Pause()
        {
            video.axMSVidCtl1.Pause();
        }

        public void Seek(int percentage)
        {

        }

        public void Dispose()
        {

        }

        public bool HasNext
        {
            get { return false; }
        }

        public bool HasPrevious
        {
            get { return false; }
        }

        public FrameworkElement VideoControl => this;

        public bool HasSubtitles => false;

        public void Next()
        {
            
        }

        public void Previous()
        {
            
        }

        public void NextSubtitle()
        {
           
        }

        public bool HasMoreChapters()
        {
            return false;
        }

        Task IPlugin.BeginInit()
        {
            return Task.CompletedTask;
        }

        Task IPlugin.EndInit()
        {
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }

        public void SetSubtitles(bool on)
        {
            
        }

        public IMediaPlayer GetMediaPlayer() => this;
    }
}
