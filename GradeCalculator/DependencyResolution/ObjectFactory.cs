using StructureMap;
using System.Reflection;

namespace GradeCalculator.DependencyResolution
{
    public class ObjectFactory
    {
        public static IContainer GetContainer()
        {
            return new Container(Configure);
        }

        private static void Configure(ConfigurationExpression e)
        {
            e.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            e.Policies.SetAllProperties(policy =>
            {
                policy.Matching(y =>
                {
                    return y.PropertyType.Assembly == Assembly.GetExecutingAssembly();
                });
            });
        }
    }
}
