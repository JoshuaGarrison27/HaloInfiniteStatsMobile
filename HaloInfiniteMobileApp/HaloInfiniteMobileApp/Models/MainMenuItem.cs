using HaloInfiniteMobileApp.Enumerations;
using System;
using Xamarin.Forms;

namespace HaloInfiniteMobileApp.Models
{
    public class MainMenuItem : BindableObject
    {
        private string _menuText;
        private MenuItemType _menuItemType;
        private Type _viewModelToLoad;
        private string _menuItemFontAwesomeCode;

        public MenuItemType MenuItemType
        {
            get
            {
                return _menuItemType;
            }
            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        public string MenuText
        {
            get
            {
                return _menuText;
            }
            set
            {
                _menuText = value;
                OnPropertyChanged();
            }
        }
        public string MenuItemFontAwesomeCode
        {
            get
            {
                return _menuItemFontAwesomeCode;
            }
            set
            {
                _menuItemFontAwesomeCode = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelToLoad
        {
            get
            {
                return _viewModelToLoad;
            }
            set
            {
                _viewModelToLoad = value;
                OnPropertyChanged();
            }
        }
    }
}