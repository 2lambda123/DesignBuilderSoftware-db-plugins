﻿using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Text;
using DB.Extensibility.Contracts;

namespace DBPluginStaticMenu
{
    [Export (typeof(IPlugin))]
    public class ExamplePlugin : PluginBase, IPlugin
    {
        class MenuKeys
        {
            public const string Root = "root";
            public const string ShowMessage = "showMessage";
        }
        public override bool HasMenu
        {
            get { return true; }
        }
        public override string MenuLayout
        {
            get {
                StringBuilder menu = new StringBuilder();
                menu.AppendFormat("*Example Plugin,{0}", MenuKeys.Root);
                menu.AppendFormat("*>Show Message,{0}", MenuKeys.ShowMessage);
                return menu.ToString();
            }
        }
        public override bool IsMenuItemVisible(string key)
        {
            return true;
        }
        public override bool IsMenuItemEnabled(string key)
        {
            return true;
        }
        public override void OnMenuItemPressed(string key)
        {
            if (key == MenuKeys.ShowMessage)
            {
                MessageBox.Show("Menu item pressed!");
            }
        }
        public override void Create()
        {
            MessageBox.Show("Plugin Initialized!");
        }
    }
}

