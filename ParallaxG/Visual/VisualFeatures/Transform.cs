using System;

namespace ParallaxG.Visual.VisualFeatures
{
    public class Transform : NotifyBase
    {
        private double rotation, x, y;
        private double zoom = 1;

        public double Rotation
        {
            get => rotation;
            set
            {
                value = TestRotationValue(value);
                rotation = value;
                Notify();
            }
        }

        public double Zoom
        {
            get => zoom;
            set
            {
                zoom = value;
                Notify();
            }
        }

        public double X
        {
            get => x;
            set
            {
                x = value;
                Notify();
            }
        }

        public double Y
        {
            get => y;
            set
            {
                y = value;
                Notify();
            }
        }

        private double TestRotationValue(double value)
        {
            if (value > 360d)
                return value - (Math.Floor(value / 360d) * 360d);
            else if (value < 0)
                return value + 360d + (Math.Abs(Math.Ceiling(value / 360d)) * 360d);
            else
                return value;
        }
    }
}
