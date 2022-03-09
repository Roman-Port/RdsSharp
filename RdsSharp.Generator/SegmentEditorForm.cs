using RdsSharp.Generator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RdsSharp.Generator
{
    public partial class SegmentEditorForm : Form
    {
        public SegmentEditorForm(ByteLayoutSegment segment)
        {
            this.segment = segment;
            InitializeComponent();
        }

        private ByteLayoutSegment segment;

        public event Action OnUpdated;

        private void fieldName_TextChanged(object sender, EventArgs e)
        {
            segment.Title = fieldName.Text;
            OnUpdated?.Invoke();
        }

        private void fieldOffset_ValueChanged(object sender, EventArgs e)
        {
            segment.BitOffset = (int)fieldOffset.Value;
            OnUpdated?.Invoke();
        }

        private void fieldLength_ValueChanged(object sender, EventArgs e)
        {
            segment.BitWidth = (int)fieldLength.Value;
            OnUpdated?.Invoke();
        }

        private void fieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            segment.BitType = (ByteLayoutType)fieldType.SelectedIndex;
            OnUpdated?.Invoke();
        }

        private void SegmentEditorForm_Load(object sender, EventArgs e)
        {
            fieldName.Text = segment.Title;
            fieldLength.Value = segment.BitWidth;
            fieldOffset.Value = segment.BitOffset;
            fieldType.SelectedIndex = (int)segment.BitType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
