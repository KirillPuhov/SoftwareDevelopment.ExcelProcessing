using System.Windows.Controls;

namespace AppUX.Animations.Interfaces
{
    public interface IGridAnimation
    {
        void DoubleAnimationHide<T>(double from, double to, double duration, T obj) where T : Grid;
        void DoubleAnimationShow<T>(double from, double to, double duration, T obj) where T : Grid;
    }
}
