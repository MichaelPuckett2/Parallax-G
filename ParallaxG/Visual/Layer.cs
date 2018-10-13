using ParallaxG.Visual.VisualFeatures;

namespace ParallaxG.Visual
{
    public class Layer : NotifyBase
    {
        private string source = "/ParallaxG;component/Images/empty.png";
        private Effect effect = new Effect();
        private Transform transform = new Transform();

        public string Source
        {
            get => source;
            set
            {
                source = value;
                Notify();
            }
        }

        public Effect Effect
        {
            get => effect;
            set
            {
                effect = value;
                Notify();
            }
        }

        public Transform Transform
        {
            get => transform;
            set
            {
                transform = value;
                Notify();
            }
        }
    }
}
