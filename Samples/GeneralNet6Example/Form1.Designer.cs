namespace GeneralNet6Example;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose( bool disposing )
	{
		if ( disposing && ( components != null ) )
		{
			components.Dispose( );
		}
		base.Dispose( disposing );
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent( )
	{
		var dataSourceColumnBinder1 = new XPTable.Models.DataSourceColumnBinder( );
		var dragDropRenderer1 = new XPTable.Renderers.DragDropRenderer( );
		var row1 = new XPTable.Models.Row( );
		var cell1 = new XPTable.Models.Cell( );
		var cellStyle1 = new XPTable.Models.CellStyle( );
		var cell2 = new XPTable.Models.Cell( );
		var cellStyle2 = new XPTable.Models.CellStyle( );
		var cell3 = new XPTable.Models.Cell( );
		var cellStyle3 = new XPTable.Models.CellStyle( );
		var cell4 = new XPTable.Models.Cell( );
		var cellStyle4 = new XPTable.Models.CellStyle( );
		var row2 = new XPTable.Models.Row( );
		var row3 = new XPTable.Models.Row( );
		var row4 = new XPTable.Models.Row( );
		table1 = new XPTable.Models.Table( );
		columnModel1 = new XPTable.Models.ColumnModel( );
		checkBoxColumn1 = new XPTable.Models.CheckBoxColumn( );
		comboBoxColumn1 = new XPTable.Models.ComboBoxColumn( );
		progressBarColumn1 = new XPTable.Models.ProgressBarColumn( );
		colorColumn1 = new XPTable.Models.ColorColumn( );
		tableModel1 = new XPTable.Models.TableModel( );
		( ( System.ComponentModel.ISupportInitialize )  table1  ).BeginInit( );
		SuspendLayout( );
		// 
		// table1
		// 
		table1.BorderColor = Color.Black;
		table1.ColumnModel = columnModel1;
		table1.DataMember = null;
		table1.DataSourceColumnBinder = dataSourceColumnBinder1;
		dragDropRenderer1.ForeColor = Color.Red;
		table1.DragDropRenderer = dragDropRenderer1;
		table1.GridLinesContrainedToData = false;
		table1.Location = new Point( 12, 12 );
		table1.Name = "table1";
		table1.Size = new Size( 776, 651 );
		table1.TabIndex = 0;
		table1.TableModel = tableModel1;
		table1.Text = "table1";
		table1.UnfocusedBorderColor = Color.Black;
		// 
		// columnModel1
		// 
		columnModel1.Columns.AddRange( new XPTable.Models.Column[ ] { checkBoxColumn1, comboBoxColumn1, progressBarColumn1, colorColumn1 } );
		// 
		// checkBoxColumn1
		// 
		checkBoxColumn1.IsTextTrimmed = false;
		checkBoxColumn1.Width = 30;
		checkBoxColumn1.Name = "checkBoxColumn1";
		// 
		// comboBoxColumn1
		// 
		comboBoxColumn1.IsTextTrimmed = false;
		comboBoxColumn1.Text = "Values";
		comboBoxColumn1.Width = 100;
		comboBoxColumn1.Name = "comboBoxColumn1";
		// 
		// progressBarColumn1
		// 
		progressBarColumn1.IsTextTrimmed = false;
		progressBarColumn1.Text = "Progress";
		progressBarColumn1.Width = 100;
		progressBarColumn1.Name = "progressBarColumn1";
		// 
		// colorColumn1
		// 
		colorColumn1.IsTextTrimmed = false;
		colorColumn1.Text = "Color";
		colorColumn1.Width = 150;
		colorColumn1.Name = "colorColumn1";
		// 
		// tableModel1
		// 
		tableModel1.RowHeight = 25;
		cellStyle1.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle1.BackColor = Color.Empty;
		cellStyle1.Font = null;
		cellStyle1.ForeColor = Color.Empty;
		cellStyle1.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle1.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle1.WordWrap = false;
		cell1.CellStyle = cellStyle1;
		cell1.ContentWidth = 13;
		cell1.Data = "";
		cell1.Tag = "";
		cell1.Text = "";
		cell1.ToolTipText = "70";
		cell1.WordWrap = false;
		cellStyle2.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle2.BackColor = Color.Empty;
		cellStyle2.Font = null;
		cellStyle2.ForeColor = Color.Empty;
		cellStyle2.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle2.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle2.WordWrap = false;
		cell2.CellStyle = cellStyle2;
		cell2.ContentWidth = 15;
		cell2.WordWrap = false;
		cellStyle3.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle3.BackColor = Color.Empty;
		cellStyle3.Font = null;
		cellStyle3.ForeColor = Color.Empty;
		cellStyle3.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle3.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle3.WordWrap = false;
		cell3.CellStyle = cellStyle3;
		cell3.ContentWidth = 0;
		cell3.Data = "60";
		cell3.WordWrap = false;
		cellStyle4.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle4.BackColor = Color.Empty;
		cellStyle4.Font = null;
		cellStyle4.ForeColor = Color.Empty;
		cellStyle4.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle4.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle4.WordWrap = false;
		cell4.CellStyle = cellStyle4;
		cell4.ContentWidth = 63;
		cell4.WordWrap = false;
		row1.Cells.AddRange( new XPTable.Models.Cell[ ] { cell1, cell2, cell3, cell4 } );
		row1.ChildIndex = 0;
		row1.ExpandSubRows = true;
		row1.Height = 15;
		row2.ChildIndex = 0;
		row2.ExpandSubRows = true;
		row2.Height = 15;
		row3.ChildIndex = 0;
		row3.ExpandSubRows = true;
		row3.Height = 15;
		row4.ChildIndex = 0;
		row4.ExpandSubRows = true;
		row4.Height = 15;
		tableModel1.Rows.AddRange( new XPTable.Models.Row[ ] { row1, row2, row3, row4 } );
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF( 8F, 20F );
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size( 800, 718 );
		Controls.Add( table1 );
		Name = "Form1";
		Text = "Form1";
		Load += Form1_Load;
		( ( System.ComponentModel.ISupportInitialize )  table1  ).EndInit( );
		ResumeLayout( false );
	}

	#endregion

	private XPTable.Models.Table table1;
	private XPTable.Models.ColumnModel columnModel1;
	private XPTable.Models.TableModel tableModel1;
	private XPTable.Models.CheckBoxColumn checkBoxColumn1;
	private XPTable.Models.ComboBoxColumn comboBoxColumn1;
	private XPTable.Models.ProgressBarColumn progressBarColumn1;
	private XPTable.Models.ColorColumn colorColumn1;
}
