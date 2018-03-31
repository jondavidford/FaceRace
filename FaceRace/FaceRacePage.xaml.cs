using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace FaceRace
{
    public partial class FaceRacePage : ContentPage
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private SKPoint circlePosition = new SKPoint(0, 0);
        private SKPoint circleVelocity = new SKPoint(30, 30);
        private int width = -1;
        private int height = -1;
        private bool pageIsActive;

        public FaceRacePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            pageIsActive = true;
            AnimationLoop();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pageIsActive = false;
        }

        private async Task AnimationLoop()
        {
            stopwatch.Start();

            while (pageIsActive)
            {
                if (width > 0)
                {
                    circlePosition.X += circleVelocity.X;
                    if (circlePosition.X > width || circlePosition.X < 0)
                    {
                        circleVelocity.X = -circleVelocity.X;
                    }
                }

                if (height > 0)
                {
                    circlePosition.Y += circleVelocity.Y;
                    if (circlePosition.Y > height || circlePosition.Y < 0)
                    {
                        circleVelocity.Y = -circleVelocity.Y;
                    }
                }

                canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }

            stopwatch.Stop();
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            width = info.Width;
            height = info.Height;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.SkyBlue;
                paint.StrokeWidth = 50;
                canvas.DrawCircle(circlePosition, 50, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.Black;
                canvas.DrawLine(0, height / 2, width, height / 2, paint);
            }
        }
    }
}
