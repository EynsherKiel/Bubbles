using PropertyChanged;

namespace Bubbles.Models
{
    [AddINotifyPropertyChangedInterface]
    public class BubbleViewModel
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
