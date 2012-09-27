using System;
using System.Windows.Forms;

using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace ZExeMaker
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Form1 : Form
    {
        bool ConsoleProject;
        bool WindowsProject;
        public Form1()
        {
            InitializeComponent();
            TextBox_TextEntry.Text = "using System;\nusing System.Drawing;\nusing System.Windows.Forms;\n\nclass MyForm : Form\n{\n     public MyForm()\n     {\n         this.Text = \"Hello World\";\n         this.StartPosition = FormStartPosition.CenterScreen;\n     }\n\n      public static void Main()\n      {\n          Application.Run(new MyForm());\n      }\n};\n";
            textBox_Name.Text = "MyProgram.exe";
            ConsoleProject = false;
            WindowsProject = true;
        }
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.TextBox_TextEntry = new System.Windows.Forms.RichTextBox();
            this.TextBox_ErrorWindow = new System.Windows.Forms.RichTextBox();
            this.button_Build = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.RadioButton_Console = new System.Windows.Forms.RadioButton();
            this.RadioButton_Window = new System.Windows.Forms.RadioButton();

            this.SuspendLayout();
            // 
            // TextBox_TextEntry
            // 
            this.TextBox_TextEntry.Location = new System.Drawing.Point(13, 13);
            this.TextBox_TextEntry.Name = "TextBox_TextEntry";
            this.TextBox_TextEntry.Size = new System.Drawing.Size(537, 241);
            this.TextBox_TextEntry.TabIndex = 0;
            this.TextBox_TextEntry.Text = "";
            this.TextBox_TextEntry.TextChanged += new System.EventHandler(this.TextBox_TextEntry_TextChanged);
            this.TextBox_TextEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_TextEntry_KeyDown);
            this.TextBox_TextEntry.WordWrap = false;
            // 
            // TextBox_ErrorWindow
            // 
            this.TextBox_ErrorWindow.Location = new System.Drawing.Point(13, 261);
            this.TextBox_ErrorWindow.Name = "TextBox_ErrorWindow";
            this.TextBox_ErrorWindow.Size = new System.Drawing.Size(257, 241);
            this.TextBox_ErrorWindow.TabIndex = 0;
            this.TextBox_ErrorWindow.Text = "";
            this.TextBox_ErrorWindow.TextChanged += new System.EventHandler(this.TextBox_TextEntry_TextChanged);
            // 
            // button_Build
            // 
            this.button_Build.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Build.Location = new System.Drawing.Point(276, 320);
            this.button_Build.Name = "button_Build";
            this.button_Build.Size = new System.Drawing.Size(275, 182);
            this.button_Build.TabIndex = 1;
            this.button_Build.Text = "COMPILE\nAND RUN";
            this.button_Build.UseVisualStyleBackColor = true;
            this.button_Build.Click += new System.EventHandler(this.button_Build_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(277, 261);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(274, 20);
            this.textBox_Name.TabIndex = 2;

            // 
            // radioButton1
            // 
            this.RadioButton_Console.AutoSize = true;
            this.RadioButton_Console.Location = new System.Drawing.Point(276, 287);
            this.RadioButton_Console.Name = "RadioButton_Console";
            this.RadioButton_Console.Size = new System.Drawing.Size(85, 17);
            this.RadioButton_Console.TabIndex = 0;
            this.RadioButton_Console.TabStop = true;
            this.RadioButton_Console.Text = "Console";
            this.RadioButton_Console.UseVisualStyleBackColor = true;
            this.RadioButton_Console.CheckedChanged += new System.EventHandler(this.RadioButton_Console_CheckedChanged);

            this.RadioButton_Window.AutoSize = true;
            this.RadioButton_Window.Location = new System.Drawing.Point(350, 287);
            this.RadioButton_Window.Name = "RadioButton_Window";
            this.RadioButton_Window.Size = new System.Drawing.Size(85, 17);
            this.RadioButton_Window.TabIndex = 0;
            this.RadioButton_Window.TabStop = true;
            this.RadioButton_Window.Text = "Window";
            this.RadioButton_Window.UseVisualStyleBackColor = true;
            this.RadioButton_Window.CheckedChanged += new System.EventHandler(this.RadioButton_Window_CheckedChanged);
            this.RadioButton_Window.Checked = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 520);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.button_Build);
            this.Controls.Add(this.TextBox_TextEntry);
            this.Controls.Add(this.TextBox_ErrorWindow);
            this.Controls.Add(this.RadioButton_Console);
            this.Controls.Add(this.RadioButton_Window);
            this.Name = "Form1";
            this.Text = "Visual StudioZ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox_TextEntry;
        private System.Windows.Forms.RichTextBox TextBox_ErrorWindow;
        private System.Windows.Forms.Button button_Build;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.RadioButton RadioButton_Console;
        private System.Windows.Forms.RadioButton RadioButton_Window;

        private void TextBox_TextEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_TextEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F5)
                button_Build_Click(sender, e);
        }

        private void RadioButton_Console_CheckedChanged(object sender, EventArgs e)
        {
            ConsoleProject = !ConsoleProject;
        }

        private void RadioButton_Window_CheckedChanged(object sender, EventArgs e)
        {
            WindowsProject = !WindowsProject;
        }

        private void button_Build_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
            ICodeCompiler myCodeCompiler = new CSharpCodeProvider().CreateCompiler();

            String[] referenceAssemblies = { "System.dll" };
            CompilerParameters cp = new CompilerParameters(referenceAssemblies, textBox_Name.Text);

            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.xml.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("System.Runtime.Serialization.Formatters.Soap.dll");
            cp.ReferencedAssemblies.Add("system.drawing.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            cp.ReferencedAssemblies.Add("System.Web.Services.dll");
            cp.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            cp.TreatWarningsAsErrors = false;

            cp.GenerateExecutable = true;

            if(WindowsProject)
            cp.CompilerOptions = "/target:winexe /optimize";

            if (!WindowsProject && !ConsoleProject)
            {
                MessageBox.Show("You must specify the project type");
                return;
            }

            CompilerResults cr = myCodeCompiler.CompileAssemblyFromSource(cp, TextBox_TextEntry.Text);
            if(cr.Errors.Count > 0)
            {
                foreach (CompilerError ce in cr.Errors)
                {
                    TextBox_ErrorWindow.Text = ce.ToString() + "\n";

                }
            }
            
            else
            System.Diagnostics.Process.Start(textBox_Name.Text);
        }
    }
}
