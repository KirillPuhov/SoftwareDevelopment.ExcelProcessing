using System.Windows.Controls;

namespace AppUX.UiMethods.Interfaces
{
    public interface IGridManager
    {
        void DoubleAnimationHide<T>(double from, double to, double duration, T obj) where T : Grid;
        void DoubleAnimationShow<T>(double from, double to, double duration, T obj) where T : Grid;
    }
}
