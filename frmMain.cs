using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ShellID3Reader
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxFilePath;
		private System.Windows.Forms.Button cmdBrowseForFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdReadTags;
		private System.Windows.Forms.ListView listViewFiles;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
       
        //sorting
        private ListViewColumnSorter lvwColumnSorter;

        private void listViewFiles_ColumnClick(object o, System.Windows.Forms.ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewFiles.Sort();
        }

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			// sorting
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewFiles.ListViewItemSorter = lvwColumnSorter;
            this.listViewFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFiles_ColumnClick);
		}

        
        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.cmdBrowseForFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdReadTags = new System.Windows.Forms.Button();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePath.Location = new System.Drawing.Point(8, 28);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(996, 20);
            this.textBoxFilePath.TabIndex = 0;
            this.textBoxFilePath.Text = "Select a folder ....";
            // 
            // cmdBrowseForFolder
            // 
            this.cmdBrowseForFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseForFolder.Location = new System.Drawing.Point(1012, 24);
            this.cmdBrowseForFolder.Name = "cmdBrowseForFolder";
            this.cmdBrowseForFolder.Size = new System.Drawing.Size(56, 24);
            this.cmdBrowseForFolder.TabIndex = 1;
            this.cmdBrowseForFolder.Text = "...";
            this.cmdBrowseForFolder.Click += new System.EventHandler(this.cmdBrowseForFolder_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Path :";
            // 
            // cmdReadTags
            // 
            this.cmdReadTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdReadTags.Location = new System.Drawing.Point(924, 56);
            this.cmdReadTags.Name = "cmdReadTags";
            this.cmdReadTags.Size = new System.Drawing.Size(144, 24);
            this.cmdReadTags.TabIndex = 3;
            this.cmdReadTags.Text = "&Read Tags";
            this.cmdReadTags.Click += new System.EventHandler(this.cmdReadTags_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Location = new System.Drawing.Point(8, 88);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(1060, 384);
            this.listViewFiles.TabIndex = 4;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1076, 478);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.cmdReadTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdBrowseForFolder);
            this.Controls.Add(this.textBoxFilePath);
            this.Name = "frmMain";
            this.Text = "Read ID3 tags using Shell functions";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void cmdBrowseForFolder_Click(object sender, System.EventArgs e) {
			try{
				folderBrowserDialog.ShowDialog();
				textBoxFilePath.Text = folderBrowserDialog.SelectedPath;
			}
			catch{}
		}

    		private void cmdReadTags_Click(object sender, System.EventArgs e) {
			
			listViewFiles.Columns.Clear();
			listViewFiles.Items.Clear();
			listViewFiles.Columns.Add("FileName", 175,HorizontalAlignment.Left);
            listViewFiles.Columns.Add("FilePath", 325, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("ArtistNameFile", 100, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("SongTitleFile", 100, HorizontalAlignment.Left); 
			listViewFiles.Columns.Add("ArtistNameTag",100,HorizontalAlignment.Left); 
            listViewFiles.Columns.Add("SongTitleTag", 100, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("AlbumNameTag", 200, HorizontalAlignment.Left);
            listViewFiles.Columns.Add("TrackNumber",100,HorizontalAlignment.Left); 
            listViewFiles.Columns.Add("Mismatch",100,HorizontalAlignment.Left);

            listViewFiles.AllowColumnReorder = true;
            listViewFiles.FullRowSelect = true;

            //listViewFiles.CanSelect = true;

            
            
			//to do: catch the exception where an entered directory path does not exist.
			DirectoryInfo dir = new DirectoryInfo(textBoxFilePath.Text);
			DirectoryInfo[] directories = dir.GetDirectories("*.*",SearchOption.AllDirectories);
            FileInfo[] files;
            
            foreach(DirectoryInfo di in directories){
                
                files = dir.GetFiles("*.mp3");
                foreach (FileInfo fi in files)
                {
                    MP3File mp3File = ShellID3TagReader.ReadID3Tags(fi.FullName);
                    ListViewItem itm = new ListViewItem();
                    itm.Text = mp3File.FileName;
                    itm.SubItems.Add(mp3File.FilePath);
                    itm.SubItems.Add(mp3File.ArtistNameFromFile);
                    itm.SubItems.Add(mp3File.SongNameFromFile);
                    itm.SubItems.Add(mp3File.ArtistName);
                    itm.SubItems.Add(mp3File.SongTitle);
                    itm.SubItems.Add(mp3File.AlbumName);
                    itm.SubItems.Add(mp3File.TrackNumber.ToString()) ;

                    if (mp3File.DataMismatch)
                        itm.SubItems.Add("X");
                    else
                        itm.SubItems.Add("");

                    listViewFiles.Items.Add(itm);

                }
                dir = di;
			}
                //run through all the sub dirs, then process files in the final sub dir
                files = dir.GetFiles("*.mp3");
                foreach (FileInfo fi in files)
                {
                    MP3File mp3File = ShellID3TagReader.ReadID3Tags(fi.FullName);
                    ListViewItem itm = new ListViewItem();
                    itm.Text = mp3File.FileName;
                    itm.Text = mp3File.FileName;
                    itm.SubItems.Add(mp3File.FilePath);
                    itm.SubItems.Add(mp3File.ArtistNameFromFile);
                    itm.SubItems.Add(mp3File.SongNameFromFile);
                    itm.SubItems.Add(mp3File.ArtistName);
                    itm.SubItems.Add(mp3File.SongTitle);
                    itm.SubItems.Add(mp3File.AlbumName);
                    itm.SubItems.Add(mp3File.TrackNumber.ToString());

                    if (mp3File.DataMismatch)
                        itm.SubItems.Add("X");
                    else
                        itm.SubItems.Add("");

                    listViewFiles.Items.Add(itm);
                }

                //after loading try to sort by mismatch column 8
                //currently sorting by SongTitleTag column 5
                //to do: do not explictly call the sorter, it should run when a column header is clicked
               
                ColumnClickEventArgs ce = new ColumnClickEventArgs(8);
                listViewFiles_ColumnClick(listViewFiles, ce); 
		}
	}



    class ListViewColumnSorter : IComparer
    {

        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            if (OrderOfSort == SortOrder.Ascending)
                return compareResult;
            else if (OrderOfSort == SortOrder.Descending)
                return (-compareResult);
            else
                return 0;
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}