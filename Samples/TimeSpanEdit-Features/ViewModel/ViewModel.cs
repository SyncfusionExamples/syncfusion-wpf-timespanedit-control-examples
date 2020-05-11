using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TimeSpanEdit_Features
{
    class ViewModel : NotificationObject
    {
        private TimeSpan minvalue = new TimeSpan(1, 0, 0, 0);
        private TimeSpan maxvalue = new TimeSpan(31, 0, 0, 0);
        private TimeSpan? _value = new TimeSpan(1, 0, 0, 0);
        private ObservableCollection<string> formatCollection;
        private ObservableCollection<string> eventLogsCollection;
        private ObservableCollection<string> coll = new ObservableCollection<string>();
        private ICommand valueChangedCommand;
        private string nullString = "Type here";
        private bool showArrowButtons = true;
        private bool incrementOnScrolling = true;
        private bool allowNull = false;
        private bool isReadOnly = false;
        private bool enableExtendedScrolling;
        private string format= "d";

        public ObservableCollection<string> EventLogsCollection
        {
            get
            {

                return eventLogsCollection;
            }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(nameof(EventLogsCollection));
            }
        }        

        public TimeSpan? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                this.RaisePropertyChanged(nameof(Value));
            }
        }

        public ObservableCollection<string> FormatCollection
        {
            get
            {
                return formatCollection;
            }
            set
            {
                formatCollection = value;
                this.RaisePropertyChanged(nameof(FormatCollection));
            }
        }

        public string NullString
        {
            get
            {
                return nullString;
            }
            set
            {
                nullString = value;
                this.RaisePropertyChanged(nameof(NullString));
            }
        }

        public bool ShowArrowButtons
        {
            get
            {
                return showArrowButtons;
            }
            set
            {
                showArrowButtons = value;
                this.RaisePropertyChanged(nameof(ShowArrowButtons));
            }
        }

        public bool IncrementOnScrolling
        {
            get
            {
                return incrementOnScrolling;
            }
            set
            {
                incrementOnScrolling = value;
                this.RaisePropertyChanged(nameof(IncrementOnScrolling));
            }
        }

        public bool EnableExtendedScrolling
        {
            get
            {
                return enableExtendedScrolling;
            }
            set
            {
                enableExtendedScrolling = value;
                this.RaisePropertyChanged(nameof(EnableExtendedScrolling));
            }
        }

        public bool AllowNull
        {
            get
            {
                return allowNull;
            }
            set
            {
                allowNull = value;
                this.RaisePropertyChanged(nameof(AllowNull));
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;
                this.RaisePropertyChanged(nameof(IsReadOnly));
            }
        }

        public string Format
        {
            get
            {
                return format;
            }
            set
            {
                format = value;
                this.RaisePropertyChanged(nameof(Format));
            }
        }

        public TimeSpan MinimumValue
        {
            get
            {
                return minvalue;
            }
            set
            {
                try
                {

                    if (MaximumValue < value)
                        minvalue = MaximumValue;
                    else
                        minvalue = value;

                    this.RaisePropertyChanged(nameof(MinimumValue));
                }
                catch { }
            }
        }

        public TimeSpan MaximumValue
        {
            get
            {
                return maxvalue;
            }
            set
            {
                try
                {
                    if (value < MinimumValue)
                        maxvalue = MinimumValue;
                    else
                        maxvalue = value;

                    this.RaisePropertyChanged(nameof(MaximumValue));
                }
                catch { }
            }
        }

        public ICommand ValueChangedCommand
        {
            get
            {
                if (valueChangedCommand == null)
                {
                    valueChangedCommand = new DelegateCommand<object>(ValueChanged);
                }
                return valueChangedCommand;
            }
        }

        public void ValueChanged(object param)
        {
            if (Value != null)
            {
                AddLog("Value Changed: " + Value.ToString());
            }
            else
            {
                AddLog("Value Changed: NULL");
            }
        }

        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }
        void addFormats()
        {
            FormatCollection = new ObservableCollection<string>();
            FormatCollection.Add("d");
            FormatCollection.Add("d.h");
            FormatCollection.Add("d.h:m");
            FormatCollection.Add("d.h:m:s");
            FormatCollection.Add("d 'Days'");
            FormatCollection.Add("d 'Days' h 'hr'");
            FormatCollection.Add("d 'Days' h 'hr' m 'min'");
            FormatCollection.Add("d 'Days' h 'hr' m 'min' s 'sec'");
            FormatCollection.Add("d 'Days' h 'hr' m 'min' s 'sec' z 'msec'");
        }
        public ViewModel()
        {
           addFormats();
        }
    }
}
