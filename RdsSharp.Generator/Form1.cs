using Newtonsoft.Json;
using RdsSharp.Generator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RdsSharp.Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<ByteLayout> items = new List<ByteLayout>();
        private ByteLayout SelectedItem => items[layoutList.SelectedIndex];

        private void ShowSegmentEditor(ByteLayoutSegment segment)
        {
            SegmentEditorForm editor = new SegmentEditorForm(segment);
            editor.OnUpdated += () => byteLayoutView1.Invalidate();
            if (editor.ShowDialog() == DialogResult.Abort)
            {
                byteLayoutView1.RemoveSegment(segment);
                SelectedItem.Segments.Remove(segment);
            }
        }

        private void byteLayoutView1_OnCellClicked(int bitOffset)
        {
            //Create new cell
            ByteLayoutSegment segment = new ByteLayoutSegment
            {
                Title = "Default",
                BitWidth = 1,
                BitOffset = bitOffset,
                BitType = ByteLayoutType.INT
            };

            //Add
            byteLayoutView1.AddSegment(segment);
            SelectedItem.Segments.Add(segment);

            //Show editor
            ShowSegmentEditor(segment);
        }

        private void byteLayoutView1_OnSegmentClicked(ByteLayoutSegment clicked)
        {
            //Make sure this is a real entry
            if (!SelectedItem.Segments.Contains(clicked))
                return;

            //Show editor
            ShowSegmentEditor(clicked);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add new item
            ByteLayout item = new ByteLayout();
            items.Add(item);
            layoutList.SelectedIndex = -1;

            //Refresh
            RefreshList();
        }

        private bool updating = false;

        private void RefreshList()
        {
            updating = true;

            //Add to main list
            int index = layoutList.SelectedIndex;
            layoutList.SuspendLayout();
            layoutList.Items.Clear();
            foreach (var i in items)
                layoutList.Items.Add(i);
            layoutList.SelectedIndex = index;
            layoutList.ResumeLayout();

            //Add to inherert list
            index = inheritedBox.SelectedIndex;
            inheritedBox.SuspendLayout();
            inheritedBox.Items.Clear();
            foreach (var i in items)
                inheritedBox.Items.Add(i);
            inheritedBox.SelectedIndex = index;
            inheritedBox.ResumeLayout();

            updating = false;
            layoutList_SelectedIndexChanged(null, null);
        }

        private void layoutList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ignore if already updating
            if (updating)
                return;

            //Get or create default
            if (layoutList.SelectedIndex == -1 && items.Count == 0)
            {
                btnAdd_Click(null, null);
            } else if (layoutList.SelectedIndex == -1)
            {
                layoutList.SelectedIndex = 0;
            }

            //Set up main
            updating = true;
            nameBox.Text = SelectedItem.Name;
            opcodeBox.SelectedIndex = SelectedItem.Opcode;
            versionBox.SelectedIndex = ((SelectedItem.VerA ? 1 : 0) | (SelectedItem.VerB ? 2 : 0)) - 1;
            inheritedBox.SelectedIndex = SelectedItem.InheritedIndex;

            //Set up the layout box
            byteLayoutView1.Reset();
            ByteLayout source = SelectedItem;
            while (true)
            {
                foreach (var item in source.Segments)
                    byteLayoutView1.AddSegment(item);
                if (source.InheritedIndex == -1)
                    break;
                source = items[source.InheritedIndex];
            }

            updating = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                SelectedItem.Name = nameBox.Text;
                RefreshList();
            }
        }

        private void opcodeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                SelectedItem.Opcode = opcodeBox.SelectedIndex;
                RefreshList();
            }
        }

        private void versionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
            {
                SelectedItem.VerA = (versionBox.SelectedIndex == 0 || versionBox.SelectedIndex == 2);
                SelectedItem.VerB = (versionBox.SelectedIndex == 1 || versionBox.SelectedIndex == 2);
                RefreshList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "Save Files (*.json)|*.json";
            if (fd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(fd.FileName, JsonConvert.SerializeObject(items));
        }

        private void inheritedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updating)
                SelectedItem.InheritedIndex = inheritedBox.SelectedIndex;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Save Files (*.json)|*.json";
            if (fd.ShowDialog() == DialogResult.OK)
                items = JsonConvert.DeserializeObject<List<ByteLayout>>(File.ReadAllText(fd.FileName));
            RefreshList();
        }

        private string GenerateSwitchCode()
        {
            string code = "using System;\nusing RdsSharp.Frames.Types;\n\nnamespace RdsSharp.Frames\n{\n    public static class RdsFrameFactory\n    {\n        public static RdsFrame DecodeFrame(ulong frame)\n        {\n            switch (RdsFrame.ReadInt(16, 5, frame))\n            {\n";
            foreach (var i in items)
            {
                string op = Convert.ToString(i.Opcode, 2).PadLeft(4, '0');
                if (i.VerA)
                    code += $"                case 0b{op}0: return new {i.Name}(frame);\n";
                if (i.VerB)
                    code += $"                case 0b{op}1: return new {i.Name}(frame);\n";
            }
            code += "                default: return new RdsFrame(frame);\n            }\n        }\n    }\n}";
            return code;
        }

        private string GenerateLayoutCode(ByteLayout i)
        {
            string code = "using System;\n\nnamespace RdsSharp.Frames.Types\n{\n";
            code += "    public class " + i.Name;
            if (i.InheritedIndex != -1)
                code += " : " + items[i.InheritedIndex].Name;
            else
                code += " : RdsFrame";
            code += "\n    {\n";
            code += "        public " + i.Name + "(ulong raw) : base(raw) {}\n\n";
            foreach (var p in i.Segments)
            {
                code += "        public ";
                switch (p.BitType)
                {
                    case ByteLayoutType.INT: code += "int"; break;
                    case ByteLayoutType.BOOL: code += "bool"; break;
                    case ByteLayoutType.CHAR: code += "char"; break;
                }
                code += " " + p.Title + "\n";
                code += "        {\n";
                code += "            get => ";
                switch (p.BitType)
                {
                    case ByteLayoutType.INT: code += "ReadInt"; break;
                    case ByteLayoutType.BOOL: code += "ReadBool"; break;
                    case ByteLayoutType.CHAR: code += "ReadChar"; break;
                }
                code += $"({p.BitOffset}, {p.BitWidth});\n";
                code += "            set => ";
                switch (p.BitType)
                {
                    case ByteLayoutType.INT: code += "WriteInt"; break;
                    case ByteLayoutType.BOOL: code += "WriteBool"; break;
                    case ByteLayoutType.CHAR: code += "WriteChar"; break;
                }
                code += $"({p.BitOffset}, {p.BitWidth}, value);\n";
                code += "        }\n";
                code += "    \n";
            }
            code += "\n    }\n";
            code += "}";
            return code;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Prompt to write
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = new DirectoryInfo(".").Parent.Parent.Parent.FullName + Path.DirectorySeparatorChar + "RdsSharp" + Path.DirectorySeparatorChar + "Frames";
            fd.Description = "Choose \"Frames\" folder.";
            if (fd.ShowDialog() != DialogResult.OK)
                return;
            DirectoryInfo dir = new DirectoryInfo(fd.SelectedPath);

            //Create types dir and generate
            DirectoryInfo types = dir.CreateSubdirectory("Types");
            foreach (var i in items)
                File.WriteAllText(types.FullName + Path.DirectorySeparatorChar + i.Name + ".cs", GenerateLayoutCode(i));

            //Generate factory
            File.WriteAllText(dir.FullName + Path.DirectorySeparatorChar + "RdsFrameFactory.cs", GenerateSwitchCode());
        }
    }
}
