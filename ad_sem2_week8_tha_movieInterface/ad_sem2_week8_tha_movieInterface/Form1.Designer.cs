namespace ad_sem2_week8_tha_movieInterface
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageListMovies = new System.Windows.Forms.ImageList(this.components);
            this.labelCoconutFilms = new System.Windows.Forms.Label();
            this.labelSurabaya = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // imageListMovies
            // 
            this.imageListMovies.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMovies.ImageStream")));
            this.imageListMovies.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMovies.Images.SetKeyName(0, "movie_air.jpg");
            this.imageListMovies.Images.SetKeyName(1, "movie_dungeonsanddragons.jpg");
            this.imageListMovies.Images.SetKeyName(2, "movie_johnwick4.jpg");
            this.imageListMovies.Images.SetKeyName(3, "movie_pelettalipocong.jpg");
            this.imageListMovies.Images.SetKeyName(4, "movie_rideon.jpg");
            this.imageListMovies.Images.SetKeyName(5, "movie_supermariobros.jpg");
            this.imageListMovies.Images.SetKeyName(6, "movie_thepopesexorcist.jpg");
            this.imageListMovies.Images.SetKeyName(7, "movie_tulah613.jpg");
            // 
            // labelCoconutFilms
            // 
            this.labelCoconutFilms.AutoSize = true;
            this.labelCoconutFilms.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCoconutFilms.Location = new System.Drawing.Point(245, 9);
            this.labelCoconutFilms.Name = "labelCoconutFilms";
            this.labelCoconutFilms.Size = new System.Drawing.Size(307, 51);
            this.labelCoconutFilms.TabIndex = 0;
            this.labelCoconutFilms.Text = "COCONUT 21";
            // 
            // labelSurabaya
            // 
            this.labelSurabaya.AutoSize = true;
            this.labelSurabaya.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSurabaya.Location = new System.Drawing.Point(336, 60);
            this.labelSurabaya.Name = "labelSurabaya";
            this.labelSurabaya.Size = new System.Drawing.Size(148, 29);
            this.labelSurabaya.TabIndex = 1;
            this.labelSurabaya.Text = "SURABAYA";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 505);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSurabaya);
            this.Controls.Add(this.labelCoconutFilms);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageListMovies;
        private System.Windows.Forms.Label labelCoconutFilms;
        private System.Windows.Forms.Label labelSurabaya;
        private System.Windows.Forms.Panel panel1;
    }
}

