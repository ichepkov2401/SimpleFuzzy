using System.Reflection;


namespace SimpleFuzzy.Models.SimulatorCrane
{
    public partial class VisualCrane : UserControl
    {
        public CraneSimulator craneSimulator;

        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;
        private const double visualLength = 100; // в пикселях
        private System.Drawing.Image backgroundImage, cartImage, containerImage, constructImage, cargoImage, platformImage;

        public VisualCrane()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);

            context = BufferedGraphicsManager.Current;
            grafx = context.Allocate(CreateGraphics(), DisplayRectangle);
            var assembly = Assembly.GetExecutingAssembly();

            LoadImages();

            Paint += OnPaint;
            Resize += OnResize;
            Dock = DockStyle.Fill;
        }

        private void LoadImages()
        {
            try
            {
                string spritesPath = Path.Combine(Application.StartupPath, "assets", "sprites");
                backgroundImage = Image.FromFile(Path.Combine(spritesPath, "port.png"));
                cartImage = Image.FromFile(Path.Combine(spritesPath, "carriage.png"));
                containerImage = Image.FromFile(Path.Combine(spritesPath, "cable and weight.png"));
                constructImage = Image.FromFile(Path.Combine(spritesPath, "construct.png"));
                cargoImage = Image.FromFile(Path.Combine(spritesPath, "cargo.png"));
                platformImage = Image.FromFile(Path.Combine(spritesPath, "platform.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображений: {ex.Message}");
            }
        }


        public VisualCrane(CraneSimulator crane) : this()
        {
            craneSimulator = crane;
        }

        protected void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.FromArgb(135, 206, 235)); // Очищаем весь экран цветом неба

            // Фон (порт)
            g.DrawImage(backgroundImage, 0, 0, Width, Height);

            float leftBoundary = Width * 0.16f;
            float rightBoundary = Width * 0.95f;
            float craneWidth = rightBoundary - leftBoundary;

            // Каретка
            float cartWidth = Width * 0.0584f; // Ширина каретки
            float cartHeight = Height * 0.0563f; // Высота каретки
            float cartX = (float)(craneSimulator.x / craneSimulator.beamSize * (craneWidth - cartWidth) + leftBoundary);
            float cartY = Height * 0.285f;
            g.DrawImage(cartImage, cartX, cartY, cartWidth, cartHeight);

            // Кран
            g.DrawImage(constructImage, Width * -0.19f, Height * -0.185f, Width * 1.168f, Height * 1.2346f);


            // Трос
            float ropeStartX = cartX + Width * 0.03f;
            float ropeStartY = Height * 0.338f;
            float ropeEndX = (float)(ropeStartX + Math.Sin(craneSimulator.y) * visualLength);
            float ropeEndY = (float)(ropeStartY + Math.Cos(craneSimulator.y) * visualLength);
            g.DrawLine(new Pen(Color.Black, 2), ropeStartX, ropeStartY, ropeEndX, ropeEndY);

            // Контейнер (груз)
            g.DrawImage(containerImage, ropeEndX - Width * 0.03f, ropeEndY - Height * 0.028f, Width * 0.0584f, Height * 0.0563f);

            // Грузовой корабль
            g.DrawImage(cargoImage, Width * 0.64f, Height * 0.206f, Width, Height);

            // Платформа
            float platformWidth = Width * 0.102f;
            float platformHeight = Height * 0.047f;
            float platformX = (float)(craneSimulator.platformPosition / craneSimulator.beamSize * craneWidth + leftBoundary + Width * 0.022f);
            float platformY = Height - Height * 0.0844f;
            g.DrawImage(platformImage, platformX, platformY, platformWidth, platformHeight);

            // Отображение текущих параметров
            using (Font font = new Font("Roboto", 10))
            {
                g.DrawString($"Позиция: {craneSimulator.x:F2} м", font, Brushes.Black, 10, 10);
                g.DrawString($"Угол: {craneSimulator.y * 180 / Math.PI:F2}°", font, Brushes.Black, 10, 30);
            }
        }


        private void OnResize(object sender, EventArgs e)
        {
            if (grafx != null)
            {
                grafx.Dispose();
            }
            grafx = context.Allocate(CreateGraphics(), DisplayRectangle);
            Invalidate();

        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "VisualCrane";
            this.Size = new System.Drawing.Size(460, 330);
            this.ResumeLayout(false);

        }
    }

}
