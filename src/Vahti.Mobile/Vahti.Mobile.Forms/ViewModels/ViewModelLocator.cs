﻿using CommonServiceLocator;
using Vahti.Mobile.Forms.ViewModels;

namespace MobileClient.ViewModels
{
    /// <summary>
    /// Helper class used to get reference to a view model
    /// </summary>
    public static class ViewModelLocator
    {
        static ViewModelLocator()
        {            
        }

        public static LocationListViewModel Items
        {
            get { return ServiceLocator.Current.GetInstance<LocationListViewModel>(); }
        }

        public static OptionsViewModel Options
        {
            get { return ServiceLocator.Current.GetInstance<OptionsViewModel>(); }
        }

        public static AboutViewModel About
        {
            get { return ServiceLocator.Current.GetInstance<AboutViewModel>(); }
        }
        public static LocationDetailsViewModel Details
        {
            get { return ServiceLocator.Current.GetInstance<LocationDetailsViewModel>(); }
        }
        public static LocationViewModel Location
        {
            get { return ServiceLocator.Current.GetInstance<LocationViewModel>(); }
        }
        public static LocationGraphViewModel Graph
        {
            get { return ServiceLocator.Current.GetInstance<LocationGraphViewModel>(); }
        }
    }
}
