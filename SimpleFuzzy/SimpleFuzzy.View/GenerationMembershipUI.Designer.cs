﻿
using OxyPlot.WindowsForms;

namespace SimpleFuzzy.View
{
    partial class GenerationMembershipUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBoxSettings = new GroupBox();
            labelBaseSet = new Label();
            comboBoxBaseSet = new ComboBox();
            groupBoxConditions = new GroupBox();
            panelConditions = new Panel();
            buttonAddCondition = new Button();
            groupBoxActions = new GroupBox();
            buttonGenerateCode = new Button();
            buttonVisualize = new Button();
            splitContainer = new SplitContainer();
            textBoxGeneratedCode = new TextBox();
            plotView = new PlotView();
            groupBoxSettings.SuspendLayout();
            groupBoxConditions.SuspendLayout();
            groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSettings
            // 
            groupBoxSettings.Controls.Add(labelBaseSet);
            groupBoxSettings.Controls.Add(comboBoxBaseSet);
            groupBoxSettings.Location = new Point(16, 19);
            groupBoxSettings.Margin = new Padding(5);
            groupBoxSettings.Name = "groupBoxSettings";
            groupBoxSettings.Padding = new Padding(5);
            groupBoxSettings.Size = new Size(400, 89);
            groupBoxSettings.TabIndex = 0;
            groupBoxSettings.TabStop = false;
            groupBoxSettings.Text = "Настройки";
            // 
            // labelBaseSet
            // 
            labelBaseSet.AutoSize = true;
            labelBaseSet.Location = new Point(8, 27);
            labelBaseSet.Margin = new Padding(5, 0, 5, 0);
            labelBaseSet.MaximumSize = new Size(133, 0);
            labelBaseSet.Name = "labelBaseSet";
            labelBaseSet.Size = new Size(90, 40);
            labelBaseSet.TabIndex = 2;
            labelBaseSet.Text = "Базовое множество:";
            // 
            // comboBoxBaseSet
            // 
            comboBoxBaseSet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaseSet.FormattingEnabled = true;
            comboBoxBaseSet.Location = new Point(166, 27);
            comboBoxBaseSet.Margin = new Padding(5);
            comboBoxBaseSet.Name = "comboBoxBaseSet";
            comboBoxBaseSet.Size = new Size(225, 28);
            comboBoxBaseSet.TabIndex = 3;
            // 
            // groupBoxConditions
            // 
            groupBoxConditions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxConditions.Controls.Add(panelConditions);
            groupBoxConditions.Controls.Add(buttonAddCondition);
            groupBoxConditions.Location = new Point(16, 119);
            groupBoxConditions.Margin = new Padding(5);
            groupBoxConditions.Name = "groupBoxConditions";
            groupBoxConditions.Padding = new Padding(5);
            groupBoxConditions.Size = new Size(400, 381);
            groupBoxConditions.TabIndex = 1;
            groupBoxConditions.TabStop = false;
            groupBoxConditions.Text = "Условия";
            // 
            // panelConditions
            // 
            panelConditions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelConditions.AutoScroll = true;
            panelConditions.Location = new Point(8, 29);
            panelConditions.Margin = new Padding(5);
            panelConditions.Name = "panelConditions";
            panelConditions.Size = new Size(384, 298);
            panelConditions.TabIndex = 0;
            // 
            // buttonAddCondition
            // 
            buttonAddCondition.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCondition.Location = new Point(9, 336);
            buttonAddCondition.Margin = new Padding(5);
            buttonAddCondition.Name = "buttonAddCondition";
            buttonAddCondition.Size = new Size(384, 35);
            buttonAddCondition.TabIndex = 1;
            buttonAddCondition.Text = "Добавить условие";
            buttonAddCondition.UseVisualStyleBackColor = true;
            buttonAddCondition.Click += buttonAddCondition_Click;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxActions.Controls.Add(buttonGenerateCode);
            groupBoxActions.Controls.Add(buttonVisualize);
            groupBoxActions.Location = new Point(16, 502);
            groupBoxActions.Margin = new Padding(5);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Padding = new Padding(5);
            groupBoxActions.Size = new Size(400, 85);
            groupBoxActions.TabIndex = 2;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Действия";
            // 
            // buttonGenerateCode
            // 
            buttonGenerateCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGenerateCode.Location = new Point(8, 29);
            buttonGenerateCode.Margin = new Padding(5);
            buttonGenerateCode.Name = "buttonGenerateCode";
            buttonGenerateCode.Size = new Size(187, 35);
            buttonGenerateCode.TabIndex = 0;
            buttonGenerateCode.Text = "Сгенерировать";
            buttonGenerateCode.UseVisualStyleBackColor = true;
            buttonGenerateCode.Click += buttonGenerateCode_Click;
            // 
            // buttonVisualize
            // 
            buttonVisualize.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonVisualize.Location = new Point(203, 29);
            buttonVisualize.Margin = new Padding(5);
            buttonVisualize.Name = "buttonVisualize";
            buttonVisualize.Size = new Size(187, 35);
            buttonVisualize.TabIndex = 1;
            buttonVisualize.Text = "Сохранить";
            buttonVisualize.UseVisualStyleBackColor = true;
            buttonVisualize.Click += buttonVisualize_Click;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(424, 19);
            splitContainer.Margin = new Padding(5);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textBoxGeneratedCode);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(plotView);
            splitContainer.Size = new Size(605, 568);
            splitContainer.SplitterDistance = 284;
            splitContainer.SplitterWidth = 5;
            splitContainer.TabIndex = 3;
            // 
            // textBoxGeneratedCode
            // 
            textBoxGeneratedCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxGeneratedCode.Location = new Point(5, 5);
            textBoxGeneratedCode.Margin = new Padding(5);
            textBoxGeneratedCode.Multiline = true;
            textBoxGeneratedCode.Name = "textBoxGeneratedCode";
            textBoxGeneratedCode.ReadOnly = true;
            textBoxGeneratedCode.ScrollBars = ScrollBars.Vertical;
            textBoxGeneratedCode.Size = new Size(595, 274);
            textBoxGeneratedCode.TabIndex = 0;
            // 
            // plotView
            // 
            plotView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            plotView.Location = new Point(5, 3);
            plotView.Name = "plotView";
            plotView.PanCursor = Cursors.Hand;
            plotView.Size = new Size(595, 272);
            plotView.TabIndex = 1;
            plotView.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // GenerationMembershipUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxConditions);
            Controls.Add(groupBoxSettings);
            Margin = new Padding(5);
            MinimumSize = new Size(1061, 605);
            Name = "GenerationMembershipUI";
            Size = new Size(1061, 605);
            groupBoxSettings.ResumeLayout(false);
            groupBoxSettings.PerformLayout();
            groupBoxConditions.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label labelBaseSet;
        private System.Windows.Forms.GroupBox groupBoxConditions;
        private System.Windows.Forms.Panel panelConditions;
        private System.Windows.Forms.Button buttonAddCondition;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonGenerateCode;
        private System.Windows.Forms.Button buttonVisualize;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBoxGeneratedCode;
        private OxyPlot.WindowsForms.PlotView plotView;
        private ComboBox comboBoxBaseSet;
    }
}

