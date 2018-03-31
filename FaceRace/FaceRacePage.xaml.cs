using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace FaceRace
{
    public partial class FaceRacePage : ContentPage
    {
        public FaceRacePage()
        {
            InitializeComponent();
        }

        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs eventArgs)
        {
            SKSurface surface = eventArgs.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.CornflowerBlue);

            canvas.DrawCircle(0, 0, 200, new SKPaint { Style = SKPaintStyle.Fill, Color = SKColors.Black });
        }
    }
}
