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
    public delegate void ByteLayoutView_OnSegmentClickedArgs(ByteLayoutSegment clicked);
    public delegate void ByteLayoutView_OnCellClickedArgs(int bitOffset);

    public partial class ByteLayoutView : Control
    {
        public ByteLayoutView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            MouseLeave += ByteLayoutView_MouseLeave;
            MouseMove += ByteLayoutView_MouseMove;
            MouseClick += ByteLayoutView_MouseClick;
            InternalReset();
        }

        private void ByteLayoutView_MouseLeave(object sender, EventArgs e)
        {
            currentHoveringX = -1;
            Invalidate();
        }

        private void ByteLayoutView_MouseMove(object sender, MouseEventArgs e)
        {
            currentHoveringX = e.X;
            Invalidate();
        }

        private void ByteLayoutView_MouseClick(object sender, MouseEventArgs e)
        {
            //Subdivide width into the groups
            float groupWidth = (Width - 1) / (float)GROUPS_PER_FRAME;
            float bitWidth = groupWidth / BITS_PER_GROUP;

            //Determine if a segment was clicked
            foreach (var s in segments)
            {
                //Calculate pos
                float startX = s.BitOffset * bitWidth;
                float widthX = s.BitWidth * bitWidth;

                //Check if it is within bounds
                if (e.X >= startX && e.X < startX + widthX)
                {
                    OnSegmentClicked?.Invoke(s);
                    return;
                }
            }

            //Determine which index was clicked
            int bitOffset = (int)(e.X / bitWidth);
            if (bitOffset >= 0 && bitOffset < BITS_PER_GROUP * GROUPS_PER_FRAME)
                OnCellClicked?.Invoke(bitOffset);
        }

        private const int BITS_PER_GROUP = 16;
        private const int GROUPS_PER_FRAME = 4;

        private int currentHoveringX = -1;
        private List<ByteLayoutSegment> segments = new List<ByteLayoutSegment>();

        public event ByteLayoutView_OnSegmentClickedArgs OnSegmentClicked;
        public event ByteLayoutView_OnCellClickedArgs OnCellClicked;

        private static readonly Color[] SEGMENT_COLORS = new Color[]
        {
            Color.FromArgb(255, 138, 138),
            Color.FromArgb(255, 214, 138),
            Color.FromArgb(247, 255, 138),
            Color.FromArgb(138, 255, 140),
            Color.FromArgb(138, 255, 249),
            Color.FromArgb(138, 208, 255),
            Color.FromArgb(142, 138, 255),
            Color.FromArgb(181, 138, 255),
            Color.FromArgb(230, 138, 255),
            Color.FromArgb(255, 138, 239)
        };
        private static readonly Brush HOVERING_BRUSH = new SolidBrush(Color.FromArgb(25, Color.Black));

        private void InternalReset()
        {
            //Clear
            segments.Clear();

            //Add defaults
            segments.Add(new ByteLayoutSegment
            {
                Title = "PI Code",
                BitOffset = 0,
                BitWidth = 16,
                BitType = ByteLayoutType.INT
            });
            segments.Add(new ByteLayoutSegment
            {
                Title = "GroupType",
                BitOffset = 16,
                BitWidth = 4,
                BitType = ByteLayoutType.INT
            });
            segments.Add(new ByteLayoutSegment
            {
                Title = "A/B",
                BitOffset = 20,
                BitWidth = 1,
                BitType = ByteLayoutType.BOOL
            });
            segments.Add(new ByteLayoutSegment
            {
                Title = "TP",
                BitOffset = 21,
                BitWidth = 1,
                BitType = ByteLayoutType.BOOL
            });
            segments.Add(new ByteLayoutSegment
            {
                Title = "PTY",
                BitOffset = 22,
                BitWidth = 5,
                BitType = ByteLayoutType.INT
            });
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Subdivide width into the groups
            float groupWidth = (Width - 1) / (float)GROUPS_PER_FRAME;
            float bitWidth = groupWidth / BITS_PER_GROUP;

            //Clear
            pe.Graphics.Clear(BackColor);

            //Prepare string format
            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            //Sort segments by their position so colors look ok
            segments.Sort((ByteLayoutSegment a, ByteLayoutSegment b) => a.BitOffset - b.BitOffset);

            //Draw backgrounds
            int segmentColorIndex = 0;
            bool segmentSelected = false;
            foreach (var s in segments)
            {
                //Calculate pos
                float startX = s.BitOffset * bitWidth;
                float widthX = s.BitWidth * bitWidth;

                //Render rectangle
                pe.Graphics.FillRectangle(
                    new SolidBrush(SEGMENT_COLORS[segmentColorIndex++ % SEGMENT_COLORS.Length]),
                    startX,
                    0,
                    widthX,
                    Height
                );

                //Render text
                pe.Graphics.DrawString(s.Title, Font, Brushes.Black, new RectangleF(startX, 0, widthX, Height * 0.75f), fmt);

                //If this is currently a highlighted cell, indicate
                if (!segmentSelected && currentHoveringX >= startX && currentHoveringX < startX + widthX)
                {
                    pe.Graphics.FillRectangle(HOVERING_BRUSH, startX, 0, widthX, Height);
                    segmentSelected = true;
                }
            }

            //Draw each
            float offsetX = 0;
            for (int i = 0; i < GROUPS_PER_FRAME; i++)
            {
                //Draw each bit
                for (int b = 0; b < BITS_PER_GROUP; b++)
                {
                    //Get start and end pos
                    float startX = offsetX + (b * bitWidth);

                    //Draw
                    if (b != 0)
                        pe.Graphics.DrawLine(Pens.Black, startX, Height * 0.75f, startX, Height);

                    //If this is currently a highlighted cell, indicate
                    if (!segmentSelected && currentHoveringX >= startX && currentHoveringX < startX + bitWidth)
                        pe.Graphics.FillRectangle(HOVERING_BRUSH, startX, 0, bitWidth, Height);
                }

                //Draw the group outline
                pe.Graphics.DrawRectangle(new Pen(Color.Black, 2), offsetX, 0, groupWidth, Height);

                //Update offset
                offsetX += groupWidth;
            }
        }

        public void AddSegment(ByteLayoutSegment segment)
        {
            segments.Add(segment);
            Invalidate();
        }

        public void RemoveSegment(ByteLayoutSegment segment)
        {
            segments.Remove(segment);
            Invalidate();
        }

        public void Reset()
        {
            InternalReset();
            Invalidate();
        }
    }
}
