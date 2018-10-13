namespace ParallaxG.Visual.VisualFeatures
{
    public class Effect : NotifyBase
    {
        private double opacity = 1;
        private double blur = 0;

        public double Opacity
        {
            get => opacity;
            set
            {
                value = TestOpacityValue(value);
                opacity = value;
                Notify();
            }
        }

        public double Blur
        {
            get => blur;
            set
            {
                blur = value;
                Notify();
            }
        }

        private static double TestOpacityValue(double value)
        {
            if (value < 0) value = 0;
            else if (value > 1) value = 1;
            return value;
        }
    }
}
