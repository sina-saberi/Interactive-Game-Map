using Interactive_Map_Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Navigation.Helpers
{
    public static class PageExtensions
    {
        public static void NorifyReadyOnPageAndLayouts(this INavigate target)
        {
            target.OnReady();
            if (target.Layout is null) return;
            NorifyReadyOnPageAndLayouts(target.Layout);
        }
        public static INavigate SortPageAndLayouts(this INavigate target)
        {
            if (target.Layout is null) return target;
            target.Layout.Content = target;
            return SortPageAndLayouts(target.Layout);
        }
    }
}
