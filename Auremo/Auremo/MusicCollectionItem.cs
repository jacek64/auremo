﻿/*
 * Copyright 2014 Mikko Teräs and Niilo Säämänen.
 *
 * This file is part of Auremo.
 *
 * Auremo is free software: you can redistribute it and/or modify it under the
 * terms of the GNU General Public License as published by the Free Software
 * Foundation, version 2.
 *
 * Auremo is distributed in the hope that it will be useful, but WITHOUT ANY
 * WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR
 * A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along
 * with Auremo. If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Auremo
{
    public class OldMusicCollectionItem : DataGridItem, INotifyPropertyChanged, IComparable
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        private bool m_IsSelected = false;

        public OldMusicCollectionItem(object content, int position)
        {
            Content = content;
            Position = position;
        }

        public OldMusicCollectionItem(object content, int position, bool isSelected)
        {
            Content = content;
            Position = position;
            IsSelected = isSelected;
        }

        // TODO: there should be a common base class for genre/artist/album/song/stream, used here.
        public object Content
        {
            get;
            set;
        }

        public int Position
        {
            get;
            private set;
        }

        public bool IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                if (value != m_IsSelected)
                {
                    m_IsSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        public override string ToString()
        {
            return "";
        }

        public int CompareTo(object o)
        {
            if (o is OldMusicCollectionItem)
            {
                return Position - ((OldMusicCollectionItem)o).Position;
            }
            else
            {
                throw new Exception("MusicCollectionItem: attempt to compare to an incompatible object");
            }
        }
    }
}
