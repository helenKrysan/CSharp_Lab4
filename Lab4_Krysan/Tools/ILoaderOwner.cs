﻿using System.ComponentModel;
using System.Windows;

namespace Lab4_Krysan.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }

}
