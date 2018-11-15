<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
* [XtraReport1.cs](./CS/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/XtraReport1.vb))
<!-- default file list end -->
# How to vertically align the XRCheckBox in the XRTableCell based on the neighbor cell text


<p>In this example, the <a href="http://msdn.microsoft.com/en-us/library/ms142108.aspx">Graphics.MeasureString Method </a> is used to measure the actual height of the text contained in the XRTableCell. The XRCheckBox location is updated based on this height. All this logic is executed in the XRCheckBox.BeforePrint event handler. Note that in this scenario, correct conversion methods between Pixels and ReportUnits are required. The GraphicsUnitConverter class is used for this purpose.</p>

<br/>


