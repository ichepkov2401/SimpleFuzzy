using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
    {

        private TextBox nameTextBox;
        private ComboBox baseSetComboBox;
        private ComboBox termsComboBox;
        private Button addTermButton;
        private PictureBox graphPictureBox;
        private ListView termsListView;
        private ColumnHeader CloseButton;
        private ColumnHeader TermName;
        private ColumnHeader TermColor;
        private Label SetProperty;
        private Label HeightLabel;
        private NumericUpDown NumericUpDown1;
        private TrackBar trackBar;
        private Label ObjectSetLabel;
        private Label FazificationDescription;

        private void InitializeComponent()
        {
            TermName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            TermColor = new ColumnHeader();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            baseSetLabel = new Label();
            baseSetComboBox = new ComboBox();
            termsLabel = new Label();
            termsComboBox = new ComboBox();
            addTermButton = new Button();
            graphLabel = new Label();
            graphPictureBox = new PictureBox();
            termsListView = new ListView();
            HeightLabel = new Label();
            NumericUpDown1 = new NumericUpDown();
            SetProperty = new Label();
            trackBar = new TrackBar();
            ObjectSetLabel = new Label();
            FazificationDescription = new Label();
            GenerateMembershipFunction = new Button();
            GenerateBaseSet = new Button();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // TermName
            // 
            TermName.Text = "Термы";
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // TermColor
            // 
            TermColor.Text = "";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(3, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(258, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя лингвистической переменной:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(3, 24);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(208, 27);
            nameTextBox.TabIndex = 1;
            nameTextBox.LostFocus += NameChangedHandler;
            // 
            // baseSetLabel
            // 
            baseSetLabel.AutoSize = true;
            baseSetLabel.Location = new Point(11, 48);
            baseSetLabel.Name = "baseSetLabel";
            baseSetLabel.Size = new Size(152, 20);
            baseSetLabel.TabIndex = 2;
            baseSetLabel.Text = "Базовое множество:";
            // 
            // baseSetComboBox
            // 
            baseSetComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            baseSetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baseSetComboBox.ItemHeight = 23;
            baseSetComboBox.Location = new Point(3, 68);
            baseSetComboBox.Name = "baseSetComboBox";
            baseSetComboBox.Size = new Size(208, 29);
            baseSetComboBox.TabIndex = 3;
            baseSetComboBox.SelectedIndexChanged += BaseSetChange;
            // 
            // termsLabel
            // 
            termsLabel.AutoSize = true;
            termsLabel.Location = new Point(11, 98);
            termsLabel.Name = "termsLabel";
            termsLabel.Size = new Size(59, 20);
            termsLabel.TabIndex = 4;
            termsLabel.Text = "Термы:";
            // 
            // termsComboBox
            // 
            termsComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            termsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            termsComboBox.ItemHeight = 23;
            termsComboBox.Location = new Point(3, 118);
            termsComboBox.Name = "termsComboBox";
            termsComboBox.Size = new Size(208, 29);
            termsComboBox.TabIndex = 5;
            // 
            // addTermButton
            // 
            addTermButton.Location = new Point(3, 148);
            addTermButton.Name = "addTermButton";
            addTermButton.Size = new Size(208, 33);
            addTermButton.TabIndex = 6;
            addTermButton.Text = "Добавить терм";
            addTermButton.Click += AddTermButton_Click;
            // 
            // graphLabel
            // 
            graphLabel.Location = new Point(0, 0);
            graphLabel.Name = "graphLabel";
            graphLabel.Size = new Size(100, 23);
            graphLabel.TabIndex = 7;
            // 
            // graphPictureBox
            // 
            graphPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graphPictureBox.Location = new Point(263, 3);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(426, 264);
            graphPictureBox.TabIndex = 8;
            graphPictureBox.TabStop = false;
            // 
            // termsListView
            // 
            termsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            termsListView.Columns.AddRange(new ColumnHeader[] { TermName, TermColor, CloseButton });
            termsListView.FullRowSelect = true;
            termsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            termsListView.Location = new Point(3, 186);
            termsListView.Margin = new Padding(3, 2, 3, 2);
            termsListView.Name = "termsListView";
            termsListView.Size = new Size(208, 285);
            termsListView.TabIndex = 1;
            termsListView.UseCompatibleStateImageBehavior = false;
            termsListView.View = System.Windows.Forms.View.Details;
            termsListView.SelectedIndexChanged += termView_SelectedIndexChanged;
            termsListView.MouseDoubleClick += termsListView_MouseDoubleClick;
            // 
            // HeightLabel
            // 
            HeightLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            HeightLabel.Location = new Point(259, 334);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(125, 20);
            HeightLabel.TabIndex = 10;
            HeightLabel.Text = "Высота сечения: ";
            HeightLabel.Visible = false;
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            NumericUpDown1.DecimalPlaces = 2;
            NumericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericUpDown1.Location = new Point(390, 332);
            NumericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(150, 27);
            NumericUpDown1.TabIndex = 11;
            NumericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            NumericUpDown1.Visible = false;
            NumericUpDown1.ValueChanged += termView_SelectedIndexChanged;
            // 
            // SetProperty
            // 
            SetProperty.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SetProperty.Location = new Point(263, 362);
            SetProperty.Name = "SetProperty";
            SetProperty.Size = new Size(426, 100);
            SetProperty.TabIndex = 9;
            // 
            // trackBar
            // 
            trackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            trackBar.Location = new Point(263, 273);
            trackBar.Maximum = 100;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(215, 56);
            trackBar.TabIndex = 12;
            trackBar.Value = 50;
            trackBar.ValueChanged += FazificationObjectChaged;
            // 
            // ObjectSetLabel
            // 
            ObjectSetLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ObjectSetLabel.Location = new Point(484, 273);
            ObjectSetLabel.Name = "ObjectSetLabel";
            ObjectSetLabel.Size = new Size(115, 30);
            ObjectSetLabel.TabIndex = 13;
            // 
            // FazificationDescription
            // 
            FazificationDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FazificationDescription.Location = new Point(259, 308);
            FazificationDescription.Name = "FazificationDescription";
            FazificationDescription.Size = new Size(430, 21);
            FazificationDescription.TabIndex = 14;
            // 
            // GenerateMembershipFunction
            // 
            GenerateMembershipFunction.Location = new Point(217, 118);
            GenerateMembershipFunction.Name = "GenerateMembershipFunction";
            GenerateMembershipFunction.Size = new Size(38, 29);
            GenerateMembershipFunction.TabIndex = 15;
            GenerateMembershipFunction.Text = "+";
            GenerateMembershipFunction.Click += GenerateMembershipFunction_Click;
            // 
            // GenerateBaseSet
            // 
            GenerateBaseSet.Location = new Point(217, 68);
            GenerateBaseSet.Name = "GenerateBaseSet";
            GenerateBaseSet.Size = new Size(38, 29);
            GenerateBaseSet.TabIndex = 16;
            GenerateBaseSet.Text = "+";
            GenerateBaseSet.Click += GenerateBaseSet_Click;
            // 
            // LinguisticVariableUI
            // 
            Controls.Add(NumericUpDown1);
            Controls.Add(HeightLabel);
            Controls.Add(SetProperty);
            Controls.Add(ObjectSetLabel);
            Controls.Add(FazificationDescription);
            Controls.Add(GenerateBaseSet);
            Controls.Add(GenerateMembershipFunction);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(baseSetLabel);
            Controls.Add(baseSetComboBox);
            Controls.Add(termsLabel);
            Controls.Add(termsComboBox);
            Controls.Add(addTermButton);
            Controls.Add(graphLabel);
            Controls.Add(graphPictureBox);
            Controls.Add(termsListView);
            Controls.Add(trackBar);
            Name = "LinguisticVariableUI";
            Size = new Size(694, 473);
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label nameLabel;
        private Label baseSetLabel;
        private Label termsLabel;
        private Label graphLabel;
        private Button GenerateMembershipFunction;
        private Button GenerateBaseSet;
    }
}