using System.Collections.Generic;
using ChartJSLib;

namespace ChartJS.Services.Utility
{
    public interface IRandomColorGenerator
    {
        string[] GenerateColorsForPointList(int [] valueArray);

        string[] GenerateColorsForBubblePointList(List<BubblePoint> bubblePointList);
    }
}
