﻿namespace Aula_9
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listViewClientes = new ListView();
            button1 = new Button();
            SuspendLayout();
            // 
            // listViewClientes
            // 
            listViewClientes.Location = new Point(127, 47);
            listViewClientes.Name = "listViewClientes";
            listViewClientes.Size = new Size(548, 238);
            listViewClientes.TabIndex = 0;
            listViewClientes.UseCompatibleStateImageBehavior = false;
            listViewClientes.SelectedIndexChanged += listViewClientes_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(521, 325);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Excluir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listViewClientes);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewClientes;
        private Button button1;
    }
}