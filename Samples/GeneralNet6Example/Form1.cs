namespace GeneralNet6Example;

public partial class Form1 : Form
{
	public Form1( )
	{
		InitializeComponent( );
	}

	private void Form1_Load( object sender, EventArgs e )
	{
		var random = new Random( );
		var round = 1;

		tableModel1.Rows.Clear( );
		for ( var i = 0; i < 20; i++ )
		{
			var row = new XPTable.Models.Row( );
			tableModel1.Rows.Add( row );

			row.Cells.Clear( );

			var checkBoxCell = new XPTable.Models.Cell( );
			row.Cells.Add( checkBoxCell );

			var comboBoxCell = new XPTable.Models.Cell( );
			comboBoxCell.Text = $"ComboBox {round}";
			row.Cells.Add( comboBoxCell );

			var progressBarCell = new XPTable.Models.Cell( );
			row.Cells.Add( progressBarCell );
			progressBarCell.Data = random.Next( 0, 100 );

			var colorCell = new XPTable.Models.Cell( );
			row.Cells.Add( colorCell );

			round++;
		}
	}
}
