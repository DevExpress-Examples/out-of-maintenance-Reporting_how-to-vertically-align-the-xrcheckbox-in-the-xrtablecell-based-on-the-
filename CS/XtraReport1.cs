using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace RepAlignCheckBoxTableCell {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
        }

        private void xrCheckBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            string neighborCellText = GetCurrentColumnValue("Content").ToString();
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);

            int neighborCellWidthPixels = ConvertFromReportUnitToPixels(xrTableCell2.WidthF);

            SizeF neighborCellSizePixels = graphics.MeasureString(neighborCellText, xrTableCell2.Font, neighborCellWidthPixels,
                BrickStringFormat.Create(xrTableCell2.TextAlignment, xrTableCell2.WordWrap).Value);

            graphics.Dispose();

            float neighborCellHeightReportUnits = ConvertFromPixelsToReportUnit((int)Math.Round(neighborCellSizePixels.Height));

            xrCheckBox1.LocationF = new PointF(xrCheckBox1.LocationF.X, neighborCellHeightReportUnits / 2 - xrCheckBox1.SizeF.Height / 2);
        }

        private int ConvertFromReportUnitToPixels(float value) {
            GraphicsUnit unit = (this.ReportUnit == ReportUnit.HundredthsOfAnInch ? GraphicsUnit.Inch : GraphicsUnit.Millimeter);
            float multiplier = (unit == GraphicsUnit.Inch ? 100 : 10);

            return (int)Math.Round(GraphicsUnitConverter.Convert(value, unit, GraphicsUnit.Pixel) / multiplier);
        }

        private float ConvertFromPixelsToReportUnit(int value) {
            GraphicsUnit unit = (this.ReportUnit == ReportUnit.HundredthsOfAnInch ? GraphicsUnit.Inch : GraphicsUnit.Millimeter);
            float multiplier = (unit == GraphicsUnit.Inch ? 100 : 10);

            return GraphicsUnitConverter.Convert(value, GraphicsUnit.Pixel, unit) * multiplier;
        }

    }

    public class ManualDataSet : DataSet {
        public ManualDataSet()
            : base() {
            DataTable table = new DataTable("table");

            DataSetName = "ManualDataSet";

            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("Content", typeof(string));
            table.Columns.Add("Checked", typeof(bool));
            table.Constraints.Add("IDPK", table.Columns["ID"], true);

            Tables.AddRange(new DataTable[] { table });
        }

        public static ManualDataSet CreateData() {
            ManualDataSet ds = new ManualDataSet();
            DataTable table = ds.Tables["table"];

            table.Rows.Add(new object[] { 0, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed...", true });
            table.Rows.Add(new object[] { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.", true });
            table.Rows.Add(new object[] { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Typi non habent claritatem insitam; est usus legentis in iis qui facit eorum claritatem.", false });
            table.Rows.Add(new object[] { 4, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.", true });

            return ds;
        }

        #region Disable Serialization for Tables and Relations
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataTableCollection Tables {
            get { return base.Tables; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataRelationCollection Relations {
            get { return base.Relations; }
        }
        #endregion Disable Serialization for Tables and Relations
    }

}
