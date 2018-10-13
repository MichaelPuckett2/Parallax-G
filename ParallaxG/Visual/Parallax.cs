using System.Collections.ObjectModel;

namespace ParallaxG.Visual
{
    public class Parallax : NotifyBase
    {
        private string name = "no-name";
        private ObservableCollection<Layer> layers = new ObservableCollection<Layer>();

        public Parallax()
        {
            Layers.Add(new Layer());
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }

        public ObservableCollection<Layer> Layers
        {
            get => layers;
            set
            {
                layers = value;
                Notify();
            }
        }
    }
}
