public class Utils {

    public static float LinearCoefficient(int index, int max) {
        if (index <= (max / 2)) return ((-2 / max) * index) + 1;
        return ((2 / max) * index) - 1;
    }

    public static float CurveCoefficient(int index, int max) {
        float halfMax = max / 2;
        return ((index / halfMax) - 1) * ((index / halfMax) - 1);
    }
}
