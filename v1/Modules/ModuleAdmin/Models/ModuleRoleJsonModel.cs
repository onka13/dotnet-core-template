using System.Collections.Generic;

namespace ModuleAdmin.Models
{
    public class ModuleRoleJsonModel
    {
        public Dictionary<string, ModuleRolePages> Modules { get; set; }

        public void AddOnce(string module)
        {
            if (Modules.ContainsKey(module)) return;
            Modules.Add(module, new ModuleRolePages());
        }

        public ModuleRoleJsonModel()
        {
            Modules = new Dictionary<string, ModuleRolePages>();
        }
    }

    public class ModuleRolePages
    {
        public Dictionary<string, ModuleRolePageItem> Pages { get; set; }

        public void AddOnce(string page)
        {
            if (string.IsNullOrEmpty(page) || Pages.ContainsKey(page)) return;
            Pages.Add(page, new ModuleRolePageItem());
        }

        public ModuleRolePages()
        {
            Pages = new Dictionary<string, ModuleRolePageItem>();
        }
    }

    public class ModuleRolePageItem
    {
        public List<string> Actions { get; set; }

        public void AddOnce(string action)
        {
            if (string.IsNullOrEmpty(action) || Actions.Contains(action)) return;
            Actions.Add(action);
        }

        public ModuleRolePageItem()
        {
            Actions = new List<string>();
        }
    }
}
