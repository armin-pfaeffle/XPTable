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
using XPTable.Renderers;


namespace XPTable.Models;

/// <summary>
/// Represents a collection of Cell objects
/// </summary>
public class CellCollection : Collection<Cell>
{
	#region Class Data

	/// <summary>
	/// The Row that owns the CellCollection
	/// </summary>
	private readonly Row _owner;

	#endregion


	#region Constructor

	/// <summary>
	/// Initializes a new instance of the CellCollection class 
	/// that belongs to the specified Row
	/// </summary>
	/// <param name="owner">A Row representing the row that owns 
	/// the Cell collection</param>
	public CellCollection( Row? owner )
	{
		if ( owner == null )
		{
			throw new ArgumentNullException( nameof( owner ), "Owner must no be null" );
		}

		_owner = owner;
	}

	public Row Row
		=> _owner;

	#endregion


	#region Methods

	/// <summary>
	/// Adds the specified Cell to the end of the collection
	/// </summary>
	/// <param name="cell">The Cell to add</param>
	public new int Add( Cell cell )
	{
		if ( cell == null )
		{
			throw new ArgumentNullException( nameof( cell ), "Cell must not be null" );
		}

		base.Add( cell );

		var index = Count - 1;

		OnCellAdded( new RowEventArgs( _owner, cell, index, index ) );

		for ( var i = 1; i < cell.ColSpan; i++ )
		{
			Add( new Cell( string.Empty ) );
		}

		return index;
	}

	/// <summary>
	/// Adds an array of Cell objects to the collection
	/// </summary>
	/// <param name="cells">An array of Cell objects to add 
	/// to the collection</param>
	public void AddRange( Cell[ ] cells )
	{
		if ( cells == null )
		{
			throw new ArgumentNullException( nameof( cells ), "Cell[] is null" );
		}

		foreach ( var cell in cells )
		{
			Add( cell );
		}
	}

	/// <summary>
	/// Removes an array of Cell objects from the collection
	/// </summary>
	/// <param name="cells">An array of Cell objects to remove 
	/// from the collection</param>
	public void RemoveRange( Cell[ ] cells )
	{
		if ( cells == null )
		{
			throw new ArgumentNullException( "Cell[] is null" );
		}

		foreach ( var cell in cells )
		{
			Remove( cell );
		}
	}

	/// <summary>
	/// Removes the Cell at the specified index from the collection
	/// </summary>
	/// <param name="index">The index of the Cell to remove</param>
	public new void RemoveAt( int index )
	{
		if ( index < 0 || index >= this.Count )
		{
			return;
		}

		var cell = this[index];

		RemoveControlIfRequired( cell );

		base.RemoveAt( index );

		OnCellRemoved( new RowEventArgs( _owner, cell, index, index ) );
	}

	/// <summary>
	/// Removes all Cells from the collection
	/// </summary>
	public new void Clear( )
	{
		if ( Count == 0 )
		{
			return;
		}

		for ( var i = 0; i < Count; i++ )
		{
			RemoveControlIfRequired( this[i] );
			this[i].InternalRow = null;
		}

		base.Clear( );

		OnCellRemoved( new RowEventArgs( _owner, null, -1, -1 ) );
	}

	private void RemoveControlIfRequired( Cell cell )
	{
		if ( ( cell.RendererData as ControlRendererData )?.Control != null )
		{
			cell.Row.TableModel.Table.Controls.Remove( ( cell.RendererData as ControlRendererData ).Control );
		}
	}

	/// <summary>
	/// Inserts a Cell into the collection at the specified index
	/// </summary>
	/// <param name="index">The zero-based index at which the Cell 
	/// should be inserted</param>
	/// <param name="cell">The Cell to insert</param>
	public void Insert( int index, Cell cell )
	{
		if ( cell == null )
		{
			return;
		}

		if ( index < 0 )
		{
			throw new IndexOutOfRangeException( );
		}

		if ( index >= Count )
		{
			Add( cell );
		}
		else
		{
			base.Insert( index, cell );

			OnCellAdded( new RowEventArgs( _owner, cell, index, index ) );
		}
	}

	/// <summary>
	/// Inserts an array of Cells into the collection at the specified index
	/// </summary>
	/// <param name="index">The zero-based index at which the cells should be inserted</param>
	/// <param name="cells">An array of Cells to be inserted into the collection</param>
	public void InsertRange( int index, Cell[ ] cells )
	{
		if ( cells == null )
		{
			throw new ArgumentNullException( nameof( cells ), "Cell[] is null" );
		}

		if ( index < 0 )
		{
			throw new IndexOutOfRangeException( );
		}

		if ( index >= Count )
		{
			AddRange( cells );
		}
		else
		{
			for ( var i = cells.Length - 1; i >= 0; i-- )
			{
				Insert( index, cells[i] );
			}
		}
	}

	#endregion


	#region Events

	/// <summary>
	/// Raises the CellAdded event
	/// </summary>
	/// <param name="e">A RowEventArgs that contains the event data</param>
	protected virtual void OnCellAdded( RowEventArgs e )
	{
		_owner.OnCellAdded( e );
	}

	/// <summary>
	/// Raises the CellRemoved event
	/// </summary>
	/// <param name="e">A RowEventArgs that contains the event data</param>
	protected virtual void OnCellRemoved( RowEventArgs e )
	{
		_owner.OnCellRemoved( e );
	}

	#endregion
}