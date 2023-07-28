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
/// Represents a collection of Column objects
/// </summary>
public class ColumnCollection : Collection<Column>
{
	#region Class Data

	/// <summary>
	/// The ColumnModel that owns the CollumnCollection
	/// </summary>
	private readonly ColumnModel _owner;

	/// <summary>
	/// A local cache of the combined width of all columns
	/// </summary>
	private int _totalColumnWidth;

	/// <summary>
	/// A local cache of the combined width of all visible columns
	/// </summary>
	private int _visibleColumnsWidth;

	/// <summary>
	/// A local cache of the number of visible columns
	/// </summary>
	private int _visibleColumnCount;

	/// <summary>
	/// A local cache of the last visible column in the collection
	/// </summary>
	private int _lastVisibleColumn;

	#endregion

	#region Constructor

	/// <summary>
	/// Initializes a new instance of the ColumnModel.ColumnCollection class 
	/// that belongs to the specified ColumnModel
	/// </summary>
	/// <param name="owner">A ColumnModel representing the columnModel that owns 
	/// the Column collection</param>
	public ColumnCollection( ColumnModel? owner )
	{
		if ( owner == null )
		{
			throw new ArgumentNullException( nameof( owner ), "Owner must no be null" );
		}

		_owner = owner;
		_totalColumnWidth = 0;
		_visibleColumnsWidth = 0;
		_visibleColumnCount = 0;
		_lastVisibleColumn = -1;
	}

	#endregion

	#region Methods

	/// <summary>
	/// Adds the specified Column to the end of the collection
	/// </summary>
	/// <param name="column">The Column to add</param>
	public new int Add( Column column )
	{
		if ( column == null )
		{
			throw new ArgumentNullException( nameof( column ), "Column is null" );
		}

		base.Add( column );

		var index = Count - 1;

		RecalculateWidthCache( );

		OnColumnAdded( new ColumnModelEventArgs( _owner, column, index, index ) );

		return index;
	}

	/// <summary>
	/// Adds an array of Column objects to the collection
	/// </summary>
	/// <param name="columns">An array of Column objects to add 
	/// to the collection</param>
	public void AddRange( Column[ ] columns )
	{
		if ( columns == null )
		{
			throw new ArgumentNullException( nameof( columns ), "Column[] is null" );
		}

		foreach ( var column in columns )
		{
			Add( column );
		}
	}

	/// <summary>
	/// Removes the specified Column from the model
	/// </summary>
	/// <param name="column">The Column to remove</param>
	public void Remove( Column column )
	{
		int columnIndex = IndexOf( column );

		if ( columnIndex != -1 )
		{
			RemoveAt( columnIndex );
		}
	}

	/// <summary>
	/// Removes an array of Column objects from the collection
	/// </summary>
	/// <param name="columns">An array of Column objects to remove 
	/// from the collection</param>
	public void RemoveRange( Column[ ] columns )
	{
		if ( columns == null )
		{
			throw new ArgumentNullException( nameof( columns ), "Column[] is null" );
		}

		foreach ( var column in columns )
		{
			Remove( column );
		}
	}

	/// <summary>
	/// Removes the Column at the specified index from the collection
	/// </summary>
	/// <param name="index">The index of the Column to remove</param>
	public new void RemoveAt( int index )
	{
		if ( index < 0 || index >= Count )
		{
			return;
		}

		var column = this[index];

		RemoveControlIfRequired( index );
		base.RemoveAt( index );

		RecalculateWidthCache( );

		OnColumnRemoved( new ColumnModelEventArgs( _owner, column, index, index ) );
	}

	/// <summary>
	/// Removes all Columns from the collection
	/// </summary>
	public new void Clear( )
	{
		if ( Count == 0 )
		{
			return;
		}

		for ( var i = 0; i < Count; i++ )
		{
			RemoveControlIfRequired( i );

			this[i].ColumnModel = null;
		}

		base.Clear( );

		RecalculateWidthCache( );

		OnColumnRemoved( new ColumnModelEventArgs( _owner, null, -1, -1 ) );
	}

	private void RemoveControlIfRequired( int index )
	{
		for ( var i = 0; i < _owner.Table.RowCount; i++ )
		{
			if ( index >= _owner.Table.TableModel.Rows[i].Cells.Count )
			{
				continue;
			}

			var cell = _owner.Table.TableModel.Rows[i].Cells[index];

			if ( cell.RendererData is not Renderers.ControlRendererData data )
			{
				continue;
			}

			if ( data.Control != null )
			{
				cell.Row.TableModel.Table.Controls.Remove( ( cell.RendererData as Renderers.ControlRendererData ).Control );
			}
		}
	}

	/// <summary>
	/// Returns the index of the named Column in the model
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public int IndexOf( string name )
	{
		for ( var i = 0; i < Count; i++ )
		{
			if ( this[i].Name == name )
			{
				return i;
			}
		}

		return -1;
	}

	/// <summary>
	/// Returns the index of the Column that has the specified text
	/// </summary>
	/// <param name="text">The text.</param>
	/// <returns></returns>
	public int IndexOfText( string text )
	{
		for ( var i = 0; i < this.Count; i++ )
		{
			if ( this[i].Text == text )
			{
				return i;
			}
		}

		return -1;
	}

	/// <summary>
	/// Recalculates the total combined width of all columns
	/// </summary>
	protected internal void RecalculateWidthCache( )
	{
		var total = 0;
		var visibleWidth = 0;
		var visibleCount = 0;
		var lastVisible = -1;

		for ( var i = 0; i < Count; i++ )
		{
			total += this[i].Width;

			if ( this[i].Visible )
			{
				this[i].X = visibleWidth;
				visibleWidth += this[i].Width;
				visibleCount++;
				lastVisible = i;
			}
		}

		this._totalColumnWidth = total;
		this._visibleColumnsWidth = visibleWidth;
		this._visibleColumnCount = visibleCount;
		this._lastVisibleColumn = lastVisible;
	}

	#endregion

	#region Properties

	/// <summary>
	/// Gets the Column at the specified index.
	///
	/// Note: In case index is out of range no exception is thrown but null is returned.
	/// </summary>
	public new Column? this[ int index ]
	{
		get
		{
			if ( index < 0 || index >= this.Count )
				return null;

			return base[index];
		}
	}

	/// <summary>
	/// Gets the Column with the specified name
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	public Column? this[ string name ]
	{
		get
		{
			var index = IndexOf( name );

			return base[index];
		}
	}

	/// <summary>
	/// Gets the ColumnModel that owns this ColumnCollection
	/// </summary>
	public ColumnModel ColumnModel
		=> _owner;

	/// <summary>
	/// Returns the total width of all the Columns in the model
	/// </summary>
	internal int TotalColumnWidth
		=> _totalColumnWidth;

	/// <summary>
	/// Returns the total width of all the visible Columns in the model
	/// </summary>
	internal int VisibleColumnsWidth
		=> _visibleColumnsWidth;

	/// <summary>
	/// Returns the number of visible Columns in the model
	/// </summary>
	internal int VisibleColumnCount
		=> _visibleColumnCount;

	/// <summary>
	/// Returns the index of the last visible Column in the model
	/// </summary>
	internal int LastVisibleColumn
		=> _lastVisibleColumn;

	#endregion

	#region Events

	/// <summary>
	/// Raises the ColumnAdded event
	/// </summary>
	/// <param name="e">A ColumnModelEventArgs that contains the event data</param>
	protected virtual void OnColumnAdded( ColumnModelEventArgs e )
	{
		_owner.OnColumnAdded( e );
	}

	/// <summary>
	/// Raises the ColumnRemoved event
	/// </summary>
	/// <param name="e">A ColumnModelEventArgs that contains the event data</param>
	protected virtual void OnColumnRemoved( ColumnModelEventArgs e )
	{
		_owner.OnColumnRemoved( e );
	}

	#endregion
}