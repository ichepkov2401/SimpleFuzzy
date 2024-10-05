﻿using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Models.SimulatorCrane
{
    public partial class FromOfSimulator : UserControl
    {
        private CraneSimulator simulator;
        private VisualCrane visualCrane;
        private System.Windows.Forms.Timer timer;
        private bool isSimulationRunning = false;

        public FromOfSimulator()
        {
            InitializeComponent();
            SetupControls();

            timer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            timer.Tick += TimerTick;
        }

        public FromOfSimulator(CraneSimulator crane)
        {
            simulator = crane;
            InitializeComponent();
            visualCrane = new VisualCrane(crane);
            cranePanel.Controls.Add(visualCrane);
            SetupControls();
            timer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                forceTrackBar.Enabled = false;
                forceTrackBar.Value = Convert.ToInt32(simulator.GetFunc(new List<object>() {
                    Math.Round((double)numPlatformPosition.Value - simulator.x, 2),
                    (int)Math.Round(simulator.y)
                })[0]);
            }
            else
            {
                forceTrackBar.Enabled = true;
            }
            simulator.Step();
            if (simulator.x <= 0 || simulator.x >= simulator.beamSize || Math.Abs(simulator.y) >= CraneSimulator.MAX_ANGLE)
            {
                timer.Stop();
                string message = (simulator.x <= 0 || simulator.x >= simulator.beamSize) ? "Каретка достигла края платформы!" : "Контейнер запрокинулся!";
                MessageBox.Show(message);
                Reset();
            }
            visualCrane.Invalidate();
        }
        public void Reset()
        {
            simulator.x = (double)numInitialPosition.Value;
            simulator.y = (double)numInitialAngle.Value * Math.PI / 180;
            simulator.dx = simulator.dy = simulator.f = 0;
            simulator.platformPosition = (double)numPlatformPosition.Value;
            visualCrane.Invalidate();
        }

        // Изменения значений 
        private void forceTrackBar_ValueChanged(object sender, EventArgs e) => simulator.f = forceTrackBar.Value;
        private void numBeamSize_ValueChanged(object sender, EventArgs e)
        {
            simulator.beamSize = (double)numBeamSize.Value;
            numInitialPosition.Maximum = numBeamSize.Value;
            numPlatformPosition.Maximum = Math.Min(numBeamSize.Value * 0.525M, numBeamSize.Value - 1);
            if (numPlatformPosition.Value > numPlatformPosition.Maximum) numPlatformPosition.Value = numPlatformPosition.Maximum;
            Invalidate();
        }
        private void numPlatformPosition_ValueChanged(object sender, EventArgs e)
        {
            simulator.platformPosition = (double)numPlatformPosition.Value;
            Invalidate();
        }

        // потом доработать
        private void CheckCargoLoading()
        {
            double containerBottom = simulator.y + simulator.l * Math.Cos(simulator.y);
            double platformHeight = 0.5;

            if (Math.Abs(containerBottom - platformHeight) < 0.1 &&
                simulator.x >= simulator.platformPosition &&
                simulator.x <= simulator.platformPosition + 5 &&
                Math.Abs(simulator.y) < 0.1 &&
                Math.Abs(simulator.x / simulator.beamSize) < 0.1)
            {
                MessageBox.Show("Груз успешно установлен на платформу!", "Успешная загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        private void SetupControls()
        {
            // Настройка стилей для элементов управления
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Roboto", 10F);
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(52, 152, 219);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Roboto", 10F, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                }
            }


            void AddAdaptiveLabel(string text, Control control)
            {
                Label label = new Label();
                label.Text = text;
                label.AutoSize = true;
                label.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                label.Dock = DockStyle.None;

                label.Location = new Point(control.Left, control.Top - 20);

                this.Controls.Add(label);
            }

            AddAdaptiveLabel("Масса маятника (кг):", numMassPendulum);
            AddAdaptiveLabel("Масса каретки (кг):", numMassCart);
            AddAdaptiveLabel("Длина маятника (м):", numLengthPendulum);
            AddAdaptiveLabel("Коэф. торможения каретки:", numDampingCart);
            AddAdaptiveLabel("Коэф. затухания колебаний:", numDampingPendulum);
            AddAdaptiveLabel("Начальная позиция:", numInitialPosition);
            AddAdaptiveLabel("Начальный угол:", numInitialAngle);
            AddAdaptiveLabel("Размер балки (м):", numBeamSize);
            AddAdaptiveLabel("Передвижение каретки:", forceTrackBar);
            AddAdaptiveLabel("Позиция платформы:", numPlatformPosition);


            // Установка начальных значений
            SetInitialValues();
        }

        private void AddLabel(string text, Control control)
        {
            Label label = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(control.Left, control.Top - 20)
            };
            Controls.Add(label);
        }

        private void SetInitialValues()
        {
            numBeamSize.Value = (decimal)simulator.beamSize;
            numInitialPosition.Value = (decimal)simulator.initPositionX;
            numInitialAngle.Value = (decimal)simulator.initPositionY;
            numDampingCart.Value = (decimal)simulator.k1;
            numDampingPendulum.Value = (decimal)simulator.k2;
            numLengthPendulum.Value = (decimal)simulator.l;
            numMassCart.Value = (decimal)simulator.M;
            numMassPendulum.Value = (decimal)simulator.m;

            numPlatformPosition.Value = (decimal)simulator.platformPosition;
            numPlatformPosition.Minimum = 0;
            numPlatformPosition.Maximum = numBeamSize.Value * 0.525M;
            numInitialPosition.Minimum = 0;
            numInitialPosition.Maximum = numBeamSize.Value;

            Reset();

            // Настройка обработчиков событий
            numMassPendulum.ValueChanged += UpdateSimulatorParameters;
            numMassCart.ValueChanged += UpdateSimulatorParameters;
            numLengthPendulum.ValueChanged += UpdateSimulatorParameters;
            numDampingCart.ValueChanged += UpdateSimulatorParameters;
            numDampingPendulum.ValueChanged += UpdateSimulatorParameters;
            numInitialPosition.ValueChanged += UpdateSimulatorParameters;
            numInitialAngle.ValueChanged += UpdateSimulatorParameters;
            numBeamSize.ValueChanged += numBeamSize_ValueChanged;
            numPlatformPosition.ValueChanged += UpdateSimulatorParameters;

        }

        private void UpdateSimulatorParameters(object sender, EventArgs e)
        {
            if (!isSimulationRunning)
            {
                simulator.m = (double)numMassPendulum.Value;
                simulator.M = (double)numMassCart.Value;
                simulator.l = (double)numLengthPendulum.Value;
                simulator.k1 = (double)numDampingCart.Value;
                simulator.k2 = (double)numDampingPendulum.Value;
                simulator.x = (double)numInitialPosition.Value;
                simulator.y = (double)numInitialAngle.Value * Math.PI / 180;
                simulator.platformPosition = (double)numPlatformPosition.Value;

                simulator.initPositionX = (double)numInitialPosition.Value;
                simulator.initPositionY = (double)numInitialAngle.Value;
                simulator.beamSize = (double)numBeamSize.Value;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            isSimulationRunning = true;
            DisableControls();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isSimulationRunning = false;
            EnableControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Reset();
            isSimulationRunning = false;
            EnableControls();
            forceTrackBar.Value = 0;
        }

        private void DisableControls()
        {
            numMassPendulum.Enabled = false;
            numMassCart.Enabled = false;
            numLengthPendulum.Enabled = false;
            numDampingCart.Enabled = false;
            numDampingPendulum.Enabled = false;
            numInitialPosition.Enabled = false;
            numInitialAngle.Enabled = false;
            numBeamSize.Enabled = false;
            numPlatformPosition.Enabled = false;
        }

        private void EnableControls()
        {
            numMassPendulum.Enabled = true;
            numMassCart.Enabled = true;
            numLengthPendulum.Enabled = true;
            numDampingCart.Enabled = true;
            numDampingPendulum.Enabled = true;
            numInitialPosition.Enabled = true;
            numInitialAngle.Enabled = true;
            numBeamSize.Enabled = true;
            numPlatformPosition.Enabled = true;
        }
    }
}
