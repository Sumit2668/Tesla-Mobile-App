﻿using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tesla.Wire
{
    public class NavigationContainer : INavigationPage
    {

        private readonly NavigationPage _page = null;

        public NavigationContainer(NavigationPage page)
        {
            _page = page;
        }

        public object Page { get { return _page; } }

        public bool CanGoBack()
        {
            return _page.Navigation.NavigationStack.Count > 1;
        }

        public async Task PopAsync()
        {
            await _page.PopAsync();
        }

        public async Task PushAsync(object page)
        {
            var xamarinPage = page as Page;

            if (xamarinPage == null)
                throw new Exception("PushAsync can not push a non Xamarin Page");

            await _page.PushAsync(xamarinPage);
        }
    }
}