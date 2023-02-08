using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModuleCommon.Business
{
    /// <summary>
    /// Contains helper methods for modules 
    /// </summary>
    public class ModuleHelper
    {
        /// <summary>
        /// List of the defined modules
        /// </summary>
        private static List<IModuleConfig> Modules;

        /// <summary>
        /// Finds all modules in the system.
        /// </summary>
        public static void FindModules()
        {
            Modules = Directory.GetFiles(AppContext.BaseDirectory, "Module*.dll")
                .Select(Assembly.LoadFrom)
                .SelectMany(x => x.DefinedTypes)
                .Where(type => type.IsClass && typeof(IModuleConfig).GetTypeInfo().IsAssignableFrom(type.AsType()))
                .Select(type => (IModuleConfig)Activator.CreateInstance(type))
                .ToList();
        }

        /// <summary>
        /// Gets module list
        /// </summary>
        /// <returns></returns>
        public static List<IModuleConfig> GetModules()
        {
            if (Modules == null) FindModules();
            return Modules;
        }

        public static List<Assembly> FindAllAssemblies()
        {
            return Directory.GetFiles(AppContext.BaseDirectory, "Module*.dll")
                .Select(Assembly.LoadFrom)
                .ToList();
        }
    }
}
