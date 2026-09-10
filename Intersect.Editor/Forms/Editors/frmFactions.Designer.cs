using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors
{
    partial class FrmFactions
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.grpFactions = new DarkUI.Controls.DarkGroupBox();
            this.btnClearSearch = new DarkUI.Controls.DarkButton();
            this.txtSearch = new DarkUI.Controls.DarkTextBox();
            this.lstGameObjects = new Intersect.Editor.Forms.Controls.GameObjectList();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.grpGeneral = new DarkUI.Controls.DarkGroupBox();
            this.btnAddFolder = new DarkUI.Controls.DarkButton();
            this.lblFolder = new System.Windows.Forms.Label();
            this.cmbFolder = new DarkUI.Controls.DarkComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.lblLeaderPlayerId = new System.Windows.Forms.Label();
            this.txtLeaderPlayerId = new DarkUI.Controls.DarkTextBox();
            this.lblWarCooldownHours = new System.Windows.Forms.Label();
            this.nudWarCooldownHours = new DarkUI.Controls.DarkNumericUpDown();
            this.grpAtWar = new DarkUI.Controls.DarkGroupBox();
            this.btnRemoveAtWar = new DarkUI.Controls.DarkButton();
            this.btnAddAtWar = new DarkUI.Controls.DarkButton();
            this.cmbAtWar = new DarkUI.Controls.DarkComboBox();
            this.lblAddAtWar = new System.Windows.Forms.Label();
            this.lstAtWar = new System.Windows.Forms.ListBox();
            this.toolStrip = new DarkUI.Controls.DarkToolStrip();
            this.toolStripItemNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlphabetical = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripItemPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripItemUndo = new System.Windows.Forms.ToolStripButton();
            this.grpFactions.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpAtWar.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(172, 27);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(132, 468);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(169, 27);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // grpFactions
            //
            this.grpFactions.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.grpFactions.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.grpFactions.Controls.Add(this.btnClearSearch);
            this.grpFactions.Controls.Add(this.txtSearch);
            this.grpFactions.Controls.Add(this.lstGameObjects);
            this.grpFactions.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpFactions.Location = new System.Drawing.Point(12, 36);
            this.grpFactions.Name = "grpFactions";
            this.grpFactions.Size = new System.Drawing.Size(203, 426);
            this.grpFactions.TabIndex = 22;
            this.grpFactions.TabStop = false;
            this.grpFactions.Text = "Factions";
            //
            // btnClearSearch
            //
            this.btnClearSearch.Location = new System.Drawing.Point(179, 16);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearSearch.Size = new System.Drawing.Size(18, 20);
            this.btnClearSearch.TabIndex = 25;
            this.btnClearSearch.Text = "X";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            //
            // txtSearch
            //
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.txtSearch.Location = new System.Drawing.Point(6, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(167, 20);
            this.txtSearch.TabIndex = 24;
            this.txtSearch.Text = "Search...";
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            //
            // lstGameObjects
            //
            this.lstGameObjects.AllowDrop = true;
            this.lstGameObjects.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            this.lstGameObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGameObjects.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstGameObjects.HideSelection = false;
            this.lstGameObjects.ImageIndex = 0;
            this.lstGameObjects.LineColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lstGameObjects.Location = new System.Drawing.Point(6, 42);
            this.lstGameObjects.Name = "lstGameObjects";
            this.lstGameObjects.SelectedImageIndex = 0;
            this.lstGameObjects.Size = new System.Drawing.Size(191, 378);
            this.lstGameObjects.TabIndex = 23;
            //
            // pnlContainer
            //
            this.pnlContainer.Controls.Add(this.grpGeneral);
            this.pnlContainer.Controls.Add(this.grpAtWar);
            this.pnlContainer.Location = new System.Drawing.Point(221, 36);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(265, 426);
            this.pnlContainer.TabIndex = 31;
            this.pnlContainer.Visible = false;
            //
            // grpGeneral
            //
            this.grpGeneral.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.grpGeneral.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.grpGeneral.Controls.Add(this.btnAddFolder);
            this.grpGeneral.Controls.Add(this.lblFolder);
            this.grpGeneral.Controls.Add(this.cmbFolder);
            this.grpGeneral.Controls.Add(this.lblName);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.lblLeaderPlayerId);
            this.grpGeneral.Controls.Add(this.txtLeaderPlayerId);
            this.grpGeneral.Controls.Add(this.lblWarCooldownHours);
            this.grpGeneral.Controls.Add(this.nudWarCooldownHours);
            this.grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpGeneral.Location = new System.Drawing.Point(7, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(250, 150);
            this.grpGeneral.TabIndex = 34;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            //
            // btnAddFolder
            //
            this.btnAddFolder.Location = new System.Drawing.Point(226, 44);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddFolder.Size = new System.Drawing.Size(18, 21);
            this.btnAddFolder.TabIndex = 23;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            //
            // lblFolder
            //
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(4, 48);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(39, 13);
            this.lblFolder.TabIndex = 22;
            this.lblFolder.Text = "Folder:";
            //
            // cmbFolder
            //
            this.cmbFolder.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            this.cmbFolder.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.cmbFolder.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFolder.ButtonColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.cmbFolder.DrawDropdownHoverOutline = false;
            this.cmbFolder.DrawFocusRectangle = false;
            this.cmbFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFolder.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(57, 44);
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(159, 21);
            this.cmbFolder.TabIndex = 21;
            this.cmbFolder.Text = null;
            this.cmbFolder.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Name:";
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.txtName.Location = new System.Drawing.Point(57, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(187, 20);
            this.txtName.TabIndex = 18;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            //
            // lblLeaderPlayerId
            //
            this.lblLeaderPlayerId.AutoSize = true;
            this.lblLeaderPlayerId.Location = new System.Drawing.Point(4, 76);
            this.lblLeaderPlayerId.Name = "lblLeaderPlayerId";
            this.lblLeaderPlayerId.Size = new System.Drawing.Size(90, 13);
            this.lblLeaderPlayerId.TabIndex = 24;
            this.lblLeaderPlayerId.Text = "Leader Player Id:";
            //
            // txtLeaderPlayerId
            //
            this.txtLeaderPlayerId.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            this.txtLeaderPlayerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeaderPlayerId.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.txtLeaderPlayerId.Location = new System.Drawing.Point(105, 74);
            this.txtLeaderPlayerId.Name = "txtLeaderPlayerId";
            this.txtLeaderPlayerId.Size = new System.Drawing.Size(139, 20);
            this.txtLeaderPlayerId.TabIndex = 25;
            this.txtLeaderPlayerId.TextChanged += new System.EventHandler(this.txtLeaderPlayerId_TextChanged);
            //
            // lblWarCooldownHours
            //
            this.lblWarCooldownHours.AutoSize = true;
            this.lblWarCooldownHours.Location = new System.Drawing.Point(4, 104);
            this.lblWarCooldownHours.Name = "lblWarCooldownHours";
            this.lblWarCooldownHours.Size = new System.Drawing.Size(120, 13);
            this.lblWarCooldownHours.TabIndex = 26;
            this.lblWarCooldownHours.Text = "War Cooldown (Hrs):";
            //
            // nudWarCooldownHours
            //
            this.nudWarCooldownHours.Location = new System.Drawing.Point(130, 102);
            this.nudWarCooldownHours.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            this.nudWarCooldownHours.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudWarCooldownHours.Name = "nudWarCooldownHours";
            this.nudWarCooldownHours.Size = new System.Drawing.Size(114, 20);
            this.nudWarCooldownHours.TabIndex = 27;
            this.nudWarCooldownHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWarCooldownHours.ValueChanged += new System.EventHandler(this.nudWarCooldownHours_ValueChanged);
            //
            // grpAtWar
            //
            this.grpAtWar.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.grpAtWar.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.grpAtWar.Controls.Add(this.btnRemoveAtWar);
            this.grpAtWar.Controls.Add(this.btnAddAtWar);
            this.grpAtWar.Controls.Add(this.cmbAtWar);
            this.grpAtWar.Controls.Add(this.lblAddAtWar);
            this.grpAtWar.Controls.Add(this.lstAtWar);
            this.grpAtWar.ForeColor = System.Drawing.Color.Gainsboro;
            this.grpAtWar.Location = new System.Drawing.Point(7, 159);
            this.grpAtWar.Name = "grpAtWar";
            this.grpAtWar.Size = new System.Drawing.Size(250, 261);
            this.grpAtWar.TabIndex = 33;
            this.grpAtWar.TabStop = false;
            this.grpAtWar.Text = "At War With";
            //
            // btnRemoveAtWar
            //
            this.btnRemoveAtWar.Location = new System.Drawing.Point(7, 227);
            this.btnRemoveAtWar.Name = "btnRemoveAtWar";
            this.btnRemoveAtWar.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveAtWar.Size = new System.Drawing.Size(237, 23);
            this.btnRemoveAtWar.TabIndex = 53;
            this.btnRemoveAtWar.Text = "Remove Selected";
            this.btnRemoveAtWar.Click += new System.EventHandler(this.btnRemoveAtWar_Click);
            //
            // btnAddAtWar
            //
            this.btnAddAtWar.Location = new System.Drawing.Point(7, 198);
            this.btnAddAtWar.Name = "btnAddAtWar";
            this.btnAddAtWar.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddAtWar.Size = new System.Drawing.Size(237, 23);
            this.btnAddAtWar.TabIndex = 50;
            this.btnAddAtWar.Text = "Add Selected";
            this.btnAddAtWar.Click += new System.EventHandler(this.btnAddAtWar_Click);
            //
            // cmbAtWar
            //
            this.cmbAtWar.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
            this.cmbAtWar.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.cmbAtWar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAtWar.ButtonColor = System.Drawing.Color.FromArgb(43, 43, 43);
            this.cmbAtWar.DrawDropdownHoverOutline = false;
            this.cmbAtWar.DrawFocusRectangle = false;
            this.cmbAtWar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAtWar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtWar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAtWar.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAtWar.FormattingEnabled = true;
            this.cmbAtWar.Location = new System.Drawing.Point(7, 171);
            this.cmbAtWar.Name = "cmbAtWar";
            this.cmbAtWar.Size = new System.Drawing.Size(237, 21);
            this.cmbAtWar.TabIndex = 49;
            this.cmbAtWar.Text = null;
            this.cmbAtWar.TextPadding = new System.Windows.Forms.Padding(2);
            //
            // lblAddAtWar
            //
            this.lblAddAtWar.AutoSize = true;
            this.lblAddAtWar.Location = new System.Drawing.Point(6, 155);
            this.lblAddAtWar.Name = "lblAddAtWar";
            this.lblAddAtWar.Size = new System.Drawing.Size(121, 13);
            this.lblAddAtWar.TabIndex = 48;
            this.lblAddAtWar.Text = "Declare War On:";
            //
            // lstAtWar
            //
            this.lstAtWar.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            this.lstAtWar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAtWar.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstAtWar.FormattingEnabled = true;
            this.lstAtWar.Location = new System.Drawing.Point(6, 19);
            this.lstAtWar.Name = "lstAtWar";
            this.lstAtWar.Size = new System.Drawing.Size(237, 123);
            this.lstAtWar.TabIndex = 47;
            //
            // toolStrip
            //
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.toolStrip.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripItemNew,
            this.toolStripSeparator1,
            this.toolStripItemDelete,
            this.toolStripSeparator2,
            this.btnAlphabetical,
            this.toolStripSeparator4,
            this.toolStripItemCopy,
            this.toolStripItemPaste,
            this.toolStripSeparator3,
            this.toolStripItemUndo});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(491, 25);
            this.toolStrip.TabIndex = 43;
            this.toolStrip.Text = "toolStrip1";
            //
            // toolStripItemNew (text-only — no icon resource file for this new form)
            //
            this.toolStripItemNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemNew.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStripItemNew.Name = "toolStripItemNew";
            this.toolStripItemNew.Size = new System.Drawing.Size(35, 22);
            this.toolStripItemNew.Text = "New";
            this.toolStripItemNew.Click += new System.EventHandler(this.toolStripItemNew_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripItemDelete
            //
            this.toolStripItemDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemDelete.Enabled = false;
            this.toolStripItemDelete.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStripItemDelete.Name = "toolStripItemDelete";
            this.toolStripItemDelete.Size = new System.Drawing.Size(45, 22);
            this.toolStripItemDelete.Text = "Delete";
            this.toolStripItemDelete.Click += new System.EventHandler(this.toolStripItemDelete_Click);
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            //
            // btnAlphabetical
            //
            this.btnAlphabetical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAlphabetical.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnAlphabetical.Name = "btnAlphabetical";
            this.btnAlphabetical.Size = new System.Drawing.Size(23, 22);
            this.btnAlphabetical.Text = "A-Z";
            this.btnAlphabetical.Click += new System.EventHandler(this.btnAlphabetical_Click);
            //
            // toolStripSeparator4
            //
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripItemCopy
            //
            this.toolStripItemCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemCopy.Enabled = false;
            this.toolStripItemCopy.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStripItemCopy.Name = "toolStripItemCopy";
            this.toolStripItemCopy.Size = new System.Drawing.Size(42, 22);
            this.toolStripItemCopy.Text = "Copy";
            this.toolStripItemCopy.Click += new System.EventHandler(this.toolStripItemCopy_Click);
            //
            // toolStripItemPaste
            //
            this.toolStripItemPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemPaste.Enabled = false;
            this.toolStripItemPaste.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStripItemPaste.Name = "toolStripItemPaste";
            this.toolStripItemPaste.Size = new System.Drawing.Size(42, 22);
            this.toolStripItemPaste.Text = "Paste";
            this.toolStripItemPaste.Click += new System.EventHandler(this.toolStripItemPaste_Click);
            //
            // toolStripSeparator3
            //
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripItemUndo
            //
            this.toolStripItemUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripItemUndo.Enabled = false;
            this.toolStripItemUndo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.toolStripItemUndo.Name = "toolStripItemUndo";
            this.toolStripItemUndo.Size = new System.Drawing.Size(42, 22);
            this.toolStripItemUndo.Text = "Undo";
            this.toolStripItemUndo.Click += new System.EventHandler(this.toolStripItemUndo_Click);
            //
            // FrmFactions
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(491, 507);
            this.ControlBox = true;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpFactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faction Editor";
            FormClosed += FrmFactions_FormClosed;
            this.Load += new System.EventHandler(this.frmFactions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.grpFactions.ResumeLayout(false);
            this.grpFactions.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpAtWar.ResumeLayout(false);
            this.grpAtWar.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private DarkButton btnCancel;
        private DarkButton btnSave;
        private DarkGroupBox grpFactions;
        private System.Windows.Forms.Panel pnlContainer;
        private DarkGroupBox grpAtWar;
        private DarkToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripItemNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripItemCopy;
        public System.Windows.Forms.ToolStripButton toolStripItemPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton toolStripItemUndo;
        private DarkGroupBox grpGeneral;
        private System.Windows.Forms.Label lblName;
        private DarkTextBox txtName;
        private DarkButton btnClearSearch;
        private DarkTextBox txtSearch;
        private DarkButton btnAddFolder;
        private System.Windows.Forms.Label lblFolder;
        private DarkComboBox cmbFolder;
        private System.Windows.Forms.ToolStripButton btnAlphabetical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Controls.GameObjectList lstGameObjects;
        private System.Windows.Forms.Label lblLeaderPlayerId;
        private DarkTextBox txtLeaderPlayerId;
        private System.Windows.Forms.Label lblWarCooldownHours;
        private DarkNumericUpDown nudWarCooldownHours;
        private DarkButton btnAddAtWar;
        private DarkComboBox cmbAtWar;
        private System.Windows.Forms.Label lblAddAtWar;
        private System.Windows.Forms.ListBox lstAtWar;
        private DarkButton btnRemoveAtWar;
    }
}
