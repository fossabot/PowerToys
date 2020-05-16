using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using AnimatedGifRecorder.Helpers;

namespace AnimatedGifRecorder.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public enum AppState
        {
            None,
            SelectCaptureRegion,
            Recording,
            Paused,
            Stopping
        }

        public AppState State { get; private set; }

        public MainViewModel()
        {
            State = AppState.None;
        }

        public ICommand RecordPauseButtonCommand 
        {
            get
            {
                if (recordPauseButtonCommand == null)
                {
                    recordPauseButtonCommand = new RelayCommand(param =>
                    {
                        if (State == AppState.SelectCaptureRegion || State == AppState.Paused)
                            State = AppState.Recording;
                        else if (State == AppState.Paused)
                            State = AppState.Recording;
                    });
                }
                return recordPauseButtonCommand;
            }
        }

        private ICommand recordPauseButtonCommand;

        public ICommand StopButtonCommand
        {
            get
            {
                if (stopButtonCommand == null)
                {
                    stopButtonCommand = new RelayCommand(param =>
                    {
                        State = AppState.Stopping;
                    });
                }
                return stopButtonCommand;
            }
        }

        private ICommand stopButtonCommand;
    }
}
