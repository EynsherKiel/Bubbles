using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bubbles.Models
{
    [AddINotifyPropertyChangedInterface]
    public class BubbleFieldViewModel
    {
        private Random _random = new Random();
        private object _syncRoot = new object();
        private Timer _timer;

        public BubbleFieldViewModel()
        {
            Bubbles = new ObservableCollection<BubbleViewModel>
            {
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
                new BubbleViewModel { X = GetX(), Y = GetY() },
            };

            AddBubbleCommand = new RelayCommand(AddBubbleHandler);
            RemoveBubbleCommand = new RelayCommand(RemoveBubbleHandler, IsMayBubbleDeleteHandler);

            _timer = new Timer(TimerHandler, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        public int Width { get; set; } = 200;
        public int Height { get; set; } = 400;
        public ICommand AddBubbleCommand { get; }
        public ICommand RemoveBubbleCommand { get; }
        public ObservableCollection<BubbleViewModel> Bubbles { get; set; }

        private void TimerHandler(object state)
        {
            lock (_syncRoot)
            {
                foreach (var bubble in Bubbles)
                {
                    bubble.X = GetX();
                    bubble.Y = GetY();
                }
            }
        }
        private void AddBubbleHandler()
        {
            lock (_syncRoot)
            { 
                Bubbles.Add(new BubbleViewModel { X = GetX(), Y = GetY() }); 
            }
        }

        private void RemoveBubbleHandler()
        {
            lock (_syncRoot)
            {
                Bubbles.Remove(Bubbles.Last());
            }
        }
        private bool IsMayBubbleDeleteHandler() => Bubbles.Count != 0;

        private int GetY() => _random.Next(0, Height);

        private int GetX() => _random.Next(0, Width);
    }
}
