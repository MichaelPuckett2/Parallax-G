using ParallaxG.Visual.VisualFeatures;

namespace ParallaxG.Visual
{
    public static class VisualHelper
    {
        public static Parallax GetGearsOfWarParallax()
        {
            var gearsParallax = new Parallax();
            var backgroundLayer = new Layer()
            {
                Source = "http://2.bp.blogspot.com/-UVJ0sPVGisM/Uff9GNxstEI/AAAAAAAAECE/U2ydhmAxjLU/s1600/Gears-Of-War-3-Wallpaper-Background-HD.jpg",
            };

            var shadowCogEffect = new Effect()
            {
                Blur = 12,
                Opacity = 0.4
            };

            var shadowCogTransform = new Transform()
            {
                X = 400,
                Y = -100,
                Zoom = 0.7
            };


            var shadowCogLayer = new Layer()
            {
                Source = "http://www.clipartbest.com/cliparts/xig/nop/xignopbKT.png",
                Effect = shadowCogEffect,
                Transform = shadowCogTransform
            };

            var cogTransform = new Transform()
            {
                X = 450,
                Y = -50,
                Zoom = 0.3
            };

            var cogLayer = new Layer()
            {
                Source = "http://www.clipartbest.com/cliparts/xig/nop/xignopbKT.png",
                Transform = cogTransform
            };

            gearsParallax.Layers.Clear();
            gearsParallax.Layers.Add(backgroundLayer);
            gearsParallax.Layers.Add(shadowCogLayer);
            gearsParallax.Layers.Add(cogLayer);

            return gearsParallax;
        }
    }
}
