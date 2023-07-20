/*
* Copyright © 2005, Mathew Hall
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without modification, 
* are permitted provided that the following conditions are met:
*
*    - Redistributions of source code must retain the above copyright notice, 
*      this list of conditions and the following disclaimer.
* 
*    - Redistributions in binary form must reproduce the above copyright notice, 
*      this list of conditions and the following disclaimer in the documentation 
*      and/or other materials provided with the distribution.
*
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
* ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
* IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
* INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
* NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
* OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
* WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
* OF SUCH DAMAGE.
*/


using System.Collections.ObjectModel;
using XPTable.Events;

namespace XPTable.Models;

/// <summary>
/// Represents a collection of Row objects
/// </summary>
public class RowCollection : Collection<Row>
{
	#region Class Data

	/// <summary>
	/// The TableModel that owns the RowCollection
	/// </summary>
	private readonly TableModel? _owner;

	/// <summary>
	/// A Row that owns this row
	/// </summary>
	private readonly Row? _rowOwner;

	private int _totalHiddenSubRows = 0;

	private readonly RowEventHandler _propertyChangedEventHandler;

	#endregion


	#region Constructor

	/// <summary>
	/// Initializes a new instance of the RowCollection class 
	/// that belongs to the specified TableModel
	/// </summary>
	/// <param name="owner">A TableModel representing the tableModel that owns 
	/// the RowCollection</param>
	public RowCollection( TableModel? owner )
	{
		if ( owner == null )
		{
			throw new ArgumentNullException( nameof( owner ), "Owner must no be null" );
		}

		_owner = owner;

		_propertyChangedEventHandler = OnRowPropertyChanged;
	}

	/// <summary>
	/// Initializes a new instance of the RowCollection class 
	/// that belongs to the specified Row
	/// </summary>
	/// <param name="owner"></param>
	public RowCollection( Row owner )
	{
		if ( owner == null )
		{
			throw new ArgumentNullException( nameof( owner ), "Owner must no be null" );
		}

		_rowOwner = owner;
	}

	public TableModel? TableModel
		=> _owner;

	public Row? Row
		=> _rowOwner; 

	#endregion

	#region Methods

	/// <summary>
	/// Adds the specified Row to the end of the collection
	/// </summary>
	/// <param name="row">The Row to add</param>
	public new int Add( Row row )
	{
		if ( row == null )
		{
			throw new ArgumentNullException( nameof( row ), "Row must not be null" );
		}

		base.Add( row );

		var index = Count - 1;

		if ( _owner != null )
		{
			// this RowCollection is the collection of toplevel rows
			OnRowAdded( new TableModelEventArgs( _owner, row, index, index ) );
		}
		else if ( _rowOwner != null )
		{
			// this is a sub row, so it needs a parent
			row.Parent = _rowOwner;
			row.ChildIndex = Count;
			OnRowAdded( new RowEventArgs( row, RowEventType.SubRowAdded, _rowOwner ) );
		}

		row.PropertyChanged += _propertyChangedEventHandler;

		return index;
	}

	/// <summary>
	/// Count the number of hidden rows before the supplied row.
	/// </summary>
	/// <param name="row">The row to count up to.</param>
	/// <returns>The number of hidden rows.</returns>
	internal int HiddenRowCountBefore( int row )
	{
		var result = 0;

		var skip = 0;
		for ( var i = 0; i < row; i++ )
		{
			switch ( skip )
			{
				case > 0:
					skip--;
					break;

				case 0 when ( !this[i].ExpandSubRows ):
					skip = this[i].SubRows.Count;
					result += skip;
					break;

				default:
					skip = this[i].SubRows.Count;
					break;
			}
		}

		return result;
	}

	/// <summary>
	/// Collapses all sub rows.
	/// </summary>
	public void CollapseAllSubRows( )
	{
		for ( var i = 0; i < Count; i++ )
		{
			if ( this[i].SubRows.Count > 0 )
			{
				this[i].ExpandSubRows = false;
			}
		}
	}

	/// <summary>
	/// Expands all sub rows.
	/// </summary>
	public void ExpandAllSubRows( )
	{
		int i = 0;
		while ( i < Count )
		{
			if ( this[i].Parent == null )
			{
				this[i].ExpandSubRows = true;
				i += this[i].SubRows.Count;
			}
		}
	}

	private void OnRowPropertyChanged( object sender, RowEventArgs evt )
	{
		if ( evt.EventType == RowEventType.ExpandSubRowsChanged )
		{
			if ( !evt.Row.ExpandSubRows )
				_totalHiddenSubRows += evt.Row.SubRows.Count;
			else
				_totalHiddenSubRows -= evt.Row.SubRows.Count;
		}
	}

	/// <summary>
	/// Adds an array of Row objects to the collection
	/// </summary>
	/// <param name="rows">An array of Row objects to add 
	/// to the collection</param>
	public void AddRange( Row[ ] rows )
	{
		if ( rows == null )
		{
			throw new ArgumentNullException( nameof( rows ), "Row[] is null" );
		}

		foreach ( var row in rows )
		{
			Add( row );
		}
	}

	/// <summary>
	/// Removes the specified Row from the model
	/// </summary>
	/// <param name="row">The Row to remove</param>
	public new void Remove( Row row )
	{
		int rowIndex = IndexOf( row );

		if ( rowIndex != -1 )
		{
			RemoveAt( rowIndex );
		}
	}

	/// <summary>
	/// Removes an array of Row objects from the collection
	/// </summary>
	/// <param name="rows">An array of Row objects to remove 
	/// from the collection</param>
	public void RemoveRange( Row[ ] rows )
	{
		if ( rows == null )
		{
			throw new ArgumentNullException( nameof( rows ), "Rows must not be null" );
		}

		foreach ( var row in rows )
		{
			Remove( row );
		}
	}

	/// <summary>
	/// Removes the Row at the specified index from the collection
	/// </summary>
	/// <param name="index">The index of the Row to remove</param>
	public new void RemoveAt( int index )
	{
		if ( index < 0 || index >= Count )
		{
			return;
		}

		var row = this[index];

		RemoveControlIfRequired( index );
		base.RemoveAt( index );

		if ( _owner != null )
		{
			OnRowRemoved( new TableModelEventArgs( _owner, row, index, index ) );
		}
		else if ( _rowOwner != null )
		{
			OnRowRemoved( new RowEventArgs( row, RowEventType.SubRowRemoved, _rowOwner ) );
		}

		row.PropertyChanged -= _propertyChangedEventHandler;
	}

	private void RemoveControlIfRequired( int index )
	{
		foreach ( var cell in this[index].Cells )
		{
			if ( cell.RendererData is Renderers.ControlRendererData data )
			{
				if ( data.Control != null )
				{
					cell.Row.TableModel.Table.Controls.Remove( ( cell.RendererData as Renderers.ControlRendererData ).Control );
				}
			}
		}
	}

	/// <summary>
	/// Removes all Rows from the collection
	/// </summary>
	public new void Clear( )
	{
		if ( Count == 0 )
		{
			return;
		}

		this[0].InternalTableModel.Table.ClearAllRowControls( );
		for ( int i = 0; i < Count; i++ )
		{
			this[i].InternalTableModel = null;
		}

		base.Clear( );

		if ( _owner != null )
		{
			_owner.OnRowRemoved( new TableModelEventArgs( _owner, null, -1, -1 ) );
		}

		else if ( _rowOwner != null )
		{
			OnRowRemoved( new RowEventArgs( null, RowEventType.SubRowRemoved, _rowOwner ) );
		}
	}

	/// <summary>
	/// Inserts a Row into the collection at the specified index
	/// </summary>
	/// <param name="index">The zero-based index at which the Row 
	/// should be inserted</param>
	/// <param name="row">The Row to insert</param>
	public new void Insert( int index, Row? row )
	{
		if ( row == null )
		{
			return;
		}

		if ( index < 0 )
		{
			throw new IndexOutOfRangeException( );
		}

		if ( index >= Count )
		{
			Add( row );
		}
		else
		{
			base.Insert( index, row );

			if ( _owner != null )
			{
				_owner.OnRowAdded( new TableModelEventArgs( _owner, row, index, index ) );
			}
			else if ( _rowOwner != null )
			{
				RowEventArgs args = new RowEventArgs( row, RowEventType.SubRowAdded, _rowOwner );
				args.SetRowIndex( index );
				OnRowAdded( args );
			}
		}
	}


	/// <summary>
	/// Inserts an array of Rows into the collection at the specified 
	/// index
	/// </summary>
	/// <param name="index">The zero-based index at which the rows 
	/// should be inserted</param>
	/// <param name="rows">The array of Rows to be inserted into 
	/// the collection</param>
	public void InsertRange( int index, Row[ ] rows )
	{
		if ( rows == null )
		{
			throw new ArgumentNullException( nameof( rows ), "Rows must not be null" );
		}

		if ( index < 0 )
		{
			throw new IndexOutOfRangeException( );
		}

		if ( index >= Count )
		{
			AddRange( rows );
		}
		else
		{
			for ( var i = rows.Length - 1; i >= 0; i-- )
			{
				Insert( index, rows[i] );
			}
		}
	}

	#endregion


	#region Properties

	/// <summary>
	/// Replaces the Row at the specified index to the specified Row
	/// </summary>
	/// <param name="index">The index of the Row to be replaced</param>
	/// <param name="row">The Row to be placed at the specified index</param>
	internal void SetRow( int index, Row row )
	{
		if ( index < 0 || index >= Count )
		{
			throw new ArgumentOutOfRangeException( nameof( index ) );
		}

		if ( row == null )
		{
			throw new ArgumentNullException( nameof( row ), "Row cannot be null" );
		}

		this[index] = row;

		row.InternalIndex = index;
	}

	#endregion


	#region Events

	/// <summary>
	/// Raises the RowAdded event
	/// </summary>
	/// <param name="e">A TableModelEventArgs that contains the event data</param>
	protected virtual void OnRowAdded( TableModelEventArgs e )
	{
		_owner?.OnRowAdded( e );
	}


	/// <summary>
	/// Raises the RowRemoved event
	/// </summary>
	/// <param name="e">A TableModelEventArgs that contains the event data</param>
	protected virtual void OnRowRemoved( TableModelEventArgs e )
	{
		_owner?.OnRowRemoved( e );
	}

	/// <summary>
	/// Raises the RowAdded event
	/// </summary>
	/// <param name="e">A TableModelEventArgs that contains the event data</param>
	protected virtual void OnRowAdded( RowEventArgs e )
	{
		_rowOwner?.OnSubRowAdded( e );
	}


	/// <summary>
	/// Raises the RowRemoved event
	/// </summary>
	/// <param name="e">A TableModelEventArgs that contains the event data</param>
	protected virtual void OnRowRemoved( RowEventArgs e )
	{
		_rowOwner?.OnSubRowRemoved( e );
	}

	/// <summary>
	/// Gets the total number of subrows that are currently not expanded.
	/// </summary>
	public int HiddenSubRows
		=> _totalHiddenSubRows;

	#endregion
}