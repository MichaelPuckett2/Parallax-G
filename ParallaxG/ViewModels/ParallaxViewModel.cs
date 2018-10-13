using ParallaxG.ViewModels.Commands;
using ParallaxG.Visual;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ParallaxG.ViewModels
{
    public class ParallaxViewModel : NotifyBase
    {
        private ObservableCollection<Parallax> parallaxes = new ObservableCollection<Parallax>();
        private Parallax selectedParallax;
        private Layer selectedLayer;

        public ParallaxViewModel()
        {
            SelectParallaxCommand = new RelayCommand(SelectParallax);
            SelectLayerCommand = new RelayCommand(SelectLayer);

            AddParallaxCommand = new RelayCommand(AddParallax);
            RemoveParallaxCommand = new RelayCommand(AddParallax);

            AddNewLayerCommand = new RelayCommand(AddNewLayer);
            RemoveLayerCommand = new RelayCommand(RemoveLayer);

            Parallaxes.Add(VisualHelper.GetGearsOfWarParallax());

            SelectedParallax = Parallaxes.First();
            SelectedLayer = SelectedParallax.Layers.First();
        }

        public ICommand SelectParallaxCommand { get; }
        public ICommand SelectLayerCommand { get; }

        public ICommand AddParallaxCommand { get; }
        public ICommand RemoveParallaxCommand { get; }

        public ICommand AddNewLayerCommand { get; }
        public ICommand RemoveLayerCommand { get; }

        public Parallax SelectedParallax
        {
            get => selectedParallax;
            private set
            {
                selectedParallax = value;
                Notify();
            }
        }

        public Layer SelectedLayer
        {
            get => selectedLayer;
            set
            {
                selectedLayer = value;
                Notify();
            }
        }

        public ObservableCollection<Parallax> Parallaxes
        {
            get => parallaxes;
            set
            {
                parallaxes = value;
                Notify();
            }
        }

        private void SelectParallax(object obj)
        {
            if (obj is Parallax parallax && Parallaxes.Contains(parallax)) SelectedParallax = parallax;
        }

        private void SelectLayer(object obj)
        {
            if (obj is Layer layer && SelectedParallax.Layers.Contains(layer)) SelectedLayer = layer;
        }

        private void AddParallax(object obj)
        {
            if (obj is Parallax parallax) Parallaxes.Add(parallax);
        }

        private void RemoveParallax(object obj)
        {
            if (obj is Parallax parallax && Parallaxes.Contains(parallax)) Parallaxes.Remove(parallax);
        }

        private void AddNewLayer(object obj)
        {
            var newLayer = new Layer();
            SelectedParallax.Layers.Add(newLayer);
            SelectedLayer = newLayer;
        }

        private void RemoveLayer(object obj)
        {
            if (obj is Layer layer && SelectedParallax.Layers.Contains(layer))
            {
                SelectedParallax.Layers.Remove(layer);
                if (SelectedLayer == layer) SelectedLayer = SelectedParallax.Layers.LastOrDefault();
            }
        }
    }
}
