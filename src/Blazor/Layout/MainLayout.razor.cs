﻿using BlazorBootstrap;

namespace Blazor.Layout;

public partial class MainLayout
{
    private Sidebar sidebar = default!;
    IEnumerable<NavItem>? navItems;
    
    private IEnumerable<NavItem> GetNavItems()
    {
        navItems = new List<NavItem>
        {
            new NavItem { Id = "1", Href = "/getting-started", IconName = IconName.HouseDoorFill, Text = "Getting Started"},

            new NavItem { Id = "2", IconName = IconName.LayoutSidebarInset, Text = "Content", IconColor = IconColor.Primary },
            new NavItem { Id = "3", Href = "/icons", IconName = IconName.PersonSquare, Text = "Icons", ParentId="2"},

            new NavItem { Id = "4", IconName = IconName.ExclamationTriangleFill, Text = "Components", IconColor = IconColor.Success },
            new NavItem { Id = "5", Href = "/alerts", IconName = IconName.CheckCircleFill, Text = "Alerts", ParentId="4"},
            new NavItem { Id = "6", Href = "/breadcrumb", IconName = IconName.SegmentedNav, Text = "Breadcrumb", ParentId="4"},
            new NavItem { Id = "7", Href = "/sidebar", IconName = IconName.LayoutSidebarInset, Text = "Sidebar", ParentId="4"},

            new NavItem { Id = "8", IconName = IconName.WindowPlus, Text = "Forms", IconColor = IconColor.Danger },
            new NavItem { Id = "9", Href = "/autocomplete", IconName = IconName.InputCursorText, Text = "Auto Complete", ParentId="8"},
            new NavItem { Id = "10", Href = "/currency-input", IconName = IconName.CurrencyDollar, Text = "Currency Input", ParentId="8"},
            new NavItem { Id = "11", Href = "/number-input", IconName = IconName.InputCursor, Text = "Number Input", ParentId="8"},
            new NavItem { Id = "12", Href = "/switch", IconName = IconName.ToggleOn, Text = "Switch", ParentId="8"},
        };

        return navItems;
    }
    
    private async Task<SidebarDataProviderResult> SidebarDataProvider(SidebarDataProviderRequest request)
    {
        if (navItems is null)
            navItems = GetNavItems();

        return await Task.FromResult(request.ApplyTo(navItems));
    }

    
    private void ToggleSidebar() => sidebar.ToggleSidebar();
}