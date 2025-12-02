
namespace CSC
{
    public class Math
    {
        public static float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            float t = (value - fromMin) / (fromMax - fromMin);
            return toMin + t * (toMax - toMin);
        }
    }
}