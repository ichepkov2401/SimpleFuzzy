using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
    {

        private TextBox nameTextBox;
        private MetroComboBox baseSetComboBox;
        private MetroComboBox termsComboBox;
        private MetroButton addTermButton;
        private PictureBox graphPictureBox;
        private ListView termsListView;
        private ColumnHeader CloseButton;
        private ColumnHeader TermName;
        private ColumnHeader TermColor;
        private MetroLabel SetProperty;
        private MetroLabel HeightLabel;
        private NumericUpDown NumericUpDown1;
        private MetroTrackBar trackBar;
        private MetroLabel ObjectSetLabel;
        private MetroLabel FazificationDescription;

        private void InitializeComponent()
        {
            TermName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            TermColor = new ColumnHeader();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            baseSetLabel = new Label();
            baseSetComboBox = new MetroComboBox();
            termsLabel = new Label();
            termsComboBox = new MetroComboBox();
            addTermButton = new MetroButton();
            graphLabel = new Label();
            graphPictureBox = new PictureBox();
            termsListView = new ListView();
            HeightLabel = new MetroLabel();
            NumericUpDown1 = new NumericUpDown();
            SetProperty = new MetroLabel();
            trackBar = new MetroTrackBar();
            ObjectSetLabel = new MetroLabel();
            FazificationDescription = new MetroLabel();
            GenerateMembershipFunction = new MetroButton();
            GenerateBaseSet = new MetroButton();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
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
            nameLabel.Location = new Point(0, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(205, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя лингвистической переменной:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(0, 24);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 23);
            nameTextBox.TabIndex = 1;
            nameTextBox.LostFocus += NameChangedHandler;
            // 
            // baseSetLabel
            // 
            baseSetLabel.AutoSize = true;
            baseSetLabel.Location = new Point(0, 50);
            baseSetLabel.Name = "baseSetLabel";
            baseSetLabel.Size = new Size(119, 15);
            baseSetLabel.TabIndex = 2;
            baseSetLabel.Text = "Базовое множество:";
            // 
            // baseSetComboBox
            // 
            baseSetComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            baseSetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            baseSetComboBox.FontSize = MetroFramework.MetroLinkSize.Medium;
            baseSetComboBox.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            baseSetComboBox.ItemHeight = 23;
            baseSetComboBox.Location = new Point(0, 68);
            baseSetComboBox.Name = "baseSetComboBox";
            baseSetComboBox.Size = new Size(200, 29);
            baseSetComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            baseSetComboBox.StyleManager = null;
            baseSetComboBox.TabIndex = 3;
            baseSetComboBox.Theme = MetroFramework.MetroThemeStyle.Light;
            baseSetComboBox.SelectedIndexChanged += BaseSetChange;
            // 
            // termsLabel
            // 
            termsLabel.AutoSize = true;
            termsLabel.Location = new Point(0, 100);
            termsLabel.Name = "termsLabel";
            termsLabel.Size = new Size(47, 15);
            termsLabel.TabIndex = 4;
            termsLabel.Text = "Термы:";
            // 
            // termsComboBox
            // 
            termsComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            termsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            termsComboBox.FontSize = MetroFramework.MetroLinkSize.Medium;
            termsComboBox.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            termsComboBox.ItemHeight = 23;
            termsComboBox.Location = new Point(0, 118);
            termsComboBox.Name = "termsComboBox";
            termsComboBox.Size = new Size(200, 29);
            termsComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            termsComboBox.StyleManager = null;
            termsComboBox.TabIndex = 5;
            termsComboBox.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // addTermButton
            // 
            addTermButton.Highlight = false;
            addTermButton.Location = new Point(0, 148);
            addTermButton.Name = "addTermButton";
            addTermButton.Size = new Size(200, 23);
            addTermButton.Style = MetroFramework.MetroColorStyle.Blue;
            addTermButton.StyleManager = null;
            addTermButton.TabIndex = 6;
            addTermButton.Text = "Добавить терм";
            addTermButton.Theme = MetroFramework.MetroThemeStyle.Light;
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
            graphPictureBox.Location = new Point(250, 3);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(430, 221);
            graphPictureBox.TabIndex = 8;
            graphPictureBox.TabStop = false;
            // 
            // termsListView
            // 
            termsListView.Columns.AddRange(new ColumnHeader[] { TermName, TermColor, CloseButton });
            termsListView.FullRowSelect = true;
            termsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            termsListView.Location = new Point(0, 176);
            termsListView.Margin = new Padding(3, 2, 3, 2);
            termsListView.Name = "termsListView";
            termsListView.Size = new Size(200, 252);
            termsListView.TabIndex = 1;
            termsListView.UseCompatibleStateImageBehavior = false;
            termsListView.View = System.Windows.Forms.View.Details;
            termsListView.SelectedIndexChanged += termView_SelectedIndexChanged;
            termsListView.MouseDoubleClick += termsListView_MouseDoubleClick;
            // 
            // HeightLabel
            // 
            HeightLabel.CustomBackground = false;
            HeightLabel.FontSize = MetroFramework.MetroLabelSize.Medium;
            HeightLabel.FontWeight = MetroFramework.MetroLabelWeight.Light;
            HeightLabel.LabelMode = MetroLabelMode.Default;
            HeightLabel.Location = new Point(250, 293);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(115, 20);
            HeightLabel.Style = MetroFramework.MetroColorStyle.Blue;
            HeightLabel.StyleManager = null;
            HeightLabel.TabIndex = 10;
            HeightLabel.Text = "Высота сечения: ";
            HeightLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            HeightLabel.UseStyleColors = false;
            HeightLabel.Visible = false;
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.DecimalPlaces = 2;
            NumericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericUpDown1.Location = new Point(371, 290);
            NumericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(150, 23);
            NumericUpDown1.TabIndex = 11;
            NumericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            NumericUpDown1.Visible = false;
            NumericUpDown1.ValueChanged += termView_SelectedIndexChanged;
            // 
            // SetProperty
            // 
            SetProperty.CustomBackground = false;
            SetProperty.FontSize = MetroFramework.MetroLabelSize.Medium;
            SetProperty.FontWeight = MetroFramework.MetroLabelWeight.Light;
            SetProperty.LabelMode = MetroLabelMode.Default;
            SetProperty.Location = new Point(250, 316);
            SetProperty.Name = "SetProperty";
            SetProperty.Size = new Size(430, 100);
            SetProperty.Style = MetroFramework.MetroColorStyle.Blue;
            SetProperty.StyleManager = null;
            SetProperty.TabIndex = 9;
            SetProperty.Theme = MetroFramework.MetroThemeStyle.Light;
            SetProperty.UseStyleColors = false;
            // 
            // trackBar
            // 
            trackBar.BackColor = Color.Transparent;
            trackBar.CustomBackground = false;
            trackBar.LargeChange = 5U;
            trackBar.Location = new Point(250, 230);
            trackBar.Maximum = 100;
            trackBar.Minimum = 0;
            trackBar.MouseWheelBarPartitions = 10;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(215, 30);
            trackBar.SmallChange = 1U;
            trackBar.Style = MetroFramework.MetroColorStyle.Blue;
            trackBar.StyleManager = null;
            trackBar.TabIndex = 12;
            trackBar.Theme = MetroFramework.MetroThemeStyle.Light;
            trackBar.Value = 50;
            trackBar.ValueChanged += FazificationObjectChaged;
            // 
            // ObjectSetLabel
            // 
            ObjectSetLabel.CustomBackground = false;
            ObjectSetLabel.FontSize = MetroFramework.MetroLabelSize.Medium;
            ObjectSetLabel.FontWeight = MetroFramework.MetroLabelWeight.Light;
            ObjectSetLabel.LabelMode = MetroLabelMode.Default;
            ObjectSetLabel.Location = new Point(471, 230);
            ObjectSetLabel.Name = "ObjectSetLabel";
            ObjectSetLabel.Size = new Size(115, 30);
            ObjectSetLabel.Style = MetroFramework.MetroColorStyle.Blue;
            ObjectSetLabel.StyleManager = null;
            ObjectSetLabel.TabIndex = 13;
            ObjectSetLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            ObjectSetLabel.UseStyleColors = false;
            // 
            // FazificationDescription
            // 
            FazificationDescription.CustomBackground = false;
            FazificationDescription.FontSize = MetroFramework.MetroLabelSize.Medium;
            FazificationDescription.FontWeight = MetroFramework.MetroLabelWeight.Light;
            FazificationDescription.LabelMode = MetroLabelMode.Default;
            FazificationDescription.Location = new Point(250, 263);
            FazificationDescription.Name = "FazificationDescription";
            FazificationDescription.Size = new Size(430, 20);
            FazificationDescription.Style = MetroFramework.MetroColorStyle.Blue;
            FazificationDescription.StyleManager = null;
            FazificationDescription.TabIndex = 14;
            FazificationDescription.Theme = MetroFramework.MetroThemeStyle.Light;
            FazificationDescription.UseStyleColors = false;
            // 
            // GenerateMembershipFunction
            // 
            GenerateMembershipFunction.Highlight = false;
            GenerateMembershipFunction.Location = new Point(206, 118);
            GenerateMembershipFunction.Name = "GenerateMembershipFunction";
            GenerateMembershipFunction.Size = new Size(38, 29);
            GenerateMembershipFunction.Style = MetroFramework.MetroColorStyle.Blue;
            GenerateMembershipFunction.StyleManager = null;
            GenerateMembershipFunction.TabIndex = 15;
            GenerateMembershipFunction.Text = "+";
            GenerateMembershipFunction.Theme = MetroFramework.MetroThemeStyle.Light;
            GenerateMembershipFunction.Click += GenerateMembershipFunction_Click;
            // 
            // GenerateBaseSet
            // 
            GenerateBaseSet.Highlight = false;
            GenerateBaseSet.Location = new Point(206, 68);
            GenerateBaseSet.Name = "GenerateBaseSet";
            GenerateBaseSet.Size = new Size(38, 29);
            GenerateBaseSet.Style = MetroFramework.MetroColorStyle.Blue;
            GenerateBaseSet.StyleManager = null;
            GenerateBaseSet.TabIndex = 16;
            GenerateBaseSet.Text = "+";
            GenerateBaseSet.Theme = MetroFramework.MetroThemeStyle.Light;
            GenerateBaseSet.Click += GenerateBaseSet_Click;
            // 
            // LinguisticVariableUI
            // 
            AutoSize = true;
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
            Controls.Add(SetProperty);
            Controls.Add(HeightLabel);
            Controls.Add(NumericUpDown1);
            Controls.Add(trackBar);
            Controls.Add(ObjectSetLabel);
            Controls.Add(FazificationDescription);
            Name = "LinguisticVariableUI";
            Size = new Size(1002, 430);
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label nameLabel;
        private Label baseSetLabel;
        private Label termsLabel;
        private Label graphLabel;
        private MetroButton GenerateMembershipFunction;
        private MetroButton GenerateBaseSet;
    }
}