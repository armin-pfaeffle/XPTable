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
		var cell5 = new XPTable.Models.Cell( );
		var cellStyle5 = new XPTable.Models.CellStyle( );
		var cell6 = new XPTable.Models.Cell( );
		var cellStyle6 = new XPTable.Models.CellStyle( );
		var row2 = new XPTable.Models.Row( );
		var cell7 = new XPTable.Models.Cell( );
		var cellStyle7 = new XPTable.Models.CellStyle( );
		var cell8 = new XPTable.Models.Cell( );
		var cellStyle8 = new XPTable.Models.CellStyle( );
		var cell9 = new XPTable.Models.Cell( );
		var cellStyle9 = new XPTable.Models.CellStyle( );
		var cell10 = new XPTable.Models.Cell( );
		var cellStyle10 = new XPTable.Models.CellStyle( );
		var cell11 = new XPTable.Models.Cell( );
		var cellStyle11 = new XPTable.Models.CellStyle( );
		var cell12 = new XPTable.Models.Cell( );
		var cellStyle12 = new XPTable.Models.CellStyle( );
		var row3 = new XPTable.Models.Row( );
		var cell13 = new XPTable.Models.Cell( );
		var cellStyle13 = new XPTable.Models.CellStyle( );
		var cell14 = new XPTable.Models.Cell( );
		var cellStyle14 = new XPTable.Models.CellStyle( );
		var cell15 = new XPTable.Models.Cell( );
		var cellStyle15 = new XPTable.Models.CellStyle( );
		var cell16 = new XPTable.Models.Cell( );
		var cellStyle16 = new XPTable.Models.CellStyle( );
		var cell17 = new XPTable.Models.Cell( );
		var cellStyle17 = new XPTable.Models.CellStyle( );
		var cell18 = new XPTable.Models.Cell( );
		var cellStyle18 = new XPTable.Models.CellStyle( );
		var row4 = new XPTable.Models.Row( );
		var cell19 = new XPTable.Models.Cell( );
		var cellStyle19 = new XPTable.Models.CellStyle( );
		var cell20 = new XPTable.Models.Cell( );
		var cellStyle20 = new XPTable.Models.CellStyle( );
		var cell21 = new XPTable.Models.Cell( );
		var cellStyle21 = new XPTable.Models.CellStyle( );
		var cell22 = new XPTable.Models.Cell( );
		var cellStyle22 = new XPTable.Models.CellStyle( );
		var cell23 = new XPTable.Models.Cell( );
		var cellStyle23 = new XPTable.Models.CellStyle( );
		var cell24 = new XPTable.Models.Cell( );
		var cellStyle24 = new XPTable.Models.CellStyle( );
		table1 = new XPTable.Models.Table( );
		columnModel1 = new XPTable.Models.ColumnModel( );
		textColumn1 = new XPTable.Models.TextColumn( );
		buttonColumn1 = new XPTable.Models.ButtonColumn( );
		textColumn2 = new XPTable.Models.TextColumn( );
		textColumn3 = new XPTable.Models.TextColumn( );
		textColumn4 = new XPTable.Models.TextColumn( );
		textColumn5 = new XPTable.Models.TextColumn( );
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
		table1.Size = new Size( 776, 426 );
		table1.TabIndex = 0;
		table1.TableModel = tableModel1;
		table1.Text = "table1";
		table1.UnfocusedBorderColor = Color.Black;
		// 
		// columnModel1
		// 
		columnModel1.Columns.AddRange( new XPTable.Models.Column[ ] { textColumn1, buttonColumn1, textColumn2, textColumn3, textColumn4, textColumn5 } );
		// 
		// textColumn1
		// 
		textColumn1.IsTextTrimmed = false;
		textColumn1.Text = "txt1";
		// 
		// buttonColumn1
		// 
		buttonColumn1.IsTextTrimmed = false;
		buttonColumn1.Text = "btncol";
		// 
		// textColumn2
		// 
		textColumn2.IsTextTrimmed = false;
		textColumn2.Text = "col2";
		// 
		// textColumn3
		// 
		textColumn3.IsTextTrimmed = false;
		textColumn3.Text = "txtcol3";
		// 
		// textColumn4
		// 
		textColumn4.IsTextTrimmed = false;
		// 
		// textColumn5
		// 
		textColumn5.IsTextTrimmed = false;
		// 
		// tableModel1
		// 
		cellStyle1.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle1.BackColor = Color.Empty;
		cellStyle1.Font = null;
		cellStyle1.ForeColor = Color.Empty;
		cellStyle1.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle1.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle1.WordWrap = false;
		cell1.CellStyle = cellStyle1;
		cell1.ContentWidth = 36;
		cell1.Text = "Col1";
		cell1.WordWrap = false;
		cellStyle2.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle2.BackColor = Color.Empty;
		cellStyle2.Font = null;
		cellStyle2.ForeColor = Color.Empty;
		cellStyle2.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle2.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle2.WordWrap = false;
		cell2.CellStyle = cellStyle2;
		cell2.ContentWidth = 36;
		cell2.Text = "Col2";
		cell2.WordWrap = false;
		cellStyle3.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle3.BackColor = Color.Empty;
		cellStyle3.Font = null;
		cellStyle3.ForeColor = Color.Empty;
		cellStyle3.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle3.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle3.WordWrap = false;
		cell3.CellStyle = cellStyle3;
		cell3.ContentWidth = 77;
		cell3.Text = "Hallo Welt";
		cell3.WordWrap = false;
		cellStyle4.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle4.BackColor = Color.Empty;
		cellStyle4.Font = null;
		cellStyle4.ForeColor = Color.Empty;
		cellStyle4.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle4.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle4.WordWrap = false;
		cell4.CellStyle = cellStyle4;
		cell4.ContentWidth = 32;
		cell4.Text = "Last";
		cell4.WordWrap = false;
		cellStyle5.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle5.BackColor = Color.Empty;
		cellStyle5.Font = null;
		cellStyle5.ForeColor = Color.Empty;
		cellStyle5.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle5.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle5.WordWrap = false;
		cell5.CellStyle = cellStyle5;
		cell5.ContentWidth = 0;
		cell5.WordWrap = false;
		cellStyle6.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle6.BackColor = Color.Empty;
		cellStyle6.Font = null;
		cellStyle6.ForeColor = Color.Empty;
		cellStyle6.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle6.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle6.WordWrap = false;
		cell6.CellStyle = cellStyle6;
		cell6.ContentWidth = 0;
		cell6.WordWrap = false;
		row1.Cells.AddRange( new XPTable.Models.Cell[ ] { cell1, cell2, cell3, cell4, cell5, cell6 } );
		row1.ChildIndex = 0;
		row1.ExpandSubRows = true;
		row1.Height = 15;
		cellStyle7.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle7.BackColor = Color.Empty;
		cellStyle7.Font = null;
		cellStyle7.ForeColor = Color.Empty;
		cellStyle7.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle7.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle7.WordWrap = false;
		cell7.CellStyle = cellStyle7;
		cell7.ContentWidth = 0;
		cell7.WordWrap = false;
		cellStyle8.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle8.BackColor = Color.Empty;
		cellStyle8.Font = null;
		cellStyle8.ForeColor = Color.Empty;
		cellStyle8.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle8.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle8.WordWrap = false;
		cell8.CellStyle = cellStyle8;
		cell8.ContentWidth = 0;
		cell8.WordWrap = false;
		cellStyle9.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle9.BackColor = Color.Empty;
		cellStyle9.Font = null;
		cellStyle9.ForeColor = Color.Empty;
		cellStyle9.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle9.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle9.WordWrap = false;
		cell9.CellStyle = cellStyle9;
		cell9.ContentWidth = 0;
		cell9.WordWrap = false;
		cellStyle10.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle10.BackColor = Color.Empty;
		cellStyle10.Font = null;
		cellStyle10.ForeColor = Color.Empty;
		cellStyle10.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle10.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle10.WordWrap = false;
		cell10.CellStyle = cellStyle10;
		cell10.ContentWidth = 0;
		cell10.WordWrap = false;
		cellStyle11.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle11.BackColor = Color.Empty;
		cellStyle11.Font = null;
		cellStyle11.ForeColor = Color.Empty;
		cellStyle11.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle11.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle11.WordWrap = false;
		cell11.CellStyle = cellStyle11;
		cell11.ContentWidth = 0;
		cell11.WordWrap = false;
		cellStyle12.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle12.BackColor = Color.Empty;
		cellStyle12.Font = null;
		cellStyle12.ForeColor = Color.Empty;
		cellStyle12.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle12.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle12.WordWrap = false;
		cell12.CellStyle = cellStyle12;
		cell12.ContentWidth = 0;
		cell12.WordWrap = false;
		row2.Cells.AddRange( new XPTable.Models.Cell[ ] { cell7, cell8, cell9, cell10, cell11, cell12 } );
		row2.ChildIndex = 0;
		row2.ExpandSubRows = true;
		row2.Height = 15;
		cellStyle13.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle13.BackColor = Color.Empty;
		cellStyle13.Font = null;
		cellStyle13.ForeColor = Color.Empty;
		cellStyle13.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle13.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle13.WordWrap = false;
		cell13.CellStyle = cellStyle13;
		cell13.ContentWidth = 0;
		cell13.WordWrap = false;
		cellStyle14.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle14.BackColor = Color.Empty;
		cellStyle14.Font = null;
		cellStyle14.ForeColor = Color.Empty;
		cellStyle14.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle14.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle14.WordWrap = false;
		cell14.CellStyle = cellStyle14;
		cell14.ContentWidth = 0;
		cell14.WordWrap = false;
		cellStyle15.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle15.BackColor = Color.Empty;
		cellStyle15.Font = null;
		cellStyle15.ForeColor = Color.Empty;
		cellStyle15.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle15.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle15.WordWrap = false;
		cell15.CellStyle = cellStyle15;
		cell15.ContentWidth = 0;
		cell15.WordWrap = false;
		cellStyle16.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle16.BackColor = Color.Empty;
		cellStyle16.Font = null;
		cellStyle16.ForeColor = Color.Empty;
		cellStyle16.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle16.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle16.WordWrap = false;
		cell16.CellStyle = cellStyle16;
		cell16.ContentWidth = 0;
		cell16.WordWrap = false;
		cellStyle17.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle17.BackColor = Color.Empty;
		cellStyle17.Font = null;
		cellStyle17.ForeColor = Color.Empty;
		cellStyle17.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle17.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle17.WordWrap = false;
		cell17.CellStyle = cellStyle17;
		cell17.ContentWidth = 0;
		cell17.WordWrap = false;
		cellStyle18.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle18.BackColor = Color.Empty;
		cellStyle18.Font = null;
		cellStyle18.ForeColor = Color.Empty;
		cellStyle18.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle18.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle18.WordWrap = false;
		cell18.CellStyle = cellStyle18;
		cell18.ContentWidth = 0;
		cell18.WordWrap = false;
		row3.Cells.AddRange( new XPTable.Models.Cell[ ] { cell13, cell14, cell15, cell16, cell17, cell18 } );
		row3.ChildIndex = 0;
		row3.ExpandSubRows = true;
		row3.Height = 15;
		cellStyle19.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle19.BackColor = Color.Empty;
		cellStyle19.Font = null;
		cellStyle19.ForeColor = Color.Empty;
		cellStyle19.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle19.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle19.WordWrap = false;
		cell19.CellStyle = cellStyle19;
		cell19.ContentWidth = 0;
		cell19.WordWrap = false;
		cellStyle20.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle20.BackColor = Color.Empty;
		cellStyle20.Font = null;
		cellStyle20.ForeColor = Color.Empty;
		cellStyle20.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle20.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle20.WordWrap = false;
		cell20.CellStyle = cellStyle20;
		cell20.ContentWidth = 0;
		cell20.WordWrap = false;
		cellStyle21.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle21.BackColor = Color.Empty;
		cellStyle21.Font = null;
		cellStyle21.ForeColor = Color.Empty;
		cellStyle21.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle21.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle21.WordWrap = false;
		cell21.CellStyle = cellStyle21;
		cell21.ContentWidth = 0;
		cell21.WordWrap = false;
		cellStyle22.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle22.BackColor = Color.Empty;
		cellStyle22.Font = null;
		cellStyle22.ForeColor = Color.Empty;
		cellStyle22.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle22.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle22.WordWrap = false;
		cell22.CellStyle = cellStyle22;
		cell22.ContentWidth = 0;
		cell22.WordWrap = false;
		cellStyle23.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle23.BackColor = Color.Empty;
		cellStyle23.Font = null;
		cellStyle23.ForeColor = Color.Empty;
		cellStyle23.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle23.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle23.WordWrap = false;
		cell23.CellStyle = cellStyle23;
		cell23.ContentWidth = 0;
		cell23.WordWrap = false;
		cellStyle24.Alignment = XPTable.Models.ColumnAlignment.Left;
		cellStyle24.BackColor = Color.Empty;
		cellStyle24.Font = null;
		cellStyle24.ForeColor = Color.Empty;
		cellStyle24.LineAlignment = XPTable.Models.RowAlignment.Top;
		cellStyle24.Padding = new XPTable.Models.CellPadding( 0, 0, 0, 0 );
		cellStyle24.WordWrap = false;
		cell24.CellStyle = cellStyle24;
		cell24.ContentWidth = 0;
		cell24.WordWrap = false;
		row4.Cells.AddRange( new XPTable.Models.Cell[ ] { cell19, cell20, cell21, cell22, cell23, cell24 } );
		row4.ChildIndex = 0;
		row4.ExpandSubRows = true;
		row4.Height = 15;
		tableModel1.Rows.AddRange( new XPTable.Models.Row[ ] { row1, row2, row3, row4 } );
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF( 8F, 20F );
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size( 800, 450 );
		Controls.Add( table1 );
		Name = "Form1";
		Text = "Form1";
		( ( System.ComponentModel.ISupportInitialize )  table1  ).EndInit( );
		ResumeLayout( false );
	}

	#endregion

	private XPTable.Models.Table table1;
	private XPTable.Models.ColumnModel columnModel1;
	private XPTable.Models.TableModel tableModel1;
	private XPTable.Models.TextColumn textColumn1;
	private XPTable.Models.ButtonColumn buttonColumn1;
	private XPTable.Models.TextColumn textColumn2;
	private XPTable.Models.TextColumn textColumn3;
	private XPTable.Models.TextColumn textColumn4;
	private XPTable.Models.TextColumn textColumn5;
}
