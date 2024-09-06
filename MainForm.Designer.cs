namespace TaskManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbDescription = new TextBox();
            labelDescription = new Label();
            buttonAdd = new Button();
            buttonRemove = new Button();
            buttonRun = new Button();
            buttonFinish = new Button();
            lbTasks = new ListBox();
            lblFeedback = new Label();
            SuspendLayout();
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(163, 13);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(432, 27);
            tbDescription.TabIndex = 0;
            tbDescription.KeyDown += tbDescription_KeyDown;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(12, 16);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(141, 20);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Descrição da tarefa:";
            labelDescription.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonAdd
            // 
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(601, 12);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(187, 29);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Adicionar";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(16, 409);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(195, 29);
            buttonRemove.TabIndex = 3;
            buttonRemove.Text = "Remover tarefa";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonRun
            // 
            buttonRun.Enabled = false;
            buttonRun.Location = new Point(593, 409);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(195, 29);
            buttonRun.TabIndex = 4;
            buttonRun.Text = "Iniciar tarefa";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Visible = false;
            buttonRun.Click += buttonRunning_Click;
            // 
            // buttonFinish
            // 
            buttonFinish.Enabled = false;
            buttonFinish.Location = new Point(593, 409);
            buttonFinish.Name = "buttonFinish";
            buttonFinish.Size = new Size(195, 29);
            buttonFinish.TabIndex = 4;
            buttonFinish.Text = "Marcar como concluida";
            buttonFinish.UseVisualStyleBackColor = true;
            buttonFinish.Visible = false;
            buttonFinish.Click += buttonFinish_Click;
            // 
            // lbTasks
            // 
            lbTasks.FormattingEnabled = true;
            lbTasks.Location = new Point(16, 64);
            lbTasks.Name = "lbTasks";
            lbTasks.Size = new Size(772, 304);
            lbTasks.TabIndex = 5;
            lbTasks.SelectedIndexChanged += lbTasks_SelectedIndexChanged;
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Location = new Point(16, 371);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(0, 20);
            lblFeedback.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFeedback);
            Controls.Add(lbTasks);
            Controls.Add(buttonFinish);
            Controls.Add(buttonRun);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(labelDescription);
            Controls.Add(tbDescription);
            Name = "MainForm";
            Text = "Gerenciador de tarefas (not system)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbDescription;
        private Label labelDescription;
        private Button buttonAdd;
        private Button buttonRemove;
        private Button buttonFinish;
        private Button buttonRun;
        private ListBox lbTasks;
        private Label lblFeedback;
    }
}
