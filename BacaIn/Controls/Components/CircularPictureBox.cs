using System.Drawing.Drawing2D;

namespace BacaIn.Controls;

/// <summary>A <see cref="PictureBox"/> that renders its <see cref="PictureBox.Image"/> clipped to an anti-aliased circle.</summary>
public class CircularPictureBox : PictureBox
{
    /// <summary>Initializes a new instance of <see cref="CircularPictureBox"/> with double buffering and transparent background support.</summary>
    public CircularPictureBox()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint,
            true);
        BackColor = Color.Transparent;
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        if (Image is null || Image.Width <= 0 || Image.Height <= 0)
            return;

        int diameter = Math.Min(ClientSize.Width, ClientSize.Height);
        if (diameter <= 1)
            return;

        float x = (ClientSize.Width - diameter) / 2f;
        float y = (ClientSize.Height - diameter) / 2f;
        var circleRect = new RectangleF(x, y, diameter - 1f, diameter - 1f);
        var destRect = GetImageBounds(circleRect, Image.Size);

        using var brush = new TextureBrush(Image, WrapMode.Clamp);
        brush.TranslateTransform(destRect.X, destRect.Y);
        brush.ScaleTransform(destRect.Width / Image.Width, destRect.Height / Image.Height);

        var g = pe.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.FillEllipse(brush, circleRect);
    }

    private RectangleF GetImageBounds(RectangleF bounds, Size imageSize)
    {
        return SizeMode switch
        {
            PictureBoxSizeMode.StretchImage => bounds,
            PictureBoxSizeMode.CenterImage => new RectangleF(
                bounds.X + (bounds.Width - imageSize.Width) / 2f,
                bounds.Y + (bounds.Height - imageSize.Height) / 2f,
                imageSize.Width,
                imageSize.Height),
            PictureBoxSizeMode.Normal => new RectangleF(bounds.X, bounds.Y, imageSize.Width, imageSize.Height),
            _ => GetZoomBounds(bounds, imageSize),
        };
    }

    private static RectangleF GetZoomBounds(RectangleF bounds, Size imageSize)
    {
        float ratio = Math.Min(bounds.Width / imageSize.Width, bounds.Height / imageSize.Height);
        float width = imageSize.Width * ratio;
        float height = imageSize.Height * ratio;
        return new RectangleF(
            bounds.X + (bounds.Width - width) / 2f,
            bounds.Y + (bounds.Height - height) / 2f,
            width,
            height);
    }
}
