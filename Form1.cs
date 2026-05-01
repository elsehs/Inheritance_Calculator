using System.Drawing.Imaging;
using System.Globalization;

namespace OOP_Project_Concept2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalMoney;
            double siblingAmount = 0;
            if (!double.TryParse(textBox_Total.Text, out totalMoney) || totalMoney <= 0)
            {
                MessageBox.Show("يا ريت تدخّل مبلغ صحيح وموجب عشان نعرف نحسب الميراث صح.");
                return;
            }

            try
            {

                int sonsCount = (int)num_Sons.Value;
                int daughtersCount = (int)num_Daughters.Value;
                int fullBrothersCount = (int)num_FullBrothers.Value;
                int fullSistersCount = (int)num_FullSisters.Value;
                bool isDeceasedMale = rb_Male.Checked;
                bool hasBranch = (sonsCount + daughtersCount > 0);
                bool hasMaleSon = (sonsCount > 0);
                bool hasAgaba = (hasMaleSon || chk_Father.Checked || fullBrothersCount > 0 || fullSistersCount > 0);

                List<Heir> fixedHeirs = new List<Heir>();
                Heir? partner = null;

                if (Chk_PartnerAlive.Checked)
                {
                    partner = isDeceasedMale ? (Heir)new Wife("الزوجة") : (Heir)new Husband("الزوج");
                    fixedHeirs.Add(partner);
                }

                Father? myFather = chk_Father.Checked ? new Father("الأب") : null;
                if (myFather != null) fixedHeirs.Add(myFather);

                Mother? myMother = chk_Mother.Checked ? new Mother("الأم") : null;
                if (myMother != null) fixedHeirs.Add(myMother);

                Daughter? myDaughters = (!hasMaleSon && daughtersCount > 0) ? new Daughter("البنات", daughtersCount, false) : null;

                double totalRatios = fixedHeirs.Sum(h => h.GetShareRatio(hasBranch, isDeceasedMale));

                if (myDaughters != null)
                    totalRatios += myDaughters.GetShareRatio(hasBranch, isDeceasedMale);

                double fullSistersRatio = 0;

                if (!hasBranch && !chk_Father.Checked && fullBrothersCount == 0 && fullSistersCount > 0)
                {
                    fullSistersRatio = (fullSistersCount == 1) ? 0.5 : (2.0 / 3.0);
                    totalRatios += fullSistersRatio;
                }

                if (totalRatios > 1.0)
                {
                    foreach (var h in fixedHeirs)
                        h.SetFinalAmount(totalMoney * (h.GetShareRatio(hasBranch, isDeceasedMale) / totalRatios));

                    if (myDaughters != null)
                        myDaughters.SetFinalAmount(totalMoney * (myDaughters.GetShareRatio(hasBranch, isDeceasedMale) / totalRatios));

                    if (fullSistersRatio > 0)
                        siblingAmount = totalMoney * (fullSistersRatio / totalRatios);
                }
                else if (totalRatios < 1.0 && !hasAgaba)
                {
                    double partnerRatio = (partner != null) ? partner.GetShareRatio(hasBranch, isDeceasedMale) : 0;

                    if (partner != null) partner.SetFinalAmount(totalMoney * partnerRatio);

                    double othersRatio = totalRatios - partnerRatio;
                    double remainingAfterPartner = totalMoney * (1 - partnerRatio);

                    foreach (var h in fixedHeirs)
                    {
                        if (h != partner)
                            h.SetFinalAmount(remainingAfterPartner * (h.GetShareRatio(hasBranch, isDeceasedMale) / othersRatio));
                    }
                    if (myDaughters != null)
                        myDaughters.SetFinalAmount(remainingAfterPartner * (myDaughters.GetShareRatio(hasBranch, isDeceasedMale) / othersRatio));

                    if (fullSistersRatio > 0)
                        siblingAmount = remainingAfterPartner * (fullSistersRatio / othersRatio);
                }
                else
                {
                    foreach (var h in fixedHeirs)
                        h.SetFinalAmount(totalMoney * h.GetShareRatio(hasBranch, isDeceasedMale));

                    if (myDaughters != null)
                        myDaughters.SetFinalAmount(totalMoney * myDaughters.GetShareRatio(hasBranch, isDeceasedMale));

                    if (fullSistersRatio > 0)
                        siblingAmount = totalMoney * fullSistersRatio;
                }

                double allocatedSoFar = fixedHeirs.Sum(h => h.FinalAmount) + (myDaughters?.FinalAmount ?? 0);
                double residue = Math.Max(0, totalMoney - allocatedSoFar);

                if (residue > 1)
                {
                    if (hasMaleSon)
                    {
                        double sonShare = (residue / (sonsCount * 2 + daughtersCount)) * 2;
                        double daughterShare = residue / (sonsCount * 2 + daughtersCount);
                    }
                    else if (chk_Father.Checked)
                    {
                        myFather!.AddResidue(residue);
                        residue = 0;
                    }
                    else if (fullBrothersCount > 0 || fullSistersCount > 0)
                    {
                        siblingAmount = residue;
                        residue = 0;
                    }
                }

                // --- Build result rows for the custom dialog ---
                var rows = new List<ResultRow>();

                foreach (var h in fixedHeirs)
                {
                    if (h.FinalAmount > 0)
                    {
                        var ratio = h.GetShareRatio(hasBranch, isDeceasedMale);
                        rows.Add(new ResultRow(h.Relationship, FormatRatio(ratio), h.FinalAmount));
                    }
                }

                if (myDaughters != null)
                {
                    var ratio = myDaughters.GetShareRatio(hasBranch, isDeceasedMale);
                    rows.Add(new ResultRow($"البنات ({daughtersCount})", FormatRatio(ratio), myDaughters.FinalAmount));
                }

                if (hasMaleSon)
                {
                    double unitShare = (totalMoney - allocatedSoFar) / (sonsCount * 2 + daughtersCount);
                    double sonsAmount = unitShare * 2 * sonsCount;
                    double daughtersAmount = unitShare * daughtersCount;

                    rows.Add(new ResultRow($"الأبناء ({sonsCount})", FormatRatio(sonsAmount / totalMoney), sonsAmount));
                    rows.Add(new ResultRow($"البنات ({daughtersCount})", FormatRatio(daughtersAmount / totalMoney), daughtersAmount));
                }

                if (siblingAmount > 0)
                {
                    double sibShare = siblingAmount / (fullBrothersCount * 2 + fullSistersCount);

                    if (fullBrothersCount > 0)
                        rows.Add(new ResultRow($"الأخوة ({fullBrothersCount})", FormatRatio((sibShare * 2 * fullBrothersCount) / totalMoney), sibShare * 2 * fullBrothersCount));

                    if (fullSistersCount > 0)
                        rows.Add(new ResultRow($"الأخوات ({fullSistersCount})", FormatRatio((sibShare * fullSistersCount) / totalMoney), sibShare * fullSistersCount));
                }

                using var dialog = new ResultDialog(rows, Properties.Resources.arch_pattern);
                dialog.ShowDialog(this);
            }   
            catch (Exception)
            {
                MessageBox.Show("تأكد من إدخال كافة البيانات بشكل صحيح.");
            }
        }

        private static string FormatRatio(double ratio)
        {
            var map = new Dictionary<double, string>
            {
                { 1.0 / 2.0, "1/2" },
                { 1.0 / 3.0, "1/3" },
                { 2.0 / 3.0, "2/3" },
                { 1.0 / 4.0, "1/4" },
                { 1.0 / 6.0, "1/6" },
                { 1.0 / 8.0, "1/8" }
            };

            foreach (var kvp in map)
            {
                if (Math.Abs(ratio - kvp.Key) < 0.0001)
                    return kvp.Value;
            }

            return ratio.ToString("P0", CultureInfo.CurrentCulture);
        }

        private void rb_Female_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb_Female.Checked)
            {
                Chk_PartnerAlive.Text = "الزوج على قيد الحياة";
            }
        }

        private void rb_Male_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb_Male.Checked)
            {
                Chk_PartnerAlive.Text = "الزوجة على قيد الحياة";
            }
        }

        private void panel_Card_Paint(object sender, PaintEventArgs e)
        {
        }
    }

    internal sealed class ResultRow
    {
        public ResultRow(string heirName, string shareText, double amount)
        {
            HeirName = heirName;
            ShareText = shareText;
            Amount = amount;
        }

        public string HeirName { get; }
        public string ShareText { get; }
        public double Amount { get; }
    }

    internal sealed class ResultDialog : Form
    {
        public ResultDialog(IReadOnlyList<ResultRow> rows, Image? backgroundImage = null)
        {
            Text = "النتيجة النهائية";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            BackColor = Color.FromArgb(15, 47, 95);
            ClientSize = new Size(820, 520);

            var backgroundPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(15, 47, 95),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            if (backgroundImage != null)
            {
                backgroundPanel.BackgroundImage = backgroundImage;
            }

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(24)
            };
            layout.RowStyles.Clear();
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));

            var headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            var title = new Label
            {
                Text = "نتائج توزيع التركة",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            var brandLabel = new Label
            {
                Text = "ميراثك",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(headerPanel.Width - 80, 8)
            };
            headerPanel.Resize += (_, _) =>
            {
                brandLabel.Location = new Point(headerPanel.Width - brandLabel.Width - 8, 8);
            };

            headerPanel.Controls.Add(title);
            headerPanel.Controls.Add(brandLabel);

            var grid = new DataGridView
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                BackgroundColor = Color.FromArgb(15, 45, 90),
                BorderStyle = BorderStyle.FixedSingle,
                GridColor = Color.FromArgb(180, 140, 70),
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RightToLeft = RightToLeft.Yes,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Margin = new Padding(0, 0, 0, 6)
            };

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(20, 55, 105),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(12, 40, 80),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                SelectionBackColor = Color.FromArgb(30, 65, 120),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(10, 35, 70),
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "اسم الوارث" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "النصيب (كسر)" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "المبلغ المستحق" });

            foreach (var row in rows)
            {
                grid.Rows.Add(row.HeirName, row.ShareText, row.Amount.ToString("N0", CultureInfo.CurrentCulture));
            }

            var newCalcButton = new Button
            {
                Text = "حساب مسألة جديدة",
                AutoSize = true,
                Padding = new Padding(18, 6, 18, 6),
                BackColor = Color.FromArgb(196, 160, 80),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            newCalcButton.FlatAppearance.BorderSize = 0;
            newCalcButton.Click += (_, _) => Close();

            var screenshotButton = new Button
            {
                Text = "حمل الصوره",
                AutoSize = true,
                Padding = new Padding(14, 6, 14, 6),
                BackColor = Color.FromArgb(196, 160, 80),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            screenshotButton.FlatAppearance.BorderSize = 0;
            screenshotButton.Click += (_, _) =>
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png",
                    FileName = "Result.png"
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    using var bitmap = new Bitmap(Width, Height);
                    DrawToBitmap(bitmap, new Rectangle(Point.Empty, Size));
                    bitmap.Save(dialog.FileName, ImageFormat.Png);
                }
            };

            var buttonsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Anchor = AnchorStyles.None
            };
            buttonsPanel.Controls.Add(newCalcButton);
            buttonsPanel.Controls.Add(screenshotButton);

            layout.Controls.Add(headerPanel, 0, 0);
            layout.Controls.Add(grid, 0, 1);
            layout.Controls.Add(buttonsPanel, 0, 2);

            backgroundPanel.Controls.Add(layout);
            Controls.Add(backgroundPanel);
        }
    }
}