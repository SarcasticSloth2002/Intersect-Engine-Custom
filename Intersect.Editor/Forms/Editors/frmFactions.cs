using DarkUI.Forms;
using Intersect.Editor.Core;
using Intersect.Editor.General;
using Intersect.Editor.Localization;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.Framework.Core.GameObjects.Factions;
using Intersect.Models;

namespace Intersect.Editor.Forms.Editors;

public partial class FrmFactions : EditorForm
{
    private List<FactionDescriptor> mChanged = new List<FactionDescriptor>();

    private string mCopiedItem;

    private FactionDescriptor mEditorItem;

    private List<string> mKnownFolders = new List<string>();

    public FrmFactions()
    {
        ApplyHooks();
        InitializeComponent();
        Icon = Program.Icon;
        _btnSave = btnSave;
        _btnCancel = btnCancel;

        lstGameObjects.Init(UpdateToolStripItems, AssignEditorItem, toolStripItemNew_Click, toolStripItemCopy_Click, toolStripItemUndo_Click, toolStripItemPaste_Click, toolStripItemDelete_Click);
    }

    private void AssignEditorItem(Guid id)
    {
        mEditorItem = FactionDescriptor.Get(id);
        UpdateEditor();
    }

    protected override void GameObjectUpdatedDelegate(GameObjectType type)
    {
        if (type == GameObjectType.Faction)
        {
            InitEditor();
            if (mEditorItem != null && !DatabaseObject<FactionDescriptor>.Lookup.Values.Contains(mEditorItem))
            {
                mEditorItem = null;
                UpdateEditor();
            }
        }
    }

    private void UpdateEditor()
    {
        if (mEditorItem != null)
        {
            pnlContainer.Show();

            txtName.Text = mEditorItem.Name;
            cmbFolder.Text = mEditorItem.Folder;

            txtLeaderPlayerId.Text = mEditorItem.LeaderPlayerId?.ToString() ?? string.Empty;
            nudWarCooldownHours.Value = mEditorItem.WarCooldownHours;

            UpdateAtWarList();

            if (mChanged.IndexOf(mEditorItem) == -1)
            {
                mChanged.Add(mEditorItem);
                mEditorItem.MakeBackup();
            }
        }
        else
        {
            pnlContainer.Hide();
        }

        var hasItem = mEditorItem != null;
        UpdateEditorButtons(hasItem);
        UpdateToolStripItems();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        mEditorItem.Name = txtName.Text;
        lstGameObjects.UpdateText(txtName.Text);
    }

    private void txtLeaderPlayerId_TextChanged(object sender, EventArgs e)
    {
        mEditorItem.LeaderPlayerId = Guid.TryParse(txtLeaderPlayerId.Text, out var leaderId) ? leaderId : (Guid?)null;
    }

    private void nudWarCooldownHours_ValueChanged(object sender, EventArgs e)
    {
        mEditorItem.WarCooldownHours = (int)nudWarCooldownHours.Value;
    }

    private void FrmFactions_FormClosed(object sender, FormClosedEventArgs e)
    {
        btnCancel_Click(null, null);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (var item in mChanged)
        {
            item.RestoreBackup();
            item.DeleteBackup();
        }

        Hide();
        Globals.CurrentEditor = -1;
        Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        foreach (var item in mChanged)
        {
            PacketSender.SendSaveObject(item);
            item.DeleteBackup();
        }

        Hide();
        Globals.CurrentEditor = -1;
        Dispose();
    }

    private void toolStripItemNew_Click(object sender, EventArgs e)
    {
        PacketSender.SendCreateObject(GameObjectType.Faction);
    }

    private void toolStripItemDelete_Click(object sender, EventArgs e)
    {
        if (mEditorItem != null && lstGameObjects.Focused)
        {
            if (DarkMessageBox.ShowWarning(
                    Strings.FactionEditor.deleteprompt, Strings.FactionEditor.delete,
                    DarkDialogButton.YesNo, Icon
                ) ==
                DialogResult.Yes)
            {
                PacketSender.SendDeleteObject(mEditorItem);
            }
        }
    }

    private void toolStripItemCopy_Click(object sender, EventArgs e)
    {
        if (mEditorItem != null && lstGameObjects.Focused)
        {
            mCopiedItem = mEditorItem.JsonData;
            toolStripItemPaste.Enabled = true;
        }
    }

    private void toolStripItemPaste_Click(object sender, EventArgs e)
    {
        if (mEditorItem != null && mCopiedItem != null && lstGameObjects.Focused)
        {
            mEditorItem.Load(mCopiedItem, true);
            UpdateEditor();
        }
    }

    private void toolStripItemUndo_Click(object sender, EventArgs e)
    {
        if (mChanged.Contains(mEditorItem) && mEditorItem != null)
        {
            if (DarkMessageBox.ShowWarning(
                    Strings.FactionEditor.undoprompt, Strings.FactionEditor.undotitle,
                    DarkDialogButton.YesNo, Icon
                ) ==
                DialogResult.Yes)
            {
                mEditorItem.RestoreBackup();
                UpdateEditor();
            }
        }
    }

    private void UpdateToolStripItems()
    {
        toolStripItemCopy.Enabled = mEditorItem != null && lstGameObjects.Focused;
        toolStripItemPaste.Enabled = mEditorItem != null && mCopiedItem != null && lstGameObjects.Focused;
        toolStripItemDelete.Enabled = mEditorItem != null && lstGameObjects.Focused;
        toolStripItemUndo.Enabled = mEditorItem != null && lstGameObjects.Focused;
    }

    private void lstGameObjects_FocusChanged(object sender, EventArgs e)
    {
        UpdateToolStripItems();
    }

    private void form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            if (e.KeyCode == Keys.N)
            {
                toolStripItemNew_Click(null, null);
            }
        }
    }

    private void frmFactions_Load(object sender, EventArgs e)
    {
        UpdateEditor();
        RefreshAtWarCombo();
        InitLocalization();
    }

    private void InitLocalization()
    {
        Text = Strings.FactionEditor.title;
        toolStripItemNew.Text = Strings.FactionEditor.New;
        toolStripItemDelete.Text = Strings.FactionEditor.delete;
        toolStripItemCopy.Text = Strings.FactionEditor.copy;
        toolStripItemPaste.Text = Strings.FactionEditor.paste;
        toolStripItemUndo.Text = Strings.FactionEditor.undo;

        grpFactions.Text = Strings.FactionEditor.factions;
        grpGeneral.Text = Strings.FactionEditor.general;
        lblName.Text = Strings.FactionEditor.name;
        lblLeaderPlayerId.Text = Strings.FactionEditor.leaderplayerid;
        lblWarCooldownHours.Text = Strings.FactionEditor.warcooldownhours;

        grpAtWar.Text = Strings.FactionEditor.atwarwith;
        lblAddAtWar.Text = Strings.FactionEditor.addatwarlabel;
        btnAddAtWar.Text = Strings.FactionEditor.add;
        btnRemoveAtWar.Text = Strings.FactionEditor.remove;

        btnAlphabetical.ToolTipText = Strings.FactionEditor.sortalphabetically;
        txtSearch.Text = Strings.FactionEditor.searchplaceholder;
        lblFolder.Text = Strings.FactionEditor.folderlabel;

        btnSave.Text = Strings.FactionEditor.save;
        btnCancel.Text = Strings.FactionEditor.cancel;
    }

    private void RefreshAtWarCombo()
    {
        cmbAtWar.Items.Clear();
        cmbAtWar.Items.AddRange(FactionDescriptor.Names);
    }

    public void UpdateAtWarList()
    {
        lstAtWar.Items.Clear();
        foreach (var id in mEditorItem.AtWarWith)
        {
            lstAtWar.Items.Add(FactionDescriptor.GetName(id));
        }
    }

    private void btnAddAtWar_Click(object sender, EventArgs e)
    {
        if (cmbAtWar.SelectedIndex < 0)
        {
            return;
        }

        var id = FactionDescriptor.IdFromList(cmbAtWar.SelectedIndex);
        if (id != mEditorItem.Id && !mEditorItem.AtWarWith.Contains(id))
        {
            mEditorItem.AtWarWith.Add(id);
            var other = FactionDescriptor.Get(id);
            if (other != null && !other.AtWarWith.Contains(mEditorItem.Id))
            {
                other.AtWarWith.Add(mEditorItem.Id);
                if (mChanged.IndexOf(other) == -1)
                {
                    mChanged.Add(other);
                    other.MakeBackup();
                }
            }

            UpdateAtWarList();
        }
    }

    private void btnRemoveAtWar_Click(object sender, EventArgs e)
    {
        if (lstAtWar.SelectedIndex > -1)
        {
            var id = mEditorItem.AtWarWith[lstAtWar.SelectedIndex];
            mEditorItem.AtWarWith.RemoveAt(lstAtWar.SelectedIndex);

            var other = FactionDescriptor.Get(id);
            if (other != null && other.AtWarWith.Remove(mEditorItem.Id))
            {
                if (mChanged.IndexOf(other) == -1)
                {
                    mChanged.Add(other);
                    other.MakeBackup();
                }
            }

            UpdateAtWarList();
        }
    }

    #region "Item List - Folders, Searching, Sorting, Etc"

    public void InitEditor()
    {
        var mFolders = new List<string>();
        foreach (var itm in FactionDescriptor.Lookup)
        {
            if (!string.IsNullOrEmpty(((FactionDescriptor)itm.Value).Folder) &&
                !mFolders.Contains(((FactionDescriptor)itm.Value).Folder))
            {
                mFolders.Add(((FactionDescriptor)itm.Value).Folder);
                if (!mKnownFolders.Contains(((FactionDescriptor)itm.Value).Folder))
                {
                    mKnownFolders.Add(((FactionDescriptor)itm.Value).Folder);
                }
            }
        }

        mFolders.Sort();
        mKnownFolders.Sort();
        cmbFolder.Items.Clear();
        cmbFolder.Items.Add("");
        cmbFolder.Items.AddRange(mKnownFolders.ToArray());

        var items = FactionDescriptor.Lookup.OrderBy(p => p.Value?.Name).Select(pair => new KeyValuePair<Guid, KeyValuePair<string, string>>(pair.Key,
            new KeyValuePair<string, string>(((FactionDescriptor)pair.Value)?.Name ?? DatabaseObject<FactionDescriptor>.Deleted, ((FactionDescriptor)pair.Value)?.Folder ?? ""))).ToArray();
        lstGameObjects.Repopulate(items, mFolders, btnAlphabetical.Checked, CustomSearch(), txtSearch.Text);

        RefreshAtWarCombo();
    }

    private void btnAddFolder_Click(object sender, EventArgs e)
    {
        var folderName = string.Empty;
        var result = DarkInputBox.ShowInformation(
            Strings.FactionEditor.folderprompt, Strings.FactionEditor.foldertitle, ref folderName,
            DarkDialogButton.OkCancel
        );

        if (result == DialogResult.OK && !string.IsNullOrEmpty(folderName))
        {
            if (!cmbFolder.Items.Contains(folderName))
            {
                mEditorItem.Folder = folderName;
                lstGameObjects.ExpandFolder(folderName);
                InitEditor();
                cmbFolder.Text = folderName;
            }
        }
    }

    private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        mEditorItem.Folder = cmbFolder.Text;
        InitEditor();
    }

    private void btnAlphabetical_Click(object sender, EventArgs e)
    {
        btnAlphabetical.Checked = !btnAlphabetical.Checked;
        InitEditor();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        InitEditor();
    }

    private void txtSearch_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            txtSearch.Text = Strings.FactionEditor.searchplaceholder;
        }
    }

    private void txtSearch_Enter(object sender, EventArgs e)
    {
        txtSearch.SelectAll();
        txtSearch.Focus();
    }

    private void btnClearSearch_Click(object sender, EventArgs e)
    {
        txtSearch.Text = Strings.FactionEditor.searchplaceholder;
    }

    private bool CustomSearch()
    {
        return !string.IsNullOrWhiteSpace(txtSearch.Text) &&
               txtSearch.Text != Strings.FactionEditor.searchplaceholder;
    }

    private void txtSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Text == Strings.FactionEditor.searchplaceholder)
        {
            txtSearch.SelectAll();
        }
    }

    #endregion
}
